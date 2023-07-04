using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PlanSaleWithAddon.Entities;

namespace PlanSaleWithAddon.EFCore.EntitiesConfig
{
    public class PlanoConfig : IEntityTypeConfiguration<Plano>
    {
        public void Configure(EntityTypeBuilder<Plano> builder)
        {
            builder.ToTable("Plano");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.TipoPlano);
            builder.Property(x => x.Anual).HasDefaultValue(false);
            builder.Property(x => x.ValorTotal);

            builder.HasOne(x => x.Pessoa)
                .WithOne(y => y.Plano)
                .HasForeignKey<Pessoa>(y => y.PlanoId)
                .IsRequired()
                .OnDelete(DeleteBehavior.NoAction); ;

            builder.HasMany(x => x.Addons)
                .WithOne(y => y.Plano)
                .HasForeignKey(y => y.PlanoId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.NoAction);


        }
    }
}
