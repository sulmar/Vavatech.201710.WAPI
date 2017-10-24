using Vavatech.WAPI.Models;
using Vavatech.WAPI.Services;
using System.Linq;

namespace Vavatech.WAPI.MockServices
{
    public class MockUsersService : MockItemsService<User>, IUsersService
    {
        public User Get(string firstname)
        {
            return items.FirstOrDefault(i => i.FirstName == firstname);
        }

    }
}
