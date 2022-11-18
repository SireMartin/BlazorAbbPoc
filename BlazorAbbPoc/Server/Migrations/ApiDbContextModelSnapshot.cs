﻿// <auto-generated />
using System;
using BlazorAbbPoc.Server.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace BlazorAbbPoc.Server.Migrations
{
    [DbContext(typeof(ApiDbContext))]
    partial class ApiDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("BlazorAbbPoc.Server.Models.Cabinet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("CabinetGroupId")
                        .HasColumnType("integer")
                        .HasColumnName("cabinetgroup_id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<int?>("ParentCabinetId")
                        .HasColumnType("integer")
                        .HasColumnName("parent_cabinet_id");

                    b.HasKey("Id");

                    b.HasIndex("CabinetGroupId");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.HasIndex("ParentCabinetId");

                    b.ToTable("cabinets", (string)null);
                });

            modelBuilder.Entity("BlazorAbbPoc.Server.Models.CabinetGroup", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("cabinetgroups", (string)null);
                });

            modelBuilder.Entity("BlazorAbbPoc.Server.Models.Device", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("CabinetId")
                        .HasColumnType("integer")
                        .HasColumnName("cabinet_id");

                    b.Property<int>("CabinetPosition")
                        .HasColumnType("integer")
                        .HasColumnName("cabinet_position");

                    b.Property<int>("DeviceTypeId")
                        .HasColumnType("integer")
                        .HasColumnName("devicetype_id");

                    b.Property<int>("MaxValue")
                        .HasColumnType("integer")
                        .HasColumnName("max_value");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<string>("PlcDeviceId")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("plc_device_id");

                    b.HasKey("Id");

                    b.HasIndex("CabinetId");

                    b.HasIndex("DeviceTypeId");

                    b.HasIndex("PlcDeviceId")
                        .IsUnique();

                    b.ToTable("devices", (string)null);
                });

            modelBuilder.Entity("BlazorAbbPoc.Server.Models.DeviceType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("devicetypes", (string)null);
                });

            modelBuilder.Entity("BlazorAbbPoc.Server.Models.Measurement", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreTimestamp")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("cre_timestamp")
                        .HasDefaultValueSql("now()");

                    b.Property<int>("DeviceId")
                        .HasColumnType("integer")
                        .HasColumnName("device_id");

                    b.Property<int?>("Frq")
                        .HasColumnType("integer")
                        .HasColumnName("frq");

                    b.Property<int?>("L1A")
                        .HasColumnType("integer")
                        .HasColumnName("l1_a");

                    b.Property<int?>("L1l2V")
                        .HasColumnType("integer")
                        .HasColumnName("l1_l2_v");

                    b.Property<int?>("L1nV")
                        .HasColumnType("integer")
                        .HasColumnName("l1_n_v");

                    b.Property<int?>("L2A")
                        .HasColumnType("integer")
                        .HasColumnName("l2_a");

                    b.Property<int?>("L2l3V")
                        .HasColumnType("integer")
                        .HasColumnName("l2_l3_v");

                    b.Property<int?>("L2nV")
                        .HasColumnType("integer")
                        .HasColumnName("l2_n_v");

                    b.Property<int?>("L3A")
                        .HasColumnType("integer")
                        .HasColumnName("l3_a");

                    b.Property<int?>("L3l1V")
                        .HasColumnType("integer")
                        .HasColumnName("l3_l1_v");

                    b.Property<int?>("L3nV")
                        .HasColumnType("integer")
                        .HasColumnName("l3_n_v");

                    b.Property<int?>("PActL1")
                        .HasColumnType("integer");

                    b.Property<int?>("PActL2")
                        .HasColumnType("integer");

                    b.Property<int?>("PActL3")
                        .HasColumnType("integer");

                    b.Property<int?>("PActTotal")
                        .HasColumnType("integer")
                        .HasColumnName("p_act_totoal");

                    b.Property<int?>("PAppL1")
                        .HasColumnType("integer");

                    b.Property<int?>("PAppL2")
                        .HasColumnType("integer");

                    b.Property<int?>("PAppL3")
                        .HasColumnType("integer");

                    b.Property<int?>("PAppTotal")
                        .HasColumnType("integer")
                        .HasColumnName("p_app_totoal");

                    b.Property<int?>("PReactTotal")
                        .HasColumnType("integer")
                        .HasColumnName("p_react_totoal");

                    b.Property<int?>("ProtA_L_I1")
                        .HasColumnType("integer")
                        .HasColumnName("prot_a_l_i1");

                    b.Property<int?>("nA")
                        .HasColumnType("integer");

                    b.Property<int?>("pReactL1")
                        .HasColumnType("integer");

                    b.Property<int?>("pReactL2")
                        .HasColumnType("integer");

                    b.Property<int?>("pReactL3")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("CreTimestamp");

                    b.HasIndex("DeviceId");

                    b.ToTable("measurements", (string)null);
                });

            modelBuilder.Entity("BlazorAbbPoc.Server.Models.Cabinet", b =>
                {
                    b.HasOne("BlazorAbbPoc.Server.Models.CabinetGroup", "CabinetGroup")
                        .WithMany("Cabinets")
                        .HasForeignKey("CabinetGroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BlazorAbbPoc.Server.Models.Cabinet", "ParentCabinet")
                        .WithMany()
                        .HasForeignKey("ParentCabinetId");

                    b.Navigation("CabinetGroup");

                    b.Navigation("ParentCabinet");
                });

            modelBuilder.Entity("BlazorAbbPoc.Server.Models.Device", b =>
                {
                    b.HasOne("BlazorAbbPoc.Server.Models.Cabinet", "Cabinet")
                        .WithMany("Devices")
                        .HasForeignKey("CabinetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BlazorAbbPoc.Server.Models.DeviceType", "DeviceType")
                        .WithMany("Devices")
                        .HasForeignKey("DeviceTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cabinet");

                    b.Navigation("DeviceType");
                });

            modelBuilder.Entity("BlazorAbbPoc.Server.Models.Measurement", b =>
                {
                    b.HasOne("BlazorAbbPoc.Server.Models.Device", "Device")
                        .WithMany()
                        .HasForeignKey("DeviceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Device");
                });

            modelBuilder.Entity("BlazorAbbPoc.Server.Models.Cabinet", b =>
                {
                    b.Navigation("Devices");
                });

            modelBuilder.Entity("BlazorAbbPoc.Server.Models.CabinetGroup", b =>
                {
                    b.Navigation("Cabinets");
                });

            modelBuilder.Entity("BlazorAbbPoc.Server.Models.DeviceType", b =>
                {
                    b.Navigation("Devices");
                });
#pragma warning restore 612, 618
        }
    }
}
