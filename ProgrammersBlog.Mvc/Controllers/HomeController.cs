using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using NToastNotify;
using ProgrammersBlog.Entities.Concrete;
using ProgrammersBlog.Entities.Dtos;
using ProgrammersBlog.Services.Abstract;
using ProgrammersBlog.Shared.Utilities.Helpers.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProgrammersBlog.Mvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly IArticleService _articleService;
        private readonly AboutUsPageInfo _aboutUsPageInfo;
        private readonly IMailService _mailService;
        private readonly IToastNotification _toastNotification;
        private readonly IWritableOptions<AboutUsPageInfo> _aboutUsPageInfoWriter;

        public HomeController(IArticleService articleService, IOptionsSnapshot<AboutUsPageInfo> aboutUsPageInfo, IMailService mailService, IToastNotification toastNotification, IWritableOptions<AboutUsPageInfo> aboutUsPageInfoWriter)
        {
            _articleService = articleService;
            _aboutUsPageInfo = aboutUsPageInfo.Value;
            _mailService = mailService;
            _toastNotification = toastNotification;
            _aboutUsPageInfoWriter = aboutUsPageInfoWriter;
        }

        [HttpGet]
        public async Task<IActionResult> Index(int? categoryId, int currentPage = 1, int pageSize = 5, bool isAscending = false)
        {
            var articleResult = await (categoryId == null
                ? _articleService.GetAllByPagingAsync(null, currentPage, pageSize, isAscending)
                : _articleService.GetAllByPagingAsync(categoryId.Value, currentPage, pageSize, isAscending));
            return View(articleResult.Data);
        }

        [HttpGet]
        public IActionResult About()
        {
            _aboutUsPageInfoWriter.Update(x =>
            {
                x.Header = "Yeni Başlık";
                x.Content = "Yeni İçerik";
            });
            return View(_aboutUsPageInfo);
        }

        [HttpGet]
        public IActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Contact(EmailSendDto emailSendDto)
        {
            if (ModelState.IsValid)
            {
                var result = _mailService.SendContactEmail(emailSendDto);
                _toastNotification.AddSuccessToastMessage(result.Message, new ToastrOptions
                {
                    Title = "Başarılı İşlem"
                });
                return View();
            }
            return View(emailSendDto);
        }
    }
}
