using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MVC_WEB_Project.Data;
using MVC_WEB_Project.Models;

namespace MVC_WEB_Project.Data
{
    public class MVCDbContext :DbContext
    {
        public MVCDbContext(DbContextOptions options)
            : base(options)
        {

        }
        public DbSet<Customer> Customers { get; set; }
    }
}


