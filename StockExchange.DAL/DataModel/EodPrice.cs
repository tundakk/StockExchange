namespace StockExchange.DAL.DataModel
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class EodPrice
    {
        [Required]
        public int ID { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public float ClosePrice { get; set; }
        //foreign key
        [Required]
        public int StockSymbolId { get; set; }

    }
}
