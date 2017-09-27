using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace REST_Operation.Models
{
    public class MemberContext : DbContext
    {
        public MemberContext() : base("MemberContext")
        { }

        public DbSet<Member> Members { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("Saurabh");
            base.OnModelCreating(modelBuilder);
        }
    }
}