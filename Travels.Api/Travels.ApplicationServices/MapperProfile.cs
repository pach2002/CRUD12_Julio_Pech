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
            CreateMap<Core.Journeys.Journey, Travels.Journeys.Dto.JourneyDto>();
            CreateMap<Travels.Journeys.Dto.JourneyDto, Core.Journeys.Journey>();
        }
    }
}
