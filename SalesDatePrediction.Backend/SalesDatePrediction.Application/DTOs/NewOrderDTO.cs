using System.ComponentModel.DataAnnotations;

namespace SalesDatePrediction.Application.DTOs
{
    public class NewOrderDTO
    {
        [Required]
        public int Empid { get; set; }
        [Required]
        public DateTime Orderdate { get; set; }
        [Required]
        public DateTime Requireddate { get; set; }
        [Required]
        public DateTime? Shippeddate { get; set; }
        [Required]
        public int Shipperid { get; set; }
        [Required]
        public decimal Freight { get; set; }
        [Required]
        [MaxLength(40)]
        public string Shipname { get; set; } = null!;
        [Required]
        [MaxLength(60)]
        public string Shipaddress { get; set; } = null!;
        [Required]
        [MaxLength(15)]
        public string Shipcity { get; set; } = null!;
        public string? Shipregion { get; set; }
        public string? Shippostalcode { get; set; }
        [Required]
        [MaxLength(15)]
        public string Shipcountry { get; set; } = null!;
        [Required]
        public int Productid { get; set; }
        [Required]
        public decimal Unitprice { get; set; }
        [Required]
        public short Qty { get; set; }
        [Required]
        [Range(0.000, 1.000, ErrorMessage = "Discount must be between 0.000 and 1.000")]
        public decimal Discount { get; set; }
    }
}
