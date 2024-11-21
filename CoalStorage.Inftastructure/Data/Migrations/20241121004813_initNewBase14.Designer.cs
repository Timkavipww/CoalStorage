﻿// <auto-generated />
using System;
using CoalStorage.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace CoalStorage.Infrastructure.Data.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20241121004813_initNewBase14")]
    partial class initNewBase14
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("CoalStorage.Core.Entities.Area", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("Created")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("text");

                    b.Property<DateTime>("LastModified")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("text");

                    b.Property<long>("MainStorageId")
                        .HasColumnType("bigint");

                    b.Property<double>("TotalLoad")
                        .HasColumnType("double precision");

                    b.HasKey("Id");

                    b.HasIndex("MainStorageId");

                    b.ToTable("Areas");
                });

            modelBuilder.Entity("CoalStorage.Core.Entities.MainStorage", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("StorageName")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("MainStorages");
                });

            modelBuilder.Entity("CoalStorage.Core.Entities.Picket", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<long>("AreaId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("Created")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("text");

                    b.Property<DateTime>("LastModified")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("text");

                    b.Property<double>("Load")
                        .HasColumnType("double precision");

                    b.Property<long>("MainStorageId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("AreaId");

                    b.ToTable("Pickets");
                });

            modelBuilder.Entity("CoalStorage.Core.Entities.Area", b =>
                {
                    b.HasOne("CoalStorage.Core.Entities.MainStorage", "MainStorage")
                        .WithMany("Areas")
                        .HasForeignKey("MainStorageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MainStorage");
                });

            modelBuilder.Entity("CoalStorage.Core.Entities.Picket", b =>
                {
                    b.HasOne("CoalStorage.Core.Entities.Area", "Area")
                        .WithMany("Pickets")
                        .HasForeignKey("AreaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Area");
                });

            modelBuilder.Entity("CoalStorage.Core.Entities.Area", b =>
                {
                    b.Navigation("Pickets");
                });

            modelBuilder.Entity("CoalStorage.Core.Entities.MainStorage", b =>
                {
                    b.Navigation("Areas");
                });
#pragma warning restore 612, 618
        }
    }
}
