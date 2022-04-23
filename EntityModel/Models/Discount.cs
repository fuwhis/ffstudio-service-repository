using EntityModel.Models.BaseModels;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityModel.Models
{
    [Table("discounts")]
    public class Discount: BaseEntity
    {
        [Key]
        [Required]
        public string Uid { get; set; } = string.Empty;

        [Required]
        public string Campaign_Name { get; set; } = string.Empty;

        [Required]
        [Range(0, 100)]
        public int Discount_Value { get; set; }

        [Column(TypeName = "json")]
        public string? Info { get; set; }
    }
}
