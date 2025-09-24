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
/// Summary description for agencycls
/// </summary>
public class empcls
{
    public OleDbConnection conn = new OleDbConnection(ConfigurationManager.ConnectionStrings["constring"].ToString());
   // public string constring = "Provider=MSDAORA;Data Source=tcp.sailco;Persist Security Info=True;User ID=pms;Unicode=True;Password=pms";
    public string sail_pno
    {
        get
        {
            return sail_pno;
        }
        set
        {
            sail_pno = value;
        }
    }

    public string name
    {
        set
        {
            name = value;
        }
        get
        {
            return name;
        }
    }
    public int unit_cd
    {
        set
        {
            unit_cd = value;
        }
        get
        {
            return unit_cd;
        }
    }
    public int desig_cd
    {
        set
        {
            desig_cd = value;
        }
        get
        {
            return desig_cd;
        }
    }
    public int dept_cd
    {
        set
        {
            dept_cd = value;
        }
        get
        {
            return dept_cd;
        }
    }
    public int loc_cd
    {
        set
        {
            loc_cd = value;
        }
        get
        {
            return loc_cd;
        }
    }

    public int grade_cd
    {
        set
        {
            grade_cd = value;
        }
        get
        {
            return grade_cd;
        }
    }

    public string dob
    {
        set
        {
            dob = value;
        }
        get
        {
            return dob;
        }
    }
    public string doj_sail
    {
        set
        {
            doj_sail = value;
        }
        get
        {
            return doj_sail;
        }
    }
    public string doj_unit
    {
        set
        {
            doj_unit = value;
        }
        get
        {
            return doj_unit;
        }
    }
    public string prom_dt
    {
        set
        {
            prom_dt = value;
        }
        get
        {
            return prom_dt;
        }
    }
    public string gender
    {
        set
        {
            gender = value;
        }
        get
        {
            return gender;
        }
    }
    public string caste_catg
    {
        set
        {
            caste_catg = value;
        }
        get
        {
            return caste_catg;
        }
    }
    public string phy_type
    {
        set
        {
            phy_type = value;
        }
        get
        {
            return phy_type;
        }
    }
    public string ex_ser
    {
        set
        {
            ex_ser = value;
        }
        get
        {
            return ex_ser;
        }
    }

    public string emp_sts_cd
    {
        set
        {
            emp_sts_cd = value;
        }
        get
        {
            return emp_sts_cd;
        }
    }
    public int to_unit
    {
        set
        {
            to_unit = value;
        }
        get
        {
            return to_unit;
        }
    }
    public string dt_of_lve
    {
        set
        {
            dt_of_lve = value;
        }
        get
        {
            return dt_of_lve;
        }
    }
    public string sec_cd
    {
        set
        {
            sec_cd = value;
        }
        get
        {
            return sec_cd;
        }
    }
   
    public empcls()
    {
        //
        // TODO: Add constructor logic here
        //
    }
   
    public void Insertemp(string sail_pno, string name,int unit_cd,int desig_cd,int loc_cd,int dept_cd,int grade_cd,string dob,string doj_sail,string doj_unit,string prom_dt,string gender,string caste_catg,string phy_type,string ex_ser,string emp_sts_cd,int to_unit,string dt_of_lve,int sec_cd)
    {
        string  vdesig;
        string vloc;
        string vdept;
        string vsec;

        if (desig_cd == 0)
        {
            vdesig = "null";
        }
        else
        {
            vdesig = Convert.ToString(desig_cd);
        }
        if (dept_cd == 0)
        {
            vdept = "null";
        }
        else
        {
            vdept = Convert.ToString(dept_cd);
        }
        if (sec_cd == 0)
        {
            vsec = "null";
        }
        else
        {
            vsec = Convert.ToString(sec_cd);
        }
        if (loc_cd == 0)
        {
            vloc = "null";
        }
        else
        {
            vloc = Convert.ToString(loc_cd);
        }
       // string sql = "insert into emp_mas_pms(sail_pno,name,UNIT_CD,DESIG_CD,LOC_CD,DEPT_CD,GRADE_CD,DOB,DOJ_SAIL,DOJ_UNIT,PROM_DT,GENDER,CASTE_CATG,PHY_TYPE,EX_SER,EMP_STS_CD,TO_UNIT,DT_OF_LVE,ENT_DT,sec_cd) values ('" + sail_pno + "','" + name + "'," + unit_cd + "," + desig_cd +"," + loc_cd + "," + dept_cd + "," + grade_cd + ",to_date('" + dob + "','dd/mm/yyyy'), to_date('" + doj_sail + "','dd/mm/yyyy'),to_date('" + doj_unit + "','dd/mm/yyyy'), to_date('" + prom_dt + "','dd/mm/yyyy'),'" + gender + "','" + caste_catg + "','" + phy_type + "','" + ex_ser + "','" + emp_sts_cd + "'," + to_unit + ",to_date('" + dt_of_lve + "','dd/mm/yyyy'), to_date(sysdate,'dd/mm/yyyy'),"+sec_cd+")";
        string sql = "insert into emp_mas_pms(sail_pno,name,UNIT_CD,DESIG_CD,LOC_CD,DEPT_CD,GRADE_CD,DOB,DOJ_SAIL,DOJ_UNIT,PROM_DT,GENDER,CASTE_CATG,PHY_TYPE,EX_SER,EMP_STS_CD,DT_OF_LVE,ENT_DT,sec_cd,passwd) values ('" + sail_pno + "','" + name + "'," + unit_cd + "," + vdesig + "," + vloc + "," + vdept + "," + grade_cd + ",to_date('" + dob + "','dd/mm/yyyy'), to_date('" + doj_sail + "','dd/mm/yyyy'),to_date('" + doj_unit + "','dd/mm/yyyy'), to_date('" + prom_dt + "','dd/mm/yyyy'),'" + gender + "','" + caste_catg + "','" + phy_type + "','" + ex_ser + "','" + emp_sts_cd + "',to_date('" + dt_of_lve + "','dd/mm/yyyy'), to_date(sysdate,'dd/mm/yyyy')," + vsec +  ",'" + sail_pno + "')";                            
        //OleDbConnection conn = new OleDbConnection(constring);
        conn.Open();
        OleDbCommand cmd = new OleDbCommand(sql, conn);
        cmd.Prepare();
        cmd.ExecuteNonQuery();
        conn.Close();
    }

