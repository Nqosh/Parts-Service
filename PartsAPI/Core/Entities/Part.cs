using System.ComponentModel.DataAnnotations;

namespace PartsAPI.Core.Entities
{
    public class Part
    {
        [Key]
        [Required]
        public string PartNumber { get; set; }

        [Required]
        [StringLength(100)]
        public string Description { get; set; }

        [Required]
        [Range(0, int.MaxValue,  ErrorMessage = "Quantity must be >= 0")]
        public int QuantityOnHand { get; set; }

        [Required]
        [StringLength(10)]
        public string LocationCode { get; set; }

        public DateTime LastStockTake { get; set; } 
    }
}
