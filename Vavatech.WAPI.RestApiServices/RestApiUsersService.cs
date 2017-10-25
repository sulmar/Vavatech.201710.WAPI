using System;
using System.Collections;
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
   

    public class GenericHttpClient
    {
        public static T Get<T>(string uri)
        {
            var address = ConfigurationManager.AppSettings["ServiceUri"];

            var client = new HttpClient();

            client.BaseAddress = new Uri(address);

            var response = client.GetAsync(uri).Result;

            var result = response.Content.ReadAsAsync<T>().Result;

            return result;
        }
    }


    public class RestApiUsersService : IUsersService
    {
        private readonly string address;

        public RestApiUsersService()
        {
            address = ConfigurationManager.AppSettings["ServiceUri"];
        }

        public void Add(User item)
        {
            var address = ConfigurationManager.AppSettings["ServiceUri"];

            string url = $"api/users";

            var client = new HttpClient();

            client.BaseAddress = new Uri(address);

            client.PostAsJsonAsync(url, item);

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

            var users = GenericHttpClient.Get<IList<User>>(url);

            return users;

        }

        public User Get(int id)
        {
            string url = $"api/users/{id}";

            var user = GenericHttpClient.Get<User>(url);

            return user;
        }

        public User GetByPesel(string pesel)
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
          
        }

        public void Update(User item)
        {
            throw new NotImplementedException();
        }
    }
}
