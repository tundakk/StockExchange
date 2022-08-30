namespace StockExchange.Domain.Model
{
    using System;

    public class EodPriceModel
    {
        public int ID { get; set; }
        public DateTime Date { get; set; }
        public float ClosePrice { get; set; }
        public int StockSymbolId { get; set; }
    }
}
