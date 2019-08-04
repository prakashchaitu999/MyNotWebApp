using Microsoft.AspNetCore.Mvc;
using UsersAPI.Models;

namespace UsersAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NoteController : ControllerBase
    {
        private readonly IMyNote repository;
        public NoteController(IMyNote noted)
        {
            repository = noted;
        }
        [HttpGet]
        public ActionResult Get()
        {
            return Ok(repository.GetUsers());
        }
        // GET api/values/5
        [HttpGet("{userId}")]
        public ActionResult Get(int userId)
        {
            var user = repository.GetUserById(userId);
            if (user == null)
            {
                return NotFound("No user exists");
            }
            else
            {
                return Ok(user);
            }
        }
        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody] MyNote user)
        {
            bool result = repository.CreateUser(user);
            return Created("/api/User", result);
        }
        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] MyNote user)
        {
            var result = repository.UpdateUser(id, user);
            if (result == null)
            {
                return NotFound("No user exists");
            }
            return Ok(result);
        }
        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            bool result = repository.RemoveUser(id);
            if (result)
            {
                return Ok();
            }
            return NotFound("No user exists");
        }
    }
}