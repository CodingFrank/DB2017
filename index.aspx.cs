using System;
using System.Data.SqlClient;
using System.Configuration;

public partial class index : System.Web.UI.Page
{
    protected string TtlMsg = "0";
    protected void Page_Load(object sender, EventArgs e)
    {
        string sql = "select count(1) as ttlmsg from messages;";
        using (SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["DBConnectionString"]))
        {
            // 1. declare command object with parameter
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = sql;
            // 2. define parameters used in command object
            //SqlParameter param = new SqlParameter();
            //param.ParameterName = "@qkid";
            //param.Value = "''";

            // 3. add new parameter to command object
            //cmd.Parameters.Add(param);
            SqlDataReader reader = null;
            reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                TtlMsg = reader["ttlmsg"].ToString();
            }
        }
    }
}