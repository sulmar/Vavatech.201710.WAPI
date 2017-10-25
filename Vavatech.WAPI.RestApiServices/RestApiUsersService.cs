using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Vavatech.WAPI.Models;
using Vavatech.WAPI.Services;

namespace Vavatech.WAPI.RestApiServices
{
    public class RestApiUsersService : IUsersService
    {
        private readonly string address;

        public RestApiUsersService()
        {
            address = ConfigurationManager.AppSettings["ServiceUri"];
        }

        public void Add(User item)
        {
            throw new NotImplementedException();
        }

        public User Get(string firstname)
        {
            throw new NotImplementedException();
        }

        public IList<User> Get(UserSearchCriteria criteria)
        {
            throw new NotImplementedException();
        }

        public IList<User> Get()
        {
            string url = $"api/users";

            var client = new HttpClient();
            client.BaseAddress = new Uri(address);

            var response = client.GetAsync(url).Result;

            var content = response.Content.ReadAsStringAsync().Result;

            throw new NotImplementedException();

        }

        public User Get(int id)
        {
            throw new NotImplementedException();
        }

        public User GetByPesel(string pesel)
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(User item)
        {
            throw new NotImplementedException();
        }
    }
}
