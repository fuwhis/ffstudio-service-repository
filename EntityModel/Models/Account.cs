using System;
using EntityModel.Models.BaseModels;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace EntityModel.Models
{
    [Table("accounts")]
    public partial class Account: BaseEntity
    {
        public Account()
        {
            Bills = new HashSet<Bill>();
            Products = new HashSet<Product>();
        }
        [Key]
        [Required]
        public string UserId { get; set; } = string.Empty;
        [Required]
        public string Username { get; set; } = string.Empty;
        [Required]
        //[JsonIgnore]
        public string Password { get; set; } = string.Empty;

        public string? Name { get; set; }

        [Column(TypeName = "json")]
        public string? Info { get; set; }
        public string? Passhash { get; set; }

        public virtual ICollection<Bill> Bills { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
