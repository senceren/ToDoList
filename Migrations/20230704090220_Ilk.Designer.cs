﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ToDoList.Data;

#nullable disable

namespace ToDoList.Migrations
{
    [DbContext(typeof(UygulamaDbContext))]
    [Migration("20230704090220_Ilk")]
    partial class Ilk
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.18")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ToDoList.Data.TodoItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<bool>("Done")
                        .HasColumnType("bit");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TodoItems");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Deleted = false,
                            Done = false,
                            Title = "Proje teklifini tamamla"
                        },
                        new
                        {
                            Id = 2,
                            Deleted = false,
                            Done = false,
                            Title = "Sunum slaytlarını hazırla"
                        },
                        new
                        {
                            Id = 3,
                            Deleted = false,
                            Done = true,
                            Title = "Kod değişikliklerini gözden geçir"
                        },
                        new
                        {
                            Id = 4,
                            Deleted = false,
                            Done = true,
                            Title = "Takip e-postalarını gönder"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
