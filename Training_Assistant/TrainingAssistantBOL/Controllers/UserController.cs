using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TraingAssistantDAL.Models;
using TrainingAssistantBLL.BusinessLogic;

namespace TrainingAssistantBOL.Controllers
{
    public class UserController : Controller
    {
        public readonly IUserBs user;
        public UserController(IUserBs user)
        {
            this.user = user;
        }

        public ActionResult GetUsers()
        {
            var users = user.GetUsers();
            return View(users);
        }


        public ActionResult GetUserById(int id)
        {
            var userDetails = user.GetUserById(id);
            if (userDetails == null)
            {
                return NotFound();
            }
            return View(userDetails);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddUser(User userToCreate)
        {
            if (ModelState.IsValid)
            {
                user.InsertUser(userToCreate);
                return RedirectToAction(nameof(Index));
            }
            return View(userToCreate);
        }

        public IActionResult UpdateUser(int id)
        {
            var userToEdit = user.GetUserById(id);
            if (userToEdit == null)
            {
                return NotFound();
            }
            return View(userToEdit);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdateUser(int id, User updatedUser)
        {
            if (id != updatedUser.Id)
            {
                return BadRequest("Invalid user data");
            }

            if (ModelState.IsValid)
            {
                user.UpdateUser(updatedUser);
                return RedirectToAction(nameof(Index));
            }
            return View(updatedUser);
        }

        public IActionResult DeleteUser(int id)
        {
            var userToDelete = user.GetUserById(id);
            if (userToDelete == null)
            {
                return NotFound();
            }
            return View(userToDelete);
        }
    }
}
