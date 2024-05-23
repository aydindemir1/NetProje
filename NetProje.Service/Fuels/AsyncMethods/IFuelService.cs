using NetProje.Service.Fuels.FuelCreateUseCase;
using NetProje.Service.Fuels.DTOs;
using NetProje.Service.SharedDTOs;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetProje.Service.Fuels.AsyncMethods
{
    public interface IFuelService
    {
        Task<ResponseModelDto<ImmutableList<FuelDto>>> GetAll();


        Task<ResponseModelDto<FuelDto?>> GetById(int id);

        Task<ResponseModelDto<ImmutableList<FuelDto>>> GetAllByPage(int page, int pageSize);


        Task<ResponseModelDto<int>> Create(FuelCreateRequestDto request);
        Task<ResponseModelDto<NoContent>> Update(int FuelId, FuelUpdateRequestDto request);

        Task<ResponseModelDto<NoContent>> UpdateFuelName(int id, string name);


        Task<ResponseModelDto<NoContent>> Delete(int id);
    }
}
