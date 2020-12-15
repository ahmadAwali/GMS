using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Employee : PersonBaseEntity
    {
        public bool IsTrainer { get; set; }
        public int TitleID { get; set; }
        public decimal Salary { get; set; }


        public virtual Title Title { set; get; }
        public virtual List<Class> Classes { set; get; }
    }
}
