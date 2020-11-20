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
    [Migration("20201120115323_addPocoConfigurationFiles")]
    partial class addPocoConfigurationFiles
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

                    b.Property<int>("ComicID")
                        .HasColumnType("int");

                    b.HasKey("AuthorsAuthorID", "ComicID");

                    b.HasIndex("ComicID");

                    b.ToTable("AuthorComic");
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

            modelBuilder.Entity("ComicStore.Domain.POCO.Genre", b =>
                {
                    b.Property<int>("GenreID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int?>("ComicID")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("GenreID");

                    b.HasIndex("ComicID");

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
                        .HasForeignKey("ComicID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ComicStore.Domain.POCO.Genre", b =>
                {
                    b.HasOne("ComicStore.Domain.POCO.Comic", null)
                        .WithMany("Genres")
                        .HasForeignKey("ComicID");
                });

            modelBuilder.Entity("ComicStore.Domain.POCO.Comic", b =>
                {
                    b.Navigation("Genres");
                });
#pragma warning restore 612, 618
        }
    }
}