using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Discovery;
using System.Text;
using System.Threading.Tasks;

namespace _2
{
    [ServiceContract]
    interface IUsluga
    {
        [OperationContract]
        string ScalNapisy(string a, string b);
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            var discoveryClient = new DiscoveryClient(new UdpDiscoveryEndpoint("soap.udp://localhost:30703"));
            var endpoints = discoveryClient.Find(new FindCriteria(typeof(IUsluga))).Endpoints;
            discoveryClient.Close();

            if (endpoints.Count <= 0)
            {
                return;
            }

            var proxy = ChannelFactory<IUsluga>.CreateChannel(new NetNamedPipeBinding(), endpoints[0].Address);
            Console.WriteLine($"\"jeden\" \"dwa\") => { proxy.ScalNapisy("jeden", "dwa")}");
            (proxy as IDisposable).Dispose();
            Console.ReadLine();
        }
    }
}
