﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Parmacy.Shaar.Data;

#nullable disable

namespace Parmacy.Shaar.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230801025823_SetupDatabase")]
    partial class SetupDatabase
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Parmacy.Shaar.Models.Company", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Tel")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("companies");
                });

            modelBuilder.Entity("Parmacy.Shaar.Models.Customer", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Tel")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("customers");
                });

            modelBuilder.Entity("Parmacy.Shaar.Models.Customer_Payment", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<float>("Amount")
                        .HasColumnType("real");

                    b.Property<int>("Cu_Id")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("Invoice_No")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("Cu_Id");

                    b.ToTable("customer_Payments");
                });

            modelBuilder.Entity("Parmacy.Shaar.Models.Delegate", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("Company_ID")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Tel")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("Company_ID");

                    b.ToTable("delegates");
                });

            modelBuilder.Entity("Parmacy.Shaar.Models.Expense", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<float>("Cost")
                        .HasColumnType("real");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("expenses");
                });

            modelBuilder.Entity("Parmacy.Shaar.Models.Item", b =>
                {
                    b.Property<int>("Item_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Item_Id"));

                    b.Property<string>("Barcode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Batch_no")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Company")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Drug_Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Manufacture_Location")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Scientific_Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Item_Id");

                    b.ToTable("items");
                });

            modelBuilder.Entity("Parmacy.Shaar.Models.Item_Info", b =>
                {
                    b.Property<DateTime>("Expiration_Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("Item_Id")
                        .HasColumnType("int");

                    b.Property<string>("Location_in_Pharmacy")
                        .IsRequired()
                        .HasMaxLength(3)
                        .HasColumnType("nvarchar(3)");

                    b.Property<string>("Location_in_Storage")
                        .IsRequired()
                        .HasMaxLength(5)
                        .HasColumnType("nvarchar(5)");

                    b.Property<float>("Quantity_in_Pharmacy")
                        .HasColumnType("real");

                    b.Property<float>("Quantity_in_Storage")
                        .HasColumnType("real");

                    b.HasKey("Expiration_Date", "Item_Id");

                    b.HasIndex("Item_Id");

                    b.ToTable("items_info");
                });

            modelBuilder.Entity("Parmacy.Shaar.Models.Item_Purchase", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("Delegate_ID")
                        .HasColumnType("int");

                    b.Property<float>("Item_Bonus")
                        .HasColumnType("real");

                    b.Property<int>("Item_ID")
                        .HasColumnType("int");

                    b.Property<string>("Note")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Price")
                        .HasColumnType("real");

                    b.Property<float>("Quantity")
                        .HasColumnType("real");

                    b.Property<float>("Quantity_Per_Item")
                        .HasColumnType("real");

                    b.Property<DateTime>("Receipt_Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("Receipt_No")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("Delegate_ID");

                    b.HasIndex("Item_ID");

                    b.ToTable("items_purchase");
                });

            modelBuilder.Entity("Parmacy.Shaar.Models.Item_Sale", b =>
                {
                    b.Property<int>("Sale_Item_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Sale_Item_Id"));

                    b.Property<int>("Cu_Id")
                        .HasColumnType("int");

                    b.Property<DateTime>("Expiration_Date")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Invoice_Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("Invoice_No")
                        .HasColumnType("int");

                    b.Property<float>("Item_Discount")
                        .HasColumnType("real");

                    b.Property<float>("Item_Price")
                        .HasColumnType("real");

                    b.Property<float>("Item_Quantity")
                        .HasColumnType("real");

                    b.Property<int>("Sale_Id")
                        .HasColumnType("int");

                    b.HasKey("Sale_Item_Id");

                    b.HasIndex("Cu_Id");

                    b.HasIndex("Sale_Id");

                    b.ToTable("items_sale");
                });

            modelBuilder.Entity("Parmacy.Shaar.Models.Item_Sell", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("Item_ID")
                        .HasColumnType("int");

                    b.Property<float>("Purchase_Price")
                        .HasColumnType("real");

                    b.Property<float>("Sale_Price")
                        .HasColumnType("real");

                    b.HasKey("ID");

                    b.HasIndex("Item_ID");

                    b.ToTable("items_sell");
                });

            modelBuilder.Entity("Parmacy.Shaar.Models.Transfer_Company", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<float>("Amount")
                        .HasColumnType("real");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("Delegate_ID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("Delegate_ID");

                    b.ToTable("transfer_Companies");
                });

            modelBuilder.Entity("Parmacy.Shaar.Models.User", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("permission")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("users");
                });

            modelBuilder.Entity("Parmacy.Shaar.Models.Customer_Payment", b =>
                {
                    b.HasOne("Parmacy.Shaar.Models.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("Cu_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("Parmacy.Shaar.Models.Delegate", b =>
                {
                    b.HasOne("Parmacy.Shaar.Models.Company", "Company")
                        .WithMany()
                        .HasForeignKey("Company_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Company");
                });

            modelBuilder.Entity("Parmacy.Shaar.Models.Item_Info", b =>
                {
                    b.HasOne("Parmacy.Shaar.Models.Item", "Item")
                        .WithMany()
                        .HasForeignKey("Item_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Item");
                });

            modelBuilder.Entity("Parmacy.Shaar.Models.Item_Purchase", b =>
                {
                    b.HasOne("Parmacy.Shaar.Models.Delegate", "Delegate")
                        .WithMany()
                        .HasForeignKey("Delegate_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Parmacy.Shaar.Models.Item", "Item")
                        .WithMany()
                        .HasForeignKey("Item_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Delegate");

                    b.Navigation("Item");
                });

            modelBuilder.Entity("Parmacy.Shaar.Models.Item_Sale", b =>
                {
                    b.HasOne("Parmacy.Shaar.Models.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("Cu_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Parmacy.Shaar.Models.Item_Sell", "Sale")
                        .WithMany()
                        .HasForeignKey("Sale_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("Sale");
                });

            modelBuilder.Entity("Parmacy.Shaar.Models.Item_Sell", b =>
                {
                    b.HasOne("Parmacy.Shaar.Models.Item", "Item")
                        .WithMany()
                        .HasForeignKey("Item_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Item");
                });

            modelBuilder.Entity("Parmacy.Shaar.Models.Transfer_Company", b =>
                {
                    b.HasOne("Parmacy.Shaar.Models.Delegate", "Delegate")
                        .WithMany()
                        .HasForeignKey("Delegate_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Delegate");
                });
#pragma warning restore 612, 618
        }
    }
}
