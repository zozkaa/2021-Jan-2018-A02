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

        [StringLength(200, ErrorMessage = "Track name is limited to 200 characters")]
        public string Name {
            get {
                return _Name;
            }
            set {
                _Name = string.IsNullOrEmpty(value) ? null : value;
            }
        }
        public int AlbumId { get; set; }
        public int MediaTypeId { get; set; }
        public int GenreId { get; set; }

        [StringLength(220, ErrorMessage = "Composer name is limited to 120 characters")]
        public string Composer {
                get {
                    return _Composer;
                }
                set {
                _Composer = string.IsNullOrEmpty(value) ? null : value;
                }
            }
        public int Milliseconds { get; set; }
        public int Bytes { get; set; }

        [RegularExpression(@"^\d+\.\d{10,2}$")]
        [Range(0, 99999999.99)]
        public decimal UnitPrice { get; set; }

        public virtual ICollection<Track> Tracks { get; set; }
    }
}
