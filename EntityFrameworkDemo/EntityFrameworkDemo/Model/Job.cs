namespace EntityFrameworkDemo.Model
{
    using System.Collections;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Job", Schema = "HR")]
    public class Job : VersionedEntity
    {
        [Required]
        [MaxLength(35)]
        public virtual string JobTitle { get; set; }

        public virtual decimal? MinSalary { get; set; }

        public virtual decimal? MaxSalary { get; set; }

    }
}
