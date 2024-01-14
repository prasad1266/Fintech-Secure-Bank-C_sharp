using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace Fintech_Hub.Controllers
{
    [Authorize]
    public class AppRolesController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager; 

        public AppRolesController(RoleManager<IdentityRole> roleManager)
        {
            this._roleManager = roleManager;

        }

        //List Of All Roles Show
        public IActionResult Index()
        {
            var Roles = _roleManager.Roles;
            return View(Roles);
        }

        [HttpGet]
        public IActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(IdentityRole model)
        {
            //avoid duplicate role
            var isThere = _roleManager.RoleExistsAsync(model.Name).GetAwaiter().GetResult();

            if (!isThere)
            {
                _roleManager.CreateAsync(new IdentityRole(model.Name)).GetAwaiter().GetResult();
            }
            return RedirectToAction("Index");
        }
    }
}
