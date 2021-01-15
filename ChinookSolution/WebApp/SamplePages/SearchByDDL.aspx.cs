using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

#region Additional Namespaces
using ChinookSystem.BLL;
using ChinookSystem.ViewModels;
#endregion


namespace WebApp.SamplePages
{
    public partial class SearchByDDL : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                // First time 
                LoadArtistList();
            }
        }

        protected void LoadArtistList()
        {
            ArtistController sysmgr = new ArtistController();
            List<SelectionList> info = sysmgr.Artist_DDLList();

            // let's assume the data collection needs to be sorted.
            info.Sort((x,y) => x.DisplayField.CompareTo(y.DisplayField)); // sorts ascending, for descending flip the x & y

            // set up the ddl
            ArtistList.DataSource = info;
            //ArtistList.DataTextField = "Displayfield"; 
            ArtistList.DataTextField = nameof(SelectionList.DisplayField); // different way of doing it 
            ArtistList.DataValueField = nameof(SelectionList.ValueField);  // this makes it more usable for other projects
            ArtistList.DataBind();

            // prompt line
            ArtistList.Items.Insert(0, new ListItem("Select...", "0")); // a more complete and proper way of doing an insert
        }
    }
}