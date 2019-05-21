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
            var afname = Environment.GetEnvironmentVariable("AF_NAME") ?? "empty";
            var piname = Environment.GetEnvironmentVariable("PI_NAME") ?? "empty";
            
            try
            {
                Console.Write("Hostname of AF Server:" + afname);
                PISystem sys = new PISystems()[afname];
                var cred = new NetworkCredential(username, password, domain);
                sys.Connect(cred);

                Console.WriteLine("AF version:" + sys.ServerVersion + "\tAF name:" + sys.Name);
                Console.WriteLine("User:" + sys.CurrentUserName + "\tIdentity:" + sys.CurrentUserIdentityString);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Can't connect to PI Server");
                Console.WriteLine(ex);
            }

            try
            {
                Console.Write("Hostname of PI Data Archive:" + piname);
                PIServer srv = new PIServers()[piname];
                srv.Connect();
                Console.WriteLine("PI version:" + srv.ServerVersion + "\tPI name:" + srv.Name);
                Console.WriteLine("User:" + srv.CurrentUserName + "\tIdentity:" + srv.CurrentUserIdentityString);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Can't connect to PI Data Archive");
                Console.WriteLine(ex);
            }
        }
    }
}
