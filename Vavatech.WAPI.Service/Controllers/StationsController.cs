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
    // [RoutePrefix("api/stations")]
    public class StationsController : ApiController
    {
        private readonly IStationsService stationsService;

        public StationsController()
            : this(new MockStationsService())
        {
        }

        public StationsController(IStationsService stationsService)
        {
            this.stationsService = stationsService;
        }



        // api/stations?lat={latitude}&lng={longitude}

        [HttpGet]
        public IHttpActionResult GetByLocation(float lat, float lng)
        {

            // TODO:

            return Ok();
        }

        [HttpGet]
        public IHttpActionResult Pobierz()
        {
            var stations = stationsService.Get();

            return Ok(stations);
        }






        [Route("api/stations/{id:int}")]
        public IHttpActionResult Get(int id)
        {
            var station = stationsService.Get(id);

            if (station == null)
            {
                return NotFound();
            }

            return Ok(station);
        }


        [Route("api/stations/{name}")]
        public IHttpActionResult Get(string name)
        {
            var station = stationsService.Get(name);

            if (station == null)
            {
                return NotFound();
            }

            return Ok(station);
        }

        public IHttpActionResult Post(Station station)
        {
            stationsService.Add(station);

            // return Created($"http://localhost:64688/api/stations/{station.Id}", station);

            return CreatedAtRoute("DefaultApi", new { id = station.Id }, station);
        }


        [Route("{id}")]
        public IHttpActionResult Put(int id, Station station)
        {
            if (id != station.Id)
            {
                return BadRequest();
            }

            stationsService.Update(station);

            return Ok();
        }

        [Route("{id}")]
        public IHttpActionResult Delete(int id)
        {
            var station = stationsService.Get(id);

            if (station == null)
                return NotFound();

            stationsService.Remove(id);

            return Ok();
        }
    }
}