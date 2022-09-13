namespace StockExchange.Domain.Model
{
    using System;
    using System.Text.Json.Serialization;

    /// <summary>
    /// Domain model for StockSymbol.
    /// </summary>
    public class StockSymbolModel
    {
        /// <summary>
        /// Primary key of StockSymbol object.
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// Human readable name of the company.
        /// </summary>
        public string CompanyName { get; set; } = string.Empty;

        /// <summary>
        /// Ticker for the stocksymbol object.
        /// </summary>
        public DateTime Ticker { get; set; } = DateTime.Now; // im unsure how the tcker is supposed to work and therefore the datatype also

        /// <summary>
        /// If stocksymbol object is active.
        /// </summary>
        public bool IsActive { get; set; } = true; // true when object is initialized ?


        /// <summary>
        /// The ID of the parent Exchange.
        /// </summary>
        public int ExchangeId { get; set; } // foreign key

        /// <summary>
        /// The parent Exchange.
        /// </summary>
        [JsonIgnore]
        public ExchangeModel? Exchange { get; set; } //1-1

        /// <summary>
        /// List of EOD prices attached to the StockSymbol object.
        /// </summary>
        public virtual ICollection<EodPriceModel> EodPrices { get; set; } = null!; //1:n //should it be new list? or nullable?
    }
}
