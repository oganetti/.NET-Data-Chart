using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using OplogDataChartBackend.Services;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

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

        //[Authorize]
        //[HttpGet]
        //public JsonResult Get()
        //{
        //    string userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        //    return Json(_menuServices.ReturnMenuList());
        //}

        [Authorize]
        [HttpGet]
        public JsonResult Get()
        {
            var returnList = _menuServices.GetMenu(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            return Json(returnList);
        }

    }
}