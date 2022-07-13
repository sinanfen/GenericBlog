using Microsoft.AspNetCore.Mvc;
using ProgrammersBlog.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProgrammersBlog.Mvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly IArticleService _articleService;

        public HomeController(IArticleService articleService)
        {
            _articleService = articleService;
        }

        [HttpGet]
        public async Task<IActionResult> Index(int? categoryId)
        {
            var articleResult = await (categoryId == null ? _articleService.GetAllByNonDeletedAndActiveAsync() : _articleService.GetAllByCategoryAsync(categoryId.Value));
            return View(articleResult.Data);
        }
    }
}
