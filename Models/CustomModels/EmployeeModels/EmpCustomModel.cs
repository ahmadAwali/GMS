using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Models.CustomModels.EmployeeModel
{
    public class EmpCustomModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; } 
        public string IsTrainer { get; set; }
        public string TitleName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public byte[] Image { get; set; }
    }
}