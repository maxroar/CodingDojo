using System.IO;
using entityCrud.Models;
using Microsoft.AspNetCore.Hosting;

namespace entityCrud
{
    public class Program
    {
        public static void Main(string[] args)
        {

            using(var db = new PersonContext())
            {
                var TableContents = db.person;
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
