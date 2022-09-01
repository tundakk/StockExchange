namespace StockExchange.Domain.Model
{
    using System;
    using System.Text.Json.Serialization;

    public class StockSymbolModel
    {
        public int ID { get; set; }
        public string CompanyName { get; set; } = string.Empty;
        public DateTime Ticker { get; set; } = DateTime.Now; //im unsure how the tcker is supposed to work and therefore the datatype also
        public bool IsActive { get; set; } = false; //true when object is initialized ? 
        public int ExchangeId { get; set; } //foreign key

        [JsonIgnore]
        public ExchangeModel? Exchange { get; set; } //1-1
        public virtual ICollection<EodPriceModel> EodPrices { get; set; } = null!; //1:n //should it be new list? or nullable?
    }
}

