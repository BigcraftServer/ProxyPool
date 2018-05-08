using System;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using ProxyPool.DAL.Entity;

namespace ProxyPool.DAL {
  public partial class ProxyDBContext : DbContext {
    public ProxyDBContext(DbContextOptions options) : base(options) {
    }

    public virtual DbSet<Proxies> Proxies { get; set; }
    public virtual DbSet<ProxyCountries> ProxyCountries { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder) {
      modelBuilder.HasPostgresExtension("uuid-ossp");

      modelBuilder.Entity<Proxies>(entity => {
        entity.HasIndex(e => new { e.IpAddress, e.Type, e.Port })
            .HasName("Proxies_ip_address_type_port_key")
            .IsUnique();

        entity.Property(e => e.Id)
            .HasColumnName("id")
            .HasDefaultValueSql("uuid_generate_v4()");

        entity.Property(e => e.AnonymousType)
            .IsRequired()
            .HasColumnName("anonymous_type")
            .HasColumnType("character varying(20)");

        entity.Property(e => e.CountryCode)
            .IsRequired()
            .HasColumnName("country_code")
            .HasColumnType("character varying(2)");

        entity.Property(e => e.CreateTime)
            .HasColumnName("create_time")
            .HasColumnType("date");

        entity.Property(e => e.IpAddress)
            .IsRequired()
            .HasColumnName("ip_address");

        entity.Property(e => e.Port).HasColumnName("port");

        entity.Property(e => e.Type)
            .IsRequired()
            .HasColumnName("type")
            .HasColumnType("character varying(20)");

        entity.HasOne(d => d.CountryCodeNavigation)
            .WithMany(p => p.Proxies)
            .HasForeignKey(d => d.CountryCode)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("Proxies_country_code_fkey");
      });

      modelBuilder.Entity<ProxyCountries>(entity => {
        entity.HasKey(e => e.Code);

        entity.HasIndex(e => new { e.Code, e.Name })
            .HasName("ProxyCountries_code_name_key")
            .IsUnique();

        entity.Property(e => e.Code)
            .HasColumnName("code")
            .HasColumnType("character varying(2)")
            .ValueGeneratedNever();

        entity.Property(e => e.Name)
            .IsRequired()
            .HasColumnName("name")
            .HasColumnType("character varying(255)");
      });
    }
  }
}
