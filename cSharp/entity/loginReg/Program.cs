using System.IO;
using Microsoft.AspNetCore.Hosting;
using loginReg.Models;

namespace loginReg
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // using(var db = new UserContext())
            // {
            //     var TableContents = db.Users;
            // }
            var host = new WebHostBuilder()
                .UseKestrel()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseStartup<Startup>()
                .Build();

            host.Run();
        }
    }
}
