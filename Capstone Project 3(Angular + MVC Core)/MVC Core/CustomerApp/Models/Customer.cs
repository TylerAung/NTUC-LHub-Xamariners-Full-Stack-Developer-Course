using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerApp.Models
{
    public class Customer
    {
        //Name of property here should map to property of input so it automatically maps
        //[Key]
        public int Id { get; set; }
        [Required] // using System.ComponentModel.DataAnnotations;
        public string CustName { get; set; }
        [Required] //Required applies to code below
        //Got pattern, string length
        public string CustAddress { get; set; }
        public List<MedicalCondition> MedicalConditions { get; set; }
    }
}
