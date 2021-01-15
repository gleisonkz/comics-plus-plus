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
    [Migration("20210115185905_ChangeFloatToDecimal")]
    partial class ChangeFloatToDecimal
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("ComicAuthor", b =>
                {
                    b.Property<int>("AuthorID")
                        .HasColumnType("int");

                    b.Property<int>("ComicID")
                        .HasColumnType("int");

                    b.HasKey("AuthorID", "ComicID");

                    b.HasIndex("ComicID");

                    b.ToTable("ComicAuthor");

                    b.HasData(
                        new
                        {
                            AuthorID = 1,
                            ComicID = 1
                        },
                        new
                        {
                            AuthorID = 2,
                            ComicID = 2
                        },
                        new
                        {
                            AuthorID = 3,
                            ComicID = 3
                        },
                        new
                        {
                            AuthorID = 4,
                            ComicID = 4
                        },
                        new
                        {
                            AuthorID = 5,
                            ComicID = 5
                        },
                        new
                        {
                            AuthorID = 6,
                            ComicID = 6
                        },
                        new
                        {
                            AuthorID = 7,
                            ComicID = 7
                        },
                        new
                        {
                            AuthorID = 1,
                            ComicID = 8
                        },
                        new
                        {
                            AuthorID = 2,
                            ComicID = 9
                        },
                        new
                        {
                            AuthorID = 3,
                            ComicID = 10
                        });
                });

            modelBuilder.Entity("ComicGenre", b =>
                {
                    b.Property<int>("ComicID")
                        .HasColumnType("int");

                    b.Property<int>("GenreID")
                        .HasColumnType("int");

                    b.HasKey("ComicID", "GenreID");

                    b.HasIndex("GenreID");

                    b.ToTable("ComicGenre");

                    b.HasData(
                        new
                        {
                            ComicID = 1,
                            GenreID = 1
                        },
                        new
                        {
                            ComicID = 2,
                            GenreID = 2
                        },
                        new
                        {
                            ComicID = 3,
                            GenreID = 3
                        },
                        new
                        {
                            ComicID = 4,
                            GenreID = 4
                        },
                        new
                        {
                            ComicID = 5,
                            GenreID = 5
                        },
                        new
                        {
                            ComicID = 6,
                            GenreID = 6
                        },
                        new
                        {
                            ComicID = 7,
                            GenreID = 1
                        },
                        new
                        {
                            ComicID = 8,
                            GenreID = 2
                        },
                        new
                        {
                            ComicID = 9,
                            GenreID = 3
                        },
                        new
                        {
                            ComicID = 10,
                            GenreID = 4
                        });
                });

            modelBuilder.Entity("ComicStore.Domain.POCO.Author", b =>
                {
                    b.Property<int>("AuthorID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Nationality")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("AuthorID");

                    b.ToTable("Author");

                    b.HasData(
                        new
                        {
                            AuthorID = 1,
                            BirthDate = new DateTime(1998, 12, 3, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "John Doe",
                            Nationality = "Australian"
                        },
                        new
                        {
                            AuthorID = 2,
                            BirthDate = new DateTime(2020, 9, 18, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Jane Doe",
                            Nationality = "Dominican"
                        },
                        new
                        {
                            AuthorID = 3,
                            BirthDate = new DateTime(2007, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "JK Rowling",
                            Nationality = "English"
                        },
                        new
                        {
                            AuthorID = 4,
                            BirthDate = new DateTime(2000, 5, 24, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Gail Simone",
                            Nationality = "Mexican"
                        },
                        new
                        {
                            AuthorID = 5,
                            BirthDate = new DateTime(1995, 7, 14, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Warren Ellis",
                            Nationality = "French"
                        },
                        new
                        {
                            AuthorID = 6,
                            BirthDate = new DateTime(2016, 7, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Jack Kirby",
                            Nationality = "Indonesian"
                        },
                        new
                        {
                            AuthorID = 7,
                            BirthDate = new DateTime(2011, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Jonathan Hickman",
                            Nationality = "Indian"
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
                        .HasMaxLength(800)
                        .HasColumnType("nvarchar(800)");

                    b.Property<int>("Pages")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("ComicID");

                    b.ToTable("Comic");

                    b.HasData(
                        new
                        {
                            ComicID = 1,
                            Description = "In his comic book appearances, the character is both the Hulk, a green-skinned, hulking and muscular humanoid possessing a vast degree of physical strength, and his alter ego Dr. Robert Bruce Banner, a physically weak, socially withdrawn, and emotionally reserved physicist.",
                            Pages = 200,
                            Price = 50.00m,
                            Title = "Hulk",
                            Year = 2012
                        },
                        new
                        {
                            ComicID = 2,
                            Description = "American teenager Peter Parker, a poor sickly orphan, is bitten by a radioactive spider. As a result of the bite, he gains superhuman strength, speed, and agility along with the ability to cling to walls.",
                            Pages = 99,
                            Price = 66.99m,
                            Title = "Spider Man",
                            Year = 1998
                        },
                        new
                        {
                            ComicID = 3,
                            Description = "Iron Man is a fictional superhero appearing in American comic books published by Marvel Comics. ... He uses the suit and successive versions to protect the world as Iron Man. Although at first concealing his true identity, Stark eventually publicly reveals himself to be Iron Man.",
                            Pages = 77,
                            Price = 45.99m,
                            Title = "Iron Man",
                            Year = 2002
                        },
                        new
                        {
                            ComicID = 4,
                            Description = "Created as a female counterpart to Superman, Kara Zor-El shares his super powers and vulnerability to Kryptonite. Supergirl plays a supporting role in various DC Comics publications, including Action Comics, Superman, and several comic book series unrelated to Superman.",
                            Pages = 85,
                            Price = 66.00m,
                            Title = "Super Girl",
                            Year = 2005
                        },
                        new
                        {
                            ComicID = 5,
                            Description = "Green Lantern is an ongoing American comic-book series featuring the DC Comics heroes of the same name. ... When the Silver Age Green Lantern, Hal Jordan, was introduced, the character starred in a new volume of Green Lantern starting in 1960.",
                            Pages = 105,
                            Price = 77.00m,
                            Title = "Green Lantern",
                            Year = 2014
                        },
                        new
                        {
                            ComicID = 6,
                            Description = "Venom is a fictional character appearing in American comic books published by Marvel Comics, commonly in association with Spider-Man. The character is a sentient alien symbiote with an amorphous, liquid-like form, who survives by bonding with a host, usually human.",
                            Pages = 135,
                            Price = 125.00m,
                            Title = "Venom",
                            Year = 2016
                        },
                        new
                        {
                            ComicID = 7,
                            Description = "Captain America is the alter ego of Steve Rogers, a frail young man enhanced to the peak of human perfection by an experimental serum to aid the United States government's efforts in World War II. Near the end of the war, he was trapped in ice and survived in suspended animation until he was revived in modern times.",
                            Pages = 136,
                            Price = 86.00m,
                            Title = "Captain America",
                            Year = 1997
                        },
                        new
                        {
                            ComicID = 8,
                            Description = "The character, which is based on the Norse deity of the same name, is the Asgardian god of thunder who possesses the enchanted hammer, Mjolnir, which grants him the ability to fly and manipulate weather amongst his other superhuman attributes.",
                            Pages = 158,
                            Price = 55.55m,
                            Title = "Thor",
                            Year = 2012
                        },
                        new
                        {
                            ComicID = 9,
                            Description = "Black Panther is a fictional superhero appearing in American comic books published by Marvel Comics. ... Black Panther's real name is T'Challa, and he is depicted as the king and protector of the fictional African nation of Wakanda.",
                            Pages = 258,
                            Price = 85.00m,
                            Title = "Black Panther",
                            Year = 2016
                        },
                        new
                        {
                            ComicID = 10,
                            Description = "Marvel is the name of many fictional superheroes appearing in comic books published by Marvel Comics. The character was originally conceived as a female counterpart to Captain Marvel. Like Captain Marvel, most of the bearers of the Ms.",
                            Pages = 200,
                            Price = 50.00m,
                            Title = "Ms. Marvel",
                            Year = 2012
                        });
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

                    b.HasData(
                        new
                        {
                            ComicID = 1,
                            Quantity = 1
                        },
                        new
                        {
                            ComicID = 2,
                            Quantity = 0
                        },
                        new
                        {
                            ComicID = 3,
                            Quantity = 1
                        },
                        new
                        {
                            ComicID = 4,
                            Quantity = 0
                        },
                        new
                        {
                            ComicID = 5,
                            Quantity = 9
                        },
                        new
                        {
                            ComicID = 6,
                            Quantity = 0
                        },
                        new
                        {
                            ComicID = 7,
                            Quantity = 1
                        },
                        new
                        {
                            ComicID = 8,
                            Quantity = 3
                        },
                        new
                        {
                            ComicID = 9,
                            Quantity = 5
                        },
                        new
                        {
                            ComicID = 10,
                            Quantity = 3
                        });
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

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<decimal>("TotalValue")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("UnitValue")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("OrderItemID");

                    b.HasIndex("ComicID");

                    b.HasIndex("OrderID");

                    b.ToTable("OrderItem");
                });

            modelBuilder.Entity("ComicAuthor", b =>
                {
                    b.HasOne("ComicStore.Domain.POCO.Author", null)
                        .WithMany()
                        .HasForeignKey("AuthorID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ComicStore.Domain.POCO.Comic", null)
                        .WithMany()
                        .HasForeignKey("ComicID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ComicGenre", b =>
                {
                    b.HasOne("ComicStore.Domain.POCO.Comic", null)
                        .WithMany()
                        .HasForeignKey("ComicID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ComicStore.Domain.POCO.Genre", null)
                        .WithMany()
                        .HasForeignKey("GenreID")
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
