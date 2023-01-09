using ProgrammersBlog.Entities.ComplexTypes;
using ProgrammersBlog.Entities.Concrete;
using ProgrammersBlog.Entities.Dtos;
using ProgrammersBlog.Shared.Utilities.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammersBlog.Services.Abstract
{
    public interface IArticleService
    {
        Task<IDataResult<ArticleDto>> GetAsync(int articleId);                       //IDataResult içersinde istersek 1 makaleyi.
        Task<IDataResult<ArticleDto>> GetByIdAsync(int articleId, bool includeCategory, bool includeComments, bool includeUser);
        Task<IDataResult<ArticleUpdateDto>> GetArticleUpdateDtoAsync(int articleId);
        Task<IDataResult<ArticleListDto>> GetAllAsyncV2
            (int? categoryId, int? userId, bool? isActive, bool? isDeleted,
            int currentPage, int pageSize, OrderByGeneral orderBy, bool isAscending,
            bool includeCategory, bool includeComments, bool includeUser);
        Task<IDataResult<ArticleListDto>> GetAllAsync();                             //Istersek de IList türünde makale lisetsi getirebiliyoruz.
        Task<IDataResult<ArticleListDto>> GetAllRandomlyAsync();                    //Her kullanıldığında rastgele makale getirsin.
        Task<IDataResult<ArticleListDto>> GetAllByNonDeletedAsync();                // Silinmemiş olan makaleleri getirecek.
        Task<IDataResult<ArticleListDto>> GetAllByNonDeletedAndActiveAsync();       //Hem silinmemiş hem aktif olan makaleler
        Task<IDataResult<ArticleListDto>> GetAllByCategoryAsync(int categoryId);     //Kategoriye göre makale getir.
        Task<IDataResult<ArticleListDto>> GetAllByDeletedAsync();
        Task<IDataResult<ArticleListDto>> GetAllByViewCountAsync(bool isAscending, int? takeSize);
        Task<IDataResult<ArticleListDto>> GetAllByPagingAsync(int? categoryId, int currentPage = 1, int pageSize = 5, bool isAscending = false);
        Task<IDataResult<ArticleListDto>> GetAllByUserIdOnFilter
            (int userId, FilterBy filterBy, OrderBy orderBy,
            bool isAscending, int takeSize, int categoryId, DateTime startAt, DateTime endAt,
            int minViewCount, int maxViewCount, int minCommentcount, int maxCommentCount);
        Task<IDataResult<ArticleListDto>> SearchAsync(string keyword, int currentPage = 1, int pageSize = 5, bool isAscending = false);
        Task<IResult> IncreaseViewCountAsync(int articleId);
        Task<IResult> AddAsync(ArticleAddDto articleAddDto, string createdByName, int userId);   //Data Transfer Object (ViewModel gibi)
        Task<IResult> UpdateAsync(ArticleUpdateDto articleUpdateDto, string modifiedByName);
        Task<IDataResult<ArticleDto>> DeleteAsync(int articleId, string modifiedByName);             //Durumunu False yapacak
        Task<IResult> HardDeleteAsync(int articleId);                                //Tamamen veritabanından silecek. Tehlikeli
        Task<IDataResult<ArticleDto>> UndoDeleteAsync(int articleId, string modifiedByName);
        Task<IDataResult<int>> CountAsync();
        Task<IDataResult<int>> CountByNonDeletedAsync();
    }
}
