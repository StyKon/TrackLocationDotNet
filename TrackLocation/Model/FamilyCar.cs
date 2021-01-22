using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TrackLocation.Model
{
    public partial class FamilyCar
    {
        [Key]
        public long FamilyCarId { get; set; }
        [Required]
        public string NameFamily { get; set; }
        
    }
}
