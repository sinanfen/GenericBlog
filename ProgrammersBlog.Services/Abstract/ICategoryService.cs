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
    {                                                                //Ful asenkron metod yazdığımız için hepsini Task yapıyoruz.
        Task<IDataResult<Category>> Get(int categoryId);             //IDataResult içersinde istersek 1 kategoriyi.
        Task<IDataResult<IList<Category>>> GetAll();                 // Istersek de IList türünde Kategori lisetsi getirebiliyoruz.
        Task<IDataResult<IList<Category>>> GetAllByNoneDeleted();    // Silinmemiş olan kategorileri getirecek.
        Task<IResult> Add(CategoryAddDto categoryAddDto, string createdByName); //Data Transfer Object (ViewModel gibi)
        Task<IResult> Update(CategoryUpdateDto categoryUpdateDto, string modifiedByName);
        Task<IResult> Delete(int categoryId, string modifiedByName);                        //Durumunu False yapacak
        Task<IResult> HardDelete(int categoryId);                    //Tamamen veritabanından silecek. Tehlikeli
    }
}
