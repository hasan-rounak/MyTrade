using AutoMapper;
using MyTrade.Common.DbEntities;
using MyTrade.Domain;

namespace MyTrade.Helper.Mapper
{
    public  class AutoMapperProfile: Profile
    {
        public AutoMapperProfile()
        {
            this.CreateMap<Trade, TradeData>()
                .ForMember(d => d.StatusId, opt => opt.MapFrom(s=>s.Status.Key ));
            this.CreateMap<TradeData, Trade>()
              .ForMember(d => d.Status, opt => opt.MapFrom(s => new KeyValue(s.StatusId, s.Status)));
            this.CreateMap<Comment, CommentData>();
            this.CreateMap<CommentData, Comment>();
        }
    }
}
