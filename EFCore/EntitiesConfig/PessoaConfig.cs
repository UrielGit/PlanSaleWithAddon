using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PlanSaleWithAddon.Entities;

namespace PlanSaleWithAddon.EFCore.EntitiesConfig
{
    public class PessoaConfig : IEntityTypeConfiguration<Pessoa>
    {
        public void Configure(EntityTypeBuilder<Pessoa> builder)
        {
            builder.ToTable("Pessoa");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Email);
            builder.Property(x => x.Telefone);

        }
    }
}
