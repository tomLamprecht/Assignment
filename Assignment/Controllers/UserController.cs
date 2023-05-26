using Assignment.Data.Models.Domains;
using Assignment.Service.IService;
using Assignment.Service.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Assignment.Controllers
{
    
    public class UserController : Controller
    {
        IUserService userService;

        public UserController()
        {
            userService = new UserService();
        }

        public ActionResult GetUser(string UserId)
        {
            return View(userService.GetUser("1"));
        }


        public ActionResult EditUser(string id)
        {
            return View(userService.GetUser(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditUser(User user)
        {
            userService.UpdateUser(user);

            return RedirectToAction("GetUser", "User", new { id = user.UserId });
        }

    }
}
