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
        /// <summary>
        /// Verilen ID parametresine ait kategorinin CategoryUpdateDto temsilini geriye döner.
        /// </summary>
        /// <param name="categoryId">0'dan büyük integer bir ID değeri</param>
        /// <returns>Asenkron bir operasyon ile Task olarak işlem sonucunu DataResult tipinde geriye döner.</returns>
        Task<IDataResult<CategoryUpdateDto>> GetCategoryUpdateDtoAsync(int categoryId);
        Task<IDataResult<CategoryListDto>> GetAllAsync();                                        // Istersek de IList türünde Kategori lisetsi getirebiliyoruz.
        Task<IDataResult<CategoryListDto>> GetAllByNoneDeletedAsync();                           // Silinmemiş olan kategorileri getirecek.
        Task<IDataResult<CategoryListDto>> GetAllByNoneDeletedAndActiveAsync();
        /// <summary>
        /// Verilen categoryAddDto ve createdByName parametrelerine ait bilgiler ile yeni bir Category ekler.
        /// </summary>
        /// <param name="categoryAddDto">categoryAddDto tipinde eklenecek kategori bilgileri</param>
        /// <param name="createdByName">string tipinde kullanıcının kullanıcı adı</param>
        /// <returns>Asenkron bir operasyon ile Task olarak bizlere ekleme işlemin sonucunu DataResult tipinde geri döner.</returns>
        Task<IDataResult<CategoryDto>> AddAsync(CategoryAddDto categoryAddDto, string createdByName);             //Data Transfer Object (ViewModel gibi)
        Task<IDataResult<CategoryDto>> UpdateAsync(CategoryUpdateDto categoryUpdateDto, string modifiedByName);
        Task<IDataResult<CategoryDto>> DeleteAsync(int categoryId, string modifiedByName);                        //Durumunu False yapacak
        Task<IResult> HardDeleteAsync(int categoryId);                                           //Tamamen veritabanından silecek. Tehlikeli
        Task<IDataResult<int>> CountAsync();
        Task<IDataResult<int>> CountByNonDeletedAsync();
    }
}
