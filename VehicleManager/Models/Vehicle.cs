using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VehicleManager.Models
{
    public class Vehicle
    {
        public Guid ID { get; set; }

        [Display(Name = "First")]
        [Required]
        public string Owner_First { get; set; }

        [Display(Name = "Last")]
        [Required]
        public string Owner_Last { get; set; }

        [Display(Name = "Phone")]
        [DataType(DataType.PhoneNumber)]
        [Required]
        public string Owner_Phone { get; set; }

        [Display(Name = "Unit")]
        [Required]
        [StringLength(30, MinimumLength = 1)]
        public string Owner_Unit { get; set; }

        [Display(Name = "Apartment")]
        [Required]
        public string Owner_Apt { get; set; }

        [Display(Name = "Make")]
        [Required]
        public string Make { get; set; }

        [Display(Name = "Model")]
        [Required]
        public string Model { get; set; }

        [Display(Name = "Color")]
        [Required]
        public string Color { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}