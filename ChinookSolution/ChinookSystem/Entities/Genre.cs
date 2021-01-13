﻿using System;
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
    [Table("Genres")]
    internal class Genre
    {
        private string _Name;

        [Key]
        public int GenreId { get; set; }
        
        [StringLength(120, ErrorMessage ="Genre name is limited to 120 characters")]
        public string Name {
            get {
                return _Name;
            }
            set { 
                _Name = string.IsNullOrEmpty(value) ? null : value;
            } 
        }

        // NAVIGATIONAL PROPERTIES are not real data, so needs the keyword VIRTUAL
        // one to many direction(parent to the child)
        public virtual ICollection<Track> Tracks { get; set; } // parent has the connection to the child
    }
}
