using System;

namespace Models
{
    public class BaseEntity
    {
        
        public int ID { get; set; }
        public DateTime AddedOn { get; set; } = DateTime.Now;
        public int AddedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public int? ModifiedBy { get; set; }
    }
}
