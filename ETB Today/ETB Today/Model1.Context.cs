﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ETB_Today
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class Emp_travel_booking_systemEntities : DbContext
    {
        public Emp_travel_booking_systemEntities()
            : base("name=Emp_travel_booking_systemEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<admin> admins { get; set; }
        public virtual DbSet<employee> employees { get; set; }
        public virtual DbSet<manager> managers { get; set; }
        public virtual DbSet<travelagent> travelagents { get; set; }
        public virtual DbSet<travelrequest> travelrequests { get; set; }
    }
}