using HtmlParser.Interfaces;
using HtmlParser.Models;
using HtmlParser.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HtmlParser.Services
{
    class BusinessmanService : IService
    {
        BusinessmanContext db;


        public BusinessmanService(BusinessmanContext db)
        {
            this.db = db;
        }


        public void Add(Businessman businessman)
        {
            db.Businessmens.Add(businessman);
            db.SaveChanges();
        }

        public IEnumerable<Businessman> GetAll()
        {
            var businessmans = db.Businessmens.ToList();
            return businessmans;
        }
    }
}
