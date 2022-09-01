namespace StockExchange.DAL.DataModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text.Json.Serialization;

    public class StockSymbol
    {
        [Required]
        public int ID { get; set; }
        [Required]
        public string CompanyName { get; set; } = string.Empty;
        [Required]
        public DateTime Ticker { get; set; } = DateTime.Now; //im unsure how the tcker is supposed to work and therefore the datatype also
        [Required]
        public bool IsActive { get; set; } = false; //true when object is initialized ? 

        [Required]
        public int ExchangeId { get; set; } //foreign key
        //[Required]
        [JsonIgnore]
        public Exchange? Exchange { get; set; } // 1-n?
        public virtual ICollection<EodPrice> EodPrices { get; set; } = null!; //  = new List<EodPrice>() 1:n //should it be new list? or nullable?


    }
}
