﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApplication1.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class MyDealDBEntities : DbContext
    {
        public MyDealDBEntities()
            : base("name=MyDealDBEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<URLMapper> URLMappers { get; set; }
        public virtual DbSet<FileList> FileLists { get; set; }
        public virtual DbSet<PNL> PNLs { get; set; }
    }
}
