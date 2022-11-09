using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Model;

namespace ProgrammersBlog.Services.Utilities
{
    public static class Messages
    {
        public static class General
        {
            public static string ValidationError()
            {
                return $"Bir veya daha fazla validasyon hatası ile karşılaşıldı.";
            }
        }

        //Messagese.CategoryMessage.NotFound()
        public static class CategoryMessage
        {
            public static string NotFound(bool isPlural) //mesaj çogul mu?
            {
                if (isPlural) return "Hiçbir kategori bulunamadı";
                return "Böyle bir kategori bulunamadı";
            }

            public static string NotFoundById(int categoryId)
            {
                return $"{categoryId} kategori koduna ait bir kategori bulunamadı.";
            }

            public static string Add(string categoryName)
            {
                return $"{categoryName} adlı kategori başarıyla eklenmiştir.";
            }

            public static string Update(string categoryName)
            {
                return $"{categoryName} adlı kategori başarıyla güncellenmiştir.";
            }

            public static string Delete(string categoryName)
            {
                return $"{categoryName} adlı kategori başarıyla silinmiştir.";
            }

            public static string HardDelete(string categoryName)
            {
                return $"{categoryName} adlı kategori başarıyla veritabanından silinmiştir.";
            }

            public static string UndoDelete(string categoryName)
            {
                return $"{categoryName} adlı kategori başarıyla arşivden geri getirilmiştir.";
            }
        }

        public static class ArticleMessage
        {
            public static string NotFound(bool isPlural) //mesaj çogul mu?
            {
                if (isPlural) return "Makaleler bulunamadı.";
                return "Böyle bir makale bulunamadı";
            }

            public static string NotFoundById(int articleId)
            {
                return $"{articleId} makale koduna ait bir makale bulunamadı.";
            }

            public static string Add(string articleTitle)
            {
                return $"{articleTitle} başlıklı makale başarıyla eklenmiştir.";
            }

            public static string Update(string articleTitle)
            {
                return $"{articleTitle} adlı makale başarıyla güncellenmiştir.";
            }

            public static string Delete(string articleTitle)
            {
                return $"{articleTitle} adlı makale başarıyla silinmiştir.";
            }

            public static string HardDelete(string articleTitle)
            {
                return $"{articleTitle} adlı makale başarıyla veritabanından silinmiştir.";
            }

            public static string UndoDelete(string articleTitle)
            {
                return $"{articleTitle} başlıklı makale başarıyla arşivden geri getirilmiştir.";
            }

            public static string IncreaseViewCount(string articleTitle)
            {
                return $"{articleTitle} başlıklı makalenin okunma sayısı başarıyla arttırılmıştır.";
            }
        }

        public static class CommentMessage
        {
            public static string NotFound(bool isPlural)
            {
                if (isPlural) return "Hiç bir yorum bulunamadı.";
                return "Böyle bir yorum bulunamadı.";
            }

            public static string Approve(int commentId)
            {
                return $"{commentId} no'lu yorum başarıyla onaylanmıştır.";
            }

            public static string Add(string createdByName)
            {
                return $"Sayın {createdByName}, yorumunuz başarıyla eklenmiştir.";
            }

            public static string Update(string createdByName)
            {
                return $"{createdByName} tarafından eklenen yorum başarıyla güncellenmiştir.";
            }
            public static string Delete(string createdByName)
            {
                return $"{createdByName} tarafından eklenen yorum başarıyla silinmiştir.";
            }
            public static string HardDelete(string createdByName)
            {
                return $"{createdByName} tarafından eklenen yorum başarıyla veritabanından silinmiştir.";
            }

            public static string UndoDelete(string createdByName)
            {
                return $"{createdByName} tarafından eklenen yorum başarıyla arşivden geri getirilmiştir.";
            }
        }

        public static class UserMessage
        {
            //public static string NotFound(bool isPlural) //mesaj çogul mu?
            //{
            //    if (isPlural) return "Hiçbir kategori bulunamadı";
            //    return "Böyle bir kategori bulunamadı";
            //}

            public static string NotFoundById(int userId)
            {
                return $"{userId} kullanıcı koduna ait bir kullanıcı bulunamadı.";
            }

            //public static string Add(string categoryName)
            //{
            //    return $"{categoryName} adlı kategori başarıyla eklenmiştir.";
            //}

            //public static string Update(string categoryName)
            //{
            //    return $"{categoryName} adlı kategori başarıyla güncellenmiştir.";
            //}

            //public static string Delete(string categoryName)
            //{
            //    return $"{categoryName} adlı kategori başarıyla silinmiştir.";
            //}

            //public static string HardDelete(string categoryName)
            //{
            //    return $"{categoryName} adlı kategori başarıyla veritabanından silinmiştir.";
            //}

            //public static string UndoDelete(string categoryName)
            //{
            //    return $"{categoryName} adlı kategori başarıyla arşivden geri getirilmiştir.";
            //}
        }
    }
}
