﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using hospitalmanagement.Data;

namespace hospitalmanagement.Migrations
{
    [DbContext(typeof(dbContext))]
    [Migration("20210908064545_Second")]
    partial class Second
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.9");

            modelBuilder.Entity("hospitalmanagement.Entities.Hospital", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("addressLine1")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("addressLine2")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("addressLine3")
                        .HasColumnType("text");

                    b.Property<string>("zipCode")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("varchar(10)");

                    b.HasKey("Id");

                    b.ToTable("hospital");
                });

            modelBuilder.Entity("hospitalmanagement.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .HasColumnType("text");

                    b.Property<DateTime>("createdOn")
                        .HasColumnType("datetime");

                    b.Property<string>("firstName")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<int>("hospitalId")
                        .HasColumnType("int");

                    b.Property<bool>("isDeleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("lastName")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<DateTime>("modifiedOn")
                        .HasColumnType("datetime");

                    b.HasKey("Id");

                    b.HasIndex("hospitalId");

                    b.ToTable("user");
                });

            modelBuilder.Entity("hospitalmanagement.Entities.User", b =>
                {
                    b.HasOne("hospitalmanagement.Entities.Hospital", null)
                        .WithMany("Users")
                        .HasForeignKey("hospitalId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("hospitalmanagement.Entities.Hospital", b =>
                {
                    b.Navigation("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
