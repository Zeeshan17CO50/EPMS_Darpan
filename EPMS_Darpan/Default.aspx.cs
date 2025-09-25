using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class index : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindGrid();
        }
    }

    protected void btnAddRole_Click(object sender, EventArgs e)
    {
        // Add role logic
        Response.Write("<script>alert('Add Role button clicked');</script>");
    }

    private void BindGrid()
    {
        DataTable dt = new DataTable();
        dt.Columns.Add("Shop");
        dt.Columns.Add("Section");
        dt.Columns.Add("RoleName");
        dt.Columns.Add("Status");
        dt.Columns.Add("ActionUrl");

        dt.Rows.Add("Power Generation", "Ladle Management & Refractory Shift", "Mechanical In-charge", "Not started", "#");
        dt.Rows.Add("Power Generation", "Ladle Management & Refractory Shift", "Mechanical In-charge", "Submitted", "view.aspx");
        dt.Rows.Add("Power Generation", "Ladle Management & Refractory Shift", "Mechanical In-charge", "Manually added", "view.aspx");

        gvRoles.DataSource = dt;
        gvRoles.DataBind();
    }
}