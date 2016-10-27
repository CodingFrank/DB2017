using System;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text;
using System.Text.RegularExpressions;

public partial class newmessage : System.Web.UI.Page
{
    protected string id = "";
    protected string s_qk_class = "";
    protected string s_qcode = "";
    protected string s_previousName = "";
    protected string s_image_path = "";
    protected string s_ci_info = "";
    protected bool s_ci_found = false;
    protected string s_image, s_titleEN, s_titleCN, s_ISSN, s_CN, s_zhubandanwei, s_zhuguanbumen, s_bianjidanwei, s_zhubian, s_dizhi, s_youbian, s_dianhua, s_email, s_guoneikanhao, s_guojikanhao, s_guancangxinxi, s_jianjie, s_toc_ind;

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
    public void update(object sender, EventArgs e)
    {
        //update qk set[英文刊名] = 'Biomedical and Environmental Sciences',[图片地址]='swyxyhjkx.jpg',类别='Q;X',Toc_ind= 'Y' where qcode = 'swyxyhjkx';
        string sql = "INSERT INTO [Messages] ([Name],[Message]) VALUES (" +
            "'" + txt_Name.Value.ToString() + "'," +
            " '" + txt_Message.Value.ToString() + "')" 
               ;
        try
        {
            DataSet ds = new DataSet();
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["DBConnectionString"]))
            {
                conn.Open();
                // 1. declare command object with parameter
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = sql;

                // 2. define parameters used in command object
                //SqlParameter param = new SqlParameter();
                //param.ParameterName = "@qkid";
                //param.Value = "''";

                // 3. add new parameter to command object
                //cmd.Parameters.Add(param);

                // get data stream
                //SqlDataReader reader = null;
                int sqlInt = cmd.ExecuteNonQuery();

                // write each record
                //while (reader.Read())
                //{
                //    Console.WriteLine("{0}, {1}",
                //        reader["CompanyName"],
                //        reader["ContactName"]);
                //}
                conn.Close();
            }
            Response.Write(string.Format("<script>alert('Submitted Successfully！');location.href='index.aspx';</script>"));
            return;
        }
        catch
        {
            Response.Write(string.Format("<script>alert('Unexpected error occurred！');</script>"));
            return;
        }
    }
}