using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.Extensions.Hosting;
using ProgrammersBlog.Shared.Entities.Concrete;

namespace ProgrammersBlog.Mvc.Filters
{
    public class MvcExceptionFilter : IExceptionFilter
    {
        private readonly IHostEnvironment _environment;
        private readonly IModelMetadataProvider _metadataProvider;

        public MvcExceptionFilter(IHostEnvironment environment, IModelMetadataProvider metadataProvider)
        {
            _environment = environment;
            _metadataProvider = metadataProvider;
        }

        public void OnException(ExceptionContext context)
        {
            if (_environment.IsDevelopment()) //Hangi ortamda olduğumuzun kontrolü. Eğer proje canlıdaysa kesinlikle IsProduction olmalı.
            {
                context.ExceptionHandled = true; //Hata kısmı ele alındı anlamında/handled.
                var mvcErrorModel = new MvcErrorModel
                {
                    Message = $"Üzgünüz,işleminiz sırasında beklenmeyen bir hata meydana geldi. Sorunu en kısa sürede çözeceğiz."
                };
                var result = new ViewResult { ViewName = "Error" }; //Bu hata için Error view'i görüntülenecek.
                result.StatusCode = 500; //Internal Server Error
                result.ViewData = new ViewDataDictionary(_metadataProvider, context.ModelState);
                result.ViewData.Add("MvcErrorModel", mvcErrorModel);
                context.Result = result;
            }
        }
    }
}
