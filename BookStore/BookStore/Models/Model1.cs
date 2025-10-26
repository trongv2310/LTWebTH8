using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;

namespace BookStore.Models
{
    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model11")
        {
        }

        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<Tintuc> Tintucs { get; set; }
        public virtual DbSet<Theloaitin> Theloaitins { get; set; }
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
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
