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
using System.Data.OleDb;
using System.Data.SqlTypes;
using System.Data.SqlClient;
using System.Globalization;
using System.Collections.Generic;
using TestWebMsgApp;
using System.Web.Services;
using System.Configuration;

/// <summary>
/// Summary description for AutoCompinvest
/// </summary>
[WebService(Namespace = "http://tempuri.org/"  )]
 [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[System.Web.Script.Services.ScriptService]
// [System.Web.Services.WebService]


public class Autokpa : System.Web.Services.WebService {

    public Autokpa()
    {

    }

    


    //[WebMethod]
    [WebMethod(EnableSession = true)]

    public string[] Getkpa(string prefixText, int count)
    {
        if (count == 0)
        {
            count = 20;
        }

        if (prefixText.Equals("xyz"))
        {
            return new string[0];
        }
         
            {

                OleDbConnection con = new OleDbConnection(ConfigurationManager.ConnectionStrings["con"].ToString());
                // string sql = "select name from emp_web_v Where lve_sts in ('0','6','8','9') and  upper(name) like upper('%" + prefixText.ToString() + "%') ";
                string sql = "select kpa_dir_desc from pms.new_kpa_directory_mas Where  upper(kpa_dir_desc) like upper('%" + prefixText.ToString() + "%') and kpa_unit_cd= " + Session["sessunit"].ToString()+ " and kpa_dept_cd=" + Session["sessdept"].ToString();
                OleDbDataAdapter da = new OleDbDataAdapter(sql, con);
                DataTable dt = new DataTable();
                da.Fill(dt);

                String dbValues;
                String dbcd;

                List<string> items = new List<string>(count);

                foreach (DataRow row in dt.Rows)
                {
                    dbValues = row["kpa_dir_desc"].ToString();
                    dbValues = dbValues.ToLower();
                    items.Add(dbValues);
                }

                return items.ToArray();

            }
        

    }
    
}

