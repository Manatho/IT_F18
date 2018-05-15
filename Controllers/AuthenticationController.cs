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
        // Used on the frontend to check if the current user is Admin
        // The "security" of the following approach is far from optimal
        // and serves more as a means to hide or show elements than
        // actual security.
        [HttpGet]
        public bool IsAdminUser()
        {
            return Request.Cookies["cookie"] != null;
        }

        [HttpPost]
        [Route("login")]
        public IActionResult Login([FromBody] LoginData data)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if(data.Username.ToLower() == "admin" && data.Password == "123")
            {
                Response.Cookies.Append("cookie", "admin");
                Response.StatusCode = 200;
            } 
            else
            {
                Response.StatusCode = StatusCodes.Status401Unauthorized;
            }

            return new EmptyResult();
        }

        [HttpPost]
        public IActionResult Logout()
        {
            Response.Cookies.Delete("cookie");

            Response.StatusCode = 200;
            return new EmptyResult();
        }
    }
}