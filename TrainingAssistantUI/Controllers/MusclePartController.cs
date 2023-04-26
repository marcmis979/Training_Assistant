using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TraingAssistantDAL.Models;
using TraingAssistantDAL.Repositories.Implementation;

namespace TrainingAssistantUI.Controllers
{
    public class MusclePartController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public MusclePartController(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }
        // GET: MusclePartController
        public ActionResult Index()
        {
            return View();
        }

        // GET: MusclePartController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: MusclePartController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MusclePartController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MusclePartController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: MusclePartController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MusclePartController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: MusclePartController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        public ActionResult<MusclePart> GetMuscleParts()
        {
            var muscleParts = _unitOfWork.MusclePartRepository.GetMuscleParts();
            return View("getMuscleParts", muscleParts);
        }
    }
}
