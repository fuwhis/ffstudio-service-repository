using EntityModel.Models.BaseModels;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityModel.Models
{
    [Table("customers")]
    public partial class Customer: BaseEntity
    {
        public Customer()
        {
            Bills = new HashSet<Bill>();
        }
        [Key]
        [Required]
        public string Uid { get; set; } = string.Empty;

        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        public int Phone_Number { get; set; }

        [EmailAddress]
        public string? Email { get; set; }

        public string? Ref_Name { get; set; }

        public int? Ref_Phone_Number { get; set; }

        public string? License_plate { get; set; }

        [Column(TypeName = "json")]
        public string? Info { get; set; }

        public virtual ICollection<Bill> Bills { get; set; }
    }
}
