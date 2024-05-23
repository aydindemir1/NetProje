using NetProje.Repository.Fuels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetProje.Repository.Fuels
{
    public class FuelRepository : GenericRepository<Fuel>, IFuelRepository
    {
        public FuelRepository(AppDbContext context) : base(context)
        {
        }


        public async Task UpdateFuelName(string name, int id)
        {
            var Fuel = await GetById(id);
            Fuel!.Name = name;
            await Update(Fuel);
        }
    }
}
