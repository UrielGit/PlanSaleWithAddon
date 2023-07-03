using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PlanSaleWithAddon.Entities.EntitiesConfig
{
    public class UserConfig : IEntityTypeConfiguration<User>
    {

        public void Configure(EntityTypeBuilder<User> builder) 
        {
            builder.ToTable("User");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Name);
            builder.Property(x => x.Email);

        }

    }
}
