using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Project02CarRentalWebApp.Models
{
    public enum ImportanceLevel
    {
        VIP, Critical, Regular
    }
    public class Address
    {
        public Guid Id { get; set; }
        [Required]
        public String CityName { get; set; }
        [Required]
        public String StreetName { get; set; }
        [Required]
        public String ZipCode { get; set; }
        [EmailAddress]
        [Required]
        public String Email { get; set; }
        [Required]
        [RegularExpression(@"^(\d{3})\d{3}-\d{4}$", ErrorMessage = "Invalid Phone Number")]
        public String PhoneNumber { get; set; }
        public ImportanceLevel ImportanceLevel { get; set; }
        public virtual List<Answer> Answers { get; set; }
    }
}