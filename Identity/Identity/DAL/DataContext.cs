using Identity.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Identity.DAL
{
    public class DataContext:DbContext
    {

        public DataContext():base("default")
        {

        }

        public DbSet<User> Users  { get; set; }

    }
}