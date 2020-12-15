using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Title : BaseEntity
    {
        public string Name { get; set; }

        public bool IsSport { get; set; }

        public virtual List<Employee> Employees { get; set; }
    }
}