    public void Updateemp(string sail_pno, string name, int unit_cd, int desig_cd, int loc_cd, int sec_cd, int grade_cd, int dept_cd, string dob, string doj_sail, string doj_unit, string prom_dt, string gender, string caste_catg, string phy_type, string ex_ser, string emp_sts_cd, int to_unit, string dt_of_lve)
    {
        string vdesig;
        string vloc;
        string vdept;
        string vsec;

        if (desig_cd == 0)
        {
            vdesig = "null";
        }
        else
        {
            vdesig = Convert.ToString(desig_cd);
        }
        if (dept_cd == 0)
        {
            vdept = "null";
        }
        else
        {
            vdept = Convert.ToString(dept_cd);
        }
        if (sec_cd == 0)
        {
            vsec = "null";
        }
        else
        {
            vsec = Convert.ToString(sec_cd);
        }
        if (loc_cd == 0)
        {
            vloc = "null";
        }
        else
        {
            vloc = Convert.ToString(loc_cd);
        }
        string sql = "update emp_mas_pms set name='" + name + "',unit_cd=" + unit_cd + ",desig_cd=" + vdesig + ",loc_cd=" + vloc + ",sec_cd=" + vsec + ",grade_cd=" + grade_cd + ",dept_cd=" + vdept + ",dob=to_date('" + dob + "','dd/mm/yyyy'),doj_sail=to_date('" + doj_sail + "','dd/mm/yyyy'),doj_unit=to_date('" + doj_unit + "','dd/mm/yyyy'),prom_dt=to_date('" + prom_dt + "','dd/mm/yyyy'),gender='" + gender + "',caste_catg='" + caste_catg + "',phy_type='" + phy_type + "',ex_ser='" + ex_ser + "',emp_sts_cd='" + emp_sts_cd + "',to_unit=" + to_unit + ",dt_of_lve=to_date('" + dt_of_lve + "','dd/mm/yyyy'),ent_dt=sysdate where sail_pno='" + sail_pno + "'";

      //  OleDbConnection conn = new OleDbConnection(constring);
        conn.Open();
        OleDbCommand cmd = new OleDbCommand(sql, conn);
        cmd.Prepare();
        cmd.ExecuteNonQuery();
        conn.Close();
    }

    public void updateemp_transfer(string sail_pno,string doj_unit,int unit_cd)
    {
        string sql = "update emp_mas_pms set unit_cd=" + unit_cd + ",dt_of_lve=null,to_unit=null,emp_sts_cd='WW',ent_dt=sysdate,doj_unit=to_date('" + doj_unit + "','dd/mm/yyyy') where sail_pno='" + sail_pno + "'";
       // OleDbConnection conn = new OleDbConnection(constring);
        conn.Open();
        OleDbCommand cmd = new OleDbCommand(sql, conn);
        cmd.Prepare();
        cmd.ExecuteNonQuery();
        conn.Close();
    }

    public void insert_sailexp(string sail_pno, string doj_unit, int unit_cd,int dept_cd,int desig_cd)
    {
        string sql = "insert into sail_exp_det(sail_pno,from_dt,UNIT_CD,DESIG_CD,dept_cd,ent_dt) values ('" + sail_pno + "',to_date('" + doj_unit + "','dd/mm/yyyy')," + unit_cd + "," + desig_cd + "," + dept_cd + ",sysdate)";
       // OleDbConnection conn = new OleDbConnection(constring);
        conn.Open();
        OleDbCommand cmd = new OleDbCommand(sql, conn);
        cmd.Prepare();
        cmd.ExecuteNonQuery();
        conn.Close();
    }

    public void Deleteemp(string sail_pno)
    {
        string sql = "delete from emp_mas_pms where sail_pno='"+@sail_pno+"'";

        //OleDbConnection conn = new OleDbConnection(constring);
        conn.Open();
        OleDbCommand cmd = new OleDbCommand(sql, conn);
        cmd.Prepare();
        cmd.ExecuteNonQuery();
        conn.Close();
    }

}

