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
/// Summary desription for emp_stscls
/// </summary>
public class emp_stscls
{
    public OleDbConnection conn = new OleDbConnection(ConfigurationManager.ConnectionStrings["constring"].ToString());
   // public string constring = "Provider=MSDAORA;Data Source=tcp.fois;Persist Security Info=True;User ID=pms;Unicode=True;Password=pms";
    public int emp_sts_cd
    {
        get
        {
            return emp_sts_cd;
        }
        set
        {
            emp_sts_cd = value;
        }
    }

    public string emp_sts_des
    {
        set
        {
            emp_sts_des = value;
        }
        get
        {
            return emp_sts_des;
        }
    }
    public string leaving_status
    {
        set
        {
            leaving_status = value;
        }
        get
        {
            return leaving_status;
        }
    }


    public emp_stscls()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public void Insertemp_sts(string emp_sts_cd, string emp_sts_des)
    {
        string sql = "insert into emp_sts_mas(emp_sts_cd,emp_sts_des) values ('" + @emp_sts_cd + "','" + @emp_sts_des  + "')";

       //OleDbConnection conn = new OleDbConnection(constring);

        conn.Open();
        OleDbCommand cmd = new OleDbCommand(sql, conn);
        cmd.Prepare();
        cmd.ExecuteNonQuery();
        conn.Close();

    }

    public void Updateemp_sts(string emp_sts_cd, string emp_sts_des)
    {
        string sql = "Update emp_sts_mas Set emp_sts_des='" + @emp_sts_des + "'  Where emp_sts_cd='" + @emp_sts_cd+"'";

        //OleDbConnection conn = new OleDbConnection(constring);
        conn.Open();
        OleDbCommand cmd = new OleDbCommand(sql, conn);

        cmd.Prepare();
        cmd.ExecuteNonQuery();

    }

    public void Deleteemp_sts(string emp_sts_cd)
    {
        string sql = "Delete From emp_sts_mas Where emp_sts_cd='" + @emp_sts_cd+"'";
      /// OleDbConnection conn = new OleDbConnection(constring);

        conn.Open();
        OleDbCommand cmd = new OleDbCommand(sql, conn);
        cmd.Prepare();
        cmd.ExecuteNonQuery();
        conn.Close();


    }

    public DataTable FetchAllemp_sts()
    {
        string sql = "Select * from emp_sts_mas Order By emp_sts_cd";
        OleDbDataAdapter da = new OleDbDataAdapter(sql, conn);
        DataTable dt = new DataTable();
        da.Fill(dt);
        return dt;
    }

    public DataTable FetchOneemp_sts(int emp_sts_cd)
    {
        string sql = "Select * from emp_sts_mas Where emp_sts_cd=" + @emp_sts_cd;
        OleDbDataAdapter da = new OleDbDataAdapter(sql, conn);
        DataTable dt = new DataTable();
        da.Fill(dt);
        return dt;
    }

}
