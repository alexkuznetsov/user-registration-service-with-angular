﻿// <auto-generated />
using System;
using LoginPage.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LoginPage.Infrastructure.Migrations
{
    [DbContext(typeof(LoginPageDbContext))]
    partial class LoginPageDbContentModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.7");

            modelBuilder.Entity("LoginPage.Domain.Locations.Country", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("TEXT")
                        .HasColumnName("id");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT")
                        .HasColumnName("created_at");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("TEXT")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.ToTable("countries", (string)null);
                });

            modelBuilder.Entity("LoginPage.Domain.Locations.Province", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("TEXT")
                        .HasColumnName("id");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT")
                        .HasColumnName("created_at");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("TEXT")
                        .HasColumnName("name");

                    b.Property<Guid>("country_id")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("country_id");

                    b.ToTable("provincies", (string)null);
                });

            modelBuilder.Entity("LoginPage.Domain.Locations.UserLocation", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("TEXT")
                        .HasColumnName("id");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT")
                        .HasColumnName("created_at");

                    b.Property<Guid>("province_id")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("user_id")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("province_id");

                    b.HasIndex("user_id");

                    b.ToTable("user_locations", (string)null);
                });

            modelBuilder.Entity("LoginPage.Domain.Users.User", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("TEXT")
                        .HasColumnName("id");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT")
                        .HasColumnName("created_at");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("TEXT")
                        .HasColumnName("email");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("TEXT")
                        .HasColumnName("password");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("TEXT")
                        .HasColumnName("user_name");

                    b.HasKey("Id");

                    b.ToTable("users", (string)null);
                });

            modelBuilder.Entity("LoginPage.Domain.Locations.Province", b =>
                {
                    b.HasOne("LoginPage.Domain.Locations.Country", "Country")
                        .WithMany()
                        .HasForeignKey("country_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Country");
                });

            modelBuilder.Entity("LoginPage.Domain.Locations.UserLocation", b =>
                {
                    b.HasOne("LoginPage.Domain.Locations.Province", "Province")
                        .WithMany()
                        .HasForeignKey("province_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LoginPage.Domain.Users.User", "User")
                        .WithMany()
                        .HasForeignKey("user_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Province");

                    b.Navigation("User");
                });
#pragma warning restore 612, 618
        }
    }
}
