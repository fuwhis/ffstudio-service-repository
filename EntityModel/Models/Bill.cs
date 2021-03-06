using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityModel.Models
{
    [Table("bills")]
    public partial class Bill
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

        public virtual Customer Customer { get; set; }
        public virtual Discount Discount { get; set; }
        public virtual Account User { get; set; }
    }
}
