using System.Collections.Generic;

namespace Project02CarRentalWebApp.Models
{
    public class AddressDetailsViewModel
    {
        public IEnumerable<Survey> Surveys { get; set; }
        public Address Address { get; set; }
    }
}