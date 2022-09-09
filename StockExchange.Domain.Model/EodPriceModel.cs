namespace StockExchange.Domain.Model
{
    using System;
    using System.Text.Json.Serialization;

    public class EodPriceModel
    {
        public int ID { get; set; }
        public DateTime Date { get; set; }
        public decimal ClosePrice { get; set; }
        public int StockSymbolId { get; set; }
        [JsonIgnore]

        public StockSymbolModel? stockSymbolModel { get; set; } // n-1

    }
}
