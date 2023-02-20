using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataContext.Models
{
    [Table("Product", Schema = "dbo")]
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Product Id")]
        public int ProductId { get; set; }

        [Required]
        [Column(TypeName = "NVarchar(100)")]
        [Display(Name = "Product Name")]
        public string ProductName { get; set; }

        [ForeignKey("CategoryInfo")]
        [Required]
        public int CategoryId { get; set; }

        [Display(Name = "Category")]
        [NotMapped]
        public string CategoryName { get; set; }

        public virtual Category? CategoryInfo { get; set; }

    }
}