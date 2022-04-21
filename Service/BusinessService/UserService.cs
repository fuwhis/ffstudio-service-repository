using EntityModel.Context;
using Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.BusinessService
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork<PostgreContext> _unitOfWork;
    }
}
