using Microsoft.AspNetCore.Mvc;
using TraingAssistantDAL.Models;
using TrainingAssistantBLL.BusinessLogic;
namespace TrainingAssistantWebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserApiController : Controller
    {
        public readonly IUserBs user;
        public UserApiController(IUserBs user)
        {
            this.user = user;
        }
        [HttpGet("BMI/{id}")]
        public double getUserBMI(int id)
        {
            return user.getUserBMI(id);
        }
        [HttpGet("getUser/{id}")]
        public User getUser(int id)
        {
            return user.GetUserById(id);
        }
        [HttpPost("addUser")]
        public IActionResult AddUser([FromBody] User us)
        {
            if (us == null)
            {
                return BadRequest("Invalid user data");
            }

            user.InsertUser(us);

            return CreatedAtAction("GetUser", new { id = us.Id }, us);
        }
        [HttpPut("updateUser/{id}")]
        public IActionResult UpdateUser(int id, [FromBody] User updatedUser)
        {
            if (updatedUser == null || updatedUser.Id != id)
            {
                return BadRequest("Invalid user data");
            }

            var existingUser = user.GetUserById(id);
            if (existingUser == null)
            {
                return NotFound();
            }

            user.UpdateUser(updatedUser);

            return NoContent();
        }
        [HttpDelete("deleteUser/{id}")]
        public IActionResult DeleteUser(int id)
        {
            var existingUser = user.GetUserById(id);
            if (existingUser == null)
            {
                return NotFound();
            }

            user.DeleteUser(id);

            return NoContent();
        }

    }
}
