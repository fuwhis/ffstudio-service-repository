using EntityModel.Context;
using EntityModel.Models;
using Model.RequestModel;
using Model.ResponseModel;
using Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.BusinessService.AccountService
{
    public class AccountService : IAccountService
    {
        private readonly IUnitOfWork<PostgreContext> _unitOfWork;
        public AuthenticateResponse Authenticate(AuthenticateRequest model)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Account> GetAll()
        {
            throw new NotImplementedException();
        }

        public Account GetById(string id)
        {
            throw new NotImplementedException();
        }
    }
}
