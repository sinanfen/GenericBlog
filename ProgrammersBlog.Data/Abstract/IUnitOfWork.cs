using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammersBlog.Data.Abstract
{
    public interface IUnitOfWork : IAsyncDisposable
    {
        IArticleRepository Articles { get; } // uintofwork.Articles
        ICategoryRepository Categories { get; }
        ICommentRepository Comments { get; }
        // Örnek kullanım şekli
        // _unitOfWork.Categories.AddAsync(category);
        // _unitOfWork.Users.AddAsync(user);
        // _unitOfWork.SaveAsync();
        Task<int> SaveAsync(); //Veritabanına Kaydetme İşlemini Gerçekleştirecek.


    }
}
