﻿// <auto-generated />
using GameZone_KEMOO.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GameZone_KEMOO.Migrations
{
    [DbContext(typeof(ApplicationDBContext))]
    partial class ApplicationDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("GameZone_KEMOO.Models.Category", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("name")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.HasKey("id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            id = 1,
                            name = "Action"
                        },
                        new
                        {
                            id = 2,
                            name = "Sports"
                        },
                        new
                        {
                            id = 3,
                            name = "Adventure"
                        },
                        new
                        {
                            id = 4,
                            name = "Racing"
                        },
                        new
                        {
                            id = 5,
                            name = "Fightening"
                        },
                        new
                        {
                            id = 6,
                            name = "Film"
                        });
                });

            modelBuilder.Entity("GameZone_KEMOO.Models.Device", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("IconName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.HasKey("id");

                    b.ToTable("Devices");

                    b.HasData(
                        new
                        {
                            id = 1,
                            IconName = "bi bi-playstation",
                            name = "Playstation"
                        },
                        new
                        {
                            id = 2,
                            IconName = "bi bi-xbox",
                            name = "Xbox"
                        },
                        new
                        {
                            id = 3,
                            IconName = "bi bi-nintendo-switch",
                            name = "Nintdo Switch"
                        },
                        new
                        {
                            id = 4,
                            IconName = "bi bi-pc",
                            name = "PC"
                        });
                });

            modelBuilder.Entity("GameZone_KEMOO.Models.Game", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Cover")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(2500)
                        .HasColumnType("nvarchar(2500)");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.HasKey("id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Games");
                });

            modelBuilder.Entity("GameZone_KEMOO.Models.GameDevice", b =>
                {
                    b.Property<int>("GameId")
                        .HasColumnType("int");

                    b.Property<int>("DeviceId")
                        .HasColumnType("int");

                    b.HasKey("GameId", "DeviceId");

                    b.HasIndex("DeviceId");

                    b.ToTable("GameDevices");
                });

            modelBuilder.Entity("GameZone_KEMOO.Models.Game", b =>
                {
                    b.HasOne("GameZone_KEMOO.Models.Category", "Category")
                        .WithMany("Games")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("GameZone_KEMOO.Models.GameDevice", b =>
                {
                    b.HasOne("GameZone_KEMOO.Models.Device", "Device")
                        .WithMany("GameDevices")
                        .HasForeignKey("DeviceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GameZone_KEMOO.Models.Game", "Game")
                        .WithMany("GameDevices")
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Device");

                    b.Navigation("Game");
                });

            modelBuilder.Entity("GameZone_KEMOO.Models.Category", b =>
                {
                    b.Navigation("Games");
                });

            modelBuilder.Entity("GameZone_KEMOO.Models.Device", b =>
                {
                    b.Navigation("GameDevices");
                });

            modelBuilder.Entity("GameZone_KEMOO.Models.Game", b =>
                {
                    b.Navigation("GameDevices");
                });
#pragma warning restore 612, 618
        }
    }
}
