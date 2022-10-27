﻿// <auto-generated />
using BlazorAbbPoc.Server.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace BlazorAbbPoc.Server.Migrations
{
    [DbContext(typeof(ApiDbContext))]
    [Migration("20221025211738_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.HasKey("Id");

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

                    b.ToTable("cabinetgroups", (string)null);
                });

            modelBuilder.Entity("BlazorAbbPoc.Server.Models.Device", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("CabinetGroupId")
                        .HasColumnType("integer")
                        .HasColumnName("cabinetgroup_id");

                    b.Property<int>("CabinetId")
                        .HasColumnType("integer")
                        .HasColumnName("cabinet_id");

                    b.Property<int>("CabinetPosition")
                        .HasColumnType("integer")
                        .HasColumnName("cabinet_position");

                    b.Property<string>("DeviceId")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("device_id");

                    b.Property<int>("DeviceTypeId")
                        .HasColumnType("integer")
                        .HasColumnName("devicetype_id");

                    b.Property<int>("MaxValue")
                        .HasColumnType("integer")
                        .HasColumnName("max_value");

                    b.HasKey("Id");

                    b.HasIndex("CabinetGroupId");

                    b.HasIndex("CabinetId");

                    b.HasIndex("DeviceTypeId");

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

                    b.ToTable("devicetypes", (string)null);
                });

            modelBuilder.Entity("BlazorAbbPoc.Server.Models.Device", b =>
                {
                    b.HasOne("BlazorAbbPoc.Server.Models.CabinetGroup", "CabinetGroup")
                        .WithMany()
                        .HasForeignKey("CabinetGroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BlazorAbbPoc.Server.Models.Cabinet", "Cabinet")
                        .WithMany()
                        .HasForeignKey("CabinetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BlazorAbbPoc.Server.Models.DeviceType", "DeviceType")
                        .WithMany()
                        .HasForeignKey("DeviceTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cabinet");

                    b.Navigation("CabinetGroup");

                    b.Navigation("DeviceType");
                });
#pragma warning restore 612, 618
        }
    }
}