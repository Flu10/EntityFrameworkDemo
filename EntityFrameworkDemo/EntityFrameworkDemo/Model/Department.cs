namespace EntityFrameworkDemo.Model
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Department", Schema = "HR")]
    public class Department : VersionedEntity
    {
        [Required]
        [MaxLength(30)]
        public virtual string DepartmentName { get; set; }


        public long? LocationId { get; set; }
        [ForeignKey("LocationId")]
        public virtual Location Location { get; set; }


        [InverseProperty("Department")]
        public virtual ICollection<Employee> Employees { get; set; }
        
    }
}
