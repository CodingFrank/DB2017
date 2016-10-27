using System;
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

public partial class default_me : System.Web.UI.Page
{
    protected string id = "";
    protected string s_qk_class = "";
    protected string s_qcode = "";
    protected string s_previousName = "";
    protected string s_image_path = "";
    protected string s_ci_info = "";
    protected bool s_ci_found = false;
    protected string s_image, s_titleEN, s_titleCN, s_ISSN, s_CN, s_zhubandanwei, s_zhuguanbumen, s_bianjidanwei, s_zhubian, s_dizhi, s_youbian, s_dianhua, s_email, s_guoneikanhao, s_guojikanhao, s_guancangxinxi, s_jianjie, s_toc_ind;

    protected void Page_Load(object sender, EventArgs e)
    {
    }

}