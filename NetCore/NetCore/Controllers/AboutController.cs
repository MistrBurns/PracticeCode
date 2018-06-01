using Microsoft.AspNetCore.Mvc;

namespace NetCore.Controllers
{
    //can also be applied at action level
    [Route("company/[controller]")]
    public class AboutController : Controller
    {
        [Route("")]
        public string Phone()
        {
            return "Phone";
        }
        [Route("[action]")]
        public string Address()
        {
            return "Wien";
        }
    }
}