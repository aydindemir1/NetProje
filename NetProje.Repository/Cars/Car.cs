using NetProje.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace NetProje.Repository.Cars
{
    public class Car:BaseEntity<int>
    {

        public int ModelId { get; set; }
        public int Kilometer { get; set; }
        public short ModelYear { get; set; }
        public string Plate { get; set; }
        public short MinFindexScore { get; set; }


        public virtual Model? Model { get; set; }

        public Car()
        {

        }

        public Car(
            int id,
            int modelId,
            int kilometer,
            short modelYear,
            string plate,
            short minFindexScore
        )
            : this()
        {
            Id = id;
            ModelId = modelId;
            Kilometer = kilometer;
            ModelYear = modelYear;
            Plate = plate;
            MinFindexScore = minFindexScore;
        }
    }
}
