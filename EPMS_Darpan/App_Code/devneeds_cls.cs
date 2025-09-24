using System;
using System.Data;
using System.Configuration;
using System.Web.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.OleDb;

/// <summary>
/// Summary description for devneeds_cls
/// </summary>
public class devneeds_cls
{
    
 public devneeds_cls()
	{
		
	}

    public void Insert(int finyr, string sail_pno, int kpa_pot_ind, int Kpa_slno, int slno, string dev_needs, int sail_trng_cd,int vperiod, string agency_ro, string action_ro, string final_agency, string final_action, string approval_hod, string app_rem_hod, string ent_by, string act)
    {
        OleDbConnection con = new OleDbConnection(ConfigurationManager.ConnectionStrings["CString"].ToString());
        OleDbCommand cmd = new OleDbCommand("insert_devneeds", con);
        cmd.CommandType = CommandType.StoredProcedure;
        OleDbParameter p1 = new OleDbParameter("@finyr", OleDbType.Integer, 4, "finyr");
        OleDbParameter p2 = new OleDbParameter("@sail_pno", OleDbType.VarChar, 7, "sail_pno");
        OleDbParameter p3 = new OleDbParameter("@kpa_pot_ind", OleDbType.Integer, 1, "kpa_pot_ind");
        OleDbParameter p4 = new OleDbParameter("@Kpa_slno", OleDbType.Integer, 2, "Kpa_slno");
        
        OleDbParameter p5 = new OleDbParameter("@slno", OleDbType.Integer, 2, "slno");
        OleDbParameter p6 = new OleDbParameter("@dev_needs", OleDbType.VarChar, 200, "dev_needs");
        OleDbParameter p7 = new OleDbParameter("@sail_trng_cd", OleDbType.Integer, 2, "sail_trng_cd");
        OleDbParameter p8 = new OleDbParameter("@vperiod", OleDbType.Integer, 1, "vperiod");
        OleDbParameter p9 = new OleDbParameter("@agency_ro", OleDbType.VarChar, 30, "agency_ro");
        OleDbParameter p10 = new OleDbParameter("@action_ro", OleDbType.VarChar, 400, "action_ro");
        OleDbParameter p11 = new OleDbParameter("@final_agency", OleDbType.VarChar, 30, "final_agency");
        OleDbParameter p12 = new OleDbParameter("@final_action", OleDbType.VarChar, 400, "final_action");
        OleDbParameter p13 = new OleDbParameter("@approval_hod", OleDbType.VarChar, 1, "approval_hod");
        OleDbParameter p14 = new OleDbParameter("@app_rem_hod", OleDbType.VarChar, 400, "app_rem_hod");
        OleDbParameter p15 = new OleDbParameter("@ent_by", OleDbType.Char, 1, "ent_by");
        OleDbParameter p16 = new OleDbParameter("@act", OleDbType.Char, 1, "act");
       
        p1.Value = finyr;
        p2.Value = sail_pno;
        p3.Value = kpa_pot_ind;
        p4.Value = Kpa_slno;
        
        p5.Value = slno;
        p6.Value = dev_needs;
        p7.Value = sail_trng_cd;
        p8.Value = vperiod;
        p9.Value = agency_ro;
        p10.Value = action_ro;
        p11.Value = final_agency;
        p12.Value = final_action;
        p13.Value = approval_hod;
        p14.Value = app_rem_hod;
        p15.Value = ent_by;
        p16.Value = act;
       
        cmd.Parameters.Add(p1);
        cmd.Parameters.Add(p2);
        cmd.Parameters.Add(p3);
        cmd.Parameters.Add(p4);
        cmd.Parameters.Add(p5);
        cmd.Parameters.Add(p6);
        cmd.Parameters.Add(p7);
        cmd.Parameters.Add(p8);
        cmd.Parameters.Add(p9);
        cmd.Parameters.Add(p10);
        cmd.Parameters.Add(p11);
        cmd.Parameters.Add(p12);
        cmd.Parameters.Add(p13);
        cmd.Parameters.Add(p14);
        cmd.Parameters.Add(p15);
        cmd.Parameters.Add(p16);
        
        con.Open();
        cmd.ExecuteNonQuery();
        con.Close();
    }

