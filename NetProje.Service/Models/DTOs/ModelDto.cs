using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetProje.Service.Models.DTOs
{
    public class ModelDto
    {
        public ModelDto()
        {
        }

        public ModelDto(int ıd, string name, int brandId, int fuelId, int transmissionId, decimal dailyPrice, string ımageUrl)
        {
            Id = ıd;
            Name = name;
            BrandId = brandId;
            FuelId = fuelId;
            TransmissionId = transmissionId;
            DailyPrice = dailyPrice;
            ImageUrl = ımageUrl;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int BrandId { get; set; }
        public int FuelId { get; set; }
        public int TransmissionId { get; set; }
        public decimal DailyPrice { get; set; }
        public string ImageUrl { get; set; }

    }
}
