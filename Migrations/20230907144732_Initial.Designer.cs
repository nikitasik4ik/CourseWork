﻿// <auto-generated />
using System;
using CourseWork.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CourseWork.Migrations
{
    [DbContext(typeof(dbnDbContext))]
    [Migration("20230907144732_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CourseWork.Models.Client", b =>
                {
                    b.Property<int>("ClientId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ClientID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ClientId"));

                    b.Property<DateTime?>("DateBirth")
                        .HasColumnType("date");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)")
                        .UseCollation("SQL_Latin1_General_CP1_CI_AS");

                    b.Property<string>("FirstNameClient")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("FirstName_Client")
                        .UseCollation("SQL_Latin1_General_CP1_CI_AS");

                    b.Property<string>("LastNameClient")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("LastName_Client");

                    b.Property<string>("PatronomykClient")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Patronomyk_Client");

                    b.Property<string>("PhoneClient")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Phone_Client");

                    b.HasKey("ClientId");

                    b.ToTable("clients", (string)null);
                });

            modelBuilder.Entity("CourseWork.Models.Country", b =>
                {
                    b.Property<int>("CountryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("CountryID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CountryId"));

                    b.Property<string>("NameCountry")
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)")
                        .HasColumnName("Name_Country")
                        .UseCollation("SQL_Latin1_General_CP1_CI_AS");

                    b.HasKey("CountryId");

                    b.ToTable("Country", (string)null);
                });

            modelBuilder.Entity("CourseWork.Models.Post", b =>
                {
                    b.Property<int>("PostId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("PostID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PostId"));

                    b.Property<string>("NamePost")
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)")
                        .HasColumnName("Name_Post")
                        .UseCollation("SQL_Latin1_General_CP1_CI_AS");

                    b.HasKey("PostId");

                    b.ToTable("posts", (string)null);
                });

            modelBuilder.Entity("CourseWork.Models.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductId"));

                    b.Property<string>("Brand")
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)")
                        .UseCollation("SQL_Latin1_General_CP1_CI_AS");

                    b.Property<int?>("ProviderId")
                        .HasColumnType("int")
                        .HasColumnName("ProviderID");

                    b.Property<int?>("ViewId")
                        .HasColumnType("int")
                        .HasColumnName("ViewID");

                    b.HasKey("ProductId");

                    b.HasIndex("ProviderId");

                    b.HasIndex("ViewId");

                    b.ToTable("products", (string)null);
                });

            modelBuilder.Entity("CourseWork.Models.ProductT", b =>
                {
                    b.Property<int>("TypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("TypeID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TypeId"));

                    b.Property<string>("NameType")
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)")
                        .HasColumnName("Name_Type")
                        .UseCollation("SQL_Latin1_General_CP1_CI_AS");

                    b.HasKey("TypeId");

                    b.ToTable("product_t", (string)null);
                });

            modelBuilder.Entity("CourseWork.Models.ProductV", b =>
                {
                    b.Property<int>("ViewId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ViewID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ViewId"));

                    b.Property<string>("NameView")
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)")
                        .HasColumnName("Name_View")
                        .UseCollation("SQL_Latin1_General_CP1_CI_AS");

                    b.Property<int?>("TypeId")
                        .HasColumnType("int")
                        .HasColumnName("TypeID");

                    b.HasKey("ViewId");

                    b.HasIndex("TypeId");

                    b.ToTable("product_v", (string)null);
                });

            modelBuilder.Entity("CourseWork.Models.Provider", b =>
                {
                    b.Property<int>("ProviderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ProviderID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProviderId"));

                    b.Property<int?>("CountryId")
                        .HasColumnType("int")
                        .HasColumnName("CountryID");

                    b.Property<string>("EmailProvider")
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)")
                        .HasColumnName("Email_Provider")
                        .UseCollation("SQL_Latin1_General_CP1_CI_AS");

                    b.Property<string>("NameProvider")
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)")
                        .HasColumnName("Name_Provider")
                        .UseCollation("SQL_Latin1_General_CP1_CI_AS");

                    b.Property<int?>("PhoneProvider")
                        .HasColumnType("int")
                        .HasColumnName("Phone_Provider");

                    b.HasKey("ProviderId");

                    b.HasIndex("CountryId");

                    b.ToTable("provider", (string)null);
                });

            modelBuilder.Entity("CourseWork.Models.Sale", b =>
                {
                    b.Property<int>("SaleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("SaleID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SaleId"));

                    b.Property<int?>("ClientId")
                        .HasColumnType("int")
                        .HasColumnName("ClientID");

                    b.Property<DateTime?>("DateSale")
                        .HasColumnType("date")
                        .HasColumnName("Date_Sale");

                    b.Property<int?>("ProductId")
                        .HasColumnType("int")
                        .HasColumnName("ProductID");

                    b.Property<int?>("Quantity")
                        .HasColumnType("int");

                    b.Property<int?>("StuffId")
                        .HasColumnType("int")
                        .HasColumnName("StuffID");

                    b.HasKey("SaleId");

                    b.HasIndex("ClientId");

                    b.HasIndex("ProductId");

                    b.HasIndex("StuffId");

                    b.ToTable("sales", (string)null);
                });

            modelBuilder.Entity("CourseWork.Models.Stuff", b =>
                {
                    b.Property<int>("StuffId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("StuffID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StuffId"));

                    b.Property<string>("FullNameStuff")
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)")
                        .UseCollation("SQL_Latin1_General_CP1_CI_AS");

                    b.Property<int?>("PostId")
                        .HasColumnType("int")
                        .HasColumnName("PostID");

                    b.HasKey("StuffId");

                    b.HasIndex("PostId");

                    b.ToTable("stuff", (string)null);
                });

            modelBuilder.Entity("CourseWork.Models.Product", b =>
                {
                    b.HasOne("CourseWork.Models.Provider", "Provider")
                        .WithMany("Products")
                        .HasForeignKey("ProviderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .HasConstraintName("FK_products_provider");

                    b.HasOne("CourseWork.Models.ProductV", "View")
                        .WithMany("Products")
                        .HasForeignKey("ViewId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .HasConstraintName("FK_products_product_v");

                    b.Navigation("Provider");

                    b.Navigation("View");
                });

            modelBuilder.Entity("CourseWork.Models.ProductV", b =>
                {
                    b.HasOne("CourseWork.Models.ProductT", "Type")
                        .WithMany("ProductVs")
                        .HasForeignKey("TypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .HasConstraintName("FK_product_v_product_t");

                    b.Navigation("Type");
                });

            modelBuilder.Entity("CourseWork.Models.Provider", b =>
                {
                    b.HasOne("CourseWork.Models.Country", "Country")
                        .WithMany("Providers")
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .HasConstraintName("FK_provider_Country");

                    b.Navigation("Country");
                });

            modelBuilder.Entity("CourseWork.Models.Sale", b =>
                {
                    b.HasOne("CourseWork.Models.Client", "Client")
                        .WithMany("Sales")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .HasConstraintName("FK_sales_clients");

                    b.HasOne("CourseWork.Models.Product", "Product")
                        .WithMany("Sales")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .HasConstraintName("FK_sales_products");

                    b.HasOne("CourseWork.Models.Stuff", "Stuff")
                        .WithMany("Sales")
                        .HasForeignKey("StuffId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .HasConstraintName("FK_sales_stuff");

                    b.Navigation("Client");

                    b.Navigation("Product");

                    b.Navigation("Stuff");
                });

            modelBuilder.Entity("CourseWork.Models.Stuff", b =>
                {
                    b.HasOne("CourseWork.Models.Post", "Post")
                        .WithMany("Stuffs")
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .HasConstraintName("FK_stuff_posts");

                    b.Navigation("Post");
                });

            modelBuilder.Entity("CourseWork.Models.Client", b =>
                {
                    b.Navigation("Sales");
                });

            modelBuilder.Entity("CourseWork.Models.Country", b =>
                {
                    b.Navigation("Providers");
                });

            modelBuilder.Entity("CourseWork.Models.Post", b =>
                {
                    b.Navigation("Stuffs");
                });

            modelBuilder.Entity("CourseWork.Models.Product", b =>
                {
                    b.Navigation("Sales");
                });

            modelBuilder.Entity("CourseWork.Models.ProductT", b =>
                {
                    b.Navigation("ProductVs");
                });

            modelBuilder.Entity("CourseWork.Models.ProductV", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("CourseWork.Models.Provider", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("CourseWork.Models.Stuff", b =>
                {
                    b.Navigation("Sales");
                });
#pragma warning restore 612, 618
        }
    }
}
