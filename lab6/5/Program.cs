using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace _5
{
    [ServiceContract]
    public interface IService
    {
        [OperationContract]
        [WebGet(UriTemplate = "index.html")]
        [XmlSerializerFormat]
        XmlDocument Index();

        [OperationContract]
        [WebGet(UriTemplate = "scripts.js")]
        [XmlSerializerFormat]
        Stream Script();

        [OperationContract]
        [WebInvoke(UriTemplate = "Dodaj/{a}/{b}")]
        int Dodaj(string a, string b);
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            var factory = new ChannelFactory<IService>(new WebHttpBinding(), new EndpointAddress("http://localhost:30703/Service.svc/"));
            factory.Endpoint.EndpointBehaviors.Add(new WebHttpBehavior());
            var channel = factory.CreateChannel();
            Console.WriteLine($"\"1\" \"2\" => {channel.Dodaj("1", "2")}");
            factory.Close();
            Console.ReadLine();
        }
    }
}
