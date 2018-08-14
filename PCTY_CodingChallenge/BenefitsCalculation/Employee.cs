namespace BenefitsCalculation
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PCTYBenefitsData.Employee")]
    public partial class Employee
    {
        public int id { get; set; }

        public int? employeeNumber { get; set; }

        [Required]
        [StringLength(100)]
        public string firstName { get; set; }

        [Required]
        [StringLength(100)]
        public string lastName { get; set; }

        public bool hasDependent { get; set; }

        public double cost { get; set; }

        public double salary { get; set; }

        public virtual Dependent Dependent { get; set; }
    }
}
