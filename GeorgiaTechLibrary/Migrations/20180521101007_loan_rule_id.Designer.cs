﻿// <auto-generated />
using GeorgiaTechLibrary.Models;
using GeorgiaTechLibrary.Models.Items;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using Microsoft.EntityFrameworkCore.ValueGeneration;
using System;

namespace GeorgiaTechLibraryAPI.Migrations
{
    [DbContext(typeof(LibraryContext))]
    [Migration("20180521101007_loan_rule_id")]
    partial class loan_rule_id
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.2-rtm-10011")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("GeorgiaTechLibrary.Models.Employees.Employee", b =>
                {
                    b.Property<long>("Ssn");

                    b.Property<string>("Address")
                        .IsRequired();

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<string>("Password")
                        .IsRequired();

                    b.Property<string>("Phone")
                        .IsRequired();

                    b.Property<string>("PictureId");

                    b.HasKey("Ssn");

                    b.ToTable("Employees");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Employee");
                });

            modelBuilder.Entity("GeorgiaTechLibrary.Models.Items.Item", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<int>("ItemCondition");

                    b.Property<int>("ItemInfoId");

                    b.Property<int>("ItemStatus");

                    b.Property<int>("RentStatus");

                    b.HasKey("Id");

                    b.HasIndex("ItemInfoId");

                    b.ToTable("Items");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Item");
                });

            modelBuilder.Entity("GeorgiaTechLibrary.Models.Items.ItemInfo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Author")
                        .IsRequired();

                    b.Property<string>("Description")
                        .IsRequired();

                    b.Property<string>("Title")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("ItemInfos");
                });

            modelBuilder.Entity("GeorgiaTechLibrary.Models.Loan", b =>
                {
                    b.Property<int>("LoanID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("EndDate");

                    b.Property<bool>("IsReturned");

                    b.Property<Guid>("ItemId");

                    b.Property<long>("MemberSsn");

                    b.Property<DateTime>("StartDate");

                    b.HasKey("LoanID");

                    b.HasIndex("ItemId");

                    b.HasIndex("MemberSsn");

                    b.ToTable("Loans");
                });

            modelBuilder.Entity("GeorgiaTechLibrary.Models.Members.LoanRule", b =>
                {
                    b.Property<int>("Id");

                    b.Property<short>("BookLimit");

                    b.Property<short>("GracePeriod");

                    b.Property<short>("LoanTime");

                    b.HasKey("Id");

                    b.ToTable("LoanRules");
                });

            modelBuilder.Entity("GeorgiaTechLibrary.Models.Members.Member", b =>
                {
                    b.Property<long>("Ssn");

                    b.Property<string>("Address")
                        .IsRequired();

                    b.Property<DateTime>("CardExpirationDate");

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<int?>("LoanRuleId");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<string>("Password")
                        .IsRequired();

                    b.Property<string>("Phone")
                        .IsRequired();

                    b.Property<string>("PictureId");

                    b.HasKey("Ssn");

                    b.HasIndex("LoanRuleId");

                    b.ToTable("Members");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Member");
                });

            modelBuilder.Entity("GeorgiaTechLibrary.Models.Employees.AssistantLibrarian", b =>
                {
                    b.HasBaseType("GeorgiaTechLibrary.Models.Employees.Employee");


                    b.ToTable("AssistantLibrarian");

                    b.HasDiscriminator().HasValue("AssistantLibrarian");
                });

            modelBuilder.Entity("GeorgiaTechLibrary.Models.Employees.CheckOutStaff", b =>
                {
                    b.HasBaseType("GeorgiaTechLibrary.Models.Employees.Employee");


                    b.ToTable("CheckOutStaff");

                    b.HasDiscriminator().HasValue("CheckOutStaff");
                });

            modelBuilder.Entity("GeorgiaTechLibrary.Models.Employees.ChiefLibrarian", b =>
                {
                    b.HasBaseType("GeorgiaTechLibrary.Models.Employees.Employee");


                    b.ToTable("ChiefLibrarian");

                    b.HasDiscriminator().HasValue("ChiefLibrarian");
                });

            modelBuilder.Entity("GeorgiaTechLibrary.Models.Employees.DepartmentLibrarian", b =>
                {
                    b.HasBaseType("GeorgiaTechLibrary.Models.Employees.Employee");


                    b.ToTable("DepartmentLibrarian");

                    b.HasDiscriminator().HasValue("DepartmentLibrarian");
                });

            modelBuilder.Entity("GeorgiaTechLibrary.Models.Employees.ReferenceLibrarian", b =>
                {
                    b.HasBaseType("GeorgiaTechLibrary.Models.Employees.Employee");


                    b.ToTable("ReferenceLibrarian");

                    b.HasDiscriminator().HasValue("ReferenceLibrarian");
                });

            modelBuilder.Entity("GeorgiaTechLibrary.Models.Items.Book", b =>
                {
                    b.HasBaseType("GeorgiaTechLibrary.Models.Items.Item");

                    b.Property<string>("ISBN");

                    b.ToTable("Book");

                    b.HasDiscriminator().HasValue("Book");
                });

            modelBuilder.Entity("GeorgiaTechLibrary.Models.Items.Map", b =>
                {
                    b.HasBaseType("GeorgiaTechLibrary.Models.Items.Item");


                    b.ToTable("Map");

                    b.HasDiscriminator().HasValue("Map");
                });

            modelBuilder.Entity("GeorgiaTechLibrary.Models.Members.Student", b =>
                {
                    b.HasBaseType("GeorgiaTechLibrary.Models.Members.Member");


                    b.ToTable("Student");

                    b.HasDiscriminator().HasValue("Student");
                });

            modelBuilder.Entity("GeorgiaTechLibrary.Models.Members.Teacher", b =>
                {
                    b.HasBaseType("GeorgiaTechLibrary.Models.Members.Member");


                    b.ToTable("Teacher");

                    b.HasDiscriminator().HasValue("Teacher");
                });

            modelBuilder.Entity("GeorgiaTechLibrary.Models.Items.Item", b =>
                {
                    b.HasOne("GeorgiaTechLibrary.Models.Items.ItemInfo", "ItemInfo")
                        .WithMany()
                        .HasForeignKey("ItemInfoId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("GeorgiaTechLibrary.Models.Loan", b =>
                {
                    b.HasOne("GeorgiaTechLibrary.Models.Items.Item", "Item")
                        .WithMany()
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("GeorgiaTechLibrary.Models.Members.Member", "Member")
                        .WithMany()
                        .HasForeignKey("MemberSsn")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("GeorgiaTechLibrary.Models.Members.Member", b =>
                {
                    b.HasOne("GeorgiaTechLibrary.Models.Members.LoanRule", "LoanRule")
                        .WithMany("Members")
                        .HasForeignKey("LoanRuleId");
                });
#pragma warning restore 612, 618
        }
    }
}
