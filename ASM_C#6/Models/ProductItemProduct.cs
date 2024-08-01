using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASM_C_6.Models
{
    public class ProductItemProduct
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ForeignKey("Product")]
        public int Product_Id { get; set; }

        [ForeignKey("ProductItem")]
        public int ProductItem_Id { get; set; }

        public Product? Product { get; set; }

        public ProductItem? ProductItem { get; set; }
    }
}
