﻿// <auto-generated />
using System;
using ManGAGA_DAL.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ManGAGA_DAL.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20220823151528_add genders table")]
    partial class addgenderstable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ManGAGA_DAL.Models.Chaper", b =>
                {
                    b.Property<int>("ChaperID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ChaperID"), 1L, 1);

                    b.Property<int>("MangaID")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Number")
                        .HasColumnType("int");

                    b.HasKey("ChaperID");

                    b.HasIndex("MangaID");

                    b.ToTable("Chapers");
                });

            modelBuilder.Entity("ManGAGA_DAL.Models.Favourites", b =>
                {
                    b.Property<int>("FavouritesId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FavouritesId"), 1L, 1);

                    b.Property<int>("userId")
                        .HasColumnType("int");

                    b.HasKey("FavouritesId");

                    b.HasIndex("userId");

                    b.ToTable("Favourites");
                });

            modelBuilder.Entity("ManGAGA_DAL.Models.Genders", b =>
                {
                    b.Property<int>("gendersID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("gendersID"), 1L, 1);

                    b.Property<int?>("MangaGId")
                        .HasColumnType("int");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("gendersID");

                    b.HasIndex("MangaGId");

                    b.ToTable("Genders");
                });

            modelBuilder.Entity("ManGAGA_DAL.Models.MangaG", b =>
                {
                    b.Property<int>("MangaGId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MangaGId"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("FavouritesId")
                        .HasColumnType("int");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PublisherID")
                        .HasColumnType("int");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("score")
                        .HasColumnType("real");

                    b.HasKey("MangaGId");

                    b.HasIndex("FavouritesId");

                    b.HasIndex("PublisherID");

                    b.ToTable("Mangas");
                });

            modelBuilder.Entity("ManGAGA_DAL.Models.Page", b =>
                {
                    b.Property<int>("PageID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PageID"), 1L, 1);

                    b.Property<int>("ChaperID")
                        .HasColumnType("int");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Number")
                        .HasColumnType("int");

                    b.HasKey("PageID");

                    b.HasIndex("ChaperID");

                    b.ToTable("Pages");
                });

            modelBuilder.Entity("ManGAGA_DAL.Models.User", b =>
                {
                    b.Property<int>("UserID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserID"), 1L, 1);

                    b.Property<int>("AccountType")
                        .HasColumnType("int");

                    b.Property<byte[]>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Profile")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("UserID");

                    b.HasIndex("UserName")
                        .IsUnique();

                    b.ToTable("Users");
                });

            modelBuilder.Entity("ManGAGA_DAL.Models.Chaper", b =>
                {
                    b.HasOne("ManGAGA_DAL.Models.MangaG", "Manga")
                        .WithMany("Chapers")
                        .HasForeignKey("MangaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Manga");
                });

            modelBuilder.Entity("ManGAGA_DAL.Models.Favourites", b =>
                {
                    b.HasOne("ManGAGA_DAL.Models.User", "user")
                        .WithMany("MyFavourites")
                        .HasForeignKey("userId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("user");
                });

            modelBuilder.Entity("ManGAGA_DAL.Models.Genders", b =>
                {
                    b.HasOne("ManGAGA_DAL.Models.MangaG", null)
                        .WithMany("Genders")
                        .HasForeignKey("MangaGId");
                });

            modelBuilder.Entity("ManGAGA_DAL.Models.MangaG", b =>
                {
                    b.HasOne("ManGAGA_DAL.Models.Favourites", null)
                        .WithMany("Mangas")
                        .HasForeignKey("FavouritesId");

                    b.HasOne("ManGAGA_DAL.Models.User", "Publisher")
                        .WithMany("MyPosts")
                        .HasForeignKey("PublisherID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Publisher");
                });

            modelBuilder.Entity("ManGAGA_DAL.Models.Page", b =>
                {
                    b.HasOne("ManGAGA_DAL.Models.Chaper", "Chaper")
                        .WithMany("Pages")
                        .HasForeignKey("ChaperID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Chaper");
                });

            modelBuilder.Entity("ManGAGA_DAL.Models.Chaper", b =>
                {
                    b.Navigation("Pages");
                });

            modelBuilder.Entity("ManGAGA_DAL.Models.Favourites", b =>
                {
                    b.Navigation("Mangas");
                });

            modelBuilder.Entity("ManGAGA_DAL.Models.MangaG", b =>
                {
                    b.Navigation("Chapers");

                    b.Navigation("Genders");
                });

            modelBuilder.Entity("ManGAGA_DAL.Models.User", b =>
                {
                    b.Navigation("MyFavourites");

                    b.Navigation("MyPosts");
                });
#pragma warning restore 612, 618
        }
    }
}
