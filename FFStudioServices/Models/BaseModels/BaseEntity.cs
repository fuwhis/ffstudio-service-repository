using System;
using System.ComponentModel.DataAnnotations;

namespace FFStudioServices.Models.BaseModels
{
    public class BaseEntity
    {
        [Required]
        public DateTime Created_Date { get; set; }
        [Required]
        public DateTime Updated_Date { get; set; }
    }
}
