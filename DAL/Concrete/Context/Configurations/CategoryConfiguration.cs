using Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Concrete.Context.Configurations
{
    public class CategoryConfiguration : BaseConfiguration<Category>
    {
        public override void Configure(EntityTypeBuilder<Category> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.CategoryName)
                    .HasMaxLength(80)
                    .IsRequired();

            builder.HasIndex(x => x.CategoryName)
                    .IsUnique();

            builder.HasMany(x => x.Foods)
                    .WithOne(x => x.Category)
                    .HasForeignKey(x => x.CategoryId)
                    .OnDelete(DeleteBehavior.NoAction);

            builder.HasData(

                    new Category { ID = 1, CategoryName = "Süt Grubu", CreateOn = DateTime.Now, IsActive = true },
                    new Category { ID = 2, CategoryName = "Et Grubu", CreateOn = DateTime.Now, IsActive = true },
                    new Category { ID = 3, CategoryName = "KuruBaklagil Grubu", CreateOn = DateTime.Now, IsActive = true },
                    new Category { ID = 4, CategoryName = "Ekmek Grubu", CreateOn = DateTime.Now, IsActive = true },
                    new Category { ID = 5, CategoryName = "Sebze Grubu", CreateOn = DateTime.Now, IsActive = true },
                    new Category { ID = 6, CategoryName = "Meyve Grubu", CreateOn = DateTime.Now, IsActive = true },
                    new Category { ID = 7, CategoryName = "Yağ Grubu", CreateOn = DateTime.Now, IsActive = true },
                    new Category { ID = 8, CategoryName = "Tatlı Grubu", CreateOn = DateTime.Now, IsActive = true },
                    new Category { ID = 9, CategoryName = "Kuruyemiş Grubu", CreateOn = DateTime.Now, IsActive = true }
                );
        }
    }
}
