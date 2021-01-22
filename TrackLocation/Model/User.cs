using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrackLocation.Model
{
    public partial class User
    {
       
        [Key]
        public long UserId { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        [EmailAddress]
        [Index(IsUnique = true)]
        public string Email { get; set; }
        [Required]
        [Index(IsUnique = true)]
        public string Cin { get; set; }
        [Required]
        [Index(IsUnique = true)]
        public string NumTel { get; set; }
        [Index(IsUnique = true)]
        public string NumPassport { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string TypeUser { get; set; }
        public string Token { get; set; }

        public virtual ICollection<Car> Car { get; set; }
        public virtual ICollection<Location> Location { get; set; }

       
    }
}
