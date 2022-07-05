using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using ProgrammersBlog.Entities.Concrete;
using ProgrammersBlog.Mvc.Areas.Admin.Models;
using System.Threading.Tasks;

namespace ProgrammersBlog.Mvc.Areas.Admin.ViewComponents
{
    public class AdminMenuViewComponent : ViewComponent
    {
        private readonly UserManager<User> _userManager;

        public AdminMenuViewComponent(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var user = await _userManager.GetUserAsync(HttpContext.User); //Login olan kullanıcıya ulaştık
            var roles = await _userManager.GetRolesAsync(user);
            if (user == null)
                return Content("Kullanıcı bulunamadı");
            if (roles == null)
                return Content("Roller bulunamadı");
            return View(new UserWithRolesViewModel
            {
                User = user,
                Roles = roles
            });
        }
    }
}
