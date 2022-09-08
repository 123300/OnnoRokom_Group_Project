﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StackOverflow.Infrastructure.DbContexts;

#nullable disable

namespace StackOverflow.Web.Data
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("StackOverflow.Infrastructure.Entities.Answer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("AuthorName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("QuestionId")
                        .HasColumnType("int");

                    b.Property<Guid?>("TempId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("QuestionId");

                    b.ToTable("Answers");
                });

            modelBuilder.Entity("StackOverflow.Infrastructure.Entities.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("AnswerId")
                        .HasColumnType("int");

                    b.Property<string>("AuthorName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("TempId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("AnswerId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("StackOverflow.Infrastructure.Entities.Membership.ApplicationUser", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("e9b3be8c-99c5-42c7-8f2e-1eb39f6d9125"),
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "95791690-023c-4951-a932-90e200236820",
                            Email = "admin@stackOverflow.com",
                            EmailConfirmed = true,
                            FirstName = "Admin",
                            LastName = "",
                            LockoutEnabled = true,
                            NormalizedEmail = "ADMIN@STACKOVERFLOW.COM",
                            NormalizedUserName = "ADMIN@STACKOVERFLOW.COM",
                            PasswordHash = "AQAAAAEAACcQAAAAEK3wMMebJn0LcIkHCmzoVlPYLNypYMAoNuMIiXyVl4Z5+7jjmB5zJ8Bf8fcGOLIFkQ==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "54447caa-99a9-4e89-a677-ffc01f340085",
                            TwoFactorEnabled = false,
                            UserName = "admin@stackOverflow.com"
                        },
                        new
                        {
                            Id = new Guid("8f3d96ce-76ec-4992-911a-33ceb81fa29d"),
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "63d43d25-1bf4-4a11-bbb7-968bb4d1765c",
                            Email = "user@stackOverflow.com",
                            EmailConfirmed = true,
                            FirstName = "Saiful",
                            LastName = "Islam",
                            LockoutEnabled = true,
                            NormalizedEmail = "USER@STACKOVERFLOW.COM",
                            NormalizedUserName = "USER@STACKOVERFLOW.COM",
                            PasswordHash = "AQAAAAEAACcQAAAAEMRAxkii5SXa5B1ADeRc6i+ddkAYuiLeoT8oUPOUGIjqUrd9sIOyQeTdiKwqub19RA==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "9db84437-121a-4b59-beb6-9dc069f9076b",
                            TwoFactorEnabled = false,
                            UserName = "user@stackOverflow.com"
                        });
                });

            modelBuilder.Entity("StackOverflow.Infrastructure.Entities.Membership.Role", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("2c5e174e-3b0e-446f-86af-483d56fd7210"),
                            ConcurrencyStamp = "637982058632865429",
                            Name = "Admin",
                            NormalizedName = "ADMIN"
                        },
                        new
                        {
                            Id = new Guid("e943ffbf-65a4-4d42-bb74-f2ca9ea8d22a"),
                            ConcurrencyStamp = "637982058632865508",
                            Name = "User",
                            NormalizedName = "USER"
                        });
                });

            modelBuilder.Entity("StackOverflow.Infrastructure.Entities.Membership.RoleClaim", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("StackOverflow.Infrastructure.Entities.Membership.UserClaim", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("StackOverflow.Infrastructure.Entities.Membership.UserLogin", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("StackOverflow.Infrastructure.Entities.Membership.UserRole", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);

                    b.HasData(
                        new
                        {
                            UserId = new Guid("e9b3be8c-99c5-42c7-8f2e-1eb39f6d9125"),
                            RoleId = new Guid("2c5e174e-3b0e-446f-86af-483d56fd7210")
                        },
                        new
                        {
                            UserId = new Guid("8f3d96ce-76ec-4992-911a-33ceb81fa29d"),
                            RoleId = new Guid("e943ffbf-65a4-4d42-bb74-f2ca9ea8d22a")
                        });
                });

            modelBuilder.Entity("StackOverflow.Infrastructure.Entities.Membership.UserToken", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("StackOverflow.Infrastructure.Entities.Question", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<Guid>("ApplicationUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AuthorName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsSolvedQstn")
                        .HasColumnType("bit");

                    b.Property<string>("QuestionBody")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ApplicationUserId");

                    b.ToTable("Questions");
                });

            modelBuilder.Entity("StackOverflow.Infrastructure.Entities.Tag", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("QuestionId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("QuestionId");

                    b.ToTable("Tags");
                });

            modelBuilder.Entity("StackOverflow.Infrastructure.Entities.Vote", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("AnswerId")
                        .HasColumnType("int");

                    b.Property<Guid>("ApplicationUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int?>("QuestionId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ApplicationUserId");

                    b.ToTable("Votes");
                });

            modelBuilder.Entity("StackOverflow.Infrastructure.Entities.Answer", b =>
                {
                    b.HasOne("StackOverflow.Infrastructure.Entities.Question", "Question")
                        .WithMany("Answers")
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Question");
                });

            modelBuilder.Entity("StackOverflow.Infrastructure.Entities.Comment", b =>
                {
                    b.HasOne("StackOverflow.Infrastructure.Entities.Answer", "Answer")
                        .WithMany("Comments")
                        .HasForeignKey("AnswerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Answer");
                });

            modelBuilder.Entity("StackOverflow.Infrastructure.Entities.Membership.RoleClaim", b =>
                {
                    b.HasOne("StackOverflow.Infrastructure.Entities.Membership.Role", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("StackOverflow.Infrastructure.Entities.Membership.UserClaim", b =>
                {
                    b.HasOne("StackOverflow.Infrastructure.Entities.Membership.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("StackOverflow.Infrastructure.Entities.Membership.UserLogin", b =>
                {
                    b.HasOne("StackOverflow.Infrastructure.Entities.Membership.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("StackOverflow.Infrastructure.Entities.Membership.UserRole", b =>
                {
                    b.HasOne("StackOverflow.Infrastructure.Entities.Membership.Role", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StackOverflow.Infrastructure.Entities.Membership.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("StackOverflow.Infrastructure.Entities.Membership.UserToken", b =>
                {
                    b.HasOne("StackOverflow.Infrastructure.Entities.Membership.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("StackOverflow.Infrastructure.Entities.Question", b =>
                {
                    b.HasOne("StackOverflow.Infrastructure.Entities.Membership.ApplicationUser", "ApplicationUser")
                        .WithMany("Questions")
                        .HasForeignKey("ApplicationUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ApplicationUser");
                });

            modelBuilder.Entity("StackOverflow.Infrastructure.Entities.Tag", b =>
                {
                    b.HasOne("StackOverflow.Infrastructure.Entities.Question", "Question")
                        .WithMany("Tags")
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Question");
                });

            modelBuilder.Entity("StackOverflow.Infrastructure.Entities.Vote", b =>
                {
                    b.HasOne("StackOverflow.Infrastructure.Entities.Membership.ApplicationUser", "ApplicationUser")
                        .WithMany("Votes")
                        .HasForeignKey("ApplicationUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ApplicationUser");
                });

            modelBuilder.Entity("StackOverflow.Infrastructure.Entities.Answer", b =>
                {
                    b.Navigation("Comments");
                });

            modelBuilder.Entity("StackOverflow.Infrastructure.Entities.Membership.ApplicationUser", b =>
                {
                    b.Navigation("Questions");

                    b.Navigation("Votes");
                });

            modelBuilder.Entity("StackOverflow.Infrastructure.Entities.Question", b =>
                {
                    b.Navigation("Answers");

                    b.Navigation("Tags");
                });
#pragma warning restore 612, 618
        }
    }
}
