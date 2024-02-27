﻿// <auto-generated />
using System;
using Clean.RGP.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Clean.RGP.Infrastructure.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240227090344_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Clean.RGP.Core.ContributorAggregate.Contributor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Contributors");
                });

            modelBuilder.Entity("Clean.RGP.Core.PersonAggregate.LandProperty", b =>
                {
                    b.Property<int>("LandPropertyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("LandPropertyId"));

                    b.Property<long>("CadastralMark")
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PersonId")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("LandPropertyId");

                    b.HasIndex("PersonId");

                    b.ToTable("LandProperties");
                });

            modelBuilder.Entity("Clean.RGP.Core.PersonAggregate.LandType", b =>
                {
                    b.Property<int>("LandTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("LandTypeId"));

                    b.Property<decimal>("AreaInHectares")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("PlotId")
                        .HasColumnType("int");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("LandTypeId");

                    b.HasIndex("PlotId");

                    b.ToTable("LandTypes");
                });

            modelBuilder.Entity("Clean.RGP.Core.PersonAggregate.Person", b =>
                {
                    b.Property<int>("PersonId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PersonId"));

                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PersonType")
                        .HasColumnType("int");

                    b.Property<string>("PersonalCodeOrRegistrationNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PersonId");

                    b.ToTable("People");
                });

            modelBuilder.Entity("Clean.RGP.Core.PersonAggregate.Plot", b =>
                {
                    b.Property<int>("PlotId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PlotId"));

                    b.Property<long>("CadastralMark")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("DateOfSurvey")
                        .HasColumnType("datetime2");

                    b.Property<int>("LandPropertyId")
                        .HasColumnType("int");

                    b.Property<decimal>("TotalAreaInHectares")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("PlotId");

                    b.HasIndex("LandPropertyId");

                    b.ToTable("Plots");
                });

            modelBuilder.Entity("Clean.RGP.Core.PersonAggregate.LandProperty", b =>
                {
                    b.HasOne("Clean.RGP.Core.PersonAggregate.Person", "Person")
                        .WithMany("LandProperties")
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Person");
                });

            modelBuilder.Entity("Clean.RGP.Core.PersonAggregate.LandType", b =>
                {
                    b.HasOne("Clean.RGP.Core.PersonAggregate.Plot", "Plot")
                        .WithMany("LandTypes")
                        .HasForeignKey("PlotId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Plot");
                });

            modelBuilder.Entity("Clean.RGP.Core.PersonAggregate.Plot", b =>
                {
                    b.HasOne("Clean.RGP.Core.PersonAggregate.LandProperty", "LandProperty")
                        .WithMany("Plots")
                        .HasForeignKey("LandPropertyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("LandProperty");
                });

            modelBuilder.Entity("Clean.RGP.Core.PersonAggregate.LandProperty", b =>
                {
                    b.Navigation("Plots");
                });

            modelBuilder.Entity("Clean.RGP.Core.PersonAggregate.Person", b =>
                {
                    b.Navigation("LandProperties");
                });

            modelBuilder.Entity("Clean.RGP.Core.PersonAggregate.Plot", b =>
                {
                    b.Navigation("LandTypes");
                });
#pragma warning restore 612, 618
        }
    }
}