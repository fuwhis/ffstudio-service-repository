using EntityModel.Models;
using Model.RequestModel;
using Model.ResponseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.BusinessService
{
    public interface IAccountService
    {
        //Task<> LoginAuthorizeUser(string username, string password);
        AuthenticateResponse Authenticate(AuthenticateRequest model);
        IEnumerable<Account> GetAll();
        Account GetById(string id);
    }
}
