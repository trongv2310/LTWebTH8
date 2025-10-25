using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;

namespace LTWeb09_Bai03_Buoi08.Models
{
    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
                .Property(e => e.City)
                .IsUnicode(false);
        }
        public void InsertOnSubmit(Employee emp)
        {
            Employees.Add(emp);
        }
        public void UpdateOnSubmit(Employee emp)
        {
            Employees.AddOrUpdate(emp);
        }
        public void DeleteOnSubmit(Employee emp)
        {
            Employees.Remove(emp);
        }
        public void SubmitChanges()
        {
            SaveChanges();
        }
    }
}
