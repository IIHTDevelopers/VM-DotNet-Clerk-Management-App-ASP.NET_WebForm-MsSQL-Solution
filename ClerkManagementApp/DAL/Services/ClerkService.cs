using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using ClerkManagementApp.DAL.Interfaces;
using ClerkManagementApp.Model;

namespace ClerkManagementApp.DAL.Services
{
    public class ClerkService : Interfaces.IClerkService
    {
        private Interfaces.IClerkRepository _repository;

        public ClerkService(Interfaces.IClerkRepository repository)
        {
            _repository = repository;
        }


        public string GetAll()
        {
            return _repository.GetAll();
        }

        public string Add()
        {
            return _repository.Add();
        }

        public string Update()
        {
            return _repository.Update();
        }

        public string Delete()
        {
            return _repository.Delete();
        }

        public ClerkModel GetById(string id)
        {
            return _repository.GetById(id);
        }
    }
}