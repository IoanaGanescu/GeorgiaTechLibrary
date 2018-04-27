﻿using GeorgiaTechLibrary.Models.Employees;
using GeorgiaTechLibrary.Models.Items;
using GeorgiaTechLibrary.Models.Members;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeorgiaTechLibrary.Models
{
    public class LibraryContext : DbContext
    {
        public DbSet<Item> Items { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Loan> Loans { get; set; }
        public DbSet<LoanRule> LoanRules { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=Kraka.ucn.dk;Initial Catalog=Psu0218_1055997;user id=Psu0218_1055997; password=Password1!");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Book>();
            builder.Entity<Map>();
            builder.Entity<Student>();
            builder.Entity<Teacher>();
            builder.Entity<ChiefLibrarian>();
            builder.Entity<CheckOutStaff>();
            builder.Entity<DepartmentLibrarian>();
            builder.Entity<ReferenceLibrarian>();
            builder.Entity<AssistantLibrarian>();

            base.OnModelCreating(builder);

        }
    }
}