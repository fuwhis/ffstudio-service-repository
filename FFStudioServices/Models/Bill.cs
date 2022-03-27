using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FFStudioServices.Models
{
    [Table("bills")]
    public class Bill
    {
        [Key]
        [Required]
        public string Uid { get; set; } = string.Empty;

        [Required]
        [ForeignKey("Account")]
        public string User_Id { get; set; } = string.Empty;

        [Required]
        public string Customer_Id { get; set; } = string.Empty;

        public long? Amount { get; set; }

        public long? Vat { get; set; }

        public string? Discount_Id { get; set; }

        [Column(TypeName = "json")]
        public string? Info { get; set; }
    }
}
