using AutoMapper;
using NetProje.Repository.Fuels;
using NetProje.Service.Fuels.FuelCreateUseCase;
using NetProje.Service.Fuels.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetProje.Service.Fuels.Configurations
{
    public class FuelMapper : Profile
    {
        public FuelMapper()
        {
            CreateMap<Fuel, FuelDto>().ReverseMap();
            CreateMap<Fuel, FuelNameUpdateRequestDto>().ReverseMap();
            CreateMap<Fuel, FuelUpdateRequestDto>().ReverseMap();
            CreateMap<Fuel, FuelCreateRequestDto>().ReverseMap();

        }
    }
}
