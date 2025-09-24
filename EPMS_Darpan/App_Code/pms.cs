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
using TestWebMsgApp;

/// <summary>
/// Summary description for pmscls
/// </summary>
public class pmscls
{
    //public string constring = "Provider=MSDAORA;Data Source=tcp.fois;Persist Security Info=True;User ID=pms;Unicode=True;Password=pms";
    public OleDbConnection conn = new OleDbConnection(ConfigurationManager.ConnectionStrings["constring"].ToString());
    
    public int finyr
    {
        get
        {
            return finyr;
        }
        set
        {
            finyr = value;
        }
    }

    public string kpa_st_dt
    {
        set
        {
            kpa_st_dt = value;
        }
        get
        {
            return kpa_st_dt;
        }
    }
    public string kpa_end_dt
    {
        set
        {
            kpa_end_dt = value;
        }
        get
        {
            return kpa_end_dt;
        }
    }
    public string mid_st_dt
    {
        set
        {
            mid_st_dt = value;
        }
        get
        {
            return mid_st_dt;
        }
    }
    public string mid_end_dt
    {
        set
        {
            mid_end_dt = value;
        }
        get
        {
            return mid_end_dt;
        }
    }
    public string final_st_dt
    {
        set
        {
            final_st_dt = value;
        }
        get
        {
            return final_st_dt;
        }
    }
    public string final_end_dt
    {
        set
        {
            final_end_dt = value;
        }
        get
        {
            return final_end_dt;
        }
    }
    public string ent_dt
    {
        set
        {
            ent_dt = value;
        }
        get
        {
            return ent_dt;
        }
    }
    public pmscls()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public void Insertpms(int finyr, string kpa_st_dt,string kpa_end_dt,string mid_st_dt,string mid_end_dt,string final_st_dt,string final_end_dt,string ent_dt)
    {
        string sql = "insert into pms_mas (finyr,kpa_st_dt,kpa_end_dt,mid_st_dt,mid_end_dt,final_st_dt,final_end_dt,ent_dt) values (" + @finyr + ",to_date('" + @kpa_st_dt + "','dd/mm/yyyy'), to_date('" + @kpa_end_dt + "','dd/mm/yyyy'), to_date('" + @mid_st_dt + "','dd/mm/yyyy'), to_date('" + @mid_end_dt + "','dd/mm/yyyy'),to_date('" + @final_st_dt + "','dd/mm/yyyy'),to_date('" + @final_end_dt + "','dd/mm/yyyy'), to_date('" + @ent_dt + "','dd/mm/yyyy'))" ;
        
      //  OleDbConnection conn = new OleDbConnection(constring);
        
        conn.Open();
        OleDbCommand cmd = new OleDbCommand(sql, conn);
        cmd.Prepare();
        cmd.ExecuteNonQuery();
        conn.Close();

    }
   
    public void Updatepms(int finyr, string kpa_st_dt,string kpa_end_dt,string mid_st_dt,string mid_end_dt,string final_st_dt,string final_end_dt,string ent_dt)
    {
      //  string sql = "Update pms_mas Set kpa_st_dt='" + @kpa_st_dt + "'  Where finyr=" + @finyr;
        string sql = "Update pms_mas Set kpa_st_dt=to_date('" + @kpa_st_dt + "','dd/mm/yyyy'), kpa_end_dt=to_date('" + @kpa_end_dt + "','dd/mm/yyyy'), mid_st_dt=to_date('" + @mid_st_dt
            + "','dd/mm/yyyy'), mid_end_dt=to_date('" + @mid_end_dt + "','dd/mm/yyyy'), final_st_dt=to_date('" + @final_st_dt + "','dd/mm/yyyy'), final_end_dt=to_date('" + @final_end_dt + "','dd/mm/yyyy') , ent_dt=to_date('" + @ent_dt + "','dd/mm/yyyy') Where finyr=" + @finyr;
        //WebMsgBox.Show(" xx " + sql); 
        conn.Open();
        OleDbCommand cmd = new OleDbCommand(sql, conn);

        cmd.Prepare();
        cmd.ExecuteNonQuery();
        conn.Close();
    }

    public void Deletepms(int finyr)
    {
        string sql = "Delete From pms_mas Where finyr=" + @finyr;
      //  OleDbConnection conn = new OleDbConnection(constring);

        conn.Open();
        OleDbCommand cmd = new OleDbCommand(sql, conn);
        cmd.Prepare();
        cmd.ExecuteNonQuery();
        conn.Close();

    }
   
    public DataTable FetchAllpms()
    {
        string sql = "Select finyr,to_char(kpa_st_dt,'dd/mm/yyyy') kpa_st_dt ,to_char(kpa_end_dt,'dd/mm/yyyy') kpa_end_dt, to_char(mid_st_dt,'dd/mm/yyyy')mid_st_dt, to_char(mid_end_dt,'dd/mm/yyyy') mid_end_dt, to_char(final_st_dt,'dd/mm/yyyy') final_st_dt, to_char(final_end_dt,'dd/mm/yyyy') final_end_dt,to_char(ent_dt,'dd/mm/yyyy') ent_dt from pms_mas Order By finyr";
       OleDbDataAdapter da = new OleDbDataAdapter(sql, conn);
        DataTable dt = new DataTable();
        da.Fill(dt);
        return dt;
    }

    public DataTable FetchOnepms(int finyr)
    {
        string sql = "Select * from pms_mas Where finyr=" + @finyr;
       OleDbDataAdapter da = new OleDbDataAdapter(sql, conn);
        DataTable dt = new DataTable();
        da.Fill(dt);
        return dt;
    }

}
