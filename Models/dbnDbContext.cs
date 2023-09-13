using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace CourseWork.Models;

public partial class dbnDbContext : DbContext
{
    public dbnDbContext()
    {
    }

    public dbnDbContext(DbContextOptions<dbnDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Client> Clients { get; set; }

    public virtual DbSet<Country> Countries { get; set; }

    public virtual DbSet<Post> Posts { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<ProductT> ProductTs { get; set; }

    public virtual DbSet<ProductV> ProductVs { get; set; }

    public virtual DbSet<Provider> Providers { get; set; }

    public virtual DbSet<Sale> Sales { get; set; }

    public virtual DbSet<Stuff> Stuffs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-9R4RDR5\\SQLEXPRESS;Initial Catalog=dbn;Integrated Security=True;Encrypt=false;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Client>(entity =>
        {
            entity.ToTable("clients");

            entity.Property(e => e.ClientId).HasColumnName("ClientID");
            entity.Property(e => e.DateBirth).HasColumnType("date");
            entity.Property(e => e.Email).UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.FirstNameClient)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("FirstName_Client");
            entity.Property(e => e.LastNameClient).HasColumnName("LastName_Client");
            entity.Property(e => e.PatronomykClient).HasColumnName("Patronomyk_Client");
            entity.Property(e => e.PhoneClient).HasColumnName("Phone_Client");
        });

        modelBuilder.Entity<Country>(entity =>
        {
            entity.ToTable("Country");

            entity.Property(e => e.CountryId).HasColumnName("CountryID");
            entity.Property(e => e.NameCountry)
                .IsUnicode(true)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("Name_Country");
        });

        modelBuilder.Entity<Post>(entity =>
        {
            entity.ToTable("posts");

            entity.Property(e => e.PostId).HasColumnName("PostID");
            entity.Property(e => e.NamePost)
                .IsUnicode(true)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("Name_Post");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.ToTable("products");

            entity.Property(e => e.Brand)
                .IsUnicode(true)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.ProviderId).HasColumnName("ProviderID");
            entity.Property(e => e.ViewId).HasColumnName("ViewID");

            entity.HasOne(d => d.Provider).WithMany(p => p.Products)
                .HasForeignKey(d => d.ProviderId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_products_provider");

            entity.HasOne(d => d.View).WithMany(p => p.Products)
                .HasForeignKey(d => d.ViewId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_products_product_v");
        });

        modelBuilder.Entity<ProductT>(entity =>
        {
            entity.HasKey(e => e.TypeId);

            entity.ToTable("product_t");

            entity.Property(e => e.TypeId).HasColumnName("TypeID");
            entity.Property(e => e.NameType)
                .IsUnicode(true)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("Name_Type");
        });

        modelBuilder.Entity<ProductV>(entity =>
        {
            entity.HasKey(e => e.ViewId);

            entity.ToTable("product_v");

            entity.Property(e => e.ViewId).HasColumnName("ViewID");
            entity.Property(e => e.NameView)
                .IsUnicode(true)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("Name_View");
            entity.Property(e => e.TypeId).HasColumnName("TypeID");

            entity.HasOne(d => d.Type).WithMany(p => p.ProductVs)
                .HasForeignKey(d => d.TypeId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_product_v_product_t");
        });

        modelBuilder.Entity<Provider>(entity =>
        {
            entity.ToTable("provider");

            entity.Property(e => e.ProviderId).HasColumnName("ProviderID");
            entity.Property(e => e.CountryId).HasColumnName("CountryID");
            entity.Property(e => e.EmailProvider)
                .IsUnicode(true)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("Email_Provider");
            entity.Property(e => e.NameProvider)
                .IsUnicode(true)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("Name_Provider");
            entity.Property(e => e.PhoneProvider).HasColumnName("Phone_Provider");

            entity.HasOne(d => d.Country).WithMany(p => p.Providers)
                .HasForeignKey(d => d.CountryId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_provider_Country");
        });

        modelBuilder.Entity<Sale>(entity =>
        {
            entity.ToTable("sales");

            entity.Property(e => e.SaleId).HasColumnName("SaleID");
            entity.Property(e => e.ClientId).HasColumnName("ClientID");
            entity.Property(e => e.DateSale)
                .HasColumnType("date")
                .HasColumnName("Date_Sale");
            entity.Property(e => e.ProductId).HasColumnName("ProductID");
            entity.Property(e => e.StuffId).HasColumnName("StuffID");

            entity.HasOne(d => d.Client).WithMany(p => p.Sales)
                .HasForeignKey(d => d.ClientId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_sales_clients");

            entity.HasOne(d => d.Product).WithMany(p => p.Sales)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_sales_products");

            entity.HasOne(d => d.Stuff).WithMany(p => p.Sales)
                .HasForeignKey(d => d.StuffId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_sales_stuff");
        });

        modelBuilder.Entity<Stuff>(entity =>
        {
            entity.ToTable("stuff");

            entity.Property(e => e.StuffId).HasColumnName("StuffID");
            entity.Property(e => e.FullNameStuff)
                .IsUnicode(true)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.PostId).HasColumnName("PostID");

            entity.HasOne(d => d.Post).WithMany(p => p.Stuffs)
                .HasForeignKey(d => d.PostId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_stuff_posts");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
