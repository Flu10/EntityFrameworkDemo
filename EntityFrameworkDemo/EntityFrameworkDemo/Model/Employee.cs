namespace EntityFrameworkDemo.Model
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Employee", Schema = "HR")]
    public class Employee : Entity
    {
        public virtual string FirstName { get; set; }

        [Required]
        public virtual string LastName { get; set; }

        //[Required]
        //[MaxLength(25)]
        //[Index("UX_Email", IsUnique = true)]
        public virtual string Email { get; set; }
        
        public virtual string PhoneNumber { get; set; }

        public virtual decimal Salary { get; set; }

        public virtual decimal? CommissionPct { get; set; }

        [Required]
        public virtual DateTime HireDate { get; set; }

        [Required]
        public virtual long? JobId { get; set; }
        [ForeignKey("JobId")]
        public virtual Job Job { get; set; }


        public virtual long? ManagerId { get; set; }
        [ForeignKey("ManagerId")]
        public virtual Employee Manager { get; set; }

        public virtual long? DepartmentId { get; set; }
        [ForeignKey("DepartmentId")]
        public virtual Department Department { get; set; }
    }
}
