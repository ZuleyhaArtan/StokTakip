﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Stok_Takip.Models.Entity
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class stok_takipEntities : DbContext
    {
        public stok_takipEntities()
            : base("name=stok_takipEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Birimler> Birimler { get; set; }
        public virtual DbSet<Kategoriler> Kategoriler { get; set; }
        public virtual DbSet<Markalar> Markalar { get; set; }
        public virtual DbSet<Musteriler> Musteriler { get; set; }
        public virtual DbSet<Satislar> Satislar { get; set; }
        public virtual DbSet<Sepet> Sepet { get; set; }
        public virtual DbSet<Urunler> Urunler { get; set; }
        public virtual DbSet<Kullanicilar> Kullanicilar { get; set; }
    }
}
