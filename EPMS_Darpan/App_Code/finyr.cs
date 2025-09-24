using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

/// <summary>
/// Summary description for finyr
/// </summary>
public class finyr
{
	public finyr()
	{
		
	}
    public Int16 finyear(DateTime dt)
    {
        Int16 f_yr;
        Int16 i = 1;
        f_yr = Convert.ToInt16(dt.Year);
          if (dt.Month == 1 || dt.Month == 2 || dt.Month == 3)
       
            return Convert.ToInt16(f_yr-i);
        else
        {
            f_yr = Convert.ToInt16(f_yr);
            return f_yr;
        }
    }
    public DateTime ret_func(DateTime dt)
    {
        dt.AddMonths(720);
        return (dt);
    }
    public string shortdate(DateTime dt)
    {
         string xdate;
        xdate =    dt.Day+"/"+dt.Month+"/"+dt.Year+ " "+dt.ToShortTimeString() ;
       
        return (xdate);
    }
    public string ddmmyyyy(DateTime dt)
    {
        string xdate;
        xdate = dt.Day + "/" + dt.Month + "/" + dt.Year ;

        return (xdate);
    }
}
