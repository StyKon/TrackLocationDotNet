using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace TrackLocation.Model
{
    public partial class Location
    {
        [Key]
        public long LocationId { get; set; }
        [NotMapped]
        [JsonProperty("Tracking")]
        public ICollection<Coordination> Tracking { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }
        [Required]
        public long UserId { get; set; }
        [Required]
        public long CarId { get; set; }
       
        public byte? Severity { get; set; }

        public virtual Car Car { get; set; }
        public virtual User User { get; set; }
        
     
       
    }
}
