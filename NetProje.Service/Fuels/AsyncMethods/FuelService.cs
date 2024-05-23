using AutoMapper;
using NetProje.Repository.Fuels;
using NetProje.Repository;
using NetProje.Service.Fuels.AsyncMethods;
using NetProje.Service.Fuels.FuelCreateUseCase;
using NetProje.Service.Fuels.DTOs;
using NetProje.Service.SharedDTOs;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace NetProje.Service.Fuels.AsyncMethods
{
    public class FuelService(IFuelRepository FuelRepository, IUnitOfWork unitOfWork, IMapper mapper)
           : IFuelService
    {
        public async Task<ResponseModelDto<int>> Create(FuelCreateRequestDto request)
        {
            var newFuel = new Fuel
            {
                Name = request.Name.Trim(),
                CreatedDate = DateTime.Now
            };

            await FuelRepository.Create(newFuel);
            await unitOfWork.CommitAsync();

            return ResponseModelDto<int>.Success(newFuel.Id, HttpStatusCode.Created);
        }

        public async Task<ResponseModelDto<NoContent>> Delete(int id)
        {
            await FuelRepository.Delete(id);
            await unitOfWork.CommitAsync();
            return ResponseModelDto<NoContent>.Success(HttpStatusCode.NoContent);
        }

        public async Task<ResponseModelDto<ImmutableList<FuelDto>>> GetAllByPage(int page, int pageSize)
        {
            var FuelsList = await FuelRepository.GetAllByPage(page, pageSize);


            var FuelListAsDto = mapper.Map<List<FuelDto>>(FuelsList);

            return ResponseModelDto<ImmutableList<FuelDto>>.Success(FuelListAsDto.ToImmutableList());
        }

        public async Task<ResponseModelDto<ImmutableList<FuelDto>>> GetAll(
            )
        {
            var FuelList = await FuelRepository.GetAll();

            var FuelListAsDto = mapper.Map<List<FuelDto>>(FuelList);


            return ResponseModelDto<ImmutableList<FuelDto>>.Success(FuelListAsDto.ToImmutableList());
        }

        public async Task<ResponseModelDto<FuelDto?>> GetById(int id)
        {
            var hasFuel = await FuelRepository.GetById(id);




            var FuelAsDto = mapper.Map<FuelDto>(hasFuel);

            return ResponseModelDto<FuelDto?>.Success(FuelAsDto);
        }

        public async Task<ResponseModelDto<NoContent>> Update(int FuelId, FuelUpdateRequestDto request)
        {
            var hasFuel = await FuelRepository.GetById(FuelId);


            hasFuel.Name = request.Name;



            await FuelRepository.Update(hasFuel);


            await unitOfWork.CommitAsync();
            return ResponseModelDto<NoContent>.Success(HttpStatusCode.NoContent);
        }

        public async Task<ResponseModelDto<NoContent>> UpdateFuelName(int id, string name)
        {
            await FuelRepository.UpdateFuelName(name, id);

            await unitOfWork.CommitAsync();

            return ResponseModelDto<NoContent>.Success(HttpStatusCode.NoContent);
        }


    }
}
