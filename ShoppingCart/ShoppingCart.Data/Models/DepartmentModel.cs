using System.ComponentModel.DataAnnotations;

namespace ShoppingCart.Data.Models
{
    public record DepartmentModel
    {
        [Key]
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime ModifiedDate { get; set; }
    }
}