using NetProje.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetProje.Repository.Transmissions
{
    public class Transmission:BaseEntity<int>
    {
        public string Name { get; set; }

        public virtual ICollection<Model> Models { get; set; }

        public Transmission()
        {
            Models = new HashSet<Model>();
        }

        public Transmission(int id, string name)
            : this()
        {
            Id = id;
            Name = name;
        }
    }
}
