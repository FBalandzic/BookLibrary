using BookWebApp.Model;
using BookWebApp.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        UserRep userRep = new UserRep();

        [HttpGet("{id}")]
        public ActionResult getUserById(string id)
        {
            User user = userRep.getUserById(id);
            return Ok(user);
        }

        [HttpPost("addUser")]
        public ActionResult addUser([FromForm] User user)
        {
            userRep.addUser(user);
            return Ok();
        }

        [HttpGet("login")]
        public ActionResult login([FromForm]User user)
        {
            if(userRep.login(user) == null)
            {
                Console.WriteLine("Failed to login");
                return Ok();
            }
            else
            {
                Console.WriteLine("Successful login");
                return Ok();
            }
        }

    }
}
