using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerApp.Models
{
    public class MedicalCondition
{
        public int Id { get; set; }
        [Required] // using System.ComponentModel.DataAnnotations;
        public string Condition { get; set; }
    }
}
