using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;
using TestWebMsgApp;
using System.Text;
using System.Net;
using System.IO;
using Oracle.ManagedDataAccess.Client;

public partial class login_epms : System.Web.UI.Page 
{    
    finyr yrcls = new finyr();
    //public DateTime dt;

    public OracleConnection con = new OracleConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString());
    OracleDataReader reader;
    OracleCommand command = new OracleCommand();

    protected void Page_Load(object sender, EventArgs e)
    {

        //  lbltime.Text = System.DateTime.Now.ToString();
        DateTime dt;
        DateTime xdt;
        // dt = System.DateTime.Now;
        command.Connection = con;
        command.CommandType = CommandType.Text;
        con.Open();
        command.CommandText = "select sysdate from dual";
        reader = command.ExecuteReader();
        while (reader.Read())
        {
            Label1.Text = Convert.ToString(Convert.ToDateTime(reader.GetValue(0)));
        }
        reader.Close();

        command.CommandText = "select msg from new_pms_msg where end_dt >= sysdate";
        reader = command.ExecuteReader();
        while (reader.Read())
        {
            pmsmsg.Text = Convert.ToString(reader.GetValue(0));
        }
        reader.Close();
        con.Close();
        if (!IsPostBack)
        {
            lbldt.Text = "  " + DateTime.Now.ToShortDateString() + "  ";
            txtusername.Focus();
            SetFocus("txtusername");
            txtusername.Text = txtusername.Text.ToUpper();
            // MainPanel.Focus();
            Scrptmain.SetFocus(txtusername);
        }
        
    }
    public void SetInputFocus()
    {
        TextBox tbox = this.form1.FindControl("txtusername") as TextBox;
        if (tbox != null)
        {
            ScriptManager.GetCurrent(this.Page).SetFocus(tbox);
        }
    }
    private string GenerateOTPno()
    {
        Random random = new Random();
        string combination = "0123456789";

        StringBuilder genotp = new StringBuilder();
        for (int i = 0; i < 6; i++)
        {
            genotp.Append(combination[random.Next(combination.Length)]);

        }
        return (genotp.ToString());

    } 
    protected void btnlogin_Click(object sender, EventArgs e)
    {
        
       
        string sql;
        sql = " select PMS.Chk_Pms_Pwd('" + txtusername.Text.ToString() + "','" + txtpassword.Text.ToUpper() + "'), Sail_Name('" + txtusername.Text.ToString() + "'), sail_unit_cd('" + txtusername.Text.ToString() + "'), sail_dept_cd('" + txtusername.Text.ToString() + "'),  sail_grade_cd('" + txtusername.Text.ToString() + "') from dual"; 
        OracleCommand cmdlogin = new OracleCommand(sql, con);
        OracleDataReader drlogin;
        try
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }

            drlogin = cmdlogin.ExecuteReader();
            drlogin.Read();
 
            if (txtusername.Text != "" && txtpassword.Text != "")
            {
               
                if (drlogin.HasRows == true)
                {
                    if (drlogin.GetValue(0).ToString() == "Y")
                    {

                        Session["vsailpno"] = txtusername.Text.ToString();
                        Session["rep_rev_ind"] = "";
                        Session["rev"] = "";
                        Session["rep"] = "";
                        Session["gridbtn"] = "";
                        Session["sessname"] = drlogin.GetValue(1).ToString();
                        Session["sessunit"] = drlogin.GetValue(2).ToString();
                        Session["sessdept"] = drlogin.GetValue(3).ToString();
                        Session["sessgrd"] = drlogin.GetValue(4).ToString();

                        command.Connection = con;
                        command.CommandType = CommandType.Text;
                        if (con.State == ConnectionState.Closed)
                        {
                            con.Open();
                        }

                        command.CommandText = "select sail_pno, substr(mobile_no,4,10) from webcit.contact_details where sail_pno='" + txtusername.Text + "' and drop_dt is null";
                        reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            lblmobile.Text = Convert.ToString(reader.GetValue(1));
                        }

                        reader.Close();
                        con.Close();

                        if (lblmobile.Text != "")
                        {
                            string StrOTP1 = GenerateOTPno();

                            Session["SessAIPROTP"] = StrOTP1;

                            string xappname = "EPMS Portal";
                            string xxtime = "3";
 
                            ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;
                            lblotp.Text = Session["SessAIPROTP"].ToString();
                            string strUrl = "https://www.proactivesms.in/sendsms.jsp?user=sailco&password=0b4a65690fXX&senderid=SAILIT&mobiles=+91" + lblmobile.Text + "&sms=OTP to log in to SAIL " + xappname + " is " + StrOTP1 + ".%0AThis OTP is valid for " + xxtime + " minutes.%0A-SAILCO &tempid= 1707172828490844790";
                           
                            WebRequest request = HttpWebRequest.Create(strUrl);

                            // Get the response back  
                            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                            Stream s = (Stream)response.GetResponseStream();
                            StreamReader readStream = new StreamReader(s);
                            string dataString = readStream.ReadToEnd();
                            response.Close();
                            s.Close();
                            readStream.Close();

                            otptotbl(Convert.ToDouble(Session["SessAIPROTP"].ToString()));
                           
                            message.Text = "A Six Digit OTP has been sent to your Mobile Number "  + lblmobile.Text;
                           
                            otptbl.Visible = true;                          
                            btn_otp_verify.Visible = true;
                            btnlogin.Enabled = false;
                            txtpassword.Enabled = false;
                            txtusername.Enabled = false;
                         
                        }
                        else
                        {
                            Session.Abandon();
                            WebMsgBox.Show("Mobile Number not available");
                             
                        }                       
                    }
                    else
                    {
                        Session.Abandon();
                        WebMsgBox.Show("Invalid Password");

                    }


                } 
            }
                    
            drlogin.Close();
            con.Close();
            
        }
        catch
        {

        }

   }

      private void otptotbl(double xotpsend)
    {

        if (lblmobile.Text.Trim() != string.Empty || lblmobile.Text.Trim().Length != 10)

           try
            {
                OracleCommand command = new OracleCommand();
                command.Connection = con;
                command.CommandType = CommandType.StoredProcedure;

                string xmobno = lblmobile.Text.Trim();

                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                command.Connection = con;
                command.CommandText = "ins_epms_otp_mas";
                command.Parameters.Add("xsail_pno", OracleDbType.NVarchar2, 7).Value = txtusername.Text;
                command.Parameters.Add("xmobile_number", OracleDbType.NVarchar2, 10).Value = lblmobile.Text;
                command.Parameters.Add("xotp", OracleDbType.Int64, 6).Value = xotpsend;
                command.ExecuteNonQuery();
                con.Close();
            }
            catch (OleDbException ex)
            {
                return;
            }
         
    }
    public void Displayerror(OleDbException exception)
    {
        //for (int i = 0; i < exception.Errors.Count; i++)
        //{
        //    message.Text = exception.Errors[i].Message;
        //}
    }

    public void msg()
    {
        message.Text = "INVALID USERNAME OR PASSWORD";
        txtusername.Text = "";
        SetFocus("txtusername");
    }
    protected void txtusername_TextChanged(object sender, EventArgs e)
    {
        SetFocus("txtpassword");
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("http://10.140.5.84/myweb/homeco.asp");
    }
    
    protected void btn_otp_verify_Click(object sender, EventArgs e)
    {
        if (txtotp.Text == "")
        {
            WebMsgBox.Show("Please enter OTP ");
        }
        else
        {
            if (txtotp.Text == Session["SessAIPROTP"].ToString())
            {
                OracleCommand command = new OracleCommand();               
                command.CommandType = CommandType.StoredProcedure;
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                command.Connection = con;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "ins_pms_login_trail";
                command.Parameters.Add("xsail_pno", OracleDbType.NVarchar2, 7).Value = Session["vsailpno"].ToString();
                command.Parameters.Add("xip_addr", OracleDbType.NVarchar2, 30).Value = getipaddress();
                command.ExecuteNonQuery();
                con.Close();
                Response.Redirect("new_pms_menu.aspx");
            }
            else
            {
                message.Text ="Incorrect OTP. Please try again" ;
                WebMsgBox.Show("Incorrect OTP. Please try again");
               
            }

        }
    }
    protected void btn_resend_Click(object sender, EventArgs e)
    {
        string StrOTP1 = GenerateOTPno();

        Session["SessAIPROTP"] = StrOTP1;

        string xappname = "EPMS Portal";
        string xxtime = "3";

        lblotp.Text = Session["SessAIPROTP"].ToString();
        string strUrl = "https://www.proactivesms.in/sendsms.jsp?user=sailco&password=0b4a65690fXX&senderid=SAILIT&mobiles=+91" + lblmobile.Text + "&sms=OTP to log in to SAIL " + xappname + " is " + StrOTP1 + ".%0AThis OTP is valid for " + xxtime + " minutes.%0A-SAILCO &tempid= 1707172828490844790";

        WebRequest request = HttpWebRequest.Create(strUrl);

        // Get the response back  
        HttpWebResponse response = (HttpWebResponse)request.GetResponse();
        Stream s = (Stream)response.GetResponseStream();
        StreamReader readStream = new StreamReader(s);
        string dataString = readStream.ReadToEnd();
        response.Close();
        s.Close();
        readStream.Close();

        otptotbl(Convert.ToDouble(Session["SessAIPROTP"].ToString()));
        WebMsgBox.Show("OTP has been resent to your Mobile Number " + lblmobile.Text);
         message.Text = "OTP has been resent to your Mobile Number " + lblmobile.Text;
         btn_resend.Enabled = false;
    }
    public string getipaddress()
    {
        HttpRequest currentRequest = HttpContext.Current.Request;
        string ipAddress = currentRequest.ServerVariables["HTTP_X_FORWARDED_FOR"];

        if (ipAddress == null || ipAddress.ToLower() == "unknown")
            ipAddress = currentRequest.ServerVariables["REMOTE_ADDR"];

        return ipAddress;
    }

   
}
