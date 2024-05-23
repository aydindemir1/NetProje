using NetProje.Repository.Cars;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetProje.Repository.Cars
{
    public class CarRepository : GenericRepository<Car>, ICarRepository
    {
        public CarRepository(AppDbContext context) : base(context)
        {
        }

        public async Task UpdateCarPlate(string plate, int id)
        {
            var car = await GetById(id);
            car!.Plate = plate;
            await Update(car);
        }
    }
    }
