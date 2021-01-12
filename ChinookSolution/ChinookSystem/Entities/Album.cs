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
    [Table("Albums")]
    internal class Album
    {
        private string _ReleaseLabel;

        [Key]
        public int AlbumId { get; set; }
        
        [Required(ErrorMessage ="Album Title is required")]
        [StringLength(160, ErrorMessage = "Album Title is limited to 160 characters.")]
        public string Title { get; set; }
                
        public int ArtistId { get; set; }
        public int ReleaseYear { get; set; }
        
        [StringLength(50, ErrorMessage = "Album release label is limited to 50 characters.")]
        public string ReleaseLabel
        {
            get
            {
                return _ReleaseLabel;
            }
            set
            {
                ReleaseLabel = string.IsNullOrEmpty(value) ? null : value;
            }
        } // this is a fully implemented property
    }
}
