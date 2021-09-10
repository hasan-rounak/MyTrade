using MyTrade.Common.DbEntities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyTrade.Common.Interfaces
{
    public interface ITradeRepository
    {
        Task<IEnumerable<TradeData>> GetAllTrades(string status);
        Task<TradeData> GetTrade(int id);
        Task<TradeData> AddTrade(TradeData trade);
        Task<TradeData> UpdateTrade(TradeData trade);
    }
}
