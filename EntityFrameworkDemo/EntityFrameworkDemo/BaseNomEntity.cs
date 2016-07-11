namespace EntityFrameworkDemo
{
    using System.ComponentModel.DataAnnotations;

    public class BaseNomEntity
    {
        [Key]
        public virtual long Id { get; set; }

        public virtual string Name { get; set; }
    }
}
