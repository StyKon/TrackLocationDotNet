using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrackLocation.Model
{
    public partial class Car
    {
        public Car()
        {
            Location = new HashSet<Location>();
        }
        [Key]
        public long CarId { get; set; }
        [Required]
        public string NameCar { get; set; }
        [Required]
        public int Puissance { get; set; }
        [Required]
        public int NumberPlace { get; set; }
        [Required]
        [Index(IsUnique = true)]
        public string Matricule { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/0:dd/yyyy}")]
        public DateTime DateCirculation { get; set; }
        public int? TotKm { get; set; }
        public long FamilyCarId { get; set; }
        public long UserId { get; set; }
        public long TypeCarId { get; set; }

        public virtual FamilyCar FamilyCar { get; set; }
        public virtual TypeCar TypeCar { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<Location> Location { get; set; }

      
    }
}
