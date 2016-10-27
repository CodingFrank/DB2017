using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Text;

public partial class messages : System.Web.UI.Page
{
    protected string Msg = "";
    protected string TtlMsg = "0";
    protected void Page_Load(object sender, EventArgs e)
    {
        string sql = "select * from messages order by id desc;";
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
            // write each record
            StringBuilder sb = new StringBuilder();

            while (reader.Read())
            {
                //sb.AppendFormat("<div class=\"js-repo-filter position-relative\">");
                //sb.AppendFormat("<div class=\"overview-tab\">");
                //sb.AppendFormat("<div class=\"columns popular-repos\">");
                //sb.AppendFormat("<div class=\"single-column\">");
                sb.AppendFormat("<div class=\"boxed-group flush js-pinned-repos-reorder-container\">");
                sb.AppendFormat("<h3>");
                sb.AppendFormat("Left By {0} on {1}", reader["Name"].ToString(), reader["date"].ToString());
                sb.AppendFormat("</h3>");
                sb.AppendFormat("<ul class=\"boxed-group-inner mini-repo-list\"><li style =\"text-align:left;padding:5px 20px;\" >{0}</li>",reader["message"].ToString());
                sb.AppendFormat("</ul></div>");
            }
            reader.Close();
            cmd.Dispose();
            Msg = sb.ToString();
            sql = "select count(1) as ttlmsg from messages;";
            cmd = conn.CreateCommand();
            cmd.CommandText = sql;
            reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                TtlMsg = reader["ttlmsg"].ToString();
            }
        }
    }
}