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
    public class UsersController : ApiController
    {
        private readonly IUsersService usersService;

        public UsersController()
            : this(new MockUsersService())
        {


        }

        public UsersController(IUsersService usersService)
        {
            this.usersService = usersService;
        }

        [Route("{id:int}")]
        public IHttpActionResult Get(int id)
        {
            var user = usersService.Get(id);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }


        [Route("{name}")]
        public IHttpActionResult Get(string name)
        {
            var user = usersService.Get(name);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        public IHttpActionResult Post(User user)
        {
            usersService.Add(user);

            // return Created($"http://localhost:64688/api/stations/{station.Id}", station);

            return CreatedAtRoute("DefaultApi", new { id = user.Id }, user);
        }


        [Route("{id}")]
        public IHttpActionResult Put(int id, User user)
        {
            if (id != user.Id)
            {
                return BadRequest();
            }

            usersService.Update(user);

            return Ok();
        }

        [Route("{id}")]
        public IHttpActionResult Delete(int id)
        {
            var user = usersService.Get(id);

            if (user == null)
                return NotFound();

            usersService.Remove(id);

            return Ok();
        }
    }
}