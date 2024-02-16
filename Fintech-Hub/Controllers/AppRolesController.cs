using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Fintech_Hub.Controllers
{
   // [Authorize(Roles = "Admin")]
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

        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _roleManager.Roles == null)
            {
                return NotFound();
            }

            var roleEntity = await _roleManager.Roles
                .FirstOrDefaultAsync(m => m.Id == id);
            if (roleEntity == null)
            {
                return NotFound();
            }

            return View(roleEntity);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_roleManager.Roles == null)
            {
                return Problem("Entity set 'AppDbContext.Roles' is null.");
            }

            var roleEntity = await _roleManager.FindByIdAsync(id);
            if (roleEntity != null)
            {
                var result = await _roleManager.DeleteAsync(roleEntity);
                if (result.Succeeded)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    // Handle the error, e.g., return a view with error messages
                    return View("Error", result.Errors);
                }
            }
            else
            {
                return NotFound();
            }
        }
    }
}
