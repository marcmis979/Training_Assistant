using Microsoft.AspNetCore.Mvc;
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

    }
}
