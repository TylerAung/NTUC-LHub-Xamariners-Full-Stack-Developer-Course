using Microsoft.EntityFrameworkCore;
using CustomerApp.Models; //Map to Model
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerApp.DbContextCust
{
    public class CustomerDbContext : DbContext
    {
        //Overwritten by startup.cs file to 
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Data Source=Tyler-Desktop;Initial Catalog=MVC-Core;Integrated Security=True");
        //}
        
        //Code below needed to replace above
        public CustomerDbContext(DbContextOptions<CustomerDbContext> options) : base(options)
        {
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>()
                .ToTable("TblCustomer");
            modelBuilder.Entity<Customer>()//Assign Primary Key
                .HasKey(C => C.Id);
            modelBuilder.Entity<MedicalCondition>()//Assign Primary Key
                .ToTable("TblMedicalCondition");
            modelBuilder.Entity<MedicalCondition>()//Assign Primary Key
                .HasKey(C => C.Id);

        }
        public DbSet<Customer> Customers { get; set; }
        //DbSet represent table 
    }
}
