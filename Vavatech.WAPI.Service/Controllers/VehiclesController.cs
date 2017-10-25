using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Vavatech.WAPI.Models;
using Vavatech.WAPI.Services;

namespace Vavatech.WAPI.Service.Controllers
{
    public class VehiclesController : ApiController
    {
        private IVehiclesService vehiclesService;

        public VehiclesController(IVehiclesService vehiclesService)
        {
            this.vehiclesService = vehiclesService;
        }


        public IHttpActionResult Get()
        {
            var items = vehiclesService.Get();

            return Ok(items);
        }

        public IHttpActionResult Post(Vehicle vehicle)
        {
            vehiclesService.Add(vehicle);

            return CreatedAtRoute("DefaultApi", new { id = vehicle.Id }, vehicle);
        }



    }
}