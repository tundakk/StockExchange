namespace StockExchange.DAL.DataModel
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Exchange
    {
        [Required]
        public int ID { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
        public bool IsActive { get; set; } = false;

        public ICollection<StockSymbol> StockSymbols { get; set; } = null!; //1:n //should it be new list? or nullable?

    }
}
