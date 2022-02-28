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
        Task<IDataResult<ArticleDto>> Get(int articleId);                       //IDataResult içersinde istersek 1 makaleyi.
        Task<IDataResult<ArticleListDto>> GetAll();                             //Istersek de IList türünde makale lisetsi getirebiliyoruz.
        Task<IDataResult<ArticleListDto>> GetAllByNoneDeleted();                // Silinmemiş olan makaleleri getirecek.
        Task<IDataResult<ArticleListDto>> GetAllByNoneDeletedAndActive();       //Hem silinmemiş hem aktif olan makaleler
        Task<IDataResult<ArticleListDto>> GetAllByCategory(int categoryId);     //Kategoriye göre makale getir.
        Task<IResult> Add(ArticleAddDto articleAddDto, string createdByName);   //Data Transfer Object (ViewModel gibi)
        Task<IResult> Update(ArticleUpdateDto articleUpdateDto, string modifiedByName);
        Task<IResult> Delete(int articleId, string modifiedByName);             //Durumunu False yapacak
        Task<IResult> HardDelete(int articleId);                                //Tamamen veritabanından silecek. Tehlikeli
    }
}
