﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;
using WebApiPizza.Models;

namespace WebApiPizza.Migrations
{
    [DbContext(typeof(Pizza_dotNetContext))]
    [Migration("20180516094236_Init")]
    partial class Init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.3-rtm-10026")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WebApiPizza.Models.Category", b =>
                {
                    b.Property<short>("IdCategory")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CategoryName")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.HasKey("IdCategory");

                    b.ToTable("category");
                });

            modelBuilder.Entity("WebApiPizza.Models.Pizza", b =>
                {
                    b.Property<short>("IdPizza")
                        .ValueGeneratedOnAdd();

                    b.Property<bool?>("Available");

                    b.Property<string>("Description")
                        .HasMaxLength(200)
                        .IsUnicode(false);

                    b.Property<short>("IdCategory");

                    b.Property<string>("ImagePath")
                        .HasMaxLength(300)
                        .IsUnicode(false);

                    b.Property<decimal?>("Price");

                    b.Property<string>("Title")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.HasKey("IdPizza");

                    b.HasIndex("IdCategory");

                    b.ToTable("pizza");
                });

            modelBuilder.Entity("WebApiPizza.Models.Pizza", b =>
                {
                    b.HasOne("WebApiPizza.Models.Category", "IdCategoryNavigation")
                        .WithMany("Pizza")
                        .HasForeignKey("IdCategory")
                        .HasConstraintName("FK_pizza_category");
                });
#pragma warning restore 612, 618
        }
    }
}
