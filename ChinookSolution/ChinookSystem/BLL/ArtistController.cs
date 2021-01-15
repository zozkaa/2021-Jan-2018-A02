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
    public class ArtistController
    {
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public List<SelectionList> Artist_DDLList()
        {
            using (var context = new ChinookSystemContext())
            {
                IEnumerable<SelectionList> results = from x in context.Artists
                                                     select new SelectionList
                                                     {
                                                         ValueField = x.ArtistId,
                                                         DisplayField = x.Name
                                                     };
                return results.ToList();
            }
        }
    }
}
