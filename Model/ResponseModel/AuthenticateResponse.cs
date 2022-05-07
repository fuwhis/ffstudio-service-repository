using EntityModel.Models;
using System;

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.ResponseModel
{
    public class AuthenticateResponse
    {
        public string Id { get; set; }
        public string? Name { get; set; }

        //[Column(TypeName = "json")]
        public string? Info { get; set; }
        public string Token { get; set; }

        public AuthenticateResponse(Account account, string token)
        {
            Id = account.UserId;
            Name = account.Name; 
            Info = account.Info;
            Token = token;
        }
    }
}
