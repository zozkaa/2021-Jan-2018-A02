using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Additional Namespace
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
#endregion

namespace ChinookSystem.Entities
{
    [Table("Tracks")]
    internal class Track
    {
        private string _Name;
        private string _Composer;

        [Key]
        public int TrackId { get; set; }

        [Required(ErrorMessage = "Track name is requried.")]
        [StringLength(200, ErrorMessage = "Track name is limited to 200 characters"), MinLength(1)]
        public string Name { get; set; }
        public int? AlbumId { get; set; }
        public int MediaTypeId { get; set; }
        public int? GenreId { get; set; }

        [StringLength(220, ErrorMessage = "Composer name is limited to 220 characters")]
        public string Composer {
                get {
                    return _Composer;
                }
                set {
                _Composer = string.IsNullOrEmpty(value) ? null : value;
                }
            }
        public int Milliseconds { get; set; }
        public int? Bytes { get; set; }
        public decimal UnitPrice { get; set; }


        // NAVIGATIONAL PROPERTIES are not real data, so needs the keyword VIRTUAL
        // direction is many to one (or child to parent)
        public virtual Album Album { get; set; } // child to parent
        public virtual Genre Genre { get; set; } // child to parent
        public virtual MediaType MediaType { get; set; } // child to parent
        
    }
}
