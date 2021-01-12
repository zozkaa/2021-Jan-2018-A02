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
    [Table("Artists")]
    // Can only be seen in the library class
    internal class Artist
    {
        private string _Name;

        
        [Key] //primary key with identity specification = yes
        public int ArtistId { get; set; }
        // annotations to do validations
        [StringLength(120, ErrorMessage = "Artist name is limited to 120 characters.")]
        public string Name {
            get { 
                return _Name; 
            }
            set {
                _Name = string.IsNullOrEmpty(value) ? null : value;
            }
        } // this is a fully implemented property
    }
}
