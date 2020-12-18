﻿// <auto-generated />
using System;
using ComicStore.Infra.EFRepository.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ComicStore.Infra.EFRepository.Migrations
{
    [DbContext(typeof(ComicStoreDbContext))]
    [Migration("20201218172033_AddressColumnsUpdate")]
    partial class AddressColumnsUpdate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("AuthorComic", b =>
                {
                    b.Property<int>("AuthorsAuthorID")
                        .HasColumnType("int");

                    b.Property<int>("ComicsComicID")
                        .HasColumnType("int");

                    b.HasKey("AuthorsAuthorID", "ComicsComicID");

                    b.HasIndex("ComicsComicID");

                    b.ToTable("AuthorComic");
                });

            modelBuilder.Entity("ComicGenre", b =>
                {
                    b.Property<int>("ComicsComicID")
                        .HasColumnType("int");

                    b.Property<int>("GenresGenreID")
                        .HasColumnType("int");

                    b.HasKey("ComicsComicID", "GenresGenreID");

                    b.HasIndex("GenresGenreID");

                    b.ToTable("ComicGenre");
                });

            modelBuilder.Entity("ComicStore.Domain.POCO.Author", b =>
                {
                    b.Property<int>("AuthorID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("AuthorID");

                    b.ToTable("Author");

                    b.HasData(
                        new
                        {
                            AuthorID = 1,
                            Name = "John Doe"
                        },
                        new
                        {
                            AuthorID = 2,
                            Name = "Jane Doe"
                        },
                        new
                        {
                            AuthorID = 3,
                            Name = "Jim Starlin"
                        },
                        new
                        {
                            AuthorID = 4,
                            Name = "Gail Simone"
                        },
                        new
                        {
                            AuthorID = 5,
                            Name = "Warren Ellis"
                        },
                        new
                        {
                            AuthorID = 6,
                            Name = "Jack Kirby"
                        },
                        new
                        {
                            AuthorID = 7,
                            Name = "Jonathan Hickman"
                        });
                });

            modelBuilder.Entity("ComicStore.Domain.POCO.Comic", b =>
                {
                    b.Property<int>("ComicID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<int>("Pages")
                        .HasColumnType("int");

                    b.Property<float>("Price")
                        .HasColumnType("real");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("ComicID");

                    b.ToTable("Comic");
                });

            modelBuilder.Entity("ComicStore.Domain.POCO.ComicImage", b =>
                {
                    b.Property<int>("ComicID")
                        .HasColumnType("int")
                        .HasColumnName("ComicID");

                    b.Property<byte[]>("Base64")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Extension")
                        .IsRequired()
                        .HasMaxLength(5)
                        .HasColumnType("nvarchar(5)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("ComicID");

                    b.ToTable("ComicImage");
                });

            modelBuilder.Entity("ComicStore.Domain.POCO.ComicInventory", b =>
                {
                    b.Property<int>("ComicID")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("ComicID");

                    b.ToTable("ComicInventory");
                });

            modelBuilder.Entity("ComicStore.Domain.POCO.Customer", b =>
                {
                    b.Property<int>("CustomerID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("UserID")
                        .IsRequired()
                        .HasMaxLength(450)
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("CustomerID");

                    b.ToTable("Customer");
                });

            modelBuilder.Entity("ComicStore.Domain.POCO.Genre", b =>
                {
                    b.Property<int>("GenreID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("GenreID");

                    b.ToTable("Genre");

                    b.HasData(
                        new
                        {
                            GenreID = 1,
                            Description = "Ação"
                        },
                        new
                        {
                            GenreID = 2,
                            Description = "Aventura"
                        },
                        new
                        {
                            GenreID = 3,
                            Description = "Drama"
                        },
                        new
                        {
                            GenreID = 4,
                            Description = "Comedia"
                        },
                        new
                        {
                            GenreID = 5,
                            Description = "Terror"
                        },
                        new
                        {
                            GenreID = 6,
                            Description = "Guerra"
                        });
                });

            modelBuilder.Entity("ComicStore.Domain.POCO.Order", b =>
                {
                    b.Property<int>("OrderID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<byte>("PaymentMethodID")
                        .HasColumnType("tinyint");

                    b.HasKey("OrderID");

                    b.ToTable("Order");
                });

            modelBuilder.Entity("ComicStore.Domain.POCO.OrderItem", b =>
                {
                    b.Property<int>("OrderItemID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("ComicID")
                        .HasColumnType("int");

                    b.Property<int>("OrderID")
                        .HasColumnType("int");

                    b.HasKey("OrderItemID");

                    b.HasIndex("ComicID");

                    b.HasIndex("OrderID");

                    b.ToTable("OrderItem");
                });

            modelBuilder.Entity("AuthorComic", b =>
                {
                    b.HasOne("ComicStore.Domain.POCO.Author", null)
                        .WithMany()
                        .HasForeignKey("AuthorsAuthorID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ComicStore.Domain.POCO.Comic", null)
                        .WithMany()
                        .HasForeignKey("ComicsComicID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ComicGenre", b =>
                {
                    b.HasOne("ComicStore.Domain.POCO.Comic", null)
                        .WithMany()
                        .HasForeignKey("ComicsComicID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ComicStore.Domain.POCO.Genre", null)
                        .WithMany()
                        .HasForeignKey("GenresGenreID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ComicStore.Domain.POCO.ComicImage", b =>
                {
                    b.HasOne("ComicStore.Domain.POCO.Comic", "Comic")
                        .WithOne("Image")
                        .HasForeignKey("ComicStore.Domain.POCO.ComicImage", "ComicID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Comic");
                });

            modelBuilder.Entity("ComicStore.Domain.POCO.ComicInventory", b =>
                {
                    b.HasOne("ComicStore.Domain.POCO.Comic", "Comic")
                        .WithOne("Inventory")
                        .HasForeignKey("ComicStore.Domain.POCO.ComicInventory", "ComicID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Comic");
                });

            modelBuilder.Entity("ComicStore.Domain.POCO.Customer", b =>
                {
                    b.OwnsOne("ComicStore.Domain.POCO.Address", "Address", b1 =>
                        {
                            b1.Property<int>("CustomerID")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int")
                                .UseIdentityColumn();

                            b1.Property<string>("City")
                                .HasMaxLength(100)
                                .HasColumnType("nvarchar(100)")
                                .HasColumnName("City");

                            b1.Property<string>("Line1")
                                .HasMaxLength(100)
                                .HasColumnType("nvarchar(100)")
                                .HasColumnName("Line1");

                            b1.Property<string>("Line2")
                                .HasMaxLength(100)
                                .HasColumnType("nvarchar(100)")
                                .HasColumnName("Line2");

                            b1.Property<string>("Neighborhood")
                                .HasMaxLength(100)
                                .HasColumnType("nvarchar(100)")
                                .HasColumnName("Neighborhood");

                            b1.Property<int>("Number")
                                .HasColumnType("int")
                                .HasColumnName("Number");

                            b1.Property<string>("PostalCode")
                                .HasMaxLength(8)
                                .HasColumnType("nvarchar(8)")
                                .HasColumnName("PostalCode");

                            b1.Property<string>("State")
                                .HasMaxLength(100)
                                .HasColumnType("nvarchar(100)")
                                .HasColumnName("State");

                            b1.HasKey("CustomerID");

                            b1.ToTable("Customer");

                            b1.WithOwner()
                                .HasForeignKey("CustomerID");
                        });

                    b.Navigation("Address");
                });

            modelBuilder.Entity("ComicStore.Domain.POCO.Order", b =>
                {
                    b.OwnsOne("ComicStore.Domain.POCO.Address", "Address", b1 =>
                        {
                            b1.Property<int>("OrderID")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int")
                                .UseIdentityColumn();

                            b1.Property<string>("City")
                                .HasMaxLength(100)
                                .HasColumnType("nvarchar(100)")
                                .HasColumnName("City");

                            b1.Property<string>("Line1")
                                .HasMaxLength(100)
                                .HasColumnType("nvarchar(100)")
                                .HasColumnName("Line1");

                            b1.Property<string>("Line2")
                                .HasMaxLength(100)
                                .HasColumnType("nvarchar(100)")
                                .HasColumnName("Line2");

                            b1.Property<string>("Neighborhood")
                                .HasMaxLength(100)
                                .HasColumnType("nvarchar(100)")
                                .HasColumnName("Neighborhood");

                            b1.Property<int>("Number")
                                .HasColumnType("int")
                                .HasColumnName("Number");

                            b1.Property<string>("PostalCode")
                                .HasMaxLength(8)
                                .HasColumnType("nvarchar(8)")
                                .HasColumnName("PostalCode");

                            b1.Property<string>("State")
                                .HasMaxLength(100)
                                .HasColumnType("nvarchar(100)")
                                .HasColumnName("State");

                            b1.HasKey("OrderID");

                            b1.ToTable("Order");

                            b1.WithOwner()
                                .HasForeignKey("OrderID");
                        });

                    b.Navigation("Address");
                });

            modelBuilder.Entity("ComicStore.Domain.POCO.OrderItem", b =>
                {
                    b.HasOne("ComicStore.Domain.POCO.Comic", "Comic")
                        .WithMany()
                        .HasForeignKey("ComicID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ComicStore.Domain.POCO.Order", "Order")
                        .WithMany("OrderItems")
                        .HasForeignKey("OrderID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Comic");

                    b.Navigation("Order");
                });

            modelBuilder.Entity("ComicStore.Domain.POCO.Comic", b =>
                {
                    b.Navigation("Image");

                    b.Navigation("Inventory");
                });

            modelBuilder.Entity("ComicStore.Domain.POCO.Order", b =>
                {
                    b.Navigation("OrderItems");
                });
#pragma warning restore 612, 618
        }
    }
}
