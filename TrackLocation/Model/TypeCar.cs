using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TrackLocation.Model
{
    public partial class TypeCar
    {
        [Key]
        public long TypeCarId { get; set; }
        [Required]
        public string NameType { get; set; }
    }
}
