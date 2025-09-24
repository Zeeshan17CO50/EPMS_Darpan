using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.OleDb;

/// <summary>
/// Summary description for valid_sailpno
/// </summary>
public class weightage
{
    public OleDbConnection con = new OleDbConnection(ConfigurationManager.ConnectionStrings["constring"].ToString());
    ////public tot_weightage()
    ////{
    ////}
    public double tot_weightage(string xsail_pno, int vfinyr )
    {
        Double xwt = 0;
        string sql = "select NVL(SUM(NVL(task_wt,0)),0) FROM  workplan_mas_pesb WHERE sail_pno ='" + xsail_pno + "' AND finyr= " + vfinyr + " and task_cd=2" ;
        con.Open();
        OleDbCommand command = new OleDbCommand(sql, con);
        command.Connection = con;
        command.CommandType = CommandType.Text;
        OleDbDataReader reader;
        reader = command.ExecuteReader();
        while (reader.Read())
        {
            xwt= Convert.ToDouble(Convert.ToString(reader.GetValue(0)));
        }
        reader.Close();
        con.Close();

        return (xwt);
       
    }
   
}
