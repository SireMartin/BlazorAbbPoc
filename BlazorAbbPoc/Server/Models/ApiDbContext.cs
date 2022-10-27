using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BlazorAbbPoc.Server.Models;

public class ApiDbContext : DbContext
{
    public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options)
    {

    }

    public DbSet<Device>? Devices { get; set; }
    public DbSet<DeviceType>? DeviceTypes { get; set; }
    public DbSet<Cabinet>? Cabinets { get; set; }
    public DbSet<CabinetGroup>? CabinetGroups { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<Device>(entityBuilder =>
        {
            entityBuilder.HasKey(e => e.Id);
            entityBuilder.ToTable("devices");
            entityBuilder.HasIndex(e => e.DeviceId).IsUnique();

            entityBuilder.Property(e => e.Id).HasColumnName("id");
            entityBuilder.Property(e => e.DeviceId).HasColumnName("device_id");
            entityBuilder.Property(e => e.DeviceTypeId).HasColumnName("devicetype_id");
            entityBuilder.Property(e => e.MaxValue).HasColumnName("max_value");
            entityBuilder.Property(e => e.CabinetGroupId).HasColumnName("cabinetgroup_id");
            entityBuilder.Property(e => e.CabinetId).HasColumnName("cabinet_id");
            entityBuilder.Property(e => e.CabinetPosition).HasColumnName("cabinet_position");
        });

        builder.Entity<DeviceType>(entityBuilder =>
        {
            entityBuilder.HasKey(e => e.Id);
            entityBuilder.ToTable("devicetypes");

            entityBuilder.Property(e => e.Id).HasColumnName("id");
            entityBuilder.Property(e => e.Name).HasColumnName("name");
        });

        builder.Entity<Cabinet>(entityBuilder =>
        {
            entityBuilder.HasKey(e => e.Id);
            entityBuilder.ToTable("cabinets");

            entityBuilder.Property(e => e.Id).HasColumnName("id");
            entityBuilder.Property(e => e.Name).HasColumnName("name");
        });

        builder.Entity<CabinetGroup>(entityBuilder =>
        {
            entityBuilder.HasKey(e => e.Id);
            entityBuilder.ToTable("cabinetgroups");

            entityBuilder.Property(e => e.Id).HasColumnName("id");
            entityBuilder.Property(e => e.Name).HasColumnName("name");
        });
    }
}
