﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebPizzaApp.Data;

namespace WebPizzaApp.Migrations
{
    [DbContext(typeof(WebPizzaAppDbContext))]
    partial class WebPizzaAppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WebPizzaApp.Data.Allapot", b =>
                {
                    b.Property<int>("AllapotId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Megnevezes")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("AllapotId");

                    b.ToTable("Allapotok");
                });

            modelBuilder.Entity("WebPizzaApp.Data.Cim", b =>
                {
                    b.Property<int>("CimId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Csengo")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("Hazszam")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("Irsz")
                        .IsRequired()
                        .HasColumnType("nvarchar(10)")
                        .HasMaxLength(10);

                    b.Property<int>("MegrendeloId")
                        .HasColumnType("int");

                    b.Property<string>("Utca")
                        .IsRequired()
                        .HasColumnType("nvarchar(300)")
                        .HasMaxLength(300);

                    b.Property<string>("Varos")
                        .IsRequired()
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.HasKey("CimId");

                    b.HasIndex("MegrendeloId");

                    b.ToTable("Cimek");
                });

            modelBuilder.Entity("WebPizzaApp.Data.Futar", b =>
                {
                    b.Property<int>("FutarId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nev")
                        .IsRequired()
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.HasKey("FutarId");

                    b.ToTable("Futarok");
                });

            modelBuilder.Entity("WebPizzaApp.Data.Megrendelo", b =>
                {
                    b.Property<int>("MegrendeloId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nev")
                        .IsRequired()
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.HasKey("MegrendeloId");

                    b.ToTable("Megrendelok");
                });

            modelBuilder.Entity("WebPizzaApp.Data.Pizza", b =>
                {
                    b.Property<int>("PizzaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nev")
                        .IsRequired()
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.HasKey("PizzaId");

                    b.ToTable("Pizzak");
                });

            modelBuilder.Entity("WebPizzaApp.Data.PizzaRendeles", b =>
                {
                    b.Property<int>("RendelesId")
                        .HasColumnType("int");

                    b.Property<int>("PizzaId")
                        .HasColumnType("int");

                    b.HasKey("RendelesId", "PizzaId");

                    b.HasIndex("PizzaId");

                    b.ToTable("PizzaRendelesek");
                });

            modelBuilder.Entity("WebPizzaApp.Data.Rendeles", b =>
                {
                    b.Property<int>("RendelesId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AllapotId")
                        .HasColumnType("int");

                    b.Property<int>("CimId")
                        .HasColumnType("int");

                    b.Property<int>("FutarId")
                        .HasColumnType("int");

                    b.HasKey("RendelesId");

                    b.HasIndex("AllapotId");

                    b.HasIndex("CimId");

                    b.HasIndex("FutarId");

                    b.ToTable("Rendelesek");
                });

            modelBuilder.Entity("WebPizzaApp.Data.Cim", b =>
                {
                    b.HasOne("WebPizzaApp.Data.Megrendelo", "Megrendelo")
                        .WithMany("Cimek")
                        .HasForeignKey("MegrendeloId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WebPizzaApp.Data.PizzaRendeles", b =>
                {
                    b.HasOne("WebPizzaApp.Data.Pizza", "Pizza")
                        .WithMany("PizzaRendelesek")
                        .HasForeignKey("PizzaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebPizzaApp.Data.Rendeles", "Rendeles")
                        .WithMany("PizzaRendelesek")
                        .HasForeignKey("RendelesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WebPizzaApp.Data.Rendeles", b =>
                {
                    b.HasOne("WebPizzaApp.Data.Allapot", "Allapot")
                        .WithMany("Rendelesek")
                        .HasForeignKey("AllapotId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebPizzaApp.Data.Cim", "Cim")
                        .WithMany()
                        .HasForeignKey("CimId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebPizzaApp.Data.Futar", "Futar")
                        .WithMany("Rendelesek")
                        .HasForeignKey("FutarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
