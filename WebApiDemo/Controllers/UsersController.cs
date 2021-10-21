using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApiDemo.Models;
using WebApiDemo.Services;

namespace WebApiDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        // GET api/users
        [HttpGet]
        public ActionResult<IEnumerable<User>> Get()
        {
            try
            {
                return Ok(_userService.GetAll());

            }
            catch (AppException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        // GET: api/Users/5
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get([FromBody] int id)
        {
            var user = _userService.GetById(id);

            return Ok(user);

        }

        // POST: api/Users
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] User user)
        {
            try
            {
                // create user
                var usersCreated = await _userService.CreateAsync(user);
                return Ok(usersCreated);
            }
            catch (AppException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        // PUT: api/Users/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] User user)
        {
            user.Id = id;

            try
            {
                // update user 
                _userService.Update(user);
                return Ok();
            }
            catch (AppException ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }

    }
}