    public void Insert_ind_pri(int finyr, string sail_pno, int kpa_pot_ind, int Kpa_slno, int slno, string dev_needs, int sail_trng_cd, int vperiod, string agency_ro, string action_ro, string pri_ind_hod, string ent_by, string act)
    {
        OleDbConnection con = new OleDbConnection(ConfigurationManager.ConnectionStrings["CString"].ToString());
        OleDbCommand cmd = new OleDbCommand("insert_needs_pri", con);
        cmd.CommandType = CommandType.StoredProcedure;
        OleDbParameter p1 = new OleDbParameter("@finyr", OleDbType.Integer, 4, "finyr");
        OleDbParameter p2 = new OleDbParameter("@sail_pno", OleDbType.VarChar, 7, "sail_pno");
        OleDbParameter p3 = new OleDbParameter("@kpa_pot_ind", OleDbType.Integer, 1, "kpa_pot_ind");
        OleDbParameter p4 = new OleDbParameter("@Kpa_slno", OleDbType.Integer, 2, "Kpa_slno");

        OleDbParameter p5 = new OleDbParameter("@slno", OleDbType.Integer, 2, "slno");
        OleDbParameter p6 = new OleDbParameter("@dev_needs", OleDbType.VarChar, 200, "dev_needs");
        OleDbParameter p7 = new OleDbParameter("@sail_trng_cd", OleDbType.Integer, 2, "sail_trng_cd");
        OleDbParameter p8 = new OleDbParameter("@vperiod", OleDbType.Integer, 1, "vperiod");
        OleDbParameter p9 = new OleDbParameter("@agency_ro", OleDbType.VarChar, 30, "agency_ro");
        OleDbParameter p10 = new OleDbParameter("@action_ro", OleDbType.VarChar, 400, "action_ro");
        OleDbParameter p11 = new OleDbParameter("@pri_ind_hod", OleDbType.VarChar, 400, "pri_ind_hod");
        OleDbParameter p12 = new OleDbParameter("@ent_by", OleDbType.Char, 1, "ent_by");
        OleDbParameter p13 = new OleDbParameter("@act", OleDbType.Char, 1, "act");

        p1.Value = finyr;
        p2.Value = sail_pno;
        p3.Value = kpa_pot_ind;
        p4.Value = Kpa_slno;

        p5.Value = slno;
        p6.Value = dev_needs;
        p7.Value = sail_trng_cd;
        p8.Value = vperiod;
        p9.Value = agency_ro;
        p10.Value = action_ro;
        p11.Value = pri_ind_hod;
        p12.Value = ent_by;
        p13.Value = act;

        cmd.Parameters.Add(p1);
        cmd.Parameters.Add(p2);
        cmd.Parameters.Add(p3);
        cmd.Parameters.Add(p4);
        cmd.Parameters.Add(p5);
        cmd.Parameters.Add(p6);
        cmd.Parameters.Add(p7);
        cmd.Parameters.Add(p8);
        cmd.Parameters.Add(p9);
        cmd.Parameters.Add(p10);
        cmd.Parameters.Add(p11);
        cmd.Parameters.Add(p12);
        cmd.Parameters.Add(p13);

        con.Open();
        cmd.ExecuteNonQuery();
        con.Close();
    }

    public void Insert_hod(int finyr, string sail_pno, int kpa_pot_ind, int Kpa_slno, int slno, string dev_needs, int sail_trng_cd, int vperiod, string agency_ro, string action_ro, string final_agency, string final_action, string approval_hod, string app_rem_hod, string pri_ind_hod, string ent_by, string act)
    {
        OleDbConnection con = new OleDbConnection(ConfigurationManager.ConnectionStrings["CString"].ToString());
        OleDbCommand cmd = new OleDbCommand("insert_needs_hod", con);
        cmd.CommandType = CommandType.StoredProcedure;
        OleDbParameter p1 = new OleDbParameter("@finyr", OleDbType.Integer, 4, "finyr");
        OleDbParameter p2 = new OleDbParameter("@sail_pno", OleDbType.VarChar, 7, "sail_pno");
        OleDbParameter p3 = new OleDbParameter("@kpa_pot_ind", OleDbType.Integer, 1, "kpa_pot_ind");
        OleDbParameter p4 = new OleDbParameter("@Kpa_slno", OleDbType.Integer, 2, "Kpa_slno");

        OleDbParameter p5 = new OleDbParameter("@slno", OleDbType.Integer, 2, "slno");
        OleDbParameter p6 = new OleDbParameter("@dev_needs", OleDbType.VarChar, 200, "dev_needs");
        OleDbParameter p7 = new OleDbParameter("@sail_trng_cd", OleDbType.Integer, 2, "sail_trng_cd");
        OleDbParameter p8 = new OleDbParameter("@vperiod", OleDbType.Integer, 1, "vperiod");
        OleDbParameter p9 = new OleDbParameter("@agency_ro", OleDbType.VarChar, 30, "agency_ro");
        OleDbParameter p10 = new OleDbParameter("@action_ro", OleDbType.VarChar, 400, "action_ro");
        OleDbParameter p11 = new OleDbParameter("@final_agency", OleDbType.VarChar, 30, "final_agency");
        OleDbParameter p12 = new OleDbParameter("@final_action", OleDbType.VarChar, 400, "final_action");
        OleDbParameter p13 = new OleDbParameter("@approval_hod", OleDbType.VarChar, 1, "approval_hod");
        OleDbParameter p14 = new OleDbParameter("@app_rem_hod", OleDbType.VarChar, 400, "app_rem_hod");
        OleDbParameter p15 = new OleDbParameter("@pri_ind_hod", OleDbType.VarChar, 400, "pri_ind_hod");
        OleDbParameter p16 = new OleDbParameter("@ent_by", OleDbType.Char, 1, "ent_by");
        OleDbParameter p17 = new OleDbParameter("@act", OleDbType.Char, 1, "act");

        p1.Value = finyr;
        p2.Value = sail_pno;
        p3.Value = kpa_pot_ind;
        p4.Value = Kpa_slno;

        p5.Value = slno;
        p6.Value = dev_needs;
        p7.Value = sail_trng_cd;
        p8.Value = vperiod;
        p9.Value = agency_ro;
        p10.Value = action_ro;
        p11.Value = final_agency;
        p12.Value = final_action;
        p13.Value = approval_hod;
        p14.Value = app_rem_hod;
        p15.Value = pri_ind_hod;
        p16.Value = ent_by;
        p17.Value = act;

        cmd.Parameters.Add(p1);
        cmd.Parameters.Add(p2);
        cmd.Parameters.Add(p3);
        cmd.Parameters.Add(p4);
        cmd.Parameters.Add(p5);
        cmd.Parameters.Add(p6);
        cmd.Parameters.Add(p7);
        cmd.Parameters.Add(p8);
        cmd.Parameters.Add(p9);
        cmd.Parameters.Add(p10);
        cmd.Parameters.Add(p11);
        cmd.Parameters.Add(p12);
        cmd.Parameters.Add(p13);
        cmd.Parameters.Add(p14);
        cmd.Parameters.Add(p15);
        cmd.Parameters.Add(p16);
        cmd.Parameters.Add(p17);

        con.Open();
        cmd.ExecuteNonQuery();
        con.Close();
    }


