using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for SqlHelper
/// </summary>
public class SqlHelper
{
    public static string conntype = null;
    public static string adaptertype = null;
    private static string constr = null;


    public static void Init(string _conntype, string _constr, string _adaptertype)
    {
        conntype = _conntype;
        constr = _constr;
        adaptertype = _adaptertype;
    }

    internal static IDbConnection CreateConnection()
    {
        if (constr == null || conntype == null)
            throw new Exception("please set conntype & connection string first.(call Init())");
        var conn = System.Activator.CreateInstance(Type.GetType(conntype)) as IDbConnection;
        conn.ConnectionString = constr;
        return conn;
    }

    private static IDbDataAdapter CreateDataAdapter()
    {
        if (adaptertype == null)
            throw new Exception("please set adaptertype first.(call Init())");
        return System.Activator.CreateInstance(Type.GetType(adaptertype)) as IDbDataAdapter;
    }

    public static IDbTransaction BeginTran()
    {
        IDbConnection conn = CreateConnection();
        conn.Open();
        IDbTransaction tran = conn.BeginTransaction();
        return tran;
    }

    public static void EndTran(IDbTransaction tran)
    {
        IDbConnection conn = tran.Connection;
        conn.Close();
        conn.Dispose();
    }

    public static object ExecuteScalar(IDbTransaction tran, string sql, params SqlParam[] _params)
    {
        IDbConnection conn = tran.Connection;
        var cmd = conn.CreateCommand();
        cmd.Transaction = tran;
        cmd.CommandText = sql;
        if (_params != null)
        {
            foreach (var item in _params)
            {
                var p = cmd.CreateParameter();
                p.ParameterName = item.Name;
                p.Value = item.Value;
                cmd.Parameters.Add(p);
            }
        }
        var r = cmd.ExecuteScalar();
        cmd.Dispose();
        return r;
    }

    public static int ExecuteNonQuery(IDbTransaction tran, string sql, params SqlParam[] _params)
    {
        IDbConnection conn = tran.Connection;
        var cmd = conn.CreateCommand();
        cmd.Transaction = tran;
        cmd.CommandText = sql;
        if (_params != null)
        {
            foreach (var item in _params)
            {
                var p = cmd.CreateParameter();
                p.ParameterName = item.Name;
                p.Value = item.Value;
                cmd.Parameters.Add(p);
            }
        }
        int num = cmd.ExecuteNonQuery();
        cmd.Dispose();
        return num;
    }

    public static int ExecuteStoredProcedure(string sp, params SqlParam[] _params)
    {
        using (IDbConnection conn = CreateConnection())
        {
            var cmd = conn.CreateCommand();
            cmd.CommandText = sp;
            cmd.CommandType = CommandType.StoredProcedure;
            if (_params != null)
            {
                foreach (var item in _params)
                {
                    var p = cmd.CreateParameter();
                    p.ParameterName = item.Name;
                    p.Value = item.Value;
                    p.Direction = item.Direction;
                    cmd.Parameters.Add(p);
                }
            }
            conn.Open();
            var r = cmd.ExecuteNonQuery();
            foreach (IDataParameter p in cmd.Parameters)
            {
                if (p.Direction == ParameterDirection.InputOutput ||
                    p.Direction == ParameterDirection.Output ||
                    p.Direction == ParameterDirection.ReturnValue)
                    _params.Where(m => m.Name == p.ParameterName).FirstOrDefault().Value = p.Value;
            }
            conn.Close();
            cmd.Dispose();
            conn.Dispose();
            return r;
        }
    }
    public static object ExecuteScalar(string sql, params SqlParam[] _params)
    {
        using (IDbConnection conn = CreateConnection())
        {
            var cmd = conn.CreateCommand();
            cmd.CommandText = sql;
            if (_params != null)
            {
                foreach (var item in _params)
                {
                    var p = cmd.CreateParameter();
                    p.ParameterName = item.Name;
                    p.Value = item.Value;
                    cmd.Parameters.Add(p);
                }
            }
            conn.Open();
            var r = cmd.ExecuteScalar();
            conn.Close();
            cmd.Dispose();
            conn.Dispose();
            return r;
        }
    }


    public static int ExecuteNonQuery(string sql, params SqlParam[] _params)
    {
        using (IDbConnection conn = CreateConnection())
        {
            var cmd = conn.CreateCommand();
            cmd.CommandText = sql;
            if (_params != null)
            {
                foreach (var item in _params)
                {
                    var p = cmd.CreateParameter();
                    p.ParameterName = item.Name;
                    p.Value = item.Value;
                    cmd.Parameters.Add(p);
                }
            }
            conn.Open();
            int num = cmd.ExecuteNonQuery();
            conn.Close();
            cmd.Dispose();
            conn.Dispose();
            return num;
        }
    }

    public static DataTable GetDataTable(string sql, params SqlParam[] _params)
    {
        DataSet ds = GetDataSet(sql, _params);
        return ds.Tables[0];
    }

    public static DataSet GetDataSet(string sql, params SqlParam[] _params)
    {
        using (IDbConnection conn = CreateConnection())
        {
            var cmd = conn.CreateCommand();
            cmd.CommandText = sql;
            if (_params != null)
            {
                foreach (var item in _params)
                {
                    var p = cmd.CreateParameter();
                    p.ParameterName = item.Name;
                    p.Value = item.Value;
                    cmd.Parameters.Add(p);
                }
            }
            IDbDataAdapter adapter = CreateDataAdapter();
            adapter.SelectCommand = cmd;
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            cmd.Dispose();
            conn.Dispose();
            return ds;
        }
    }
}