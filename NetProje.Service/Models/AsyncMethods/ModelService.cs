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

namespace NetProje.Service.Models.AsyncMethods
{
    public class ModelService(IModelRepository ModelRepository, IUnitOfWork unitOfWork, IMapper mapper)
         : IModelService
    {
        public async Task<ResponseModelDto<int>> Create(ModelCreateRequestDto request)
        {
            var newModel = new Model
            {
                Name = request.Name.Trim(),
                BrandId = request.BrandId,
                FuelId = request.FuelId,
                TransmissionId = request.TransmissionId,
                DailyPrice = request.DailyPrice,
                ImageUrl = request.ImageUrl,
                CreatedDate = DateTime.Now
            };

            await ModelRepository.Create(newModel);
            await unitOfWork.CommitAsync();

            return ResponseModelDto<int>.Success(newModel.Id, HttpStatusCode.Created);
        }

        public async Task<ResponseModelDto<NoContent>> Delete(int id)
        {
            await ModelRepository.Delete(id);
            await unitOfWork.CommitAsync();
            return ResponseModelDto<NoContent>.Success(HttpStatusCode.NoContent);
        }

        public async Task<ResponseModelDto<ImmutableList<ModelDto>>> GetAllByPage(int page, int pageSize)
        {
            var ModelsList = await ModelRepository.GetAllByPage(page, pageSize);


            var ModelListAsDto = mapper.Map<List<ModelDto>>(ModelsList);

            return ResponseModelDto<ImmutableList<ModelDto>>.Success(ModelListAsDto.ToImmutableList());
        }

        public async Task<ResponseModelDto<ImmutableList<ModelDto>>> GetAll(
            )
        {
            var ModelList = await ModelRepository.GetAll();

            var ModelListAsDto = mapper.Map<List<ModelDto>>(ModelList);


            return ResponseModelDto<ImmutableList<ModelDto>>.Success(ModelListAsDto.ToImmutableList());
        }

        public async Task<ResponseModelDto<ModelDto?>> GetById(int id)
        {
            var hasModel = await ModelRepository.GetById(id);




            var ModelAsDto = mapper.Map<ModelDto>(hasModel);

            return ResponseModelDto<ModelDto?>.Success(ModelAsDto);
        }

        public async Task<ResponseModelDto<NoContent>> Update(int ModelId, ModelUpdateRequestDto request)
        {
            var hasModel = await ModelRepository.GetById(ModelId);


            hasModel.Name = request.Name;



            await ModelRepository.Update(hasModel);


            await unitOfWork.CommitAsync();
            return ResponseModelDto<NoContent>.Success(HttpStatusCode.NoContent);
        }

        public async Task<ResponseModelDto<NoContent>> UpdateModelName(int id, string name)
        {
            await ModelRepository.UpdateModelName(name, id);

            await unitOfWork.CommitAsync();

            return ResponseModelDto<NoContent>.Success(HttpStatusCode.NoContent);
        }


    }
}
