namespace BenefitsCalculation
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PCTYBenefitsData.Dependent")]
    public partial class Dependent
    {
        public int id { get; set; }

        [Required]
        [StringLength(100)]
        public string firstName { get; set; }

        [Required]
        [StringLength(100)]
        public string lastName { get; set; }

        public int? employeeID { get; set; }

        public double cost { get; set; }

        public virtual Employee Employee { get; set; }
    }
}
