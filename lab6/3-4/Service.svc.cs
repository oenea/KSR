using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Xml;

namespace _3_4
{

    // http://localhost:30703/Service.svc/index.html
    public class Service : IService
    {
        private readonly string basePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @".\wwwroot\");

        public int Dodaj(string a, string b)
        {
            return int.Parse(a) + int.Parse(b);
        }
    
        public XmlDocument Index()
        {
            var xml = new XmlDocument();
            xml.Load(Path.Combine(basePath, "index.xhtml"));
            //xml.Load("C:\\Users\\oenea\\Downloads\\lab5\\3-4\\wwwroot\\index.xhtml");
            return xml;
        }
    
        public Stream Script()
        {
            return File.OpenRead(Path.Combine(basePath, "scripts.js"));
            //return File.OpenRead("C:\\Users\\oenea\\Downloads\\lab5\\3-4\\wwwroot\\scripts.js");
        }
    }
}
