﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApplication7.Models.Entity
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class hastaneEntities : DbContext
    {
        public hastaneEntities()
            : base("name=hastaneEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Adresler> Adresler { get; set; }
        public virtual DbSet<Birimler> Birimler { get; set; }
        public virtual DbSet<Doktorlar> Doktorlar { get; set; }
        public virtual DbSet<Fiyat> Fiyat { get; set; }
        public virtual DbSet<Iletisim> Iletisim { get; set; }
        public virtual DbSet<Kullanicilar> Kullanicilar { get; set; }
        public virtual DbSet<Randevular> Randevular { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
    }
}