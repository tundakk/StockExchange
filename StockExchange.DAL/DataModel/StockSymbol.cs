namespace StockExchange.DAL.DataModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text.Json.Serialization;

    /// <summary>
    /// DAL datamodel for StockSymbol.
    /// </summary>
    public class StockSymbol
    {
        /// <summary>
        /// Primary key of StockSymbol object.
        /// </summary>
        [Required]
        public int ID { get; set; }

        /// <summary>
        /// Human readable name of the company.
        /// </summary>
        [Required]
        public string CompanyName { get; set; } = string.Empty;

        /// <summary>
        /// Ticker for the stocksymbol object.
        /// </summary>
        [Required]
        public DateTime Ticker { get; set; } = DateTime.Now;

        /// <summary>
        /// If stocksymbol object is active.
        /// </summary>
        [Required]
        public bool IsActive { get; set; } = true; //true when object is initialized ?

        /// <summary>
        /// The ID of the parent Exchange.
        /// </summary>
        [Required]
        public int ExchangeId { get; set; } //foreign key

        /// <summary>
        /// The parent Exchange.
        /// </summary>
        [JsonIgnore]
        public Exchange? Exchange { get; set; }// 1-n?

        /// <summary>
        /// List of EOD prices attached to the StockSymbol object.
        /// </summary>
        public virtual ICollection<EodPrice> EodPrices { get; set; } = null!; //  = new List<EodPrice>() 1:n //should it be new list? or nullable?
    }
}
