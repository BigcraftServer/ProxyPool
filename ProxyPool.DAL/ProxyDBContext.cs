using System;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using ProxyPool.DAL.Entity;

namespace ProxyPool.DAL {
  public partial class ProxyDBContext : DbContext {
    public ProxyDBContext(DbContextOptions options) : base(options) {
    }

    public virtual DbSet<Proxy> Proxies { get; set; }
    public virtual DbSet<ProxyCountry> ProxyCountries { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder) {
      modelBuilder.HasPostgresExtension("uuid-ossp");

      modelBuilder.Entity<Proxy>(entity => {
        entity.HasOne(d => d.CountryCodeNavigation)
            .WithMany(p => p.Proxies)
            .HasForeignKey(d => d.CountryCode);
      });
      
    }
  }
}
