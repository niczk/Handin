using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebAPIAssignment.Data;
using WebAPIAssignment.Model;

namespace WebAPIAssignment.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private IUserService userService;

        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpGet]
        public async Task<ActionResult<User>> ValidateUser([FromQuery] string Username, [FromQuery] string Password)
        {
            try
            {
                var user = await userService.ValidateUser(Username, Password);
                return Ok(user);
            }catch (Exception e )
            {
                return BadRequest(e.Message);
            }
        }
    }
}
