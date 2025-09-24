using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Collections;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.OleDb;
using System.Data.SqlTypes;
using System.Globalization;

/// <summary>
/// Summary description for deptcls
/// </summary>
public class compcls
{
   public OleDbConnection conn = new OleDbConnection(ConfigurationManager.ConnectionStrings["constring"].ToString());
   // public string constring = "Provider=MSDAORA;Data Source=tcp.fois;Persist Security Info=True;User ID=pms;Unicode=True;Password=pms";
    OleDbDataReader reader;
    OleDbCommand command = new OleDbCommand();
    OleDbCommand cmd = new OleDbCommand();
    public int comp_ind
    {
        get
        {
            return comp_ind;
        }
        set
        {
            comp_ind = value;
        }
    }

    public string comp_cd
    {
        set
        {
            comp_cd = value;
        }
        get
        {
            return comp_cd;
        }
    }
    public string comp_des
    {
        set
        {
            comp_des = value;
        }
        get
        {
            return comp_des;
        }
    }
    public compcls()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public void Insertcomp(int comp_ind,int comp_cd , string comp_des)
    {
        string sql = "insert into compt_val_pot_mas(comp_ind,comp_cd,comp_des) values (" + @comp_ind + ","+@comp_cd  + ",'" + @comp_des + "')";

       // OleDbConnection conn = new OleDbConnection(constring);

        conn.Open();
        OleDbCommand cmd = new OleDbCommand(sql, conn);
        cmd.Prepare();
        cmd.ExecuteNonQuery();
        conn.Close();

    }

    public void Updatecomp(int comp_ind,int comp_cd,string comp_des)
    {
        string sql = "Update compt_val_pot_mas   Set comp_des='" + @comp_des + "'  Where comp_ind=" + @comp_ind + "and comp_cd = " +@comp_cd;

       // OleDbConnection conn = new OleDbConnection(constring);
        conn.Open();
        OleDbCommand cmd = new OleDbCommand(sql, conn);

        cmd.Prepare();
        cmd.ExecuteNonQuery();
        conn.Close();
    }

    public void Deletecomp(int comp_ind,int comp_cd)
    {
        string sql = "Delete From compt_val_pot_mas  Where comp_ind=" + @comp_ind + "and comp_cd = " + @comp_cd;

      //  OleDbConnection conn = new OleDbConnection(constring);

        conn.Open();
        OleDbCommand cmd = new OleDbCommand(sql, conn);
        cmd.Prepare();
        cmd.ExecuteNonQuery();
        conn.Close();


    }

    public DataTable FetchAllcomp(int xx)
    {
        string sql = "Select * from compt_val_pot_mas  where comp_ind =" +xx ;
        OleDbDataAdapter da = new OleDbDataAdapter(sql, conn);
        DataTable dt = new DataTable();
        da.Fill(dt);
        return dt;
    }

    public DataTable FetchOnecomp(int comp_ind,int comp_cd)
    {
        string sql = "Select * from compt_val_pot_mas Where comp_ind=" + @comp_ind + "and comp_cd = " + @comp_cd;
       OleDbDataAdapter da = new OleDbDataAdapter(sql, conn);
        DataTable dt = new DataTable();
        da.Fill(dt);
        return dt;
    }
    
    public int maxcntcomp(int y)
    {     
        int z=0;
         string sql = "Select nvl(max(comp_cd),0)+1 from compt_val_pot_mas where  comp_ind =" + y;
        // OleDbConnection conn = new OleDbConnection(constring); 
         OleDbCommand cmd = new OleDbCommand(sql,conn);
         conn.Open();
         
         OleDbDataReader dr;
         
           dr = cmd.ExecuteReader();
           dr.Read();
           if (dr.HasRows == true)
           {

               z =  Convert.ToInt16( dr.GetValue(0));
           }
           conn.Close();
           return (z);
    
    }


}