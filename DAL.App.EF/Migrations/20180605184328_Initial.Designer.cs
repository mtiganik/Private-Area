﻿// <auto-generated />
using DAL.App.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace DAL.App.EF.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20180605184328_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.3-rtm-10026")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Domain.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("Address")
                        .HasMaxLength(100);

                    b.Property<string>("Comments")
                        .HasMaxLength(500);

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<int>("DepartmentId");

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<string>("FirstName")
                        .HasMaxLength(100);

                    b.Property<string>("LastName")
                        .HasMaxLength(100);

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<string>("Skype")
                        .HasMaxLength(100);

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.Property<int>("UserStatusId");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.HasIndex("UserStatusId");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Domain.Company", b =>
                {
                    b.Property<int>("CompanyId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CompanyFieldOfActivityId");

                    b.Property<string>("CompanyName")
                        .HasMaxLength(100);

                    b.Property<string>("CompanyRegistrationName")
                        .HasMaxLength(200);

                    b.Property<int>("CompanyTypeId");

                    b.Property<string>("CompanyWebsite")
                        .HasMaxLength(200);

                    b.HasKey("CompanyId");

                    b.HasIndex("CompanyFieldOfActivityId");

                    b.HasIndex("CompanyTypeId");

                    b.ToTable("Companies");
                });

            modelBuilder.Entity("Domain.CompanyFieldOfActivity", b =>
                {
                    b.Property<int>("CompanyFieldOfActivityId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ActivityNameId");

                    b.HasKey("CompanyFieldOfActivityId");

                    b.HasIndex("ActivityNameId");

                    b.ToTable("CompanyFieldOfActivities");
                });

            modelBuilder.Entity("Domain.CompanyProject", b =>
                {
                    b.Property<int>("CompanyProjectId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CompanyId");

                    b.Property<int>("ProjectId");

                    b.HasKey("CompanyProjectId");

                    b.HasIndex("CompanyId");

                    b.HasIndex("ProjectId");

                    b.ToTable("CompanyProjects");
                });

            modelBuilder.Entity("Domain.CompanyType", b =>
                {
                    b.Property<int>("CompanyTypeId")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("CompanyTypeNameId");

                    b.HasKey("CompanyTypeId");

                    b.HasIndex("CompanyTypeNameId");

                    b.ToTable("CompanyTypes");
                });

            modelBuilder.Entity("Domain.CompanyWorker", b =>
                {
                    b.Property<int>("CompanyWorkerId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CompanyId");

                    b.Property<int>("CompanyWorkerPositionId");

                    b.Property<DateTime>("EntryAdded");

                    b.Property<string>("WorkerEmail")
                        .HasMaxLength(100);

                    b.Property<string>("WorkerName")
                        .HasMaxLength(100);

                    b.Property<string>("WorkerPhone")
                        .HasMaxLength(100);

                    b.HasKey("CompanyWorkerId");

                    b.HasIndex("CompanyId");

                    b.HasIndex("CompanyWorkerPositionId");

                    b.ToTable("CompanyWorkers");
                });

            modelBuilder.Entity("Domain.CompanyWorkerPosition", b =>
                {
                    b.Property<int>("CompanyWorkerPositionId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("PositionName")
                        .HasMaxLength(100);

                    b.Property<string>("PositionNameEst")
                        .HasMaxLength(100);

                    b.HasKey("CompanyWorkerPositionId");

                    b.ToTable("CompanyWorkerPositions");
                });

            modelBuilder.Entity("Domain.Contact", b =>
                {
                    b.Property<int>("ContactId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ApplicationUserId");

                    b.Property<string>("Comments")
                        .HasMaxLength(400);

                    b.Property<int>("CompanyId");

                    b.Property<int?>("CompanyWorkerId");

                    b.Property<DateTime>("ContactDate");

                    b.Property<int>("ContactTypeId");

                    b.Property<bool>("IsNewContactNeeded");

                    b.Property<DateTime?>("NewContactDate");

                    b.Property<string>("NewContactType");

                    b.Property<int>("ProjectId");

                    b.HasKey("ContactId");

                    b.HasIndex("ApplicationUserId");

                    b.HasIndex("CompanyId");

                    b.HasIndex("CompanyWorkerId");

                    b.HasIndex("ContactTypeId");

                    b.HasIndex("ProjectId");

                    b.ToTable("Contacts");
                });

            modelBuilder.Entity("Domain.ContactType", b =>
                {
                    b.Property<int>("ContactTypeId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ContactTypeNameId");

                    b.HasKey("ContactTypeId");

                    b.HasIndex("ContactTypeNameId");

                    b.ToTable("ContactTypes");
                });

            modelBuilder.Entity("Domain.Department", b =>
                {
                    b.Property<int>("DepartmentId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("DepartmentName")
                        .HasMaxLength(100);

                    b.Property<string>("DepartmentNameEst")
                        .HasMaxLength(100);

                    b.HasKey("DepartmentId");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("Domain.MultiLangString", b =>
                {
                    b.Property<int>("MultiLangStringId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Value")
                        .HasMaxLength(4096);

                    b.HasKey("MultiLangStringId");

                    b.ToTable("MultiLangStrings");
                });

            modelBuilder.Entity("Domain.Position", b =>
                {
                    b.Property<int>("PositionId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ApplicationUserId");

                    b.Property<bool>("IsMarketer");

                    b.Property<int>("PositionNameId");

                    b.Property<int>("ProjectId");

                    b.HasKey("PositionId");

                    b.HasIndex("ApplicationUserId");

                    b.HasIndex("PositionNameId");

                    b.HasIndex("ProjectId");

                    b.ToTable("Positions");
                });

            modelBuilder.Entity("Domain.PositionName", b =>
                {
                    b.Property<int>("PositionNameId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("PositionNameEng")
                        .HasMaxLength(200);

                    b.Property<string>("PositionNameEst")
                        .HasMaxLength(200);

                    b.HasKey("PositionNameId");

                    b.ToTable("PositionNames");
                });

            modelBuilder.Entity("Domain.Project", b =>
                {
                    b.Property<int>("ProjectId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("ProjectEndDate");

                    b.Property<string>("ProjectName")
                        .HasMaxLength(100);

                    b.Property<string>("ProjectNameEst")
                        .HasMaxLength(100);

                    b.Property<DateTime>("ProjectStartDate");

                    b.Property<int>("ProjectTypeId");

                    b.HasKey("ProjectId");

                    b.HasIndex("ProjectTypeId");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("Domain.ProjectType", b =>
                {
                    b.Property<int>("ProjectTypeId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ProjectTypeComments")
                        .HasMaxLength(300);

                    b.Property<string>("ProjectTypeCommentsEst")
                        .HasMaxLength(300);

                    b.Property<string>("ProjectTypeName")
                        .HasMaxLength(100);

                    b.Property<string>("ProjectTypeNameEst")
                        .HasMaxLength(100);

                    b.HasKey("ProjectTypeId");

                    b.ToTable("ProjectTypes");
                });

            modelBuilder.Entity("Domain.Translation", b =>
                {
                    b.Property<int>("TranslationId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Culture")
                        .HasMaxLength(12);

                    b.Property<int>("MultiLangStringId");

                    b.Property<string>("Value")
                        .HasMaxLength(4096);

                    b.HasKey("TranslationId");

                    b.HasIndex("MultiLangStringId");

                    b.ToTable("Translations");
                });

            modelBuilder.Entity("Domain.UserStatus", b =>
                {
                    b.Property<int>("UserStatusId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("UserStatusName")
                        .HasMaxLength(100);

                    b.Property<string>("UserStatusNameEst")
                        .HasMaxLength(100);

                    b.HasKey("UserStatusId");

                    b.ToTable("UserStatuses");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("Domain.ApplicationUser", b =>
                {
                    b.HasOne("Domain.Department", "Department")
                        .WithMany("ApplicationUsers")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Domain.UserStatus", "UserStatus")
                        .WithMany()
                        .HasForeignKey("UserStatusId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Domain.Company", b =>
                {
                    b.HasOne("Domain.CompanyFieldOfActivity", "CompanyFieldOfActivity")
                        .WithMany()
                        .HasForeignKey("CompanyFieldOfActivityId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Domain.CompanyType", "CompanyType")
                        .WithMany()
                        .HasForeignKey("CompanyTypeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Domain.CompanyFieldOfActivity", b =>
                {
                    b.HasOne("Domain.MultiLangString", "ActivityName")
                        .WithMany()
                        .HasForeignKey("ActivityNameId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Domain.CompanyProject", b =>
                {
                    b.HasOne("Domain.Company", "Company")
                        .WithMany("CompanyProjects")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Domain.Project", "Project")
                        .WithMany("CompanyProjects")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Domain.CompanyType", b =>
                {
                    b.HasOne("Domain.MultiLangString", "CompanyTypeName")
                        .WithMany()
                        .HasForeignKey("CompanyTypeNameId");
                });

            modelBuilder.Entity("Domain.CompanyWorker", b =>
                {
                    b.HasOne("Domain.Company", "Company")
                        .WithMany("CompanyWorkers")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Domain.CompanyWorkerPosition", "CompanyWorkerPosition")
                        .WithMany("CompanyWorkers")
                        .HasForeignKey("CompanyWorkerPositionId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Domain.Contact", b =>
                {
                    b.HasOne("Domain.ApplicationUser", "ApplicationUser")
                        .WithMany("Contacts")
                        .HasForeignKey("ApplicationUserId");

                    b.HasOne("Domain.Company", "Company")
                        .WithMany("CompanyContacts")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Domain.CompanyWorker", "CompanyWorker")
                        .WithMany()
                        .HasForeignKey("CompanyWorkerId");

                    b.HasOne("Domain.ContactType", "ContactType")
                        .WithMany()
                        .HasForeignKey("ContactTypeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Domain.Project", "Project")
                        .WithMany()
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Domain.ContactType", b =>
                {
                    b.HasOne("Domain.MultiLangString", "ContactTypeName")
                        .WithMany()
                        .HasForeignKey("ContactTypeNameId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Domain.Position", b =>
                {
                    b.HasOne("Domain.ApplicationUser", "ApplicationUser")
                        .WithMany("Positions")
                        .HasForeignKey("ApplicationUserId");

                    b.HasOne("Domain.PositionName", "PositionName")
                        .WithMany("Positions")
                        .HasForeignKey("PositionNameId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Domain.Project", "Project")
                        .WithMany("Positions")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Domain.Project", b =>
                {
                    b.HasOne("Domain.ProjectType", "ProjectType")
                        .WithMany()
                        .HasForeignKey("ProjectTypeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Domain.Translation", b =>
                {
                    b.HasOne("Domain.MultiLangString", "MultiLangString")
                        .WithMany("Translations")
                        .HasForeignKey("MultiLangStringId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Domain.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Domain.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Domain.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Domain.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
