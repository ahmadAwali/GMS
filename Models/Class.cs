using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    public class Class : BaseEntity
    {
        public string Name { get; set; }
        public string Days { get; set; }
        public string Hours { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public decimal Cost { get; set; }
        public string Hall { get; set; }
        public int Count { get; set; }
        public int MaxCount { get; set; }


        public int EmployeeId { get; set; }
        [ForeignKey("EmployeeId")]
        public virtual Employee Employee { get; set; }


        public virtual ICollection<Member> Members { set; get; }
    }
}
