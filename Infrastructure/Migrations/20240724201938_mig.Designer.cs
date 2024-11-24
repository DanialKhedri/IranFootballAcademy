﻿// <auto-generated />
using System;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infrastructure.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20240724201938_mig")]
    partial class mig
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Domain.Entities.Drill.Ages.DrillAge", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("DrillId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DrillId");

                    b.ToTable("DrillAges");
                });

            modelBuilder.Entity("Domain.Entities.Drill.Ages.SelectedAge", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("DrillAgeId")
                        .HasColumnType("int");

                    b.Property<int>("DrillId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DrillAgeId");

                    b.HasIndex("DrillId");

                    b.ToTable("SelectedAges");
                });

            modelBuilder.Entity("Domain.Entities.Drill.Drill", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description2")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<bool>("IsFree")
                        .HasColumnType("bit");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title2")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Drills");
                });

            modelBuilder.Entity("Domain.Entities.Drill.DrillCoachingPoint.DrillCoachingPoint", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CoachingPoint")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DrillId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DrillId");

                    b.ToTable("DrillCoachingPoints");
                });

            modelBuilder.Entity("Domain.Entities.Drill.DrillInstructions.DrillInstruction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("DrillId")
                        .HasColumnType("int");

                    b.Property<string>("Instruction")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DrillId");

                    b.ToTable("DrillInstructions");
                });

            modelBuilder.Entity("Domain.Entities.Drill.DrillSetup.DrillSetup", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("DrillId")
                        .HasColumnType("int");

                    b.Property<string>("Setup")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DrillId");

                    b.ToTable("DrillSetups");
                });

            modelBuilder.Entity("Domain.Entities.Drill.DrillType.SelectedDrillType", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<int>("DrillId")
                        .HasColumnType("int");

                    b.Property<int>("DrillTypeId")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("DrillId");

                    b.HasIndex("DrillTypeId");

                    b.ToTable("SelectedDrillTypes");
                });

            modelBuilder.Entity("Domain.Entities.Drill.DrillVariotion.DrillVariotion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("DrillId")
                        .HasColumnType("int");

                    b.Property<string>("Variotion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DrillId");

                    b.ToTable("DrillVariotions");
                });

            modelBuilder.Entity("Domain.Entities.Drill.Equipment.DrillEquipment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("DrillId")
                        .HasColumnType("int");

                    b.Property<string>("Equipmnet")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DrillId");

                    b.ToTable("DrillEquipment");
                });

            modelBuilder.Entity("Domain.Entities.Drill.Types.DrillType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("DrillId")
                        .HasColumnType("int");

                    b.Property<string>("UniqueName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DrillId");

                    b.ToTable("DrillTypes");
                });

            modelBuilder.Entity("Domain.Entities.Order.Location.Location", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PostCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.ToTable("Locations");
                });

            modelBuilder.Entity("Domain.Entities.Order.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<bool>("IsFinaly")
                        .HasColumnType("bit");

                    b.Property<int>("Sum")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("Domain.Entities.Order.OrderDetail.OrderDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Count")
                        .HasColumnType("int");

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.HasIndex("ProductId");

                    b.ToTable("OrderDetails");
                });

            modelBuilder.Entity("Domain.Entities.Product.Category.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("Domain.Entities.Product.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("Domain.Entities.Product.SelectedCategory.SelectedCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("ProductId");

                    b.ToTable("SelectedCategories");
                });

            modelBuilder.Entity("Domain.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Domain.Entities.Drill.Ages.DrillAge", b =>
                {
                    b.HasOne("Domain.Entities.Drill.Drill", null)
                        .WithMany("DrillAges")
                        .HasForeignKey("DrillId");
                });

            modelBuilder.Entity("Domain.Entities.Drill.Ages.SelectedAge", b =>
                {
                    b.HasOne("Domain.Entities.Drill.Ages.DrillAge", "DrillAge")
                        .WithMany("SelectedAges")
                        .HasForeignKey("DrillAgeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Drill.Drill", "Drill")
                        .WithMany("SelectedAges")
                        .HasForeignKey("DrillId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Drill");

                    b.Navigation("DrillAge");
                });

            modelBuilder.Entity("Domain.Entities.Drill.DrillCoachingPoint.DrillCoachingPoint", b =>
                {
                    b.HasOne("Domain.Entities.Drill.Drill", null)
                        .WithMany("DrillCoachingPoints")
                        .HasForeignKey("DrillId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Entities.Drill.DrillInstructions.DrillInstruction", b =>
                {
                    b.HasOne("Domain.Entities.Drill.Drill", null)
                        .WithMany("DrillInstructions")
                        .HasForeignKey("DrillId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Entities.Drill.DrillSetup.DrillSetup", b =>
                {
                    b.HasOne("Domain.Entities.Drill.Drill", null)
                        .WithMany("DrillSetups")
                        .HasForeignKey("DrillId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Entities.Drill.DrillType.SelectedDrillType", b =>
                {
                    b.HasOne("Domain.Entities.Drill.Drill", "Drill")
                        .WithMany("SelectedDrillTypes")
                        .HasForeignKey("DrillId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Drill.Types.DrillType", "DrillType")
                        .WithMany("SelectedDrillTypes")
                        .HasForeignKey("DrillTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Drill");

                    b.Navigation("DrillType");
                });

            modelBuilder.Entity("Domain.Entities.Drill.DrillVariotion.DrillVariotion", b =>
                {
                    b.HasOne("Domain.Entities.Drill.Drill", null)
                        .WithMany("DrillVariotions")
                        .HasForeignKey("DrillId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Entities.Drill.Equipment.DrillEquipment", b =>
                {
                    b.HasOne("Domain.Entities.Drill.Drill", null)
                        .WithMany("Equipments")
                        .HasForeignKey("DrillId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Entities.Drill.Types.DrillType", b =>
                {
                    b.HasOne("Domain.Entities.Drill.Drill", null)
                        .WithMany("DrillTypes")
                        .HasForeignKey("DrillId");
                });

            modelBuilder.Entity("Domain.Entities.Order.Location.Location", b =>
                {
                    b.HasOne("Domain.Entities.Order.Order", "order")
                        .WithMany()
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("order");
                });

            modelBuilder.Entity("Domain.Entities.Order.OrderDetail.OrderDetail", b =>
                {
                    b.HasOne("Domain.Entities.Order.Order", "Order")
                        .WithMany("orderDetails")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Product.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Domain.Entities.Product.SelectedCategory.SelectedCategory", b =>
                {
                    b.HasOne("Domain.Entities.Product.Category.Category", "Category")
                        .WithMany("SelectedCategories")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Product.Product", "Product")
                        .WithMany("SelectedCategories")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Domain.Entities.Drill.Ages.DrillAge", b =>
                {
                    b.Navigation("SelectedAges");
                });

            modelBuilder.Entity("Domain.Entities.Drill.Drill", b =>
                {
                    b.Navigation("DrillAges");

                    b.Navigation("DrillCoachingPoints");

                    b.Navigation("DrillInstructions");

                    b.Navigation("DrillSetups");

                    b.Navigation("DrillTypes");

                    b.Navigation("DrillVariotions");

                    b.Navigation("Equipments");

                    b.Navigation("SelectedAges");

                    b.Navigation("SelectedDrillTypes");
                });

            modelBuilder.Entity("Domain.Entities.Drill.Types.DrillType", b =>
                {
                    b.Navigation("SelectedDrillTypes");
                });

            modelBuilder.Entity("Domain.Entities.Order.Order", b =>
                {
                    b.Navigation("orderDetails");
                });

            modelBuilder.Entity("Domain.Entities.Product.Category.Category", b =>
                {
                    b.Navigation("SelectedCategories");
                });

            modelBuilder.Entity("Domain.Entities.Product.Product", b =>
                {
                    b.Navigation("SelectedCategories");
                });
#pragma warning restore 612, 618
        }
    }
}
