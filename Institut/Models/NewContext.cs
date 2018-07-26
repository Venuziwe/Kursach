using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Institut.Models
{
    public class NewContext : DbContext
    {
        public DbSet<New> News { get; set; }
    }
}