using System;
using FFStudioServices.Models.BaseModels;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FFStudioServices.Models
{
    public class Account: BaseEntity
    {
        [Key]
        public string UserId { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        [Column(TypeName = "json")]
        public string info { get; set; }
    }
}
