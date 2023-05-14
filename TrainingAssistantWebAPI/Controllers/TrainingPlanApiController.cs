using Microsoft.AspNetCore.Mvc;

namespace TrainingAssistantWebAPI.Controllers
{
    public class TrainingPlanApiController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
