using AutoMapper;
using EntityModel.Models;
using Model.ResponseModel;
using Model.ViewModel;

namespace FFStudioServices.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            // User -> AuthenticateResponse
            //CreateMap<User, AuthenticateResponse>();

            // Account -> AuthenticateResponse
            CreateMap<Account, AuthenticateResponse>();

            // RegisterRequest -> User
            //CreateMap<RegisterRequest, User>();

            //// UpdateRequest -> User
            //CreateMap<UpdateRequest, User>()
            //    .ForAllMembers(x => x.Condition(
            //        (src, dest, prop) =>
            //        {
            //            // ignore null & empty string properties
            //            if(prop == null) return false;
            //            if(prop.GetType() == typeof(string) && string.IsNullOrEmpty((string)prop)) return false;

            //            return true;
            //        }
            //    ));
        }
    }
}
