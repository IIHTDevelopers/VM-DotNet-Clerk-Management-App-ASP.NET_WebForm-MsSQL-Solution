using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using ClerkManagementApp.Model;

namespace ClerkManagementApp.DAL
{
    public class ClerkDbContext : DbContext
    {
        public DbSet<Model.ClerkModel> ClerkModels { get; set; }

        public ClerkDbContext() : base("ConnStr")
        {
        }
    }
}