using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EmptyGridView
{
    public class EmptyGridView : GridView
    {Table table = new Table();

        #region Properties

        /// <summary>
        /// Enable or Disable generating an empty table if no data rows in source
        /// </summary>
        [
        Description("Enable or disable generating an empty table with headers if no data rows in source"),
        Category("Misc"),
        DefaultValue("true"),
        ]
        public bool ShowEmptyTable
        {
            get
            {
                object o = ViewState["ShowEmptyTable"];
                return (o != null ? (bool)o : true);
            }
            set
            {
                ViewState["ShowEmptyTable"] = value;
            }
        }

        /// <summary>
        /// Get or Set Text to display in empty data row
        /// </summary>
        [
        Description("Text to display in empty data row"),
        Category("Misc"),
        DefaultValue(""),
        ]
        public string EmptyTableRowText
        {
            get
            {
                object o = ViewState["EmptyTableRowText"];
                return (o != null ? o.ToString() : "");
            }
            set
            {
                ViewState["EmptyTableRowText"] = value;
            }
        }

        #endregion
        public new GridViewRow HeaderRow
        {
            get
            {
                return (table.FindControl("HeaderRow") as GridViewRow == null) ? base.HeaderRow : table.FindControl("HeaderRow") as GridViewRow;
            }
        }
        public new GridViewRow FooterRow
        {
            get
            {
                return (table.FindControl("FooterRow") as GridViewRow == null) ? base.FooterRow : table.FindControl("FooterRow") as GridViewRow;
            }
        }

        protected override int CreateChildControls(System.Collections.IEnumerable dataSource, bool dataBinding)
        {
            int numRows = base.CreateChildControls(dataSource, dataBinding);

            //no data rows created, create empty table if enabled
            if (numRows == 0 && ShowEmptyTable)
            {
                //create table
                 table = new Table();
               table.ID = this.ID;
               // table.CssClass = this.CssClass;
               GridViewRow row;
                //create a new header row
               //  GridViewRow row = base.CreateRow(-1, -1, DataControlRowType.Footer, DataControlRowState.Normal);
               if (this.ShowHeader && (this.HeaderRow == null))
               {
                    row = base.CreateRow(-1, -1, DataControlRowType.Header, DataControlRowState.Normal);

                   //convert the exisiting columns into an array and initialize
                   DataControlField[] fields = new DataControlField[this.Columns.Count];
                   this.Columns.CopyTo(fields, 0);
                   this.InitializeRow(row, fields);
                   row.ID = "HeaderRow";
                   table.Rows.Add(row);

               }

                //create a new Footer row
                if (this.ShowFooter && (this.FooterRow == null))
                {
                     row = base.CreateRow(-1, -1, DataControlRowType.Footer, DataControlRowState.Normal);

                    //GridViewRow row = base.CreateRow(-1, 0, DataControlRowType.Header, DataControlRowState.Normal);

                    //convert the exisiting columns into an array and initialize
                    DataControlField[] fields = new DataControlField[this.Columns.Count];
                    this.Columns.CopyTo(fields, 0);
                    this.InitializeRow(row, fields);
                    row.ID = "FooterRow";
                    table.Rows.Add(row);
                }
                   

                    this.Controls.Add(table);
              
           
            }
            return numRows;
    }
   }
}



