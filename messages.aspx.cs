using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Text;
using Npgsql;
using MongoDB.Driver;
using MongoDB.Bson;

public partial class messages : System.Web.UI.Page
{
    protected string Msg = "";
    protected string TtlMsg = "0";
    //private readonly IMongoClient client;
    //private readonly IMongoCollection<BsonDocument> collection;
    //private readonly IMongoDatabase database;
    protected void Page_Load(object sender, EventArgs e)
    {
        string sql = "select * from schools order by name_full desc;";

        using (var conn = new NpgsqlConnection(ConfigurationManager.AppSettings["NPGSqlConnectionString"]))
        {
            conn.Open();

            //// Insert some data
            //using (var cmd = new NpgsqlCommand())
            //{
            //    cmd.Connection = conn;
            //    cmd.CommandText = "INSERT INTO data (some_field) VALUES (@p)";
            //    cmd.Parameters.AddWithValue("p", "Hello world");
            //    cmd.ExecuteNonQuery();
            //}
            var connectionString = ConfigurationManager.AppSettings["MONGODB"];
            IMongoClient client = new MongoClient(connectionString);
            IMongoDatabase database = client.GetDatabase("mean-test");
            IMongoCollection<BsonDocument> collection = database.GetCollection<BsonDocument>("articles");
            //database.DropCollection("articles");

            StringBuilder sb = new StringBuilder();
            // Retrieve all rows
            using (var cmd = new NpgsqlCommand(sql, conn))
            using (var reader = cmd.ExecuteReader())
                while (reader.Read())
                {
                    Console.WriteLine(reader.GetString(0));
                    sb.AppendFormat("<div class=\"boxed-group flush js-pinned-repos-reorder-container\">");
                    sb.AppendFormat("<h3>");
                    sb.AppendFormat("City: {0} State: {1}", reader["city"].ToString(), reader["state"].ToString());
                    sb.AppendFormat("</h3>");
                    sb.AppendFormat("<ul class=\"boxed-group-inner mini-repo-list\"><li style =\"text-align:left;padding:5px 20px;\" >{0}</li>", reader["name_full"].ToString());
                    sb.AppendFormat("</ul></div>");
                    // Start Example 1
                    var document = new BsonDocument
                    {
                        { "City", reader["city"].ToString()},
                        { "State", reader["city"].ToString() },
                        { "University", reader["name_full"].ToString()}
                    };
                    collection.InsertOne(document);
                }
            Msg = sb.ToString();
            sql = "select count(1) as ttl from schools;";
            using (var cmd = new NpgsqlCommand(sql, conn))
            using (var reader = cmd.ExecuteReader())
            if (reader.Read())
            {
                TtlMsg = reader["ttl"].ToString();
            }
        }

        //using (SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["DBConnectionString"]))
        //{
        //    // 1. declare command object with parameter
        //    conn.Open();
        //    SqlCommand cmd = conn.CreateCommand();
        //    cmd.CommandText = sql;
        //    // 2. define parameters used in command object
        //    //SqlParameter param = new SqlParameter();
        //    //param.ParameterName = "@qkid";
        //    //param.Value = "''";

        //    // 3. add new parameter to command object
        //    //cmd.Parameters.Add(param);
        //    SqlDataReader reader = null;
        //    reader = cmd.ExecuteReader();
        //    // write each record
        //    StringBuilder sb = new StringBuilder();

        //    while (reader.Read())
        //    {
        //        //sb.AppendFormat("<div class=\"js-repo-filter position-relative\">");
        //        //sb.AppendFormat("<div class=\"overview-tab\">");
        //        //sb.AppendFormat("<div class=\"columns popular-repos\">");
        //        //sb.AppendFormat("<div class=\"single-column\">");
        //        sb.AppendFormat("<div class=\"boxed-group flush js-pinned-repos-reorder-container\">");
        //        sb.AppendFormat("<h3>");
        //        sb.AppendFormat("Left By {0} on {1}", reader["Name"].ToString(), reader["date"].ToString());
        //        sb.AppendFormat("</h3>");
        //        sb.AppendFormat("<ul class=\"boxed-group-inner mini-repo-list\"><li style =\"text-align:left;padding:5px 20px;\" >{0}</li>",reader["message"].ToString());
        //        sb.AppendFormat("</ul></div>");
        //    }
        //    reader.Close();
        //    cmd.Dispose();
        //    Msg = sb.ToString();
        //    sql = "select count(1) as ttlmsg from messages;";
        //    cmd = conn.CreateCommand();
        //    cmd.CommandText = sql;
        //    reader = cmd.ExecuteReader();
        //    if (reader.Read())
        //    {
        //        TtlMsg = reader["ttlmsg"].ToString();
        //    }
        //}
    }
}