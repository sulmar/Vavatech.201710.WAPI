using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Vavatech.WAPI.MockServices;
using Vavatech.WAPI.Models;
using Vavatech.WAPI.Services;

namespace Vavatech.WAPI.Service.Controllers
{
    public class StationsController : ApiController
    {
        private readonly IStationsService stationsService;

        public StationsController()
            :this(new MockStationsService())
        {
        }

        public StationsController(IStationsService stationsService)
        {
            this.stationsService = stationsService;
        }

        [HttpGet]
        public IList<Station> Pobierz()
        {
            var stations = stationsService.Get();

            return stations;
        }

        public Station Get(int id)
        {
            var station = stationsService.Get(id);

            return station;
        }

        public void Post(Station station)
        {
            stationsService.Add(station);
        }

        public void Put(Station station)
        {
            stationsService.Update(station);
        }

        public void Delete(int id)
        {
            stationsService.Remove(id);
        }
    }
}