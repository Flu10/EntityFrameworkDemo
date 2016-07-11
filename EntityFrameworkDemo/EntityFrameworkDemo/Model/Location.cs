namespace EntityFrameworkDemo.Model
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Location", Schema = "HR")]
    public class Location : VersionedEntity
    {

        [Index("UX_StreetAddressAndPostalCode", 1, IsUnique = true)]
        [MaxLength(100)]
        public virtual string StreetAddress { get; set; }

        [Index("UX_StreetAddressAndPostalCode", 2, IsUnique = true)]
        [MaxLength(30)]
        public virtual string PostalCode { get; set; }
        
        [Required]
        [MaxLength(30)]
        public virtual string City { get; set; }
        
        public virtual string StateProvince { get; set; }
    }
}
