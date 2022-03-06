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
    public interface ICategoryService
    {                                                                                       //Ful asenkron metod yazdığımız için hepsini Task yapıyoruz.
        Task<IDataResult<CategoryDto>> Get(int categoryId);                                 //IDataResult içersinde istersek 1 kategoriyi.
        Task<IDataResult<CategoryListDto>> GetAll();                                        // Istersek de IList türünde Kategori lisetsi getirebiliyoruz.
        Task<IDataResult<CategoryListDto>> GetAllByNoneDeleted();                           // Silinmemiş olan kategorileri getirecek.
        Task<IDataResult<CategoryListDto>> GetAllByNoneDeletedAndActive();
        Task<IDataResult<CategoryDto>> Add(CategoryAddDto categoryAddDto, string createdByName);             //Data Transfer Object (ViewModel gibi)
        Task<IDataResult<CategoryDto>> Update(CategoryUpdateDto categoryUpdateDto, string modifiedByName);
        Task<IResult> Delete(int categoryId, string modifiedByName);                        //Durumunu False yapacak
        Task<IResult> HardDelete(int categoryId);                                           //Tamamen veritabanından silecek. Tehlikeli
    }
}
