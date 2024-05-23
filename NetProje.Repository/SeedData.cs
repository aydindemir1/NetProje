using NetProje.Repository.Brands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetProje.Repository
{
    public class SeedData
    {
        public static void SeedDatabase(AppDbContext context)
        {
            context.Database.EnsureCreated();

            if (context.Brands.Any())
            {
                return;
            }

            var Brands = new[]
    {

            new Brand { Id = 1, Name = "Toyota" },
            new Brand { Id = 2, Name = "Ford" },
            new Brand { Id = 3, Name = "Honda" },
            new Brand { Id = 4, Name = "BMW" },
            new Brand { Id = 5, Name = "Mercedes-Benz" }
};

            context.Brands.AddRange(Brands);


            context.SaveChanges();
        }
    }
}
