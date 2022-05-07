using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Model.ViewModel
{
    public class User
    {
        [Key]
        public string Uid { get; set; }
        public string UserName { get; set; }
        [JsonIgnore]
        public string Pwd { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string? Name { get; set; }
        public string? Info { get; set; }
        public string? Passhash { get; set; }
    }
}
