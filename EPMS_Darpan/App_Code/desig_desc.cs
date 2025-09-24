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
using System.Web.Script.Services;
using System.Configuration;

/// <summary>
/// Summary description for AutoCompinvest
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[System.Web.Script.Services.ScriptService]

public class desig_desc : System.Web.Services.WebService {

    public desig_desc()
    {

    }

    [WebMethod]
    public string[] GetName(string prefixText, int count)
    {
        if (count == 0)
        {
            count = 30;
        }

        if (prefixText.Equals("xyz"))
        {
            return new string[0];
        }

        OleDbConnection con = new OleDbConnection(ConfigurationManager.ConnectionStrings["con"].ToString());
        string sql = "select desig_desc from pms.desig_mas Where upper(desig_desc) like upper('%" + prefixText.ToString() + "%') ";
        OleDbDataAdapter da = new OleDbDataAdapter(sql, con);
        DataTable dt = new DataTable();
        da.Fill(dt);

        String dbValues;
        String dbcd;

        List<string> items = new List<string>(count);

        foreach (DataRow row in dt.Rows)
        {
            dbValues = row["desig_desc"].ToString();
            dbValues = dbValues.Trim().ToUpper();
            items.Add(dbValues);         
        }
        return items.ToArray();



    }
    
}

