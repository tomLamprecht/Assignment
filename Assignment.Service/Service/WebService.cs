using Assignment.Service.IService;
using Assignment.Service.Models;
using Azure;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.Service.Service
{
    public class WebService : IWebService
    {
        HttpClient client;
        public WebService()
        {
            client = new HttpClient();

        }

        public IList<Course> GetCourses(string uniString) {
            IList<Course> courses = new List<Course>();
            client.BaseAddress = new Uri("http://54.235.143.83/api/" + uniString);
            HttpResponseMessage response = client.GetAsync(client.BaseAddress).Result;
            if(!response.IsSuccessStatusCode)
            {
                throw new Exception(response.StatusCode.ToString());
            }

            string data = response.Content.ReadAsStringAsync().Result;
            dynamic[] dynamics = JsonConvert.DeserializeObject<dynamic[]>(data);
            foreach (var item in dynamics) { 
                courses.Add(new Course {
                    Name = item.name,
                    Degree = item.degree,
                    University = item.university,
                    Overview = item.overview,
                  });
            }
            return courses;
        }

    }
}
