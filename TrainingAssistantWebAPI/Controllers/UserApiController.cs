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
        public void addUser(User us)
        {
            user.InsertUser(us);
        }
        [HttpPut("updateUser")]
        public void updateUser(User us)
        {
            user.UpdateUser(us);
        }

    }
}
