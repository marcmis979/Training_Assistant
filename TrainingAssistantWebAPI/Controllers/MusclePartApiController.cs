using Microsoft.AspNetCore.Mvc;

namespace TrainingAssistantWebAPI.Controllers
{
    public class MusclePartApiController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
