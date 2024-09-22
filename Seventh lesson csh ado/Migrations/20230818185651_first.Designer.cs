﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Seventh_lesson_csh_ado;

#nullable disable

namespace Seventh_lesson_csh_ado.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20230818185651_first")]
    partial class first
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Seventh_lesson_csh_ado.Author", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar")
                        .HasColumnName("FirstName");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("varchar")
                        .HasColumnName("LastName");

                    b.HasKey("ID");

                    b.ToTable("Authors");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            Name = "Anton",
                            Surname = "Some1"
                        });
                });

            modelBuilder.Entity("Seventh_lesson_csh_ado.Book", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int?>("IDPublisher")
                        .HasColumnType("int")
                        .HasColumnName("IdPublisher");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<int>("Size")
                        .HasColumnType("int")
                        .HasColumnName("Pages");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar");

                    b.HasKey("ID");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("Seventh_lesson_csh_ado.BookAuthor", b =>
                {
                    b.Property<int?>("IDAuthor")
                        .IsRequired()
                        .HasColumnType("int")
                        .HasColumnName("Author_id");

                    b.Property<int?>("IDBook")
                        .IsRequired()
                        .HasColumnType("int")
                        .HasColumnName("Book_id");

                    b.ToTable("BookAuthors");
                });

            modelBuilder.Entity("Seventh_lesson_csh_ado.Publisher", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar")
                        .HasColumnName("Name");

                    b.HasKey("ID");

                    b.ToTable("Pubishers");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            Name = "First"
                        },
                        new
                        {
                            ID = 2,
                            Name = "Second"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}