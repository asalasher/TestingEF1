using Domain;
using DTOs;
using Newtonsoft.Json;
using Services;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Http.Results;

namespace API2.Controllers
{
    [RoutePrefix("api/users")]
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
        public string Get(int id)
        {
            return "Hello";
        }

        [HttpGet]
        [Route("GetAll")] // atencion!!! hace overwrite del api/users
        //public JsonResult<List<string>> Get()
        public HttpResponseMessage Get()
        {

            List<string> users = _userService.GetListUsers();
            var superString = JsonConvert.SerializeObject(users);

            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK);
            response.Content = new StringContent(superString);
            return response;

            //return Json(users);
            //return $"hola from getall with id {id}";
        }

        [HttpGet]
        [Route("getId/{id:int}")]
        public JsonResult<int> GetIdFromUrl(int id)
        {
            return Json(id);
        }

        [HttpGet]
        [Route("getobject")]
        [ResponseType(typeof(User))]
        public IHttpActionResult GetIdFromUrl()
        {
            User user = new User { Id = 2, Name = "Alberto", DateOfBirth = DateTime.Now };
            return Ok(user);
            //return NotFound();
        }

        [HttpGet]
        [Route("getusersbylist")]
        [ResponseType(typeof(List<User>))]
        public IHttpActionResult GetUsersByList()
        {
            List<User> users = new List<User>() {
                new User { Id = 2, Name = "Alberto", DateOfBirth = DateTime.Now },
                new User { Id = 3, Name = "Pedro", DateOfBirth = DateTime.Now },
                new User { Id = 4, Name = "Manolo", DateOfBirth = DateTime.Now }
            };

            return Ok(users);
            //return NotFound();
            //return Content(HttpStatusCode.NotFound, "student not found");
        }

        [HttpGet]
        [Route("getobject")]
        [ResponseType(typeof(string))]
        public IHttpActionResult GetQueryString()
        {
            // No consigo hacer funcionar esto
            var queryValues = Request.GetQueryNameValuePairs();
            if (queryValues is null)
                return Ok("null query");

            return Ok("return");
        }

        // POST: api/Users
        [HttpPost]
        [Route("pruebapost")]
        [ResponseType(typeof(UserDTO))]
        public IHttpActionResult Post([FromBody] UserDTO value)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("format incorrect");
                //return Content(HttpStatusCode.BadGateway, "NO");
            }

            return Ok(value);
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
