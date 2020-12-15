using Models.CustomModels.ClassModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GymManagmentSystem.Models.MemberModels
{
    public class ListMemberModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime ExbiryDate { get; set; }
        public byte[] Image { get; set; }
        public List<ClassCustomModel> Classes { get; set; }
    }
}