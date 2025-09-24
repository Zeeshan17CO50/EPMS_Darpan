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
/// Summary description for desigycls
/// </summary>
public class desigcls
{
    
    public OleDbConnection conn = new OleDbConnection(ConfigurationManager.ConnectionStrings["constring"].ToString());
    //public string constring = "Provider=MSDAORA;Data Source=tcp.fois;Persist Security Info=True;User ID=pms;Unicode=True;Password=pms";
    public desigcls()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public void Insertdesig(int desig_cd, string desig_desc,string vdesig_abb)
    {
        string sql = "insert into desig_mas(desig_cd,desig_desc,desig_abb) values (" + @desig_cd + ",'" + @desig_desc + "',"+ @vdesig_abb + "')";

       // OleDbConnection conn = new OleDbConnection(constring);

        conn.Open();
        OleDbCommand cmd = new OleDbCommand(sql, conn);
        cmd.Prepare();
        cmd.ExecuteNonQuery();
        conn.Close();

    }

    public void Updatedesig(int desig_cd, string desig_desc,string vdesig_abb)
    {
        string sql = "Update desig_mas Set desig_desc='" + @desig_desc + "',desig_abb='"+vdesig_abb+"'  Where desig_cd=" + @desig_cd;

        //OleDbConnection conn = new OleDbConnection(constring);
        conn.Open();
        OleDbCommand cmd = new OleDbCommand(sql, conn);

        cmd.Prepare();
        cmd.ExecuteNonQuery();

    }

    public void Deletedesig(int desig_cd)
    {
        string sql = "Delete From desig_mas Where desig_cd=" + @desig_cd;
        //OleDbConnection conn = new OleDbConnection(constring);

        conn.Open();
        OleDbCommand cmd = new OleDbCommand(sql, conn);
        cmd.Prepare();
        cmd.ExecuteNonQuery();
        conn.Close();


    }

    public DataTable FetchAlldesig()
    {
        string sql = "Select * from desig_mas Order By desig_cd";
        OleDbDataAdapter da = new OleDbDataAdapter(sql, conn);
        DataTable dt = new DataTable();
        da.Fill(dt);
        return dt;
    }

    public DataTable FetchOnedesig(int desig_cd)
    {
        string sql = "Select * from desig_mas Where desig_cd=" + @desig_cd;
        OleDbDataAdapter da = new OleDbDataAdapter(sql, conn);
        DataTable dt = new DataTable();
        da.Fill(dt);
        return dt;
    }

}
