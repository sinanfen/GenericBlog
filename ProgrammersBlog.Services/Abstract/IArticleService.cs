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
        Task<IDataResult<ArticleUpdateDto>> GetArticleUpdateDtoAsync(int articleId);
        Task<IDataResult<ArticleListDto>> GetAllAsync();                             //Istersek de IList türünde makale lisetsi getirebiliyoruz.
        Task<IDataResult<ArticleListDto>> GetAllByNonDeletedAsync();                // Silinmemiş olan makaleleri getirecek.
        Task<IDataResult<ArticleListDto>> GetAllByNonDeletedAndActiveAsync();       //Hem silinmemiş hem aktif olan makaleler
        Task<IDataResult<ArticleListDto>> GetAllByCategoryAsync(int categoryId);     //Kategoriye göre makale getir.
        Task<IDataResult<ArticleListDto>> GetAllByDeletedAsync();
        Task<IDataResult<ArticleListDto>> GetAllByViewCountAsync(bool isAscending, int? takeSize);
        Task<IResult> AddAsync(ArticleAddDto articleAddDto, string createdByName, int userId);   //Data Transfer Object (ViewModel gibi)
        Task<IResult> UpdateAsync(ArticleUpdateDto articleUpdateDto, string modifiedByName);
        Task<IResult> DeleteAsync(int articleId, string modifiedByName);             //Durumunu False yapacak
        Task<IResult> HardDeleteAsync(int articleId);                                //Tamamen veritabanından silecek. Tehlikeli
        Task<IResult> UndoDeleteAsync(int articleId, string modifiedByName);
        Task<IDataResult<int>> CountAsync();
        Task<IDataResult<int>> CountByNonDeletedAsync();
    }
}
