using Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace DAL.Concrete.Context.Configurations
{
    public abstract class BaseConfiguration<T> : IEntityTypeConfiguration<T> where T : BaseEntity
    {
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            builder.Property(x => x.ID)
                    .UseIdentityColumn();

            builder.HasKey(x => x.ID);

            builder.Property(x => x.CreateOn)
                    .HasColumnType("datetime")
                    .IsRequired();

            builder.Property(x => x.UpdateOn)
                    .HasColumnType("datetime")
                    .IsRequired(false);

            builder.Property(x => x.IsActive)
                    .HasColumnType("bit");
        }
    }
}
