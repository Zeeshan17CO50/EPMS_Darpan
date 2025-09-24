<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="login.aspx.cs" Inherits="login_epms" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
    <script language="javascript" type="text/javascript">
    <!--     
    window.history.forward(1);     
    -->      
    </script>
 
<head runat="server">
    <title>EPMS-E5-E7 </title>
    <style type="text/css">

html 
{
 overflow: hidden;
  display: table;
    margin: auto;
}
    body
{
    margin: 0px;
	padding:0px;
	height:700px;
	text-align:center;
	border: 1px solid gray;
	align : center;
}
</style>   
</head>
<body    >
      <form id="form1" runat="server">
        <asp:ScriptManager ID="Scrptmain" runat="server" />
        <div>
               <table width="1000px"  border="0" cellpadding="0" cellspacing="0" style="background-color:WhiteSmoke; margin:0px; padding:0px; text-align:center   "  >
               <tr  style="background-color:#003366;">
               <td colspan="3" valign="top">
                <table>
                <tr>
                <td align="left">
                 <asp:Label ID="Label6" runat="server" Text="CORPORATE PERSONNEL" Width="594px" ForeColor="White" Font-Bold="False" Font-Italic="False" Font-Size="16px"  Font-Names="Arial"></asp:Label>
                </td>
                <td align="right" style="width: 687px">
              <!--   <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Always" >
                <ContentTemplate >
                    &nbsp; &nbsp; &nbsp; &nbsp;
                    <asp:Label ID="lbltime" runat="server" Width="280px" Font-Bold="False" Font-Names="Arial" Font-Size="11px" ForeColor="White"></asp:Label>
                </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="tmr" EventName="Tick" />
                </Triggers>
                </asp:UpdatePanel>
                <asp:Timer ID="tmr" runat="server" Interval="1000"></asp:Timer> -->
                </td>
                </tr>
                </table>
               </td>
                </tr>
             <tr style="background-color:#336699;" >
             <td  style="width: 231px; font-stretch:wider; height: 40px;" valign="top" rowspan="2">
            </td>
              
             <td  align="center" rowspan="2" style="width: 1239px; height: 40px;">
                <asp:Label ID="Label5" runat="server" Text="SAIL Executive Performance Management System" Width="734px" ForeColor="White" Font-Bold="False" Font-Italic="False" Font-Size="32px" Height="40px" Font-Names="Arial" BackColor="Transparent"></asp:Label> 
             </td>
             <td align="left" style="width: 425px; height: 10px;">
                             </td>
             </tr>
              <tr valign="top"  style="background-color:#336699;"   >
                         <td align="left" style="height: 57px; width: 425px;" valign="top">
                         <table>
                         <tr>
                        
                         <td style="width: 247px;" valign="top">
                                                         <asp:HyperLink ID="HyperLink2" runat="server" Font-Names="Arial" Font-Size="12px"
                                 Font-Underline="True" ForeColor="Gold"
                                 Width="104px" NavigateUrl="http://10.140.5.84/coportal.asp">Corp. Office Portal</asp:HyperLink></td>
                         </tr>
                             <tr>
                                 <td style="width: 247px" valign="top">
                                     <asp:Label ID="lbldt" runat="server" Font-Names="Arial" Font-Size="12px" ForeColor="White"
                                         Width="119px"></asp:Label></td>
                             </tr>
                         </table>
                    </td> 
           </tr> 
           <tr>
             <td   colspan="3" align="left" style="height:45px;">
             &nbsp;
             </td>
           </tr> 
                   <tr align="center">
                       <td align="center" colspan="3"  >
                       <table style="text-align:center; background-color:White;">
                       <tr>
                       <td colspan="2" style="height:30px;">
                       </td>
                       </tr>
                       <tr>
                       <td style="text-align: right;  ">
                           &nbsp;
                           <asp:Label ID="Label3" runat="server" Font-Bold="False" Font-Names="Arial" Font-Size="14px"
                               ForeColor="Maroon" Text="Username :"></asp:Label>&nbsp;
                       </td>
                        
                       <td style="text-align: left; height:30px;">
                        <asp:TextBox ID="txtusername" runat="server" Width="100px" MaxLength="7" TabIndex="1" Font-Names="Arial" Font-Size="14px"></asp:TextBox>
                       </td>
                       </tr>
                       <tr>
                       <td style="text-align: right; height:30px; ">
                         <asp:Label ID="Label4" runat="server" Font-Bold="False" Font-Names="Arial"
                               Font-Size="14px" ForeColor="Maroon" Text="Password :"></asp:Label>&nbsp;
                           </td>
                       
                       <td style="text-align: left">
                       <asp:TextBox ID="txtpassword" runat="server" Width="100px" TextMode="Password" TabIndex="2" MaxLength="10" Font-Names="Arial" Font-Size="14px"></asp:TextBox>
                       </td>
                       </tr>
                        <tr>
                       <td colspan="2" style="text-align: center; height:40px;">
                         <asp:Button ID="btnlogin" runat="server" BorderStyle="Solid" Font-Bold="False" Font-Names="Arial"
                        Font-Size="14px" ForeColor="DarkBlue" OnClick="btnlogin_Click"
                        Text="Sign In" Width="72px" TabIndex="3" BorderColor="DimGray" BorderWidth="1px" Height="30px" />
                       </td>
                       </tr>
                        <tr>
                            <td colspan="2">
                      
                            </td>
                       </tr>
                       
                        <tr>
                       <td colspan="2">
                        <asp:Label ID="TextBox1" runat="server" Width="732px" BackColor="White" Font-Bold="False" Font-Names="Arial" Font-Size="12px" ForeColor="Navy" Height="25px" Font-Italic="True" > Pl. Note : This site is best viewed in Internet Explorer</asp:Label></td>
                       </tr> 
                       <tr>
                       <td colspan="2">
                         <asp:Label ID="message" runat="server" Width="725px" Font-Names="Arial" Font-Size="14px" ForeColor="Red" Font-Bold="True" Font-Italic="True"></asp:Label>
                       </td>
                       </tr>
                        <tr>
                       <td colspan="2">
                        
                       </td>
                       </tr>
                          <tr>
                       <td colspan="2" align="center">
                       <table  runat="server" id="otptbl" visible="false">
                       <tr>
                       <td colspan="2" align="center">
                          <asp:Label ID="Label7" runat="server" Font-Bold="False" Font-Names="Arial" Font-Size="14px"
                               ForeColor="Maroon" Text="Enter OTP :"></asp:Label>
                          <asp:TextBox ID="txtotp" runat="server" Font-Names="Arial" Font-Size="14px" MaxLength="10"
                                TabIndex="2" TextMode="Password" Width="95px"></asp:TextBox>
                       </td>
                       </tr>
                        <tr>
                      <td colspan="2" align="center">
                        <asp:TextBox ID="lblmobile" runat="server" Font-Names="Arial" Font-Size="12px"  
                              Width="77px" Visible="False"></asp:TextBox>
                        <asp:TextBox ID="lblotp" runat="server" Font-Names="Arial" Font-Size="12px" MaxLength="10"
                            TabIndex="2" Width="99px" Visible="False"></asp:TextBox></td>
                       </tr>
                        <tr>
                      <td colspan="2" align="center">
                    
                      <asp:Button ID="btn_otp_verify" runat="server" BorderStyle="Outset" Font-Bold="False" Font-Names="Arial"
                        Font-Size="14px" ForeColor="DarkBlue" OnClick="btn_otp_verify_Click"
                        Text="Verify OTP" Width="96px" TabIndex="3" Height="30px" BorderColor="Gray" BorderWidth="1px" />
                           </td>
                       </tr>
                        <tr>
                       <td colspan="2" align="center">
                           <asp:Button ID="btn_resend" runat="server" BorderStyle="None" Font-Bold="False" Font-Names="Arial"
                        Font-Size="14px" ForeColor="Maroon" OnClick="btn_resend_Click"
                        Text="Resend OTP" Width="98px" TabIndex="3" Height="30px" BackColor="Transparent" Font-Italic="True" Font-Underline="True" /></td>
                       </tr>
                       </table>
                           </td>
                       </tr>
                           <tr>
                               <td align="center" colspan="2">
                                   <asp:Label ID="Label8" runat="server" Font-Bold="True" Font-Italic="True" Font-Names="Arial" Text="In case of change of Mobile No., please update the same through SAIL HRMS" 
                                       Font-Size="14px" ForeColor="DarkRed" Width="725px"></asp:Label><br />
                                   <asp:HyperLink ID="HyperLink3" runat="server" Font-Bold="True" Font-Names="Arial" Font-Size="14px" ForeColor="Blue" NavigateUrl="http://10.140.5.84/hrms_app/login.aspx" Target="_blank">http://10.140.5.84/hrms_app/login.aspx </asp:HyperLink>    
                                       </td>
                                       
                           </tr>
                       
                         
                       
                       </table>
                       </td>
                   </tr>
         
            <tr>
                <td colspan="3" style="height: 18px; text-align: left">
                    <asp:Label ID="pmsmsg" runat="server" Font-Bold="True" Font-Names="Arial" Font-Size="12px"
                        ForeColor="DarkRed" Text=" " Width="985px"></asp:Label></td>
            </tr>
            
              <tr>
                    <td colspan="3" style="font-weight: bold; font-size: 14pt; color: red; font-style: italic; height: 14px" align="center"  >
                    <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Names="Times New Roman"
                        Font-Size="Small" ForeColor="Maroon" Text=" "
                        Width="257px"></asp:Label>
                        </td>
                </tr>
      
             <tr>
        <td colspan="3" align="center" style="height: 28px">
                        <asp:Image ID="Image1" runat="server" ImageUrl="~/images/logo.jpg" />
            &nbsp;&nbsp;
     <asp:Label ID="unit" runat="server" Text="" Visible="false"></asp:Label>
        
        </td>
        </tr>  
        <tr>
        <td colspan="3" align="center" style="height: 20px">
            <asp:Label ID="Label9" runat="server" BackColor="Navy" Font-Bold="False" Font-Names="Arial"
                Font-Size="12px" ForeColor="White" Text=" Pl. Note : This site is best viewed in Internet Explorer"
                Width="825px"></asp:Label>
          &nbsp;&nbsp;
        </td>
        </tr> 
        <tr  style="background-color:#003366;">
        <td colspan="3" align="CENTER" valign="middle" style="height:35px;" >
                        <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Names="Times New Roman"
                            Font-Size="Small" ForeColor="Maroon" Text=" " Width="310px" Visible="False"></asp:Label></td>
        </tr>        
            <tr>
      
    <td  colspan="3" bgcolor="LightSteelBlue"><marquee style=" width: 994px; height: 25px;  font-size: 10pt; font-family:Arial; color: maroon; "><I><B><asp:Label id="Label99" __designer:dtid="562992903094356" runat="server" Font-Names="Times New Roman" Font-Size="12px" Font-Bold="True" ForeColor="Maroon" Width="940px" Text="SAIL Executive Performance Management System ......... Developed by C&IT(CO) in consultation with Corporate Cadre Services " Height="25px"></asp:Label></B></I></marquee></td>
            </tr>
             </table>
             </div>
        
         
    </form>
</body>
</html>
