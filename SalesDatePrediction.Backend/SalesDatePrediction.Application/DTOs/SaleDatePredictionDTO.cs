namespace SalesDatePrediction.Application.DTOs
{
    public class SaleDatePredictionDTO
    {
        public string CustomerName { get; set; } = null!;
        public DateTime LastOrderDate { get; set; }
        public DateTime NextPredictedOrder { get; set; }
    }
}
