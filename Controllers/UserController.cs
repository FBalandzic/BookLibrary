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

        [HttpGet]
        public ActionResult<IEnumerable<UserRep>> getAllUsers()
        {
            var books = userRep.getAllUsers();
            return Ok(books);
        }

        [HttpGet("{id}")]
        public ActionResult getUserById(string id)
        {
            User user = userRep.getUserById(id);
            return Ok(user);
        }

        [HttpPost("add")]
        public ActionResult addUser()
        {
            User user = new User();
            user.UserAccountID = "dd";
            user.Username = "Filip";
            user.Password = "Filip";
            user.IsDeleted = 0;
            userRep.addUser(user);
            return Ok();
        }


        [HttpPost("Delete")]
        public ActionResult deleteUser(User user)
        {
            userRep.deleteUser(user);
            return Ok(user);
        }
    }
}
