﻿namespace SalesDatePrediction.Domain.StoreProceduresEntities
{
    public class NewOrder
    {
        public int Empid { get; set; }

        public DateTime Orderdate { get; set; }

        public DateTime Requireddate { get; set; }

        public DateTime? Shippeddate { get; set; }

        public int Shipperid { get; set; }

        public decimal Freight { get; set; }

        public string Shipname { get; set; } = null!;

        public string Shipaddress { get; set; } = null!;

        public string Shipcity { get; set; } = null!;

        public string? Shipregion { get; set; }

        public string? Shippostalcode { get; set; }

        public string Shipcountry { get; set; } = null!;
        
        public int Productid { get; set; }

        public decimal Unitprice { get; set; }

        public short Qty { get; set; }

        public decimal Discount { get; set; }
    }
}
