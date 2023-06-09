using Newtonsoft.Json;
using Services;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API2.Controllers
{
    public class UsersController : ApiController
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        // GET: api/Users
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{

        //    return new string[] { "value1", "value2" };
        //}

        // GET: api/Users/5
        //public string Get(int id)
        //{
        //    return "Hello";
        //}

        [HttpGet]
        [Route("GetAll")] // atencion!!! hace overwrite del api/users
        //public JsonResult<List<string>> Get()
        public HttpResponseMessage Get()
        {

            List<string> users = _userService.GetListUsers();
            var superString = JsonConvert.SerializeObject(users);

            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, "data");
            response.Content = new StringContent(superString);
            return response;

            //return Json(users);
            //return $"hola from getall with id {id}";
        }

        //[HttpGet]
        //[Route("getall")]
        //public JsonResult<List<string>> GetAllUsers(int id)
        //{
        //    var users = _userService.GetListUsers();
        //    return Json(users);
        //}

        // POST: api/Users
        [HttpPost]
        [Route("pruebapost")]
        public void Post([FromBody] string value)
        {
            // hay que deserialize el cuerpo o como va esto?
            Console.WriteLine(value);
        }

        // PUT: api/Users/5
        public void Put(int id, [FromBody] string value)
        {
            Console.WriteLine(id);
            Console.WriteLine(value);
        }

        // DELETE: api/Users/5
        public void Delete(int id)
        {
        }
    }
}
