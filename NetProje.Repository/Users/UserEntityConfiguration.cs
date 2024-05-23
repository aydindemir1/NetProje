using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using NetProje.Repository.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetProje.Repository.Users
{
    public class UserEntityConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users").HasKey(b => b.Id);

            builder.Property(b => b.Id).HasColumnName("Id").IsRequired();
            builder.Property(b => b.Name).HasColumnName("Name").IsRequired().HasMaxLength(100);
            builder.Property(b => b.UserName).HasColumnName("UserName").IsRequired();
            builder.Property(b => b.Password).HasColumnName("Password").IsRequired();
            builder.Property(b => b.Surname).HasColumnName("Surname").IsRequired();
            builder.Property(b => b.Email).HasColumnName("Email").IsRequired();
            builder.Property(b => b.Birthdate).HasColumnName("Birthdate").IsRequired();
            builder.Property(b => b.Address).HasColumnName("Address").IsRequired();
            builder.Property(b => b.PhoneNumber).HasColumnName("PhoneNumber").IsRequired();
            builder.Property(b => b.IsAdmin).HasColumnName("IsAdmin").IsRequired();
            builder.Property(b => b.CreatedDate).HasColumnName("CreatedDate").IsRequired();
            builder.Property(b => b.UpdatedDate).HasColumnName("UpdatedDate");
            builder.Property(b => b.DeletedDate).HasColumnName("DeletedDate");

            builder.HasIndex(indexExpression: b => b.Name, name: "UK_Users_Name").IsUnique();


            builder.HasQueryFilter(b => !b.DeletedDate.HasValue);
        }
    }
}
