using AutoMapper;
using InnoEvents.Models;

namespace InnoEvents.Infrastructure
{
    public class InnoProfile : Profile
    {
        public InnoProfile()
        {
            CreateMap<DTOs.CreateEvent, Event>();
            CreateMap<Event, DTOs.Event>().ReverseMap();
            CreateMap<UserEvent, DTOs.UserEvent>().ReverseMap();
        }
    }
}
