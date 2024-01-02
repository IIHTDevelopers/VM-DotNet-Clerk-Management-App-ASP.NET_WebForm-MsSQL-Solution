using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClerkManagementApp.Model;

namespace ClerkManagementApp.DAL.Interfaces
{
    public interface IClerkService
    {
        string GetAll();
        string Add();
        string Update();
        string Delete();
        ClerkModel GetById(string id);
    }
}
