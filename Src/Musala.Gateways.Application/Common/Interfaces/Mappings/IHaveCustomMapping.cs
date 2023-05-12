using AutoMapper;

namespace Musala.Gateways.Application.Common.Interfaces.Mappings
{
    public interface IHaveCustomMapping
    {
        void CreateMappings(Profile configuration);
    }
}
