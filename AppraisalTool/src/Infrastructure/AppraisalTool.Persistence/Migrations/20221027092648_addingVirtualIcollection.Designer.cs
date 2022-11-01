﻿// <auto-generated />
using System;
using AppraisalTool.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AppraisalTool.Persistence.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20221027092648_addingVirtualIcollection")]
    partial class addingVirtualIcollection
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("AppraisalTool.Domain.Entities.Appraisal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("ApprovedOn")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("FinancialYearId")
                        .HasColumnType("int");

                    b.Property<int?>("KraId")
                        .HasColumnType("int");

                    b.Property<DateTime>("ReviewedOn")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("StatusId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FinancialYearId");

                    b.HasIndex("StatusId");

                    b.HasIndex("UserId");

                    b.ToTable("Appraisal");
                });

            modelBuilder.Entity("AppraisalTool.Domain.Entities.Branch", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("AddedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("AddedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("BranchCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BranchName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Branch");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AddedOn = new DateTime(2022, 10, 27, 9, 26, 47, 755, DateTimeKind.Utc).AddTicks(1940),
                            BranchCode = "BR001",
                            BranchName = "Mumbai"
                        });
                });

            modelBuilder.Entity("AppraisalTool.Domain.Entities.Category", b =>
                {
                    b.Property<Guid>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("varchar(450)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("varchar(450)");

                    b.Property<DateTime?>("LastModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.HasKey("CategoryId");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            CategoryId = new Guid("b0788d2f-8003-43c1-92a4-edc76a7c5dde"),
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Concerts"
                        },
                        new
                        {
                            CategoryId = new Guid("6313179f-7837-473a-a4d5-a5571b43e6a6"),
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Musicals"
                        },
                        new
                        {
                            CategoryId = new Guid("bf3f3002-7e53-441e-8b76-f6280be284aa"),
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Plays"
                        },
                        new
                        {
                            CategoryId = new Guid("fe98f549-e790-4e9f-aa16-18c2292a2ee9"),
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Conferences"
                        });
                });

            modelBuilder.Entity("AppraisalTool.Domain.Entities.Event", b =>
                {
                    b.Property<Guid>("EventId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Artist")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<Guid>("CategoryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("varchar(450)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("varchar(500)");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("varchar(450)");

                    b.Property<DateTime?>("LastModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.HasKey("EventId");

                    b.HasIndex("CategoryId");

                    b.ToTable("Events");

                    b.HasData(
                        new
                        {
                            EventId = new Guid("ee272f8b-6096-4cb6-8625-bb4bb2d89e8b"),
                            Artist = "John Egbert",
                            CategoryId = new Guid("b0788d2f-8003-43c1-92a4-edc76a7c5dde"),
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Date = new DateTime(2023, 4, 27, 9, 26, 47, 755, DateTimeKind.Utc).AddTicks(1314),
                            Description = "Join John for his farwell tour across 15 continents. John really needs no introduction since he has already mesmerized the world with his banjo.",
                            ImageUrl = "https://gillcleerenpluralsight.blob.core.windows.net/files/GloboTicket/banjo.jpg",
                            Name = "John Egbert Live",
                            Price = 65
                        },
                        new
                        {
                            EventId = new Guid("3448d5a4-0f72-4dd7-bf15-c14a46b26c00"),
                            Artist = "Michael Johnson",
                            CategoryId = new Guid("b0788d2f-8003-43c1-92a4-edc76a7c5dde"),
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Date = new DateTime(2023, 7, 27, 9, 26, 47, 755, DateTimeKind.Utc).AddTicks(1408),
                            Description = "Michael Johnson doesn't need an introduction. His 25 concert across the globe last year were seen by thousands. Can we add you to the list?",
                            ImageUrl = "https://gillcleerenpluralsight.blob.core.windows.net/files/GloboTicket/michael.jpg",
                            Name = "The State of Affairs: Michael Live!",
                            Price = 85
                        },
                        new
                        {
                            EventId = new Guid("b419a7ca-3321-4f38-be8e-4d7b6a529319"),
                            Artist = "DJ 'The Mike'",
                            CategoryId = new Guid("b0788d2f-8003-43c1-92a4-edc76a7c5dde"),
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Date = new DateTime(2023, 2, 27, 9, 26, 47, 755, DateTimeKind.Utc).AddTicks(1428),
                            Description = "DJs from all over the world will compete in this epic battle for eternal fame.",
                            ImageUrl = "https://gillcleerenpluralsight.blob.core.windows.net/files/GloboTicket/dj.jpg",
                            Name = "Clash of the DJs",
                            Price = 85
                        },
                        new
                        {
                            EventId = new Guid("62787623-4c52-43fe-b0c9-b7044fb5929b"),
                            Artist = "Manuel Santinonisi",
                            CategoryId = new Guid("b0788d2f-8003-43c1-92a4-edc76a7c5dde"),
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Date = new DateTime(2023, 2, 27, 9, 26, 47, 755, DateTimeKind.Utc).AddTicks(1445),
                            Description = "Get on the hype of Spanish Guitar concerts with Manuel.",
                            ImageUrl = "https://gillcleerenpluralsight.blob.core.windows.net/files/GloboTicket/guitar.jpg",
                            Name = "Spanish guitar hits with Manuel",
                            Price = 25
                        },
                        new
                        {
                            EventId = new Guid("1babd057-e980-4cb3-9cd2-7fdd9e525668"),
                            Artist = "Many",
                            CategoryId = new Guid("fe98f549-e790-4e9f-aa16-18c2292a2ee9"),
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Date = new DateTime(2023, 8, 27, 9, 26, 47, 755, DateTimeKind.Utc).AddTicks(1462),
                            Description = "The best tech conference in the world",
                            ImageUrl = "https://gillcleerenpluralsight.blob.core.windows.net/files/GloboTicket/conf.jpg",
                            Name = "Techorama 2021",
                            Price = 400
                        },
                        new
                        {
                            EventId = new Guid("adc42c09-08c1-4d2c-9f96-2d15bb1af299"),
                            Artist = "Nick Sailor",
                            CategoryId = new Guid("6313179f-7837-473a-a4d5-a5571b43e6a6"),
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Date = new DateTime(2023, 6, 27, 9, 26, 47, 755, DateTimeKind.Utc).AddTicks(1481),
                            Description = "The critics are over the moon and so will you after you've watched this sing and dance extravaganza written by Nick Sailor, the man from 'My dad and sister'.",
                            ImageUrl = "https://gillcleerenpluralsight.blob.core.windows.net/files/GloboTicket/musical.jpg",
                            Name = "To the Moon and Back",
                            Price = 135
                        });
                });

            modelBuilder.Entity("AppraisalTool.Domain.Entities.FinancialYear", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("EndYear")
                        .HasColumnType("int");

                    b.Property<int>("StartYear")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("FinancialYear");
                });

            modelBuilder.Entity("AppraisalTool.Domain.Entities.JobRoles", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("JobRoles");
                });

            modelBuilder.Entity("AppraisalTool.Domain.Entities.Kra", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Weightage")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Kra");
                });

            modelBuilder.Entity("AppraisalTool.Domain.Entities.KraDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsMeasurable")
                        .HasColumnType("bit");

                    b.Property<int>("KraTypeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("KraTypeId");

                    b.ToTable("KraDetail");
                });

            modelBuilder.Entity("AppraisalTool.Domain.Entities.MenuList", b =>
                {
                    b.Property<int>("Menu_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Menu_Id"), 1L, 1);

                    b.Property<string>("MenuClass")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MenuIcon")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MenuText")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MenuUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Menu_Id");

                    b.ToTable("MenuLists");
                });

            modelBuilder.Entity("AppraisalTool.Domain.Entities.MenuRoleMapping", b =>
                {
                    b.Property<int>("MenuRoleMapping_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MenuRoleMapping_id"), 1L, 1);

                    b.Property<int>("Menu_id")
                        .HasColumnType("int");

                    b.Property<int>("Role_id")
                        .HasColumnType("int");

                    b.HasKey("MenuRoleMapping_id");

                    b.HasIndex("Menu_id");

                    b.HasIndex("Role_id");

                    b.ToTable("MenuRoleMappings");
                });

            modelBuilder.Entity("AppraisalTool.Domain.Entities.Message", b =>
                {
                    b.Property<Guid>("MessageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Language")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MessageContent")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MessageId");

                    b.ToTable("Messages");

                    b.HasData(
                        new
                        {
                            MessageId = new Guid("253c75d5-32af-4dbf-ab63-1af449bde7bd"),
                            Code = "1",
                            Language = "en",
                            MessageContent = "{PropertyName} is required.",
                            Type = "Error"
                        },
                        new
                        {
                            MessageId = new Guid("ed0cc6b6-11f4-4512-a441-625941917502"),
                            Code = "2",
                            Language = "en",
                            MessageContent = "{PropertyName} must not exceed {MaxLength} characters.",
                            Type = "Error"
                        },
                        new
                        {
                            MessageId = new Guid("fafe649a-3e2a-4153-8fd8-9dcd0b87e6d8"),
                            Code = "3",
                            Language = "en",
                            MessageContent = "An event with the same name and date already exists.",
                            Type = "Error"
                        });
                });

            modelBuilder.Entity("AppraisalTool.Domain.Entities.Order", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("OrderId");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("varchar(450)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("varchar(450)");

                    b.Property<DateTime?>("LastModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("OrderPaid")
                        .HasColumnType("bit");

                    b.Property<DateTime>("OrderPlaced")
                        .HasColumnType("datetime2");

                    b.Property<int>("OrderTotal")
                        .HasColumnType("int");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("Orders");

                    b.HasData(
                        new
                        {
                            Id = new Guid("7e94bc5b-71a5-4c8c-bc3b-71bb7976237e"),
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            OrderPaid = true,
                            OrderPlaced = new DateTime(2022, 10, 27, 9, 26, 47, 755, DateTimeKind.Utc).AddTicks(1500),
                            OrderTotal = 400,
                            UserId = new Guid("a441eb40-9636-4ee6-be49-a66c5ec1330b")
                        },
                        new
                        {
                            Id = new Guid("86d3a045-b42d-4854-8150-d6a374948b6e"),
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            OrderPaid = true,
                            OrderPlaced = new DateTime(2022, 10, 27, 9, 26, 47, 755, DateTimeKind.Utc).AddTicks(1518),
                            OrderTotal = 135,
                            UserId = new Guid("ac3cfaf5-34fd-4e4d-bc04-ad1083ddc340")
                        },
                        new
                        {
                            Id = new Guid("771cca4b-066c-4ac7-b3df-4d12837fe7e0"),
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            OrderPaid = true,
                            OrderPlaced = new DateTime(2022, 10, 27, 9, 26, 47, 755, DateTimeKind.Utc).AddTicks(1531),
                            OrderTotal = 85,
                            UserId = new Guid("d97a15fc-0d32-41c6-9ddf-62f0735c4c1c")
                        },
                        new
                        {
                            Id = new Guid("3dcb3ea0-80b1-4781-b5c0-4d85c41e55a6"),
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            OrderPaid = true,
                            OrderPlaced = new DateTime(2022, 10, 27, 9, 26, 47, 755, DateTimeKind.Utc).AddTicks(1545),
                            OrderTotal = 245,
                            UserId = new Guid("4ad901be-f447-46dd-bcf7-dbe401afa203")
                        },
                        new
                        {
                            Id = new Guid("e6a2679c-79a3-4ef1-a478-6f4c91b405b6"),
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            OrderPaid = true,
                            OrderPlaced = new DateTime(2022, 10, 27, 9, 26, 47, 755, DateTimeKind.Utc).AddTicks(1558),
                            OrderTotal = 142,
                            UserId = new Guid("7aeb2c01-fe8e-4b84-a5ba-330bdf950f5c")
                        },
                        new
                        {
                            Id = new Guid("f5a6a3a0-4227-4973-abb5-a63fbe725923"),
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            OrderPaid = true,
                            OrderPlaced = new DateTime(2022, 10, 27, 9, 26, 47, 755, DateTimeKind.Utc).AddTicks(1575),
                            OrderTotal = 40,
                            UserId = new Guid("f5a6a3a0-4227-4973-abb5-a63fbe725923")
                        },
                        new
                        {
                            Id = new Guid("ba0eb0ef-b69b-46fd-b8e2-41b4178ae7cb"),
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            OrderPaid = true,
                            OrderPlaced = new DateTime(2022, 10, 27, 9, 26, 47, 755, DateTimeKind.Utc).AddTicks(1589),
                            OrderTotal = 116,
                            UserId = new Guid("7aeb2c01-fe8e-4b84-a5ba-330bdf950f5c")
                        });
                });

            modelBuilder.Entity("AppraisalTool.Domain.Entities.Status", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("StatusTitle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Status");
                });

            modelBuilder.Entity("AppraisalTool.Domain.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("AddedBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("AddedOn")
                        .HasColumnType("datetime2");

                    b.Property<int>("BranchId")
                        .HasColumnType("int");

                    b.Property<int?>("DeletedBy")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DeletedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("JoinDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("LastAppraisalDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("PasswordHash")
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("PasswordSalt")
                        .HasColumnType("varbinary(max)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<int?>("UpdatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedOn")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("AddedBy");

                    b.HasIndex("BranchId");

                    b.HasIndex("DeletedBy");

                    b.HasIndex("RoleId");

                    b.ToTable("User");
                });

            modelBuilder.Entity("AppraisalTool.Domain.Entities.UserAuthorityMapping", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("ReportingAuthorityId")
                        .HasColumnType("int");

                    b.Property<int>("ReviewingAuthorityId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ReportingAuthorityId");

                    b.HasIndex("ReviewingAuthorityId");

                    b.HasIndex("UserId");

                    b.ToTable("UserAuthorityMappings");
                });

            modelBuilder.Entity("AppraisalTool.Domain.Entities.UserJobRoles", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("IsPrimary")
                        .HasColumnType("bit");

                    b.Property<bool>("IsSecondary")
                        .HasColumnType("bit");

                    b.Property<int>("JobRoleId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("JobRoleId");

                    b.HasIndex("UserId");

                    b.ToTable("UserJobRoles");
                });

            modelBuilder.Entity("AppraisalTool.Domain.Entities.UserRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("UserRole");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Role = "ADMINISTRATOR"
                        },
                        new
                        {
                            Id = 2,
                            Role = "REPORTINGAUTHORITY"
                        },
                        new
                        {
                            Id = 3,
                            Role = "REVIEWINGAUTHORITY"
                        });
                });

            modelBuilder.Entity("AppraisalTool.Domain.Entities.Appraisal", b =>
                {
                    b.HasOne("AppraisalTool.Domain.Entities.FinancialYear", "FinancialYear")
                        .WithMany()
                        .HasForeignKey("FinancialYearId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("AppraisalTool.Domain.Entities.Status", "Status")
                        .WithMany()
                        .HasForeignKey("StatusId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("AppraisalTool.Domain.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("FinancialYear");

                    b.Navigation("Status");

                    b.Navigation("User");
                });

            modelBuilder.Entity("AppraisalTool.Domain.Entities.Event", b =>
                {
                    b.HasOne("AppraisalTool.Domain.Entities.Category", "Category")
                        .WithMany("Events")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("AppraisalTool.Domain.Entities.KraDetail", b =>
                {
                    b.HasOne("AppraisalTool.Domain.Entities.Kra", "KraType")
                        .WithMany()
                        .HasForeignKey("KraTypeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("KraType");
                });

            modelBuilder.Entity("AppraisalTool.Domain.Entities.MenuRoleMapping", b =>
                {
                    b.HasOne("AppraisalTool.Domain.Entities.UserRole", "UserRole")
                        .WithMany("MenuRoleMappings")
                        .HasForeignKey("Menu_id")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("AppraisalTool.Domain.Entities.MenuList", "MenuList")
                        .WithMany()
                        .HasForeignKey("Role_id")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("MenuList");

                    b.Navigation("UserRole");
                });

            modelBuilder.Entity("AppraisalTool.Domain.Entities.User", b =>
                {
                    b.HasOne("AppraisalTool.Domain.Entities.User", "AddedByUser")
                        .WithMany()
                        .HasForeignKey("AddedBy")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("AppraisalTool.Domain.Entities.Branch", "Branch")
                        .WithMany()
                        .HasForeignKey("BranchId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("AppraisalTool.Domain.Entities.User", "DeletedByUser")
                        .WithMany()
                        .HasForeignKey("DeletedBy")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("AppraisalTool.Domain.Entities.UserRole", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("AddedByUser");

                    b.Navigation("Branch");

                    b.Navigation("DeletedByUser");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("AppraisalTool.Domain.Entities.UserAuthorityMapping", b =>
                {
                    b.HasOne("AppraisalTool.Domain.Entities.User", "ReportingAuthority")
                        .WithMany()
                        .HasForeignKey("ReportingAuthorityId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("AppraisalTool.Domain.Entities.User", "ReviewingAuthority")
                        .WithMany()
                        .HasForeignKey("ReviewingAuthorityId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("AppraisalTool.Domain.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("ReportingAuthority");

                    b.Navigation("ReviewingAuthority");

                    b.Navigation("User");
                });

            modelBuilder.Entity("AppraisalTool.Domain.Entities.UserJobRoles", b =>
                {
                    b.HasOne("AppraisalTool.Domain.Entities.JobRoles", "JobRole")
                        .WithMany()
                        .HasForeignKey("JobRoleId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("AppraisalTool.Domain.Entities.User", "RoleUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("JobRole");

                    b.Navigation("RoleUser");
                });

            modelBuilder.Entity("AppraisalTool.Domain.Entities.Category", b =>
                {
                    b.Navigation("Events");
                });

            modelBuilder.Entity("AppraisalTool.Domain.Entities.UserRole", b =>
                {
                    b.Navigation("MenuRoleMappings");
                });
#pragma warning restore 612, 618
        }
    }
}
