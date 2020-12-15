using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class PersonBaseEntity : BaseEntity
    {
        public string Name1 { get; set; }
        public string Name2 { get; set; }
        public string Name3 { get; set; }
        public string Name4 { get; set; }
        public String Gender { get; set; }
        public string NationalID { get; set; }
        public DateTime BirthDate { get; set; }
        public string MartialState { get; set; }
        public string Address { get; set; }
        public string PhoneNo1 { get; set; }
        public string PhoneNo2 { get; set; }
        public string Email { get; set; }
        public byte[] Image { get; set; }
        public byte[] IdentityImage { get; set; }

    }
}
