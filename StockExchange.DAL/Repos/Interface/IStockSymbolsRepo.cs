﻿namespace StockExchange.DAL.Repos.Interface
{
    using StockExchange.DAL.DataModel;
    using StockExchange.DAL.Repos.Base;

    public interface IStockSymbolsRepo : IBaseRepo<StockSymbol>
    {
        //GET
        StockSymbol GetById(int id);
        StockSymbol GetByName(string name);
        IEnumerable<StockSymbol> GetListOfStockByExchangeId(int exchangeId);

        //PUT
        //POST
        //DELETE
    }
}
