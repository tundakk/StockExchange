namespace StockExchange.DAL.DataModel
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class EodPrice
    {
        [Required]
        public int ID { get; set; }
        [Required]
        public DateTime Date { get; set; } = DateTime.Now;
        [Required]
        public float ClosePrice { get; set; }
        [Required]
        public StockSymbol? stockSymbol { get; set; } // n-1
        //foreign key
        [Required]
        public int StockSymbolId { get; set; }

    }
}
