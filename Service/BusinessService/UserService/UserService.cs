using AutoMapper;
using EntityModel.Context;
using EntityModel.Models;
using FFStudioServices.Authorization;
using FFStudioServices.Helpers;
using Microsoft.Extensions.Options;

using Model.RequestModel;
using Model.ResponseModel;
using Model.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.BusinessService.UserService
{
    public interface IUserService
    {
        AuthenticateResponse Authenticate(AuthenticateRequest model);
        IEnumerable<Account> GetAll();
        Account GetById(string id);
        //void Register(RegisterRequest model);
        //void Update(string id, UpdateRequest model);
        //void Delete(string id);
    }
    public class UserService : IUserService
    {
        // users hardcoded for simplicity, store in a db with hashed passwords in production applications
        //private List<User> _users;
        private PostgreContext _context;
        private IJwtUtils _jwtUtils;
        private readonly IMapper _mapper;

        public UserService(
            PostgreContext context,
            IJwtUtils jwtUtils,
            IMapper mapper
            )
        {
            //_appSettings = appSettings.Value;
            _context = context;
            _jwtUtils = jwtUtils;
            _mapper = mapper;
        }

        public AuthenticateResponse Authenticate(AuthenticateRequest model)
        {
            //var user = _context.User.SingleOrDefault(x => x.UserName == model.Username && x.Pwd == model.Password);
            var user = _context.Accounts.SingleOrDefault(x => x.Username == model.Username);
            // validate
            if(user == null)
                throw new AppException("Username or password is incorrect");

            // return null if user not found
            //if(user == null) return null;

            // authentication successful so generate jwt token
            var response = _mapper.Map<AuthenticateResponse>(user);
            response.Token = _jwtUtils.GenerateToken(user);
            return response;

            //return new AuthenticateResponse(user, token);
        }

        public IEnumerable<Account> GetAll()
        {
            return _context.Accounts;
        }

        public Account GetById(string id)
        {
            return _context.Accounts.FirstOrDefault(x => x.UserId == id);
        }

        //public void Register(RegisterRequest model)
        //{
        //    // validate
        //    if(_context.User.Any(x => x.UserName == model.UserName))
        //        throw new AppException("Username '" + model.UserName + "' is already taken");

        //    // map model to new user object
        //    var user = _mapper.Map<User>(model);

        //    // hash password
        //    user.Passhash = BCrypt.Net.BCrypt.HashPassword(model.Pwd);

        //    // save user
        //    _context.User.Add(user);
        //    _context.SaveChanges();
        //}

        //public void Update(string id, UpdateRequest model)
        //{
        //    var user = getUser(id);

        //    // validate
        //    if(model.UserName != user.UserName && _context.User.Any(x => x.UserName == model.UserName))
        //        throw new AppException("Username '" + model.UserName + "' is already taken");

        //    // hash password if it was entered
        //    if(!string.IsNullOrEmpty(model.Pwd))
        //        user.Passhash = BCrypt.Net.BCrypt.HashPassword(model.Pwd);

        //    // copy model to user and save
        //    _mapper.Map(model, user);
        //    _context.User.Update(user);
        //    _context.SaveChanges();
        //}

        //public void Delete(string id)
        //{
        //    var user = getUser(id);
        //    _context.User.Remove(user);
        //    _context.SaveChanges();
        //}
        // helper methods
        private Account getUser(string id)
        {
            var user = _context.Accounts.Find(id);
            if(user == null) throw new KeyNotFoundException("User not found");
            return user;
        }
    }
}
