using EntityModel.Models.BaseModels;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityModel.Models
{
    [Table("products")]
    public partial class Product : BaseEntity
    {
        [Key]
        [Required]
        public string Uid { get; set; } = string.Empty;

        [Required]
        public string Product_Name { get; set; } = string.Empty;

        public int? Quantity { get; set; }

        public float? Import_Price { get; set; }

        public float? Sale_Price { get; set; }

        public string? Unit { get; set; }

        public string? Product_Code { get; set; }

        [Column(TypeName = "json")]
        public string? Info { get; set; }
        public string Created_By { get; set; }

        public virtual Account Created_By_Navigation { get; set; }
    }
}
