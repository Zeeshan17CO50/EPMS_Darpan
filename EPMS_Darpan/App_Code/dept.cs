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
/// Summary description for deptcls
/// </summary>
public class deptcls
{
    OleDbConnection conn = new OleDbConnection(ConfigurationManager.ConnectionStrings["constring"].ToString());
    public int dept_cd
    {
        get
        {
            return dept_cd;
        }
        set
        {
            dept_cd = value;
        }
    }

    public string dept_desc
    {
        set
        {
            dept_desc = value;
        }
        get
        {
            return dept_desc;
        }
    }
    
    public deptcls()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public void Insertdept(int dept_cd, string dept_desc)
    {
        string sql = "insert into dept_mas(dept_cd,dept_desc) values (" + @dept_cd + ",'" + @dept_desc + "')";

        //OleDbConnection conn = new OleDbConnection(constring);

        conn.Open();
        OleDbCommand cmd = new OleDbCommand(sql, conn);
        cmd.Prepare();
        cmd.ExecuteNonQuery();
        conn.Close();

    }

    public void Updatedept(int dept_cd, string dept_desc)
    {
        string sql = "Update dept_mas Set dept_desc='" + @dept_desc + "'  Where dept_cd=" + @dept_cd;

        //OleDbConnection conn = new OleDbConnection(constring);
        conn.Open();
        OleDbCommand cmd = new OleDbCommand(sql, conn);

        cmd.Prepare();
        cmd.ExecuteNonQuery();

    }

    public void Deletedept(int dept_cd)
    {
        string sql = "Delete From dept_mas Where dept_cd=" + @dept_cd;
        //OleDbConnection conn = new OleDbConnection(constring);

        conn.Open();
        OleDbCommand cmd = new OleDbCommand(sql, conn);
        cmd.Prepare();
        cmd.ExecuteNonQuery();
        conn.Close();


    }

    public DataTable FetchAlldept()
    {
        string sql = "Select * from dept_mas Order By dept_cd";
        OleDbDataAdapter da = new OleDbDataAdapter(sql, conn);
        DataTable dt = new DataTable();
        da.Fill(dt);
        return dt;
    }

    public DataTable FetchOnedept(int dept_cd)
    {
        string sql = "Select * from dept_mas Where dept_cd=" + @dept_cd;
        OleDbDataAdapter da = new OleDbDataAdapter(sql, conn);
        DataTable dt = new DataTable();
        da.Fill(dt);
        return dt;
    }

}
