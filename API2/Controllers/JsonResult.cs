using System.Collections.Generic;

namespace API2.Controllers
{
    internal class JsonResult
    {
        private List<string> users;

        public JsonResult(List<string> users)
        {
            this.users = users;
        }
    }
}