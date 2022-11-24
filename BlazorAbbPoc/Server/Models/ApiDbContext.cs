using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BlazorAbbPoc.Server.Models;

public class ApiDbContext : DbContext
{
    public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options)
    {
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
    }

    public DbSet<Device>? Devices { get; set; }
    public DbSet<DeviceType>? DeviceTypes { get; set; }
    public DbSet<Cabinet>? Cabinets { get; set; }
    public DbSet<CabinetGroup>? CabinetGroups { get; set; }
    public DbSet<Measurement> Measurements { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<Device>(entityBuilder =>
        {
            entityBuilder.HasKey(e => e.Id);
            entityBuilder.ToTable("devices");
            entityBuilder.HasIndex(e => e.PlcDeviceId).IsUnique();

            entityBuilder.Property(e => e.Id).HasColumnName("id");
            entityBuilder.Property(e => e.Name).HasColumnName("name");
            entityBuilder.Property(e => e.PlcDeviceId).HasColumnName("plc_device_id");
            entityBuilder.Property(e => e.DeviceTypeId).HasColumnName("devicetype_id");
            entityBuilder.Property(e => e.MaxValue).HasColumnName("max_value");
            entityBuilder.Property(e => e.CabinetId).HasColumnName("cabinet_id");
            entityBuilder.Property(e => e.CabinetPosition).HasColumnName("cabinet_position");
        });

        builder.Entity<DeviceType>(entityBuilder =>
        {
            entityBuilder.HasKey(e => e.Id);
            entityBuilder.ToTable("devicetypes");
            entityBuilder.HasIndex(e => e.Name).IsUnique();

            entityBuilder.Property(e => e.Id).HasColumnName("id");
            entityBuilder.Property(e => e.Name).HasColumnName("name");
        });

        builder.Entity<Cabinet>(entityBuilder =>
        {
            entityBuilder.HasKey(e => e.Id);
            entityBuilder.ToTable("cabinets");
            entityBuilder.HasIndex(e => e.Name).IsUnique();

            entityBuilder.Property(e => e.Id).HasColumnName("id");
            entityBuilder.Property(e => e.Name).HasColumnName("name");
            entityBuilder.Property(e => e.CabinetGroupId).HasColumnName("cabinetgroup_id");
            entityBuilder.Property(e => e.ParentCabinetId).HasColumnName("parent_cabinet_id");
        });

        builder.Entity<CabinetGroup>(entityBuilder =>
        {
            entityBuilder.HasKey(e => e.Id);
            entityBuilder.ToTable("cabinetgroups");
            entityBuilder.HasIndex(e => e.Name).IsUnique();

            entityBuilder.Property(e => e.Id).HasColumnName("id");
            entityBuilder.Property(e => e.Name).HasColumnName("name");
        });

        builder.Entity<Measurement>(entityBuilder =>
        {
            entityBuilder.HasKey(e => e.Id);
            entityBuilder.ToTable("measurements");
            entityBuilder.HasIndex(e => e.CreTimestamp);

            entityBuilder.Property(e => e.Id).HasColumnName("id");
            entityBuilder.Property(e => e.DeviceId).HasColumnName("device_id");
            entityBuilder.Property(e => e.CreTimestamp).HasColumnName("cre_timestamp").HasDefaultValueSql("now()");
            entityBuilder.Property(e => e.L1A).HasColumnName("l1_a");
            entityBuilder.Property(e => e.L2A).HasColumnName("l2_a");
            entityBuilder.Property(e => e.L3A).HasColumnName("l3_a");
            entityBuilder.Property(e => e.nA).HasColumnName("n_a");
            entityBuilder.Property(e => e.L1nV).HasColumnName("l1_n_v");
            entityBuilder.Property(e => e.L2nV).HasColumnName("l2_n_v");
            entityBuilder.Property(e => e.L3nV).HasColumnName("l3_n_v");
            entityBuilder.Property(e => e.L1l2V).HasColumnName("l1_l2_v");
            entityBuilder.Property(e => e.L2l3V).HasColumnName("l2_l3_v");
            entityBuilder.Property(e => e.L3l1V).HasColumnName("l3_l1_v");
            entityBuilder.Property(e => e.PActL1).HasColumnName("p_act_l1");
            entityBuilder.Property(e => e.PActL2).HasColumnName("p_act_l2");
            entityBuilder.Property(e => e.PActL3).HasColumnName("p_act_l3");
            entityBuilder.Property(e => e.PActTotal).HasColumnName("p_act_totoal");
            entityBuilder.Property(e => e.pReactL1).HasColumnName("p_react_l1");
            entityBuilder.Property(e => e.pReactL2).HasColumnName("p_react_l2");
            entityBuilder.Property(e => e.pReactL3).HasColumnName("p_react_l3");
            entityBuilder.Property(e => e.PReactTotal).HasColumnName("p_react_totoal");
            entityBuilder.Property(e => e.PAppL1).HasColumnName("p_app_l1");
            entityBuilder.Property(e => e.PAppL2).HasColumnName("p_app_l2");
            entityBuilder.Property(e => e.PAppL3).HasColumnName("p_app_l3");
            entityBuilder.Property(e => e.PAppTotal).HasColumnName("p_app_totoal");
            entityBuilder.Property(e => e.Frq).HasColumnName("frq");
            entityBuilder.Property(e => e.ProtA_L_I1).HasColumnName("prot_a_l_i1");
        });
    }
}
