﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RieltBaza.dataFiles
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class RieltorEntities : DbContext
    {
        public RieltorEntities()
            : base("name=RieltorEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Adress> Adress { get; set; }
        public virtual DbSet<City> City { get; set; }
        public virtual DbSet<Client> Client { get; set; }
        public virtual DbSet<Comment> Comment { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<Objects> Objects { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<Steet> Steet { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<Tabel> Tabel { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<Client_City> Client_City { get; set; }
        public virtual DbSet<comm> comm { get; set; }
        public virtual DbSet<Emp_Citys> Emp_Citys { get; set; }
    }
}
