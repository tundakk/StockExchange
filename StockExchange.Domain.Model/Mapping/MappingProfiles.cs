﻿namespace StockExchange.Domain.Model.Mapping
{
    using AutoMapper;
    using StockExchange.DAL.DataModel;

    /// <summary>
    /// Class containing mapping profiles.
    /// </summary>
    public class MappingProfiles : Profile
    {
        /// <summary>
        /// Automapper setup method.
        /// </summary>
        public MappingProfiles()
        {
            CreateMap<Exchange, ExchangeModel>();
            CreateMap<ExchangeModel, Exchange>();
            CreateMap<StockSymbol, StockSymbolModel>();
            CreateMap<StockSymbolModel, StockSymbol>();
            CreateMap<EodPrice, EodPriceModel>();
            CreateMap<EodPriceModel, EodPrice>();
        }
    }
}
