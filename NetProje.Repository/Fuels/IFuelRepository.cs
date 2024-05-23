using NetProje.Repository.Fuels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetProje.Repository.Fuels
{
    public interface IFuelRepository : IGenericRepository<Fuel>
    {
        Task UpdateFuelName(string name, int id);
    }
}
