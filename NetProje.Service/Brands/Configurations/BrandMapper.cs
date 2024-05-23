using AutoMapper;
using NetProje.Repository.Brands;
using NetProje.Service.Brands.BrandCreateUseCase;
using NetProje.Service.Brands.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetProje.Service.Brands.Configurations
{
    public class BrandMapper : Profile
    {
        public BrandMapper()
        {
            CreateMap<Brand, BrandDto>().ReverseMap();
            CreateMap<Brand, BrandNameUpdateRequestDto>().ReverseMap();
            CreateMap<Brand, BrandUpdateRequestDto>().ReverseMap();
            CreateMap<Brand, BrandCreateRequestDto>().ReverseMap();
            
        }
    }
}
