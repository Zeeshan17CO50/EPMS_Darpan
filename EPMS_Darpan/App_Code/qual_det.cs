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
/// Summary description for qual_detcls
/// </summary>
public class qual_detcls
{
   // public OleDbDataAdapter da = new OleDbDataAdapter(ConfigurationManager.ConnectionStrings["constring"].ToString()); 
    //public string constring = "Provider=MSDAORA;Data Source=tcp.fois;Persist Security Info=True;User ID=pms;Unicode=True;Password=pms";
    public OleDbConnection conn = new OleDbConnection(ConfigurationManager.ConnectionStrings["constring"].ToString());
    public qual_detcls()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public void Insertqual_det(string sail_pno, int slno, int degree_cd, int spec_cd, string univ, int yr_pass, int dur, string div, string ent_dt)
    {
        string sql = "insert into qual_det values ('" + @sail_pno + "', " + @slno + ", " + @degree_cd + ", " + @spec_cd + ", '" + @univ + "', " + @yr_pass + "," + @dur + ",'" + @div + "', to_date('" + @ent_dt + "','dd/mm/yyyy'))" ;
         
        //OleDbConnection conn = new OleDbConnection(constring);

        conn.Open();
        OleDbCommand cmd = new OleDbCommand(sql, conn);
        cmd.Prepare();
        cmd.ExecuteNonQuery();
        conn.Close();

    }

    public void Updatequal_det(string sail_pno, int slno, int degree_cd, int spec_cd, string univ, int yr_pass, int dur, string div, string ent_dt)
    {
        string sql = "Update qual_det Set degree_cd = "+@degree_cd+", spec_cd = "+@spec_cd+", univ = '"+@univ+"' , yr_pass = "+@yr_pass+",  dur = "+@dur+" , div = '"+@div+"', ent_dt = to_date('"+@ent_dt+"','dd/mm/yyyy') Where  sail_pno = '" + @sail_pno+ "' and slno ="+ @slno;
       // OleDbConnection conn = new OleDbConnection(constring);
        conn.Open();
        OleDbCommand cmd = new OleDbCommand(sql, conn);

        cmd.Prepare();
        cmd.ExecuteNonQuery();

    }
   
    public void Deletequal_det(string sail_pno,int slno)
    {
        string sql = "Delete From qual_det Where sail_pno ='" + @sail_pno+ "'  and slno="+@slno ;
      //  OleDbConnection conn = new OleDbConnection(constring);

        conn.Open();
        OleDbCommand cmd = new OleDbCommand(sql, conn);
        cmd.Prepare();
        cmd.ExecuteNonQuery();
        conn.Close();

    }
   
    public DataTable FetchAllqual_det(string sail_pno)
    {
        string sql = "Select sail_pno,slno,degree_desc, spec_desc ,univ, yr_pass, dur ,div ,to_char(ent_dt,'dd/mm/yyyy') ent_dt from qual_det a, degree_mas b, spec_mas c where a.degree_cd = b.degree_cd and a.spec_cd = c.spec_cd and sail_pno='"+sail_pno+"' Order By slno";
        OleDbDataAdapter da = new OleDbDataAdapter(sql, conn);
        DataTable dt = new DataTable();
        da.Fill(dt);
        return dt;
    }


    public DataTable FetchOnequal_det(string sail_pno,int slno)
    {
        string sql = "Select * from qual_det Where sail_pno = '"+sail_pno+"' and slno = " + @slno;
        OleDbDataAdapter da = new OleDbDataAdapter(sql, conn);
        DataTable dt = new DataTable();
        da.Fill(dt);
        return dt;
    }

}

