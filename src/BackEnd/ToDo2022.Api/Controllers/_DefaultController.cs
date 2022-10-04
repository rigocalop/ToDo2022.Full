using Microsoft.AspNetCore.Mvc;

namespace ToDo2022.Api.Controllers
{
    [ApiController]
    [Route("/")]
    public class _DefaultController
    {
        [HttpGet]
        public string Index()
        {
            return "Running... [ToDo2022.Api]";
        }
    }
}
