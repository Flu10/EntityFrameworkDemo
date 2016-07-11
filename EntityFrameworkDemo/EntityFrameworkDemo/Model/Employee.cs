namespace EntityFrameworkDemo.Model
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Diagnostics;
    using Nomenclatures;

    [Table("Employee", Schema = "HR")]
    public class Employee : VersionedEntity
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

        public virtual long? LevelId { get; set; }
        [ForeignKey("LevelId")]
        public virtual Level Level { get; set; }

        public virtual long? GenderId { get; set; }
        [ForeignKey("GenderId")]
        public virtual Gender Gender { get; set; }

        [NotMapped]
        public  string FullName { get {return FirstName+' '+LastName; } }


        public virtual ICollection<Project> Projects { get; set; }

        
    }
}
