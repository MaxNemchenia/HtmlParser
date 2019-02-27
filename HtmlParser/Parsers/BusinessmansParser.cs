using CsQuery;
using HtmlParser.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;

namespace HtmlParser.Parsers
{
    class BusinessmansParser
    {
        List<Businessman> businessmans = new List<Businessman>();
        public void CsParse()
        {
            var web = CQ.CreateFromUrl("https://ej.by/rating/business2018/");
            var image = web.Select(".member-list .visual img");
            if (image != null)
            {
                foreach (var img in image)
                {
                    Businessman businessman = new Businessman();
                    businessman.Photo = "ej.by" + img.Attributes.GetAttribute("src");
                    businessmans.Add(businessman);
                }
            }

            var mark = web.Select(".member-list .visual .mark");
            if (mark != null)
            {
                for (int i = 0; i < mark.Length; i++)
                {
                    businessmans[i].Position = mark[i].FirstChild.ToString();
                }
            }

            var information = web.Select(".member-list .text-holder .title2 .name-link");
            if (information != null)
            {
                for (int i = 0; i < information.Length; i++)
                {
                    businessmans[i].Name = information[i].FirstChild.ToString();
                }
            }

            var age = web.Select(".member-list .text-holder .title2 span");
            if (age != null)
            {
                for (int i = 0; i < age.Length; i++)
                {
                    businessmans[i].Age = age[i].FirstChild.ToString();
                }
            }


        }


        public void Parse()
        {
            string data = GetHtmlPageText("https://ej.by/rating/business2018/");

            // Тег для поиска, ищем теги <a></a>
            string tag = "ul class=\"member-list\"";
            string pattern = string.Format(@"\<{0}.*?\>(?<tegData>.+?)\<\/{0}\>", tag.Trim());
            // \<{0}.*?\> - открывающий тег
            // \<\/{0}\> - закрывающий тег
            // (?<tegData>.+?) - содержимое тега, записываем в группу tegData

            Regex regex = new Regex(pattern, RegexOptions.ExplicitCapture);
            MatchCollection matches = regex.Matches(data);
            Method(matches);
        }


        public void Method(MatchCollection matches)
        {
            foreach (Match matche in matches)
            {
                Console.WriteLine(matche.Value);
                Console.WriteLine("Содержание:");
                Console.WriteLine(matche.Groups["tegData"].Value);
                Console.WriteLine("---------------------------");
            }

        }

        public static string GetHtmlPageText(string url)
        {
            WebClient client = new WebClient();
            using (Stream data = client.OpenRead(url))
            {
                using (StreamReader reader = new StreamReader(data))
                {
                    return reader.ReadToEnd();
                }
            }
        }
    }
}
