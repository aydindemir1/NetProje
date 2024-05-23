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
    public class BrandService(IBrandRepository BrandRepository, IUnitOfWork unitOfWork, IMapper mapper,RedisCacheService redisCacheService)
         : IBrandService
    {
        private const string BrandCacheKey = "brands";
        private const string BrandCacheKeyAsList = "brands-list";
        public async Task<ResponseModelDto<int>> Create(BrandCreateRequestDto request)
        {
            redisCacheService.Database.KeyDelete(BrandCacheKey);
            var newBrand = new Brand
            {
                Name = request.Name.Trim(),
                CreatedDate = DateTime.Now
            };

            await BrandRepository.Create(newBrand);
            await unitOfWork.CommitAsync();

            return ResponseModelDto<int>.Success(newBrand.Id, HttpStatusCode.Created);
        }

        public async Task<ResponseModelDto<NoContent>> Delete(int id)
        {
            redisCacheService.Database.KeyDelete(BrandCacheKey);
            await BrandRepository.Delete(id);
            await unitOfWork.CommitAsync();
            return ResponseModelDto<NoContent>.Success(HttpStatusCode.NoContent);
        }

        public async Task<ResponseModelDto<ImmutableList<BrandDto>>> GetAllByPage(int page, int pageSize)
        {
            var BrandsList = await BrandRepository.GetAllByPage(page, pageSize);


            var BrandListAsDto = mapper.Map<List<BrandDto>>(BrandsList);

            return ResponseModelDto<ImmutableList<BrandDto>>.Success(BrandListAsDto.ToImmutableList());
        }

        public async Task<ResponseModelDto<ImmutableList<BrandDto>>> GetAll(
            )
        {
            if (redisCacheService.Database.KeyExists(BrandCacheKey))
            {
                var brandListAsJsonFromCache =  redisCacheService.Database.StringGet(BrandCacheKey);

                var brandListFromCache =
                    JsonSerializer.Deserialize<ImmutableList<BrandDto>>(brandListAsJsonFromCache!);


                return ResponseModelDto<ImmutableList<BrandDto>>.Success(brandListFromCache);
            }
            var brandList = await BrandRepository.GetAll();

            var brandListAsJson = JsonSerializer.Serialize(brandList);
            redisCacheService.Database.StringSet(BrandCacheKey, brandListAsJson);

            //brandList.ForEach(brand =>
            //{
            //    redisCacheService.Database.ListLeftPush($"{BrandCacheKeyAsList}:{brand.Id}",
            //        JsonSerializer.Serialize(brand));
            //});

            foreach (var brand in brandList)
            {
                await redisCacheService.Database.ListLeftPushAsync($"{BrandCacheKeyAsList}:{brand.Id}",
                    JsonSerializer.Serialize(brand));
            }

            var BrandListAsDto = mapper.Map<List<BrandDto>>(brandList);


            return ResponseModelDto<ImmutableList<BrandDto>>.Success(BrandListAsDto.ToImmutableList());
        }

        public async Task<ResponseModelDto<BrandDto?>> GetById(int id)
        {


            var customKey = $"{BrandCacheKeyAsList}:{id}";

            if (redisCacheService.Database.KeyExists(customKey))
            {
                var brandAsJsonFromCache = redisCacheService.Database.ListGetByIndex(customKey, 0);

                var brandFromCache = JsonSerializer.Deserialize<BrandDto>(brandAsJsonFromCache!);

                return ResponseModelDto<BrandDto?>.Success(brandFromCache);
            }
            var hasBrand = await BrandRepository.GetById(id);

            redisCacheService.Database.ListLeftPush($"{BrandCacheKeyAsList}:{hasBrand.Id}",
                  JsonSerializer.Serialize(hasBrand));


            var BrandAsDto = mapper.Map<BrandDto>(hasBrand);

            return ResponseModelDto<BrandDto?>.Success(BrandAsDto);
        }

        public async Task<ResponseModelDto<NoContent>> Update(int BrandId, BrandUpdateRequestDto request)
        {
            redisCacheService.Database.KeyDelete(BrandCacheKey);

            var hasBrand = await BrandRepository.GetById(BrandId);


            hasBrand.Name = request.Name;



            await BrandRepository.Update(hasBrand);


            await unitOfWork.CommitAsync();
            return ResponseModelDto<NoContent>.Success(HttpStatusCode.NoContent);
        }

        public async Task<ResponseModelDto<NoContent>> UpdateBrandName(int id, string name)
        {
            redisCacheService.Database.KeyDelete(BrandCacheKey);
            await BrandRepository.UpdateBrandName(name, id);

            await unitOfWork.CommitAsync();

            return ResponseModelDto<NoContent>.Success(HttpStatusCode.NoContent);
        }

     
    }
}
