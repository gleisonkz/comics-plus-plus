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
    [Migration("20201201123241_ComicImageConfigurationOnetoOne")]
    partial class ComicImageConfigurationOnetoOne
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
                });

            modelBuilder.Entity("ComicStore.Domain.POCO.Comic", b =>
                {
                    b.Property<int>("ComicID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<byte[]>("Image")
                        .HasColumnType("varbinary(max)");

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
                        .HasColumnType("int");

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
                        .WithOne()
                        .HasForeignKey("ComicStore.Domain.POCO.ComicImage", "ComicID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Comic");
                });
#pragma warning restore 612, 618
        }
    }
}