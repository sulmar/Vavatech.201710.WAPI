using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vavatech.WAPI.RestApiServices;
using Vavatech.WAPI.Services;

namespace Vavatech.WAPI.ConsoleClient
{
    class Program
    {
        static void Main(string[] args)
        {
            GetUsersTest();

            Console.WriteLine("Press any key to exit.");

            Console.ReadKey();

        }

        private static void GetUsersTest()
        {
            

            IUsersService usersService = new RestApiUsersService();

            var users = usersService.Get();

            foreach (var user in users)
            {
                Console.WriteLine($"{user.FirstName} {user.LastName}");
            }
        }
    }
}
