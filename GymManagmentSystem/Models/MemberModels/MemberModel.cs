using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GymManagmentSystem.Models.MemberModels
{
    public class MemberModel
    {
        public int Id { get; set; }
        public string Name1 { get; set; }
        public string Name2 { get; set; }
        public string Name3 { get; set; }
        public string Name4 { get; set; }
        public string Gender { get; set; }
        public string NationalID { get; set; }
        public DateTime BirthDate { get; set; }
        public string MartialState { get; set; }
        public string Address { get; set; }
        public string PhoneNo1 { get; set; }
        public string PhoneNo2 { get; set; }
        public string Email { get; set; }
        public int ClassId { get; set; }
        public bool IsStarted { get; set; }
        public DateTime MembershipStart { get; set; }
        public DateTime MembershipExpired { get; set; }
        
    }
}