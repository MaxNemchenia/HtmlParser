using HtmlParser.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HtmlParser.Interfaces
{
    public interface IService
    {
        IEnumerable<Businessman> GetAll();
        void Add(Businessman businessman);
    }
}
