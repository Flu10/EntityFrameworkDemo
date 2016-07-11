using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkDemo.Model.Nomenclatures
{
    using System.ComponentModel.DataAnnotations.Schema;

    [Table( "Gender", Schema = "Nom")]
    public class Gender : BaseNomEntity
    {
    }
}
