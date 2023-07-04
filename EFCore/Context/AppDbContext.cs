using PlanSaleWithAddon.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace PlanSaleWithAddon.Context
{
    public class AppDbContext : IdentityDbContext<IdentityUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Plano> Planos { get; set; }
        public DbSet<Pessoa> Pessoas { get; set; }
        public DbSet<Addon> Addons { get; set; }

    }
}
