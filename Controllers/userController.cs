using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using hospitalmanagement.Model;
using hospitalmanagement.Entities;

namespace hospitalmanagement.Controllers{

    [Route("users")]
    [ApiController]
    public class userController : ControllerBase{
        private readonly IDataRepository<User> _dataRepository;
        public userController(IDataRepository<User> dataRepository)
        {
            _dataRepository = dataRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<User> users = _dataRepository.GetUsers();
            return Ok(users);
        }

        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(int id)
        {
            User user = _dataRepository.GetUser(id);
            if (user == null)
            {
                return NotFound("User record not found");
            }
            return Ok(user);
        }

        [HttpPost]
        public IActionResult Post([FromBody] User user){
            if (user == null)
            {
                return BadRequest("User is null.");
            }
            _dataRepository.Add(user);
            return CreatedAtRoute("Get", new { id = user.Id },user);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] User user)
        {
            if (user == null)
            {
                return BadRequest("User is null.");
            }
            User userToUpdate = _dataRepository.GetUser(id);
            if (userToUpdate == null)
            {
                return NotFound("User not found.");
            }
            _dataRepository.Update(userToUpdate, user);
            return Accepted();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            User user = _dataRepository.GetUser(id);
            if (user == null)
            {
                return NotFound("User record not found.");
            }
            _dataRepository.Delete(user);
            return NoContent();
        }

        [HttpGet("func")]
        public IActionResult GetUsers(string sortByfirstName, string sortBylastName,string search){
            IEnumerable<User> users = _dataRepository.GetUsers(sortByfirstName, sortBylastName, search);
            return Ok(users);
        }
        
    }
}