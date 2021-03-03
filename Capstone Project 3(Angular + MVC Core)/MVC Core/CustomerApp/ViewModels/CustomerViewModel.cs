using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CustomerApp.Models;
using System.ComponentModel.DataAnnotations;


namespace CustomerApp.ViewModels
{
    public class CustomerViewModel
    {
        public Customer customer { get; set; }
        public List<ValidationResult> errors { get; set; }

        public CustomerViewModel() //Constructor
        {
            customer = new Customer();
            errors = new List<ValidationResult>();
        }
    }
}
