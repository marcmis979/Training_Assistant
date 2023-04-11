using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TraingAssistantDAL.Models;
using TraingAssistantDAL.Repositories;

namespace TrainingAssistantUI.Controllers
{
    public class TrainingController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public TrainingController(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }
        // GET: TrainingController
        public ActionResult Index()
        {
            return View();
        }

        // GET: TrainingController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: TrainingController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TrainingController/Create
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

        // GET: TrainingController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: TrainingController/Edit/5
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

        // GET: TrainingController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: TrainingController/Delete/5
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
        public ActionResult<Training> GetTrainings()
        {
            var trainings = _unitOfWork.TrainingRepository.GetTrainings();
            return View("getTrainings", trainings);
        }
    }
}
