using AutoMapper;
using NetProje.Repository.Models;
using NetProje.Service.Models.ModelCreateUseCase;
using NetProje.Service.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetProje.Service.Models.Configurations
{
    public class ModelMapper : Profile
    {
        public ModelMapper()
        {
            CreateMap<Model, ModelDto>().ReverseMap();
            CreateMap<Model, ModelNameUpdateRequestDto>().ReverseMap();
            CreateMap<Model, ModelUpdateRequestDto>().ReverseMap();
            CreateMap<Model, ModelCreateRequestDto>().ReverseMap();

        }
    }
}
