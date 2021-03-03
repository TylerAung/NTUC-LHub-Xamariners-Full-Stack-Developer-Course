using CustomerApp.DbContextCust;
using CustomerApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

//File templated taken from add--> controllers --> api read/write
namespace CustomerApp.Controllers
{
    [Route("api/[controller]")]
[ApiController]
public class CustomerAPIController : ControllerBase
{
        CustomerDbContext custDbContext = null;
        public CustomerAPIController(CustomerDbContext _custDbContext, IConfiguration configuration)
        {
            custDbContext = _custDbContext;
            string str = configuration["ConnString"];
        }

        // GET: api/<CustomerAPIController>
        [HttpGet]
    public IActionResult Get()
    {
            //IEnumberable is just data
            //IActionResult return response and data
            //Select ALL
            //List<Customer> custs = (from temp in custDbContext.Customers
            //                        select temp).ToList<Customer>();
            List<Customer> custs = custDbContext.Customers
                .Include(p => p.MedicalConditions)
                .ToList<Customer>();

            //return StatusCode(StatusCodes.Status200OK, custs); Shorthand--> return Ok(custs);
            return Ok(custs);
        }

    // GET api/<CustomerAPIController>/5
    [HttpGet("{id}")]
    public IActionResult Get(string CustName)
    {
            //Select with Parameter
            List<Customer> custs = (from temp in custDbContext.Customers
                                    where temp.CustName == CustName //Find specifically
                                    select temp)
                                    .Include(p => p.MedicalConditions)
                                    .ToList<Customer>();
            return Ok(custs);
        }

    // POST api/<CustomerAPIController>
    [HttpPost]
    public IActionResult Post([FromBody] Customer obj)
    {
            //Validation Method
            var context = new ValidationContext(obj, null, null);
            var errorResult = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(obj, context, errorResult, true);
            //CustomerDbContext cust = new CustomerDbContext();


            if (isValid)
            { //Only when isValid, Runs insert
              //Can sub with ModelState.isValid, but if customization is need. Everything else that follows crashes alongside
              //Inserting Data
                custDbContext.Customers.Add(obj);
                custDbContext.SaveChanges();
                //Get all the records
                List<Customer> custs = custDbContext.Customers
                                        .Include(p => p.MedicalConditions)
                                       .ToList<Customer>();

                return Ok(custs);
                //Instead of return Json, use return StatusCode
                //Helps to signal success/fail
            }
            else
            {
                return StatusCode(StatusCodes.Status500InternalServerError, errorResult);//Log error msg
            }
        }

        // PUT api/<CustomerAPIController>/5
        [HttpPut("{id}")]
    public void Put(int id, [FromBody] string value)
    {
    }

    // DELETE api/<CustomerAPIController>/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
            //CustModel item = custDbContext.Customers
            //    .Include(p => p.MedicalConditions)
            //    .FirstOrDefault(x => x.Id = Id);

            //custDbContext.Customers.Remove(item);
    }
}
}
