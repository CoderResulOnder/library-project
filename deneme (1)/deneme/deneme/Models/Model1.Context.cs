﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace deneme.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class libraryProjectEntities : DbContext
    {
        public libraryProjectEntities()
            : base("name=libraryProjectEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<address> address { get; set; }
        public virtual DbSet<author> author { get; set; }
        public virtual DbSet<book> book { get; set; }
        public virtual DbSet<bookLocation> bookLocation { get; set; }
        public virtual DbSet<category> category { get; set; }
        public virtual DbSet<employee> employee { get; set; }
        public virtual DbSet<library> library { get; set; }
        public virtual DbSet<member> member { get; set; }
        public virtual DbSet<publishingHouse> publishingHouse { get; set; }
        public virtual DbSet<register> register { get; set; }
        public virtual DbSet<trustGet> trustGet { get; set; }
    }
}