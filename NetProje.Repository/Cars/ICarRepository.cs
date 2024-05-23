using NetProje.Repository.Cars;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetProje.Repository.Cars
{
    public interface ICarRepository : IGenericRepository<Car>
    {
        Task UpdateCarPlate(string plate, int id);
    }
}
