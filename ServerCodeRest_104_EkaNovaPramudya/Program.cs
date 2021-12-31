using System;
using System.Collections.Generic;
using ServiceRest_20190140104_EkaNovaPramudya;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.ServiceModel.Channels;

namespace ServerCodeRest_104_EkaNovaPramudya
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceHost host = null;
            Uri address = new Uri("http://localhost:1907/Mahasiswa");
            WebHttpBinding binding = new WebHttpBinding();

            try 
            {
                host = new ServiceHost(typeof(TI_UMY), address);               
                host.AddServiceEndpoint(typeof(ITI_UMY), binding, "");
                
                ServiceMetadataBehavior smb = new ServiceMetadataBehavior(); 
                smb.HttpGetEnabled = true; 
                host.Description.Behaviors.Add(smb);                
                Binding mexbind = MetadataExchangeBindings.CreateMexHttpBinding();
                host.AddServiceEndpoint(typeof(IMetadataExchange), mexbind, "mex");

                WebHttpBehavior whb = new WebHttpBehavior();
                whb.HelpEnabled = true;
                host.Description.Endpoints[0].EndpointBehaviors.Add(whb);

                host.Open();
                Console.WriteLine("Server is ready!!!!");
                Console.ReadLine();
                host.Close();
            }
            catch(Exception e)
            {
                host = null;
                Console.WriteLine(e.Message);
                Console.ReadLine();
            }
        }
    }
}
