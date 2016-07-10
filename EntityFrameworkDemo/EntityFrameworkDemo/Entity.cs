namespace EntityFrameworkDemo
{
    using System.ComponentModel.DataAnnotations;

    public class Entity
    {
        [Key]
        public virtual long Id { get; set; }
    }
}
