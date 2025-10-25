using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;

namespace LTWe08_Bai01.Models
{
    public partial class BookStore : DbContext
    {
        public BookStore()
            : base("name=BookStore")
        {
        }

        public virtual DbSet<Tintuc> Tintucs { get; set; }
        public virtual DbSet<Theloaitin> Theloaitins { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tintuc>()
                .HasOptional(e => e.Tintuc1)
                .WithRequired(e => e.Tintuc2);
        }
        public void InsertOnSubmit(Theloaitin theloaitin)
        {
            Theloaitins.Add(theloaitin);
        }
        public void UpdateOnSubmit(Theloaitin theloaitin)
        {
            Theloaitins.AddOrUpdate(theloaitin);
        }
        public void DeleteOnSubmit(Theloaitin theloaitin)
        {
            Theloaitins.Remove(theloaitin);
        }
        public void SubmitChanges()
        {
            SaveChanges();
        }
    }
}
