using NetProje.Repository.Transmissions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetProje.Repository.Transmissions
{
    public interface ITransmissionRepository : IGenericRepository<Transmission>
    {
        Task UpdateTransmissionName(string name, int id);
    }
}
