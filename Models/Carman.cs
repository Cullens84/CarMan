using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CarMan.Models;

    public class Carman
    {
        [Key]
        public int Id { get; set; }
        public string Manufacturer { get; set; }
        [DisplayName("Model")]
        public string model { get; set; }
        [DisplayName("Colour")]
        public string colour { get; set; }
        [DisplayName("Engine size in Cubic Centimeters")]
        [Range(.995, 5995, ErrorMessage = "Engine Size must be between .995 and 5995 (measured in cc)")]
        public int enginesize { get; set; }
        public DateTime CreatedDateTime { get; set; } = DateTime.Now;

    }


