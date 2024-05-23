using AutoMapper;
using NetProje.Repository.Models;
using NetProje.Repository;
using NetProje.Service.Models.AsyncMethods;
using NetProje.Service.Models.ModelCreateUseCase;
using NetProje.Service.Models.DTOs;
using NetProje.Service.SharedDTOs;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using NetProje.Service.Models.ModelCreateUseCase;
using NetProje.Service.Models.DTOs;

namespace NetProje.Service.Models.AsyncMethods
{
    public interface IModelService
    {
        Task<ResponseModelDto<ImmutableList<ModelDto>>> GetAll();


        Task<ResponseModelDto<ModelDto?>> GetById(int id);

        Task<ResponseModelDto<ImmutableList<ModelDto>>> GetAllByPage(int page, int pageSize);


        Task<ResponseModelDto<int>> Create(ModelCreateRequestDto request);
        Task<ResponseModelDto<NoContent>> Update(int ModelId, ModelUpdateRequestDto request);

        Task<ResponseModelDto<NoContent>> UpdateModelName(int id, string name);


        Task<ResponseModelDto<NoContent>> Delete(int id);
    }
}
