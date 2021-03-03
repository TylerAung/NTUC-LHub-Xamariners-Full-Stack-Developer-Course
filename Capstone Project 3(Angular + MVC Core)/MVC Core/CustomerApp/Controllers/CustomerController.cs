using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CustomerApp.Models;
using CustomerApp.DbContextCust;
using System.ComponentModel.DataAnnotations;
using CustomerApp.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Cors;

namespace CustomerApp.Controllers
{
    [EnableCors("MyPolicy")]
    public class CustomerController : Controller
    {
        //Instead of using  clas obj = new obj
        // CustomerDbContext cust = new CustomerDbContext();
        //replaced ----> by CustDbContext = _custDbContext ---> Replace all cust
        CustomerDbContext custDbContext = null;
        public CustomerController(CustomerDbContext _custDbContext, IConfiguration configuration)
        {
            custDbContext = _custDbContext;
            string str = configuration["ConnString"];
        }
        int i = 0;
        public IActionResult Add()//Add because <a href="Customer/Add">Add Customer</a>
        {
            //Check if variablei exist in session
            if(HttpContext.Session.GetInt32("variablei") != null)
            {
                i = (int)HttpContext.Session.GetInt32("variablei");
            }
            i++;
            //Update or overwrite current value of variablei
            HttpContext.Session.SetInt32("variablei", i);
            return View("CustomerAdd", new CustomerViewModel());//Will Crash because is null, so parse empty CustomerViewModel
        }

        public void AddCust([FromBody] Customer obj)
        {
            ////Validation Method
            //var context = new ValidationContext(obj, null, null);
            //var errorResult = new List<ValidationResult>();
            //var isValid = Validator.TryValidateObject(obj, context, errorResult, true);
            ////CustomerDbContext cust = new CustomerDbContext();


            //if (isValid) { //Only when isValid, Runs insert
            //               //Can sub with ModelState.isValid, but if customization is need. Everything else that follows crashes alongside
            //               //Inserting Data
            //    custDbContext.Customers.Add(obj);
            //    custDbContext.SaveChanges();
            ////Get all the records
            //List<Customer> custs = custDbContext.Customers.ToList<Customer>();
            //return StatusCode(StatusCodes.Status200OK, custs); 
            //    //Instead of return Json, use return StatusCode
            //    //Helps to signal success/fail
            //} else
            //{
            //    //CustomerViewModel custvm = new CustomerViewModel();
            //    //custvm.customer = obj;
            //    //custvm.errors = errorResult;
            //    CustomerViewModel custvm = new CustomerViewModel
            //    {
            //        customer = obj,
            //        errors = errorResult
            //    };
            //    return StatusCode(StatusCodes.Status500InternalServerError, custvm);//Log error msg
            //}
        }
        public IActionResult Display()
        {
            //Converts DbSet to
            //CustomerDbContext cust = new CustomerDbContext();
            List<Customer> custs = custDbContext.Customers.ToList<Customer>();
            return View("DisplayCustomer", custs); //custs become Model
        }

        public IActionResult Search(string CustName) //To execute search query
        {
            //CustomerDbContext cust = new CustomerDbContext();
            List<Customer> custs = (from temp in custDbContext.Customers.ToList<Customer>()//LINQ Query. From Where Select
                                    where temp.CustName == CustName //Find specifically
                                    select temp).ToList<Customer>();
            return View("DisplayCustomer", custs);
        }

    }
}
