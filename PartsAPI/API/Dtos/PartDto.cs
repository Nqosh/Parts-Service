using System.ComponentModel.DataAnnotations;

namespace PartsAPI.API.Dtos
{
    public class PartDto
    {
        public string PartNumber { get; set; }
        public string Description { get; set; }
        public int QuantityOnHand { get; set; }
        public string LocationCode { get; set; }
        public DateTime LastStockTake { get; set; }
    }
}