    public void Deleteneeds(int finyr, string sail_pno, int slno)
    {
        string sql = "Delete From training_needs Where finyr=" + @finyr + "and sail_pno = '" + @sail_pno + "' and slno = " + @slno;
        OleDbConnection con = new OleDbConnection(ConfigurationManager.ConnectionStrings["CString"].ToString());

        con.Open();
        OleDbCommand cmd = new OleDbCommand(sql, con);
        cmd.Prepare();
        cmd.ExecuteNonQuery();
        con.Close();
    }

    public DataTable FetchAll(string sail_pno, int finyear)
     {
        string sql = "Select slno,type,kpa_desc,dev_needs,decode(period,1,'APR-SEP',2,'OCT-MAR') period, sail_trng_cd, decode(sail_trng_cd,999,null,trng_unit_desc) trng_unit_desc from dev_vw  where  sail_pno='" + sail_pno + "' and finyr=" + finyear + " order by slno";
        OleDbConnection con = new OleDbConnection(ConfigurationManager.ConnectionStrings["CString"].ToString());
        OleDbDataAdapter da = new OleDbDataAdapter(sql, con);
        DataTable dt = new DataTable();
        da.Fill(dt);
        return dt;
    }
        
    public int maxslno(string sail_pno, int finyear)
    {
        string sql = "Select nvl(max(slno),0)+1 from training_needs where sail_pno='" + sail_pno + "' and finyr=" + finyear ;
        int dt = 0;
        OleDbConnection con = new OleDbConnection(ConfigurationManager.ConnectionStrings["CString"].ToString());
        OleDbCommand cmd = new OleDbCommand(sql,con);
        OleDbDataReader dr;
        con.Open();
        dr = cmd.ExecuteReader();
        dr.Read();
        if (dr.HasRows == true)
            dt = Convert.ToInt16(dr.GetValue(0).ToString());
        con.Close();
        return dt;
    }

    public bool agency_check(int finyear, string sail_pno)
    {
        string sql = "Select count(1) from training_needs  where agency_ro is null and sail_pno='" + sail_pno + "' and finyr=" + finyear;
        bool dtyesno = false;
        int dt;
        OleDbConnection con = new OleDbConnection(ConfigurationManager.ConnectionStrings["CString"].ToString());
        OleDbCommand cmd = new OleDbCommand(sql, con);
        OleDbDataReader dr;
        con.Open();
        dr = cmd.ExecuteReader();
        dr.Read();
        if (dr.HasRows == true)
        {
            dt = Convert.ToInt16(dr.GetValue(0).ToString());
            if (dt > 0)
            {
                dtyesno = true;
            }
            else
            {
                dtyesno = false;
            }
        }
        con.Close();
        return dtyesno;
    }

    public bool approval_check(int finyear, string sail_pno)
    {
        string sql = "Select count(1) from training_needs  where approval_hod is null and final_agency not like 'SELF' and sail_pno='" + sail_pno + "' and finyr=" + finyear;
        bool dtyesno = false;
        int dt;
        OleDbConnection con = new OleDbConnection(ConfigurationManager.ConnectionStrings["CString"].ToString());
        OleDbCommand cmd = new OleDbCommand(sql, con);
        OleDbDataReader dr;
        con.Open();
        dr = cmd.ExecuteReader();
        dr.Read();
        if (dr.HasRows == true)
        {
            dt = Convert.ToInt16(dr.GetValue(0).ToString());
            if (dt > 0)
            {
                dtyesno = true;
            }
            else
            {
                dtyesno = false;
            }
        }
        con.Close();
        return dtyesno;
    }




}
