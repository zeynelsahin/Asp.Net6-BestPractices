using AutoMapper;

namespace BestPractices.Api.Extensions;

public static class ConfigureMappingProfileExtension
{
    public static IServiceCollection ConfigureMapping(this IServiceCollection service)
    {
        var mappingConfig = new MapperConfiguration(i => i.AddProfile(new AutoMapperMappingProfile()));
        IMapper mapper = mappingConfig.CreateMapper();

        service.AddSingleton(mapper);
        return service;
    }
}

public class AutoMapperMappingProfile : Profile
{
    public AutoMapperMappingProfile()
    {
        CreateMap<BestPractices.Api.Data.Models.Contact, BestPractices.Api.Models.ContactDVO>()
            .ForMember(x => x.FullName, y => y.MapFrom(z => z.FirstName + " " + z.LastName))
            .ReverseMap();
    }
}