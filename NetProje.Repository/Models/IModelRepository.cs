using NetProje.Repository.Brands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetProje.Repository.Models
{
    public interface IModelRepository : IGenericRepository<Model>
    {
        Task UpdateModelName(string name, int id);
    }
}
