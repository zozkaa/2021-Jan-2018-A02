using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Additional Namespace
using ChinookSystem.DAL;
using ChinookSystem.Entities; // for SQL and are internal
using ChinookSystem.ViewModels; // for data classes to transfer data from BLL to webapp
using System.ComponentModel; // for ODS wizard
#endregion

namespace ChinookSystem.BLL
{
    [DataObject]
    public class AlbumController //interface to the outside world
    {
        #region Queries
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public List<ArtistAlbums> Albums_GetArtistAlbums()
        {
            using (var context = new ChinookSystemContext())
            {
                IEnumerable<ArtistAlbums> results = from x in context.Albums
                                                    select new ArtistAlbums
                                                    {
                                                        Title = x.Title,
                                                        ReleaseYear = x.ReleaseYear,
                                                        ArtistName = x.Artist.Name
                                                    };
                return results.ToList();
            }
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public List<ArtistAlbums> Albums_GetAlbumsForArtist(int artistid)
        {
            using (var context = new ChinookSystemContext())
            {
                IEnumerable<ArtistAlbums> results = from x in context.Albums
                                                    where x.ArtistId == artistid
                                                    select new ArtistAlbums
                                                    {
                                                        Title = x.Title,
                                                        ReleaseYear = x.ReleaseYear,
                                                        ArtistName = x.Artist.Name,
                                                        ArtistId = x.ArtistId
                                                    };
                return results.ToList();
            }
        }
        // query to return all data of the Album table
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public List<AlbumItem> Albums_List()
        {
            using (var context = new ChinookSystemContext())
            {
                IEnumerable<AlbumItem> results = from x in context.Albums
                                                    select new AlbumItem
                                                    {   
                                                        AlbumId = x.AlbumId,
                                                        Title = x.Title,
                                                        ReleaseYear = x.ReleaseYear,
                                                        ArtistId = x.ArtistId,
                                                        ReleaseLabel = x.ReleaseLabel
                                                    };
                return results.ToList();
            }
        }

        // query to look up an Album record by pkey
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public AlbumItem Albums_FindById(int albumid)
        {
            /*  (...).FirstOrDefault will return either 
                A) the first record matching the where condition
                B) a null value
             */
            using (var context = new ChinookSystemContext())
            {
                AlbumItem results = (from x in context.Albums
                              where x.AlbumId == albumid
                              select new AlbumItem
                              {
                                   AlbumId = x.AlbumId,
                                  Title = x.Title,
                                  ReleaseYear = x.ReleaseYear,
                                ArtistId = x.ArtistId,
                                ReleaseLabel = x.ReleaseLabel
                              }).FirstOrDefault();
                return results;
            }
        }
        #endregion // end Queries region

        #region Add, Update and Delete CRUD
        // Add
        [DataObjectMethod(DataObjectMethodType.Insert, false)]
        public int Album_Add(AlbumItem item)
        {
            using (var context = new ChinookSystemContext())
            {
                /*  due to the fact we have seperated the handling of our entities from the data transfer between webapp
                    and class library using the VIEWMODEL classes, we MUST create an instance of the entity and move the 
                    data from the ViewModel class to the entity instance. */
                // creating and loading an instance immediately
                Album addItem = new Album
                {
                    // Why no PKey set???
                    // PKey is an identity pkey, no value is needed.
                    Title = item.Title,
                    ArtistId = item.ArtistId,
                    ReleaseYear = item.ReleaseYear,
                    ReleaseLabel = item.ReleaseLabel
                };

                /*  Staging
                    - Setup in local memory
                    At this point you will NOT have sent anything to the database
              !!!!!    Therefore, you will NOT have your new PKey yet    !!!!!!!!!!!*/
                context.Albums.Add(addItem);

                /*  Commit to Database
                 *  On this command you
                        a) execute entity validation annotation
                        b) send you local memory staging to the database for execution
                    after a successful execution your enitiy instance will have the new PKey(identity) value */
                context.SaveChanges();

                /*  at this point your entity instance has the new PKey value
                    now we can return it */
                return addItem.AlbumId;
            }
        }

        // Update
        [DataObjectMethod(DataObjectMethodType.Update, false)]
        public void Album_Update(AlbumItem item)
        {
            using (var context = new ChinookSystemContext())
            {
                Album updateItem = new Album
                {
                    /*  For an UPDATE you NEED to supply the PKey value */
                    AlbumId = item.AlbumId,
                    Title = item.Title,
                    ArtistId = item.ArtistId,
                    ReleaseYear = item.ReleaseYear,
                    ReleaseLabel = item.ReleaseLabel
                };
                //  Staging
                context.Entry(updateItem).State = System.Data.Entity.EntityState.Modified;
                //  Commit
                context.SaveChanges();             
            }
        }

        // Delete
        /*  When we do an ODS CRUD on the Delete, the ODS sends in the extire instance record,
            not just the PKey value 
        
  !!!!!!!   Overload the Album_Delete methoed so it receives a whole instance
            then call the actual delete method passing just the PKey value to the actual delete method  !!!!!!!!!    */
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public void Album_Delete(AlbumItem item)
        {
            Album_Delete(item.AlbumId);
        }
        public void Album_Delete(int albumid)
        {
            using (var context = new ChinookSystemContext())
            {
                //  retrieve the current entity instance based on the incoming parameter
                var exists = context.Albums.Find(albumid);
                //  staged the remove
                context.Albums.Remove(exists);
                //  commit the remove
                context.SaveChanges();
            }
        }
        #endregion
    }
}
