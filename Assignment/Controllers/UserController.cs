using Assignment.Service.IService;
using Assignment.Service.Service;
using Microsoft.AspNetCore.Mvc;

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

    }
}
