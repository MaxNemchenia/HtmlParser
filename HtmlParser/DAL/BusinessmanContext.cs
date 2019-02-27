using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using HtmlParser.Models;

namespace HtmlParser.DAL
{
    class BusinessmanContext : DbContext
    {
        public BusinessmanContext()
            : base("DbConnection")
        { }

        public DbSet<Businessman> Businessmens { get; set; }
    }
}
