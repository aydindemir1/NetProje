using AutoMapper;
using NetProje.Repository.Fuels;
using NetProje.Repository;
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
using NetProje.Repository.Transmissions;
using NetProje.Service.Transmissions.TransmissionCreateUseCase;
using NetProje.Service.Transmissions.DTOs;

namespace NetProje.Service.Transmissions.AsyncMethods
{
    public class TransmissionService(ITransmissionRepository TransmissionRepository, IUnitOfWork unitOfWork, IMapper mapper)
         : ITransmissionService
    {
        public async Task<ResponseModelDto<int>> Create(TransmissionCreateRequestDto request)
        {
            var newTransmission = new Transmission
            {
                Name = request.Name.Trim(),
                CreatedDate = DateTime.Now
            };

            await TransmissionRepository.Create(newTransmission);
            await unitOfWork.CommitAsync();

            return ResponseModelDto<int>.Success(newTransmission.Id, HttpStatusCode.Created);
        }

        public async Task<ResponseModelDto<NoContent>> Delete(int id)
        {
            await TransmissionRepository.Delete(id);
            await unitOfWork.CommitAsync();
            return ResponseModelDto<NoContent>.Success(HttpStatusCode.NoContent);
        }

        public async Task<ResponseModelDto<ImmutableList<TransmissionDto>>> GetAllByPage(int page, int pageSize)
        {
            var TransmissionsList = await TransmissionRepository.GetAllByPage(page, pageSize);


            var TransmissionListAsDto = mapper.Map<List<TransmissionDto>>(TransmissionsList);

            return ResponseModelDto<ImmutableList<TransmissionDto>>.Success(TransmissionListAsDto.ToImmutableList());
        }

        public async Task<ResponseModelDto<ImmutableList<TransmissionDto>>> GetAll(
            )
        {
            var TransmissionList = await TransmissionRepository.GetAll();

            var TransmissionListAsDto = mapper.Map<List<TransmissionDto>>(TransmissionList);


            return ResponseModelDto<ImmutableList<TransmissionDto>>.Success(TransmissionListAsDto.ToImmutableList());
        }

        public async Task<ResponseModelDto<TransmissionDto?>> GetById(int id)
        {
            var hasTransmission = await TransmissionRepository.GetById(id);




            var TransmissionAsDto = mapper.Map<TransmissionDto>(hasTransmission);

            return ResponseModelDto<TransmissionDto?>.Success(TransmissionAsDto);
        }

        public async Task<ResponseModelDto<NoContent>> Update(int TransmissionId, TransmissionUpdateRequestDto request)
        {
            var hasTransmission = await TransmissionRepository.GetById(TransmissionId);


            hasTransmission.Name = request.Name;



            await TransmissionRepository.Update(hasTransmission);


            await unitOfWork.CommitAsync();
            return ResponseModelDto<NoContent>.Success(HttpStatusCode.NoContent);
        }

        public async Task<ResponseModelDto<NoContent>> UpdateTransmissionName(int id, string name)
        {
            await TransmissionRepository.UpdateTransmissionName(name, id);

            await unitOfWork.CommitAsync();

            return ResponseModelDto<NoContent>.Success(HttpStatusCode.NoContent);
        }


    }
}
