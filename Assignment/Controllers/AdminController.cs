using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Newtonsoft.Json;
using Assignment.Data;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Assignment.Controllers
{
    public class AdminController : Controller
    {
        ApplicationDbContext context;
        private readonly SignInManager<IdentityUser> _signInManager;
        public AdminController(SignInManager<IdentityUser> signInManager)
        {
            context = new ApplicationDbContext();
            _signInManager = signInManager;
        }


        void FillInDropDowns()
        {
            var userList = context.Users.OrderBy(
                u => u.UserName).ToList().Select
                (
                    uu => new SelectListItem
                    {
                        Value = uu.UserName.ToString(),
                        Text = uu.UserName
                    }
                    ).ToList();
            ViewData["Users"] = userList;

            var roleList = context.Roles.OrderBy(

                r => r.Name).ToList().Select(
                rr => new SelectListItem
                {
                    Value = rr.Name.ToString(),
                    Text = rr.Name
                }
                ).ToList();
            ViewData["Roles"] = roleList;
        }


        public ActionResult GetUsers()
        {
            return View(context.Users.ToList());
        }

        public ActionResult GetRoles()
        {
            return View(context.Roles.ToList());
        }

        public ActionResult AddRole()
        {
            return View();
        }

        public ActionResult AddUserToRole()
        {
            FillInDropDowns();
            return View();
        }

        // GET: AdminController
        public ActionResult Index()
        {
            return View();
        }

        // GET: AdminController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }
        [Authorize(Roles = "Admin")]
        // GET: AdminController/Create
        public ActionResult Create()
        {
            return View();
        }

       

        /*[HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteUser(IFormCollection collection)
        {
            var userName = collection["UserName"].ToString();
            var user = await _signInManager.FindByNameAsync(userName);
            if (user != null)
            {
                var result = await _signInManager.DeleteAsync(user);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", "Fehler beim Löschen des Benutzers.");
                }
            }
            else
            {
                ModelState.AddModelError("", "Benutzer nicht gefunden.");
            }
            return View();
        }*/


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddRole(IFormCollection collection)
        {
            IdentityRole role = new IdentityRole();
            role.Name = collection["RoleName"].ToString();
            role.NormalizedName = collection["RoleName"]
                .ToString().ToUpper();
            context.Roles.Add(role);
            context.SaveChanges();
            return RedirectToAction("GetRoles");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> 
            AddUserToRole(string userName, string roleName)
        {
            IdentityUser user = _signInManager.UserManager.FindByNameAsync(userName).Result;
                await _signInManager.UserManager.AddToRoleAsync(user, roleName);
            FillInDropDowns();
            return RedirectToAction("AddUserToRole");
        }


        // POST: AdminController/Create
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

        // GET: AdminController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AdminController/Edit/5
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

        // GET: AdminController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AdminController/Delete/5
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
    }
}
