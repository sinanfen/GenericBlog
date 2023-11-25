using AutoMapper;
using ProgrammersBlog.Entities.ComplexTypes;
using ProgrammersBlog.Entities.Concrete;
using ProgrammersBlog.Entities.Dtos;
using ProgrammersBlog.Mvc.Helpers.Abstract;

namespace ProgrammersBlog.Mvc.AutoMapper.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            //CreateMap<UserAddDto, User>().ForMember(dest=>dest.Picture,opt=>opt.MapFrom(x=>imageHelper.Upload(x.UserName,x.PictureFile,PictureType.User,null)));
            ////UserAddDto'yu User'a map ederken Upload işleminin de aynı anda gerçekleşmesini sağladık
            //CreateMap<User, UserUpdateDto>();
            //CreateMap<UserUpdateDto, User>();
            CreateMap<UserAddDto, User>();
            CreateMap<UserRegisterDto, User>();
            CreateMap<User, UserUpdateDto>();
            CreateMap<UserUpdateDto, User>();
        }
    }
}
