using AutoMapper;
using NetProje.Repository.Cars;
using NetProje.Repository;
using NetProje.Service.Cars.AsyncMethods;
using NetProje.Service.Cars.CarCreateUseCase;
using NetProje.Service.Cars.DTOs;
using NetProje.Service.SharedDTOs;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace NetProje.Service.Cars.AsyncMethods
{
    public class CarService(ICarRepository CarRepository, IUnitOfWork unitOfWork, IMapper mapper)
         : ICarService
    {
        public async Task<ResponseModelDto<int>> Create(CarCreateRequestDto request)
        {
            var newCar = new Car
            {
                ModelId = request.ModelId,
                Kilometer = request.Kilometer,
                ModelYear = request.ModelYear,
                Plate = request.Plate,
                MinFindexScore = request.MinFindexScore,
                CreatedDate = DateTime.Now
            };

            await CarRepository.Create(newCar);
            await unitOfWork.CommitAsync();

            return ResponseModelDto<int>.Success(newCar.Id, HttpStatusCode.Created);
        }

        public async Task<ResponseModelDto<NoContent>> Delete(int id)
        {
            await CarRepository.Delete(id);
            await unitOfWork.CommitAsync();
            return ResponseModelDto<NoContent>.Success(HttpStatusCode.NoContent);
        }

        public async Task<ResponseModelDto<ImmutableList<CarDto>>> GetAllByPage(int page, int pageSize)
        {
            var CarsList = await CarRepository.GetAllByPage(page, pageSize);


            var CarListAsDto = mapper.Map<List<CarDto>>(CarsList);

            return ResponseModelDto<ImmutableList<CarDto>>.Success(CarListAsDto.ToImmutableList());
        }

        public async Task<ResponseModelDto<ImmutableList<CarDto>>> GetAll(
            )
        {
            var CarList = await CarRepository.GetAll();

            var CarListAsDto = mapper.Map<List<CarDto>>(CarList);


            return ResponseModelDto<ImmutableList<CarDto>>.Success(CarListAsDto.ToImmutableList());
        }

        public async Task<ResponseModelDto<CarDto?>> GetById(int id)
        {
            var hasCar = await CarRepository.GetById(id);




            var CarAsDto = mapper.Map<CarDto>(hasCar);

            return ResponseModelDto<CarDto?>.Success(CarAsDto);
        }

        public async Task<ResponseModelDto<NoContent>> Update(int CarId, CarUpdateRequestDto request)
        {
            var hasCar = await CarRepository.GetById(CarId);


            hasCar.Plate = request.Plate;
            hasCar.MinFindexScore = request.MinFindexScore;


            await CarRepository.Update(hasCar);


            await unitOfWork.CommitAsync();
            return ResponseModelDto<NoContent>.Success(HttpStatusCode.NoContent);
        }

        public async Task<ResponseModelDto<NoContent>> UpdateCarPlate(int id, string plate)
        {
            await CarRepository.UpdateCarPlate(plate, id);

            await unitOfWork.CommitAsync();

            return ResponseModelDto<NoContent>.Success(HttpStatusCode.NoContent);
        }


    }
}
