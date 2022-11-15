using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using ProgrammersBlog.Entities.ComplexTypes;
using ProgrammersBlog.Entities.Dtos;
using ProgrammersBlog.Mvc.Helpers.Abstract;
using ProgrammersBlog.Shared.Utilities.Extensions;
using ProgrammersBlog.Shared.Utilities.Results.Abstract;
using ProgrammersBlog.Shared.Utilities.Results.ComplexTypes;
using ProgrammersBlog.Shared.Utilities.Results.Concrete;
using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ProgrammersBlog.Mvc.Helpers.Concrete
{
    public class ImageHelper : IImageHelper
    {
        private readonly IWebHostEnvironment _env;
        private readonly string _wwwroot;
        private const string imgFolder = "img";
        private const string userImagesFolder = "userImages";
        private const string postImagesFolder = "postImages";

        public ImageHelper(IWebHostEnvironment env)
        {
            _env = env;
            _wwwroot = _env.WebRootPath; //dinamik şekilde wwwroot yolunu aldı
        }

        public IDataResult<ImageDeletedDto> Delete(string pictureName)
        {

            var fileToDelete = Path.Combine($"{_wwwroot}/{imgFolder}/", pictureName);
            if (System.IO.File.Exists(fileToDelete))
            {
                var fileInfo = new FileInfo(fileToDelete);
                var imageDeletedDto = new ImageDeletedDto
                {
                    FullName = pictureName,
                    Extension = fileInfo.Extension,
                    Path = fileInfo.FullName,
                    Size = fileInfo.Length
                };
                System.IO.File.Delete(fileToDelete);
                return new DataResult<ImageDeletedDto>(ResultStatus.Success, imageDeletedDto);
            }
            else
            {
                return new DataResult<ImageDeletedDto>(ResultStatus.Error, $"Böyle bir fotoğraf bulunamadı.", null);
            }
        }

        public string Upload(string name, IFormFile pictureFile, PictureType pictureType, string folderName = null)
        {
            /* Eğer folderName değişkeni null gelir ise, o zaman fotoğraf tipine göre (PictureType) klasör adı ataması yapılır */
            folderName ??= pictureType == PictureType.User ? userImagesFolder : postImagesFolder; 

            /* Eğer folderName değişkeni ile gelen klasör adı sistemimizde mevcut değilse, yeni bir klasör oluşturulur. */
            if (!Directory.Exists($"{_wwwroot}/{imgFolder}/{folderName}")) //Eğer böyle bir klasör yok ise--
            {
                Directory.CreateDirectory($"{_wwwroot}/{imgFolder}/{folderName}"); //Oluştur
            }

            /* Fotoğrafın yüklenme sırasındaki ilk adı oldFileName adlı değişkene atanır. */
            string oldFileName = Path.GetFileNameWithoutExtension(pictureFile.FileName);

            /* Fotoğrafın uzantısı fileExtension adlı değişkene atanır. */
            string fileExtension = Path.GetExtension(pictureFile.FileName);


            Regex regex = new Regex("[*'\",._&#^@]");
            name = regex.Replace(name, string.Empty);


            DateTime dateTime = DateTime.Now;
            /*
            Parametre ile gelen değerler kullanılarak yeni bir fotoğraf adı oluşturulur.
            Örn: SinanFen_587_5_38_12_3_10_2020.png
            */
            string newFileName = $"{name}_{dateTime.FullDateAndTimeStringWithUnderscore()}{fileExtension}";

            /* Kendi parametrelerimiz ile sistemimize uygun yeni bir dosya yolu (path) oluşturulur. */
            var path = Path.Combine($"{_wwwroot}/{imgFolder}/{folderName}", newFileName);

            /* Sistemimiz için oluşturulan yeni dosya yoluna fotoğraf kopyalanır. */
            using (var stream = new FileStream(path, FileMode.Create))
            {
                pictureFile.CopyToAsync(stream);
            }

            /* Fotoğraf tipine göre kullanıcı için bir mesaj oluşturulur.(UserImage veya PostImage) */
            string message = pictureType == PictureType.User
                ? $"{name} adlı kullanıcının fotoğrafı başarıyla yüklenmiştir."
                : $"{name} adlı makalenin fotoğrafı başarıyla yüklenmiştir.";

            return $"{folderName}/{newFileName}";
        }
    }
}
