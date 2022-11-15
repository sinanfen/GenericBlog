using ProgrammersBlog.Data.Abstract;
using ProgrammersBlog.Data.Concrete.EntityFramework.Contexts;
using ProgrammersBlog.Data.Concrete.EntityFramework.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammersBlog.Data.Concrete
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ProgrammersBlogContext _context;
        private EfArticleRepository _articleRepository;
        private EfCategoryRepository _categoryRepository;
        private EfCommentRepository _commentRepository;

        public UnitOfWork(ProgrammersBlogContext context)
        {
            _context = context;
        }

        //eğer _articleRepository null ise yeni bir ArticleRepository oluştur ve bunu bir önceki _articleRepository değerine ata.
        public IArticleRepository Articles => _articleRepository ??= new EfArticleRepository(_context); 
        //açıklama: articleRepository'e ulaş. Yok veya null ise New'le ve context ile birlikte çalış.

        public ICategoryRepository Categories => _categoryRepository ??= new EfCategoryRepository(_context);

        public ICommentRepository Comments => _commentRepository ??= new EfCommentRepository(_context);

        public async ValueTask DisposeAsync()
        {
            await _context.DisposeAsync();
        }

        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
