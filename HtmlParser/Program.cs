using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlParser.Parsers;

namespace HtmlParser
{
    class Program
    {
        static void Main(string[] args)
        {
            BusinessmansParser parser = new BusinessmansParser();
            parser.CsParse();
            Console.ReadKey();
        }
    }
}
