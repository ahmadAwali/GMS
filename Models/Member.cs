using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Member : PersonBaseEntity
    {
        public int Balance { get; set; }
        public DateTime MembershipStart { get; set; } = DateTime.Now;
        public DateTime MembershipExpired { get; set; }

        public virtual ICollection<Class> Classes { set; get; }

    }
}
