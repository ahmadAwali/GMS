using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Vacation : BaseEntity
    {
        public string Day { get; set; }
        public DateTime Date { get; set; }

    }
}
