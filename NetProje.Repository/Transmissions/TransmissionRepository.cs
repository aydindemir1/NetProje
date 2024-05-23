using NetProje.Repository.Transmissions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetProje.Repository.Transmissions
{
    public class TransmissionRepository : GenericRepository<Transmission>, ITransmissionRepository
    {
        public TransmissionRepository(AppDbContext context) : base(context)
        {
        }


        public async Task UpdateTransmissionName(string name, int id)
        {
            var Transmission = await GetById(id);
            Transmission!.Name = name;
            await Update(Transmission);
        }
    }
}
