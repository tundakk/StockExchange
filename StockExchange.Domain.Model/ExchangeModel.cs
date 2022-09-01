namespace StockExchange.Domain.Model
{
    using System.Collections.Generic;

    public class ExchangeModel
    {
        public int ID { get; set; }
        public string Name { get; set; } = string.Empty;
        public bool IsActive { get; set; } = false;

        public virtual ICollection<StockSymbolModel> StockSymbols { get; set; } = null!; //1:n //should it be new list? or nullable?
    }
}
