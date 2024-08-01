using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASM_C_6.Models
{
    public class ProductItem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [StringLength(20, ErrorMessage = "Không được nhập quá 20 kí tự")]
        public string? Name { get; set; }

        [StringLength(200, ErrorMessage = "Không được nhập quá 200 kí tự")]
        public string? Description { get; set; }

        [StringLength(20, ErrorMessage = "Không được nhập quá 20 kí tự")]
        public string? Stock {  get; set; }

        public string? ImageUrl { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [ForeignKey("Category")]
        public int Category_Id { get; set; }

        public Category? Category { get; set; }

        public ICollection<ProductItemProduct>? ProductItemProducts { get; set; }

    }
}
