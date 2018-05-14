﻿// <auto-generated />
using IT_F18.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace IT_F18.Migrations
{
    [DbContext(typeof(BlogDB))]
    partial class BlogDBModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.2-rtm-10011")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("IT_F18.Models.AboutInfo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("BirthDay");

                    b.Property<string>("CurrentOccupation");

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("AboutInfo");
                });

            modelBuilder.Entity("IT_F18.Models.GalleryEntry", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<string>("ImagePath");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.ToTable("GalleryEntry");
                });

            modelBuilder.Entity("IT_F18.Models.Project", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("AboutInfoId");

                    b.Property<string>("ProjectDescription");

                    b.Property<string>("ProjectName");

                    b.HasKey("Id");

                    b.HasIndex("AboutInfoId");

                    b.ToTable("Project");
                });

            modelBuilder.Entity("IT_F18.Models.Subscriber", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email");

                    b.HasKey("Id");

                    b.ToTable("Subscriber");
                });

            modelBuilder.Entity("IT_F18.Models.Project", b =>
                {
                    b.HasOne("IT_F18.Models.AboutInfo")
                        .WithMany("Projects")
                        .HasForeignKey("AboutInfoId");
                });
#pragma warning restore 612, 618
        }
    }
}
