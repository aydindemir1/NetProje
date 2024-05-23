using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetProje.Service.Cars.CarCreateUseCase
{
    public record CarCreateRequestDto(int ModelId, int Kilometer, short ModelYear, string Plate, short MinFindexScore);
}
