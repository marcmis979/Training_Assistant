using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TraingAssistantDAL.Models;
using TrainingAssistantBLL.BusinessLogic;
using static TraingAssistantDAL.Models.Login;

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
        [HttpGet("getUserById/{id}")]
        public User getUserById(int id)
        {
            return user.GetUserById(id);
        }
        [HttpGet("getUserByEmail/{email}")]
        public User getUserByEmail(string email)
        {
            return user.GetUserByEmail(email);
        }
        [HttpGet("getUsers")]
        public List<User> GetUsers()
        {
            return user.GetUsers();
        }
        [HttpPost("addUser")]
        public IActionResult AddUser([FromBody] User us)
        {
            if (us == null)
            {
                return BadRequest("Invalid user data");
            }

            user.InsertUser(us);

            return CreatedAtAction("getUserById", new { id = us.Id }, us);
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
        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequest request)
        {

            var user = getUserByEmail(request.Login);
            if (user != null && user.Password == request.Password)
            {
                var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("superTajneHasłoooooo"));
                var credentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
                var tokenOptions = new JwtSecurityToken(
                    issuer: "http://localhost:5100",
                    audience: "http://localhost:4200",
                    claims: new List<Claim>(),
                    expires: DateTime.Now.AddMinutes(30),
                    signingCredentials: credentials
                );
                var token = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
                return Ok(new LoginResponse(token));
            }

            return Unauthorized();
        }

        [HttpPut("addTrainingPlanToUser/{id}/{trainingPlanId}")]
        public IActionResult AddTrainingPlanToUser(User updatedUser, int id, int trainingPlanId)
        {
            if (updatedUser == null || updatedUser.Id != id)
            {
                return BadRequest("Invalid exercise data");
            }

            var existingUser = user.GetUserById(id);
            if (existingUser == null)
            {
                return NotFound();
            }

            user.AddTrainingPlanToUser(updatedUser, trainingPlanId);

            return NoContent();
        }

        [HttpPut("removeTrainingPlanFromUser/{id}/{trainingPlanId}")]
        public IActionResult RemoveTrainingPlanFromUser(User updatedUser, int id, int trainingPlanId)
        {
            if (updatedUser == null || updatedUser.Id != id)
            {
                return BadRequest("Invalid exercise data");
            }

            var existingUser = user.GetUserById(id);
            if (existingUser == null)
            {
                return NotFound();
            }

            user.RemoveTrainingPlanFromUser(updatedUser, trainingPlanId);

            return NoContent();
        }

    }
}
