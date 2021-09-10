using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using MyTrade.Helper.Mapper;

namespace MyTrade.Helper.Extensions
{
    public static class Automapper
    {
        public static IServiceCollection AddAutomapperConfiguration(this IServiceCollection services)
        {
            MapperConfiguration mappingConfig = new(mc => { mc.AddProfile(new AutoMapperProfile()); });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);

            return services;
        }
    }
}
