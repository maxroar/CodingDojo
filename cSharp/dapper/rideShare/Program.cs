using System.IO;
using Microsoft.AspNetCore.Hosting;
using rideShare.Models;

namespace rideShare
{
    public class Program
    {
        public static void Main(string[] args)
        {

            using(var db = new UserContext())
            {
                //perform database interactions
                var TableContents = db.users;
            }
            var host = new WebHostBuilder()
                .UseKestrel()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseStartup<Startup>()
                .Build();

            host.Run();
        }
    }
}
