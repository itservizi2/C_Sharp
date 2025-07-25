
using LessonThirtyFive.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;



namespace LessonThirtyFive.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {

            modelBuilder.HasAnnotation("ProductVersion", "8.0.18");

            modelBuilder.Entity("LessonThirtyFive.Models.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("CopiesAvailable")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Year")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Books");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Author = "Jon Skeet",
                            CopiesAvailable = 5,
                            Title = "C# in Depth",
                            Year = 2019
                        },
                        new
                        {
                            Id = 2,
                            Author = "Andrew Troelsen",
                            CopiesAvailable = 2,
                            Title = "Pro C# 7",
                            Year = 2018
                        },
                        new
                        {
                            Id = 3,
                            Author = "Andrew Troelsen",
                            CopiesAvailable = 0,
                            Title = "C# 6.0 and the .NET 4.6 Framework",
                            Year = 2015
                        },
                        new
                        {
                            Id = 4,
                            Author = "Harrison Ferrone",
                            CopiesAvailable = 4,
                            Title = "Learning C# by Developing Games",
                            Year = 2020
                        },
                        new
                        {
                            Id = 5,
                            Author = "Jeffrey Richter",
                            CopiesAvailable = 1,
                            Title = "CLR via C#",
                            Year = 2012
                        });
                });

        }
    }
}
