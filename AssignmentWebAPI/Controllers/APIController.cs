using Microsoft.AspNetCore.Mvc;
using static System.Net.WebRequestMethods;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AssignmentWebAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class APIController : ControllerBase
    {

        // GET api/<StyleController>/5
        [HttpGet]
        public IActionResult Get()
        {
            return Ok();
        }

       /* string (HttpClient client = new HttpClient())
            {
            client.BaseAddress = new Uri(https://shudemo23.azurewebsites.net/api/SHU/);

                string endpoint = "/users";
        string userId = "123";

        HttpResponseMessage response = await client.GetAsync($"{endpoint}/{userId}");

            if(response.IsSuccessStatusCode)
            {
            string responseData = await response.Content.ReadAsStringAsync();
        Console.WriteLine(responseData);
            }
    else
    {
    Console.WriteLine(%"API request failed")}}
       */

        // POST api/<StyleController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<StyleController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<StyleController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
