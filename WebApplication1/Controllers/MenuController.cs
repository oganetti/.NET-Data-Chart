using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using OplogDataChartBackend.Services;

namespace OplogDataChartBackend.Controllers


{

    [Route("api/[controller]")]
    public class MenuController : Controller

    {
        private readonly IConfiguration configuration;
        private readonly MenuServices _menuServices;

        public MenuController(IConfiguration config, MenuServices menuServices)
        {
            this.configuration = config;
            _menuServices = menuServices;
        }
        
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult Get()
        {
            return Json( _menuServices.ReturnMenuList() );
        }
    }
}