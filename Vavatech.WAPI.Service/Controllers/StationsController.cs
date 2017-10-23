using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Vavatech.WAPI.Models;

namespace Vavatech.WAPI.Service.Controllers
{
    public class StationsController : ApiController
    {
        [HttpGet]
        public IList<Station> Pobierz()
        {
            var stations = new List<Station>
            {
                new Station { Id = 1, Name = "ST001" },
                new Station { Id = 2, Name = "ST002" },
                new Station { Id = 3, Name = "ST003" },
            };

            return stations;
        }

        public Station Get(int id)
        {
            return new Station { Id = 1, Name = "ST001" };
        }

        public void Post(Station station)
        {

        }
    }
}