using AutoMapper;
using NetProje.Repository.Transmissions;
using NetProje.Service.Transmissions.TransmissionCreateUseCase;
using NetProje.Service.Transmissions.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetProje.Service.Transmissions.Configurations
{
    public class TransmissionMapper : Profile
    {
        public TransmissionMapper()
        {
            CreateMap<Transmission, TransmissionDto>().ReverseMap();
            CreateMap<Transmission, TransmissionNameUpdateRequestDto>().ReverseMap();
            CreateMap<Transmission, TransmissionUpdateRequestDto>().ReverseMap();
            CreateMap<Transmission, TransmissionCreateRequestDto>().ReverseMap();

        }
    }
}
