using AutoMapper;
using CQRS.Entities.DbSet;
using CQRS.Entities.Dtos.Requests;
using CQRS.Entities.Dtos.Responses;

namespace CQRS.Api.MappingProfiles
{
    public class DomainToResponse : Profile
    {
        public DomainToResponse()
        {
            CreateMap<Achievement, DriverAchievementResponse>()
                .ForMember(
                    dest => dest.Wins,
                    opt => opt.MapFrom(src => src.RaceWins));

            CreateMap<Driver, GetDriverResponse>()
                .ForMember(
                    dest => dest.DriverId,
                    opt => opt.MapFrom(src => src.Id))
                .ForMember(
                    dest => dest.FullName,
                    opt => opt.MapFrom(src => $"{src.FirstName}{src.LastName}"));
        }
    }
}
