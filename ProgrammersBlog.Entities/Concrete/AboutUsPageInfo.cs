using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammersBlog.Entities.Concrete
{
    public class AboutUsPageInfo
    {
        [DisplayName("Başlık")]
        [Required(ErrorMessage = "{0} alanı boş geçilmemelidir.")]
        [MaxLength(150, ErrorMessage = "{0} alanı {1} karakterden fazla olmamalıdır.")]
        [MinLength(5, ErrorMessage = "{0} alanı {1} karakterden az olmamalıdır.")]
        public string Header { get; set; }
        [DisplayName("İçerik")]
        [Required(ErrorMessage = "{0} alanı boş geçilmemelidir.")]
        [MaxLength(1500, ErrorMessage = "{0} alanı {1} karakterden fazla olmamalıdır.")]
        [MinLength(5, ErrorMessage = "{0} alanı {1} karakterden az olmamalıdır.")]
        public string Content { get; set; }
        [DisplayName("Seo Açıklaması")]
        [Required(ErrorMessage = "{0} alanı boş geçilmemelidir.")]
        [MaxLength(100, ErrorMessage = "{0} alanı {1} karakterden fazla olmamalıdır.")]
        [MinLength(5, ErrorMessage = "{0} alanı {1} karakterden az olmamalıdır.")]
        public string SeoDescription { get; set; }
        [DisplayName("Seo Etiketleri")]
        [Required(ErrorMessage = "{0} alanı boş geçilmemelidir.")]
        [MaxLength(100, ErrorMessage = "{0} alanı {1} karakterden fazla olmamalıdır.")]
        [MinLength(5, ErrorMessage = "{0} alanı {1} karakterden az olmamalıdır.")]
        public string SeoTags { get; set; }
        [DisplayName("Seo Yazar")]
        [Required(ErrorMessage = "{0} alanı boş geçilmemelidir.")]
        [MaxLength(60, ErrorMessage = "{0} alanı {1} karakterden fazla olmamalıdır.")]
        [MinLength(5, ErrorMessage = "{0} alanı {1} karakterden az olmamalıdır.")]
        public string SeoAuthor { get; set; }
    }
}
