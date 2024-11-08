using Epic.Application.DTOs;
using Epic.Domain.Entities;
using Mapster;

namespace Epic.Application.Mappings
{
    public class MappingConfig
    {
        public static void RegisterMappings()
        {
            // Mappeo producto
            TypeAdapterConfig<GameDTO, Game>.NewConfig()
                .Map(dest => dest.Name, src => src.Name)
                .Map(dest => dest.Description, src => src.Description)
                .Map(dest => dest.Genre, src => src.Genre)
                .Map(dest => dest.Price, src => src.Price);

            // Mappeo usuario
            TypeAdapterConfig<RegisterDTO, User>.NewConfig()
                .Map(dest => dest.FullName, src => src.FullName)
                .Map(dest => dest.UserName, src => src.UserName)
                .Map(dest => dest.Email, src => src.Email)
                .Map(dest => dest.Password, src => src.Password)
                .Map(dest => dest.Country, src => src.Country);

            TypeAdapterConfig<User, RegisterDTO>.NewConfig()
               .Map(dest => dest.FullName, src => src.FullName)
               .Map(dest => dest.UserName, src => src.UserName)
               .Map(dest => dest.Email, src => src.Email)
               .Map(dest => dest.Password, src => src.Password)
               .Map(dest => dest.Country, src => src.Country);
        }
    }
}
