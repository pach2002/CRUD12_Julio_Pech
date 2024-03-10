using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Travels.ApplicationServices
{
    public class MapperProfile : Profile
    {

        // builder
        public MapperProfile()
        {
            // map of journeyDto
            CreateMap<Core.Journeys.Journey, Travels.Journeys.Dto.JourneyDto>();
            CreateMap<Travels.Journeys.Dto.JourneyDto, Core.Journeys.Journey>();

            // map of passengersDto
            CreateMap<Core.Journeys.Passenger, Travels.Journeys.Dto.PassengerDto>();
            CreateMap<Travels.Journeys.Dto.PassengerDto, Core.Journeys.Passenger>();

            // map of Ticket
            CreateMap<Core.Journeys.Ticket, Travels.Journeys.Dto.TicketDto>();
            CreateMap<Travels.Journeys.Dto.TicketDto, Core.Journeys.Ticket>();
        }
    }
}
