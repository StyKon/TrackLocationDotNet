using System;
using System.ComponentModel.DataAnnotations;

namespace TrackLocation.Model
{
    public class Coordination
    {
        public double latitude { get; set; }
       	public double longitude { get; set; }
       	public int speed { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/0:dd/yyyy HH:mm:ss}")]

        public DateTime timestamp { get; set; }
    }
}