using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using ClerkManagementApp.DAL.Interfaces;

namespace ClerkManagementApp.DAL.Services
{
    public class ClerkRepository : Interfaces.IClerkRepository
    {
        private ClerkDbContext _context;

        public ClerkRepository(ClerkDbContext context)
        {
            _context = context;
        }

        public Model.ClerkModel GetById(string id)
        {
            return _context.ClerkModels.FirstOrDefault(t => t.Id == int.Parse(id));
        }

        public string GetAll()
        {
            string qry = "select* from ClerkModels";
            return qry;
        }

        public string Add()
        {
            string qry = "insert into ClerkModels(FirstName, LastName, DateOfBirth)" +
                "values('";
            return qry;
        }

        public string Update()
        {
            var query = "update ClerkModels set FirstName='";
            return query;
        }

        public string Delete()
        {
            var query = "delete from ClerkModels where ID='";
            return query;
        }
    }
}