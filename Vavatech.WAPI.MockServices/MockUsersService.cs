using Vavatech.WAPI.Models;
using Vavatech.WAPI.Services;
using System.Linq;
using System;
using System.Collections.Generic;

namespace Vavatech.WAPI.MockServices
{
    public class MockUsersService : MockItemsService<User>, IUsersService
    {
        public User Get(string firstname)
        {
            return items.FirstOrDefault(i => i.FirstName == firstname);
        }

        public IList<User> Get(UserSearchCriteria criteria)
        {
            IQueryable<User> query = items.AsQueryable();

            if (!string.IsNullOrEmpty(criteria.FirstName))
            {
                query = query.Where(u => u.FirstName == criteria.FirstName);
            }

            if (!string.IsNullOrEmpty(criteria.LastName))
            {
                query = query.Where(u => u.LastName == criteria.LastName);
            }

            if (!string.IsNullOrEmpty(criteria.Pesel))
            {
                query = query.Where(u => u.Pesel == criteria.Pesel);
            }

            return query.ToList();

            

        }

        public User GetByPesel(string pesel)
        {

            if (string.IsNullOrEmpty(pesel))
            {
                throw new ArgumentNullException(nameof(pesel));
            }

            if (pesel.Length != 11)
            {
                throw new ArgumentException(nameof(pesel));
            }


            // ...

            return items.SingleOrDefault(u => u.Pesel == pesel);
        }
    }
}
