using Assignment.Data.Models.Domains;
using Assignment.Models;
using Assignment.Service.IService;
using Assignment.Service.Models;
using Assignment.Service.Service;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Assignment.Controllers
{
    public class ApplicationController : Controller
    {
        IUserService userService = new UserService();
        IApplicationService applicationService = new ApplicationService();
        IUniversityService universityService = new UniversityService();
        IWebService webService = new WebService();
        Helper helper = new Helper();
        public ApplicationController() { }


        public ActionResult chooseUniversity() {
            string userId = "1"; //HARDCODED TODO UPDATE WITH USER IDENTITY
            if(userService.GetUser(userId).Applications.Count >= 5)
            {
                Debug.WriteLine("User has already 5 applications");
                return RedirectToAction("GetUser", "User", new { id = userId });
            }

            ViewBag.universityList = helper.GetUniversityDropDown();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult chooseUniversity(University uni)
        {
            Debug.WriteLine(uni.UniversityId);
            return RedirectToAction("chooseCourse", "Application", new { uniId = uni.UniversityId });
        }

        public ActionResult chooseCourse(int uniId) {
            
            University uni = universityService.GetUniversity(uniId);
            IList<Course> courses = webService.GetCourses(uni.Name);
            ViewBag.courseList = helper.GetCourseDropDown(courses);
            UniCourse uniCourse = new UniCourse();
            uniCourse.UniId = uniId; 
            return View(uniCourse);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult chooseCourse(UniCourse uniCourse2) {
            return RedirectToAction("create", "Application", new { UniId = uniCourse2.UniId, CourseName = uniCourse2.CourseName });
        }
        public ActionResult create(int UniId, string CourseName)
        {
            ApplicationUserUniversity auu = new ApplicationUserUniversity();
            auu.Course = CourseName;
            auu.UniversityId = UniId;
            return View(auu);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult create(ApplicationUserUniversity auu) {
            Debug.WriteLine("CREATED AUU for " + auu.UniversityId + " " + auu.Statement + " " + auu.Course);
            auu.UserId = "1"; //TODO CHANGE STATIC ID HERE AS SOON AS IDENTITY IS IMPLEMENTED!!!! 
            applicationService.AddApplication(auu);
            return RedirectToAction("GetUser", "User", new { id = auu.UserId });
        }
    }
}
