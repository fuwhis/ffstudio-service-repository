using System;
using FFStudioServices.Models.BaseModels;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FFStudioServices.Models
{
    [Table("accounts")]
    public class Account: BaseEntity
    {
        [Key]
        [Required]
        public string UserId { get; set; } = string.Empty;
        [Required]
        public string Username { get; set; } = string.Empty;
        [Required]
        public string Password { get; set; } = string.Empty;

        public string? Name { get; set; }

        [Column(TypeName = "json")]
        public string? Info { get; set; }
    }
}
