using Dapper;
using Microsoft.Extensions.Configuration;
using MyTrade.Common.DbEntities;
using MyTrade.Common.Interfaces;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace MyTrade.Infra
{
    public class TradeRepository : RepositoryBase, ITradeRepository
    {
        public TradeRepository(IConfiguration configuration)
           : base(configuration.GetConnectionString("TradeDb"))
        {

        }
        public async Task<TradeData> AddTrade(TradeData trade)
        {
            DynamicParameters parameters = new();
            parameters.Add("@Trade", trade.ToString(), DbType.String, size: int.MaxValue);

            return await GetAssociationAsync<TradeData>("", parameters, "dbo.usp_AddTrade");
        }

        public async Task<IEnumerable<TradeData>> GetAllTrades(string status)
        {
            DynamicParameters parameters = new();
            if (!string.IsNullOrWhiteSpace(status))
            {
                parameters.Add("@status", status);
            }

            return await this.GetListAsync<TradeData>("", parameters, "dbo.usp_GetAllTrades");
        }

        public async Task<TradeData> GetTrade(int id)
        {
            DynamicParameters parameters = new();
            parameters.Add("@TradeId", id);
            return await this.GetAssociationAsync<TradeData>("", parameters, "dbo.usp_GetTrade");
        }

        public async Task<TradeData> UpdateTrade(TradeData trade)
        {
            DynamicParameters parameters = new();
            parameters.Add("@Trade", trade.ToString(), DbType.String, size: int.MaxValue);

            return await GetAssociationAsync<TradeData>("", parameters, "dbo.usp_UpdateTrade");
        }
    }
}
