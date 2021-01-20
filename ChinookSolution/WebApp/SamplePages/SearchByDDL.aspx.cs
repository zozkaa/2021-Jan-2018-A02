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
            //Message.Text = "";
            if (!Page.IsPostBack)
            {
                // First time 
                LoadArtistList();
            }
        }
        #region Error Handling ODS
        protected void SelectCheckForException(object sender, ObjectDataSourceStatusEventArgs e)
        {
            MessageUserControl.HandleDataBoundException(e);
        }
        #endregion

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

        protected void SearchAlbums_Click(object sender, EventArgs e)
        {
            if (ArtistList.SelectedIndex == 0)
            {
                // index 0 is physically pointing to the promptline. This is why using selectedindex instead of selectedvalue
                // using MessageUserControl for your own message
                //MessageUserControl.ShowInfo("Select an artist for the search.");
                MessageUserControl.ShowInfo("Search concern", "Select an artist for the search.");
                ArtistAlbumList.DataSource = null;
                ArtistAlbumList.DataBind();
            }
            else
            {

                /*  user friendly error handling
                 * normally when you leave the web page to your class library, you will want to have error handling
                    (aka try/catch) 
                 
                    use MessageUserControl to handle errors
                    !!!!!    MessageUserControl has try/catch embedded inside it's logic      !!!!!
                    Syntax
                    
                MessageUserControl.TryRun(() = > {
                
                    AlbumController sysmgr = new AlbumController();
                    List<ChinookSystem.ViewModels.ArtistAlbums> info = sysmgr.Albums_GetAlbumsForArtist(int.Parse(ArtistList.SelectedValue));

                    ArtistAlbumList.DataSource = info;
                    ArtistAlbumList.DataBind();
                }, "Success Message Title", "Your success message goes here");
                 
                SUCCESS message goes AFTER the coding block


                or MessageUserControl.ShowInfo("Show Concern", "Message here")
                 */
                // standard lookup and assignment

                MessageUserControl.TryRun(() =>
                {
                    AlbumController sysmgr = new AlbumController();
                    List<ChinookSystem.ViewModels.ArtistAlbums> info = sysmgr.Albums_GetAlbumsForArtist(int.Parse(ArtistList.SelectedValue));

                    ArtistAlbumList.DataSource = info;
                    ArtistAlbumList.DataBind();
                }, "Success Message Title", "Your success message goes here");

            }
        }
    }
}