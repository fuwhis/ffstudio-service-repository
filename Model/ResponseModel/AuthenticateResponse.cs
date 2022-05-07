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
        public string UserName { get; set; }
        public string Token { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string? Name { get; set; }
        public string? Info { get; set; }
        public string? Passhash { get; set; }

        public AuthenticateResponse(Account account, string token)
        {
            Id = account.UserId;
            UserName = account.Username;
            Token = token;
            Name = account.Name;
            Info = account.Info;
            CreatedDate = account.Created_Date;
            UpdatedDate = account.Updated_Date;
            Passhash = account.Passhash;
        }

        public AuthenticateResponse()
        {
        }
    }
}
