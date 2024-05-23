using NetProje.Service.Cars.CarCreateUseCase;
using NetProje.Service.Cars.DTOs;
using NetProje.Service.SharedDTOs;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetProje.Service.Cars.AsyncMethods
{
    public interface ICarService
    {
        Task<ResponseModelDto<ImmutableList<CarDto>>> GetAll();


        Task<ResponseModelDto<CarDto?>> GetById(int id);

        Task<ResponseModelDto<ImmutableList<CarDto>>> GetAllByPage(int page, int pageSize);


        Task<ResponseModelDto<int>> Create(CarCreateRequestDto request);
        Task<ResponseModelDto<NoContent>> Update(int CarId, CarUpdateRequestDto request);

        Task<ResponseModelDto<NoContent>> UpdateCarPlate(int id, string plate);


        Task<ResponseModelDto<NoContent>> Delete(int id);
    }
}

