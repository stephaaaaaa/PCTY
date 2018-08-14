namespace BenefitsCalculation
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class BenefitsContext : DbContext
    {
        public BenefitsContext()
            : base("name=BenefitsContext")
        {
        }

        public virtual DbSet<Dependent> Dependents { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Dependent>()
                .Property(e => e.firstName)
                .IsUnicode(false);

            modelBuilder.Entity<Dependent>()
                .Property(e => e.lastName)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.lastName)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.firstName)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .HasOptional(e => e.Dependent)
                .WithRequired(e => e.Employee);
        }
    }
}
