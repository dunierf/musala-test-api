using Musala.Gateways.Persistence.Contexts;
using Musala.Gateways.Application.Common.Mappings;
using AutoMapper;

namespace  Musala.Gateways.Application.UnitTests.Mocks.Persistence
{
    public static class  AutoMapperMock
    {
        public static IMapper mapper;

        static AutoMapperMock()
        {
            var mapperConfiguration = new MapperConfiguration(c => {
                c.AddProfile<AutoMapperProfile>();
            });

            mapper = mapperConfiguration.CreateMapper();
        }        
    }
}