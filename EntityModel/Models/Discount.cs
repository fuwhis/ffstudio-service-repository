using EntityModel.Models.BaseModels;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityModel.Models
{
    [Table("discounts")]
    public partial class Discount: BaseEntity
    {
        public Discount()
        {
            Bills = new HashSet<Bill>();
        }
        [Key]
        [Required]
        public string Uid { get; set; } = string.Empty;

        [Required]
        public string Campaign_Name { get; set; } = string.Empty;

        [Required]
        [Range(0, 100)]
        public int Discount_Num { get; set; }

        [Column(TypeName = "json")]
        public string? Info { get; set; }

        public DateTime Expired_Date { get; set; }


        public virtual ICollection<Bill> Bills { get; set; }

    }
}
