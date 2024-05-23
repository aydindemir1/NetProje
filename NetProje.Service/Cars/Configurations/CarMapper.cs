using AutoMapper;
using NetProje.Repository.Cars;
using NetProje.Repository.Cars;
using NetProje.Service.Cars.CarCreateUseCase;
using NetProje.Service.Cars.DTOs;
using NetProje.Service.Cars.CarCreateUseCase;
using NetProje.Service.Cars.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetProje.Service.Cars.Configurations
{
    public class CarMapper : Profile
    {
        public CarMapper()
        {
            CreateMap<Car, CarDto>().ReverseMap();
            CreateMap<Car, CarUpdateRequestDto>().ReverseMap();
            CreateMap<Car, CarCreateRequestDto>().ReverseMap();

        }
    }
}
