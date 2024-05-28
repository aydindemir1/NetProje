using AutoMapper;
using NetProje.Repository;
using NetProje.Repository.Brands;
using NetProje.Service.Brands.BrandCreateUseCase;
using NetProje.Service.Brands.DTOs;
using NetProje.Service.CacheService.Interfaces;
using NetProje.Service.CacheService.RedisCacheService;
using NetProje.Service.SharedDTOs;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace NetProje.Service.Brands.AsyncMethods
{
    public class BrandService(
    IBrandRepository _brandRepository,
    IUnitOfWork _unitOfWork,
    IMapper _mapper,
    ICacheService _cacheService) : IBrandService
    {
        private const string BrandCacheKey = "brands";
        private const string BrandCacheKeyAsList = "brands-list";

        public async Task<ResponseModelDto<int>> Create(BrandCreateRequestDto request)
        {
            await _cacheService.RemoveAsync(BrandCacheKey);

            var newBrand = new Brand
            {
                Name = request.Name.Trim(),
                CreatedDate = DateTime.Now
            };

            await _brandRepository.Create(newBrand);
            await _unitOfWork.CommitAsync();

            return ResponseModelDto<int>.Success(newBrand.Id, HttpStatusCode.Created);
        }

        public async Task<ResponseModelDto<NoContent>> Delete(int id)
        {
            await _cacheService.RemoveAsync(BrandCacheKey);
            await _brandRepository.Delete(id);
            await _unitOfWork.CommitAsync();
            return ResponseModelDto<NoContent>.Success(HttpStatusCode.NoContent);
        }

        public async Task<ResponseModelDto<ImmutableList<BrandDto>>> GetAllByPage(int page, int pageSize)
        {
            var brandsList = await _brandRepository.GetAllByPage(page, pageSize);
            var brandsListAsDto = _mapper.Map<List<BrandDto>>(brandsList);

            return ResponseModelDto<ImmutableList<BrandDto>>.Success(brandsListAsDto.ToImmutableList());
        }

        public async Task<ResponseModelDto<ImmutableList<BrandDto>>> GetAll()
        {
            var cachedBrands = await _cacheService.GetAsync<ImmutableList<BrandDto>>(BrandCacheKey);
            if (cachedBrands != null)
            {
                return ResponseModelDto<ImmutableList<BrandDto>>.Success(cachedBrands);
            }

            var brandList = await _brandRepository.GetAll();
            var brandListAsDto = _mapper.Map<List<BrandDto>>(brandList);
            var brandListAsImmutable = brandListAsDto.ToImmutableList();

            await _cacheService.SetAsync(BrandCacheKey, brandListAsImmutable, TimeSpan.FromHours(1)); // Expiration süresi ayarlanabilir

            return ResponseModelDto<ImmutableList<BrandDto>>.Success(brandListAsImmutable);
        }

        public async Task<ResponseModelDto<BrandDto?>> GetById(int id)
        {
            var cacheKey = $"{BrandCacheKeyAsList}:{id}";
            var cachedBrand = await _cacheService.GetAsync<BrandDto>(cacheKey);
            if (cachedBrand != null)
            {
                return ResponseModelDto<BrandDto?>.Success(cachedBrand);
            }

            var brand = await _brandRepository.GetById(id);
            var brandAsDto = _mapper.Map<BrandDto>(brand);

            await _cacheService.SetAsync(cacheKey, brandAsDto, TimeSpan.FromHours(1)); // Expiration süresi ayarlanabilir

            return ResponseModelDto<BrandDto?>.Success(brandAsDto);
        }

        public async Task<ResponseModelDto<NoContent>> Update(int brandId, BrandUpdateRequestDto request)
        {
            await _cacheService.RemoveAsync(BrandCacheKey);

            var brand = await _brandRepository.GetById(brandId);
            brand.Name = request.Name;

            await _brandRepository.Update(brand);
            await _unitOfWork.CommitAsync();

            return ResponseModelDto<NoContent>.Success(HttpStatusCode.NoContent);
        }

        public async Task<ResponseModelDto<NoContent>> UpdateBrandName(int id, string name)
        {
            await _cacheService.RemoveAsync(BrandCacheKey);
            await _brandRepository.UpdateBrandName(name, id);
            await _unitOfWork.CommitAsync();

            return ResponseModelDto<NoContent>.Success(HttpStatusCode.NoContent);
        }
    }



}
