using OSIsoft.AF;
using OSIsoft.AF.PI;
using System;
using System.Net;

namespace afs
{
    class Program
    {
        static void Main(string[] args)
        {
            var username = Environment.GetEnvironmentVariable("PI_USER");
            var password = Environment.GetEnvironmentVariable("PI_PASSWORD");
            var domain = Environment.GetEnvironmentVariable("PI_DOMAIN");
            var server = Environment.GetEnvironmentVariable("PI_SERVER");
            try
            {
                Console.WriteLine("Connecting to Server: " + username + "@" + server);
                PISystem piSystem;
                PIServer piServer;
                if(server != null)
                {
                    piServer = PIServer.FindPIServer(server);
                } else
                {
                    piSystem = new PISystems().DefaultPISystem;
                    piServer = PIServer.FindPIServer(piSystem.DefaultPIServerName);
                }
                
                if(username != null && password != null && domain != null)
                {
                    NetworkCredential cred = new NetworkCredential(username, password, domain);
                    piServer.Connect(cred, PIAuthenticationMode.WindowsAuthentication);
                } else
                {
                    piServer.Connect();
                }
                
                Console.WriteLine("AF version:" + piServer.ServerVersion + "\tAF name:" + piServer.Name);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}
