using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using NetProje.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetProje.Repository.Models
{
    public class ModelEntityConfiguration : IEntityTypeConfiguration<Model>
    {
        public void Configure(EntityTypeBuilder<Model> builder)
        {
            builder.ToTable("Models").HasKey(b => b.Id);

            builder.Property(b => b.Id).HasColumnName("Id").IsRequired();
            builder.Property(m => m.BrandId).HasColumnName("BrandId");
            builder.Property(m => m.FuelId).HasColumnName("FuelId");
            builder.Property(m => m.TransmissionId).HasColumnName("TransmissionId");
            builder.Property(b => b.Name).HasColumnName("Name").IsRequired().HasMaxLength(100);
            builder.Property(m => m.DailyPrice).HasColumnName("DailyPrice");
            builder.Property(m => m.ImageUrl).HasColumnName("ImageUrl");
            builder.Property(b => b.CreatedDate).HasColumnName("CreatedDate").IsRequired();
            builder.Property(b => b.UpdatedDate).HasColumnName("UpdatedDate");
            builder.Property(b => b.DeletedDate).HasColumnName("DeletedDate");

            builder.HasIndex(indexExpression: b => b.Name, name: "UK_Models_Name").IsUnique();

            builder.HasOne(b => b.Brand);
            builder.HasOne(b => b.Fuel);
            builder.HasOne(b => b.Transmission);

            builder.HasMany(b => b.Cars);

            builder.HasQueryFilter(b => !b.DeletedDate.HasValue);
        }
    }
}
