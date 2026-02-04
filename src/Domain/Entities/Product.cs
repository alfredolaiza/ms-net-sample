using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backend_api.Domain.Entities;

//Agregar entidad Product heredando de BaseAuditableEntity
public class Product : BaseAuditableEntity
{   
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public decimal Price { get; set; }
    public int Stock { get; set; }
}
