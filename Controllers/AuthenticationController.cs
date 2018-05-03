using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using IT_F18.Models;

namespace IT_F18.Controllers
{
    [Route("api/[controller]")]
    public class AuthenticationController : Controller
    {
        // GET: api/Subscribers
        [HttpGet]
        public bool IsAdminUser()
        {
            return Request.Cookies["cookie"] != null;
        }

        // POST: api/Subscribers
        [HttpPost]
        [Route("login")]
        public IActionResult Login([FromBody] LoginData data)
        {
            Console.WriteLine("Hej");
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if(data.Username == "Kurt" && data.Password == "123")
            {
                Response.Cookies.Append("cookie", "hej");
                Response.StatusCode = 200;
            } 
            else
            {
                Response.StatusCode = StatusCodes.Status401Unauthorized;
            }

            return new EmptyResult();
        }

        // DELETE: api/Subscribers/5
        [HttpPost]
        public IActionResult Logout()
        {
            Response.Cookies.Delete("cookie");

            Response.StatusCode = 200;
            return new EmptyResult();
        }
    }
}