using Assignment.Data.Models.Domains;
using Assignment.Service.IService;
using Assignment.Service.Models;
using Assignment.Service.Service;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Assignment.Controllers
{
    public class Helper
    {
        IUniversityService universityService;

        public Helper()
        {
            universityService = new UniversityService();
        }

        public List<SelectListItem> GetCourseDropDown(IList<Course> courses)
        {
            List<SelectListItem> courseList = new List<SelectListItem>();
            foreach (var uni in courses)
            {
                courseList.Add(
                    new SelectListItem()
                    {
                        Text = uni.Name,
                        Selected = uni.Name == courses[0].Name
                    });
            }
            return courseList;

        }

        public List<SelectListItem> GetUniversityDropDown()
        {
            List<SelectListItem> uniList = new List<SelectListItem>();
            IList<University> universities = universityService.GetUniversities();
            foreach (var uni in universities)
            {
                uniList.Add(
                    new SelectListItem()
                    {
                        Text = uni.Name,
                        Value = uni.UniversityId.ToString(),
                        Selected = uni.Name == universities[0].Name
                    });
            }
            return uniList;
        }

    }
}
