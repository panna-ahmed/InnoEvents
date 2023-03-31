using AutoMapper;
using InnoEvents.Models;

namespace InnoEvents.Infrastructure
{
    public class InnoProfile : Profile
    {
        public InnoProfile()
        {
            CreateMap<Event, DTOs.CreateEvent>().ReverseMap();

            CreateMap<Event, DTOs.Event>().ReverseMap();
            CreateMap<User, DTOs.User>().ReverseMap();
            CreateMap<UserEvent, DTOs.UserEvent>().ReverseMap();
        }
    }
}
