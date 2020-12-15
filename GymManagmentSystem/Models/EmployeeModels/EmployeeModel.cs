using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GymManagmentSystem.Models.EmployeeModels
{
    public class EmployeeModel
    {
        public int ID { get; set; }
        public DateTime AddedOn { get; set; }
        public int AddedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public int? ModifiedBy { get; set; }
        public string Name1 { get; set; }
        public string Name2 { get; set; }
        public string Name3 { get; set; }
        public string Name4 { get; set; }
        public string Gender { get; set; }
        public string NationalID { get; set; }
        public string BirthDate { get; set; }
        public string MartialState { get; set; }
        public string Address { get; set; }
        public string PhoneNo1 { get; set; }
        public string PhoneNo2 { get; set; }
        public string Email { get; set; }
        public string Image { get; set; }
        public string IdentityImage { get; set; }
        public bool IsTrainer { get; set; }
        public int TitleID { get; set; }
        public decimal Salary { get; set; }
    }
}