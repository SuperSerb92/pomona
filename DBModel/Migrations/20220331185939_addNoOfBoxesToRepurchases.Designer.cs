﻿// <auto-generated />
using System;
using DBModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DBModel.Migrations
{
    [DbContext(typeof(DbModelContext))]
    [Migration("20220331185939_addNoOfBoxesToRepurchases")]
    partial class addNoOfBoxesToRepurchases
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.6")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DBModel.Models.BarCodeGenerator", b =>
                {
                    b.Property<int>("EmployeeID")
                        .HasColumnType("int");

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.Property<int>("PlotListId")
                        .HasColumnType("int");

                    b.Property<int>("PackagingId")
                        .HasColumnType("int");

                    b.Property<int>("Rbr")
                        .HasColumnType("int");

                    b.Property<int>("CultureId")
                        .HasColumnType("int");

                    b.Property<int>("CultureTypeId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateGenerated")
                        .HasColumnType("datetime2");

                    b.Property<string>("BarCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Bruto")
                        .HasColumnType("int");

                    b.Property<int>("IndPrint")
                        .HasColumnType("int");

                    b.Property<int>("IndStorn")
                        .HasColumnType("int");

                    b.Property<int>("LoggedUserID")
                        .HasColumnType("int");

                    b.Property<int>("MaxRbr")
                        .HasColumnType("int");

                    b.Property<int>("Neto")
                        .HasColumnType("int");

                    b.Property<int?>("PlotId")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<int>("Tara")
                        .HasColumnType("int");

                    b.HasKey("EmployeeID", "UserID", "PlotListId", "PackagingId", "Rbr", "CultureId", "CultureTypeId", "DateGenerated");

                    b.HasIndex("CultureId");

                    b.HasIndex("CultureTypeId");

                    b.HasIndex("PackagingId");

                    b.HasIndex("PlotListId");

                    b.HasIndex("UserID");

                    b.ToTable("BarCodeGenerators");
                });

            modelBuilder.Entity("DBModel.Models.Buyer", b =>
                {
                    b.Property<int>("BuyerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("BuyerName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("BuyerPhoneNumber")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("City")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Email")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Jmbf")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Pib")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("BuyerId");

                    b.ToTable("Buyers");
                });

            modelBuilder.Entity("DBModel.Models.ControlorEmployeesRelation", b =>
                {
                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.Property<int>("EmployeeID")
                        .HasColumnType("int");

                    b.HasKey("UserID", "EmployeeID");

                    b.HasIndex("EmployeeID");

                    b.ToTable("ControlorEmployeesRelations");
                });

            modelBuilder.Entity("DBModel.Models.Culture", b =>
                {
                    b.Property<int>("CultureId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CultureName")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("CultureId");

                    b.ToTable("Cultures");
                });

            modelBuilder.Entity("DBModel.Models.CultureType", b =>
                {
                    b.Property<int>("CultureTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CultureId")
                        .HasColumnType("int");

                    b.Property<string>("CultureTypeName")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("CultureTypeId");

                    b.HasIndex("CultureId");

                    b.ToTable("CultureTypes");
                });

            modelBuilder.Entity("DBModel.Models.Employee", b =>
                {
                    b.Property<int>("EmployeeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("MiddleName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("PhoneNumber")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Recomendation")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Surname")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("EmployeeID");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("DBModel.Models.Group", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("GroupName")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("Id");

                    b.ToTable("Groups");
                });

            modelBuilder.Entity("DBModel.Models.Packaging", b =>
                {
                    b.Property<int>("PackagingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("PackagingType")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<int>("Tara")
                        .HasColumnType("int");

                    b.HasKey("PackagingId");

                    b.ToTable("Packagings");
                });

            modelBuilder.Entity("DBModel.Models.Plot", b =>
                {
                    b.Property<int>("PlotId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("PlotLabel")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<int>("PlotListId")
                        .HasColumnType("int");

                    b.Property<string>("PlotName")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("PlotId");

                    b.HasIndex("PlotListId");

                    b.ToTable("Plots");
                });

            modelBuilder.Entity("DBModel.Models.PlotList", b =>
                {
                    b.Property<int>("PlotListId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("PlotListName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PlotListId");

                    b.ToTable("PlotList");
                });

            modelBuilder.Entity("DBModel.Models.ProfitLossReport", b =>
                {
                    b.Property<int>("BrojBeraca")
                        .HasColumnType("int");

                    b.Property<int>("BrojKutija")
                        .HasColumnType("int");

                    b.Property<DateTime>("Datum")
                        .HasColumnType("datetime2");

                    b.Property<int>("NetoOtkup")
                        .HasColumnType("int");

                    b.Property<int>("Prihod")
                        .HasColumnType("int");

                    b.Property<int>("Profit")
                        .HasColumnType("int");

                    b.Property<int>("ProsecanTrosakPoBeracu")
                        .HasColumnType("int");

                    b.Property<int>("ProsecnaCenaKost")
                        .HasColumnType("int");

                    b.Property<int>("ProsecnaPC")
                        .HasColumnType("int");

                    b.Property<int>("Trosak")
                        .HasColumnType("int");

                    b.Property<decimal>("TrosakProc")
                        .HasColumnType("decimal(18,2)");

                    b.ToTable("ProfitLossReports");
                });

            modelBuilder.Entity("DBModel.Models.Repurchase", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BuyerId")
                        .HasColumnType("int");

                    b.Property<int>("CultureId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("Difference")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Income")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Neto")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("NetoShipped")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("NoOfBoxes")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("Repurchases");
                });

            modelBuilder.Entity("DBModel.Models.SummaryReport", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Culture")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CultureId")
                        .HasColumnType("int");

                    b.Property<string>("CultureType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CultureTypeId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<string>("NameSurname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Neto")
                        .HasColumnType("int");

                    b.Property<int>("NoOfBoxes")
                        .HasColumnType("int");

                    b.Property<int>("PlotListId")
                        .HasColumnType("int");

                    b.Property<string>("PlotListName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("SummaryReports");
                });

            modelBuilder.Entity("DBModel.Models.SummaryReportRepurchase", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Buyer")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Comment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CultureName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("Income")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Net")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("NetBuyed")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("NetDifference")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("NoOfBoxes")
                        .HasColumnType("int");

                    b.Property<bool?>("Paid")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("PaidDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("SummaryReportsRepurchases");
                });

            modelBuilder.Entity("DBModel.Models.User", b =>
                {
                    b.Property<int>("UserID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FarmName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FarmNo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IdGroup")
                        .HasColumnType("int");

                    b.Property<int>("IndLogged")
                        .HasColumnType("int");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RepeatedPassword")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserID");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("DBModel.Models.WorkEvaluation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("EmployeeID")
                        .HasColumnType("int");

                    b.Property<int>("Evaluation")
                        .HasColumnType("int");

                    b.Property<int>("ExpenseKg")
                        .HasColumnType("int");

                    b.Property<string>("NameSurname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Neto")
                        .HasColumnType("int");

                    b.Property<int>("NoOfBoxes")
                        .HasColumnType("int");

                    b.Property<int>("PayPerDay")
                        .HasColumnType("int");

                    b.Property<int>("Total")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeID");

                    b.ToTable("WorkEvaluations");
                });

            modelBuilder.Entity("DBModel.Models.BarCodeGenerator", b =>
                {
                    b.HasOne("DBModel.Models.Culture", "Culture")
                        .WithMany()
                        .HasForeignKey("CultureId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DBModel.Models.CultureType", "CultureType")
                        .WithMany()
                        .HasForeignKey("CultureTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DBModel.Models.Employee", "Employee")
                        .WithMany()
                        .HasForeignKey("EmployeeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DBModel.Models.Packaging", "Packaging")
                        .WithMany()
                        .HasForeignKey("PackagingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DBModel.Models.PlotList", "PlotList")
                        .WithMany()
                        .HasForeignKey("PlotListId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DBModel.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Culture");

                    b.Navigation("CultureType");

                    b.Navigation("Employee");

                    b.Navigation("Packaging");

                    b.Navigation("PlotList");

                    b.Navigation("User");
                });

            modelBuilder.Entity("DBModel.Models.ControlorEmployeesRelation", b =>
                {
                    b.HasOne("DBModel.Models.Employee", "Employee")
                        .WithMany()
                        .HasForeignKey("EmployeeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DBModel.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");

                    b.Navigation("User");
                });

            modelBuilder.Entity("DBModel.Models.CultureType", b =>
                {
                    b.HasOne("DBModel.Models.Culture", "Culture")
                        .WithMany()
                        .HasForeignKey("CultureId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Culture");
                });

            modelBuilder.Entity("DBModel.Models.Plot", b =>
                {
                    b.HasOne("DBModel.Models.PlotList", "PlotList")
                        .WithMany()
                        .HasForeignKey("PlotListId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("PlotList");
                });

            modelBuilder.Entity("DBModel.Models.WorkEvaluation", b =>
                {
                    b.HasOne("DBModel.Models.Employee", "Employee")
                        .WithMany()
                        .HasForeignKey("EmployeeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");
                });
#pragma warning restore 612, 618
        }
    }
}
