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
        Task<IDataResult<CategoryDto>> GetAsync(int categoryId);                                
        Task<IDataResult<CategoryUpdateDto>> GetCategoryUpdateDtoAsync(int categoryId);
        Task<IDataResult<CategoryListDto>> GetAllAsync();                                        // Istersek de IList türünde Kategori lisetsi getirebiliyoruz.
        Task<IDataResult<CategoryListDto>> GetAllByNoneDeletedAsync();                           // Silinmemiş olan kategorileri getirecek.
        Task<IDataResult<CategoryListDto>> GetAllByNoneDeletedAndActiveAsync();
        Task<IDataResult<CategoryDto>> AddAsync(CategoryAddDto categoryAddDto, string createdByName);             //Data Transfer Object (ViewModel gibi)
        Task<IDataResult<CategoryDto>> UpdateAsync(CategoryUpdateDto categoryUpdateDto, string modifiedByName);
        Task<IDataResult<CategoryDto>> DeleteAsync(int categoryId, string modifiedByName);                        //Durumunu False yapacak
        Task<IResult> HardDeleteAsync(int categoryId);                                           //Tamamen veritabanından silecek. Tehlikeli
        Task<IDataResult<int>> CountAsync();
        Task<IDataResult<int>> CountByNonDeletedAsync();
    }
}
