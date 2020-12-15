using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GymManagmentSystem.Models.MemberModels
{
    public class MemClassModel
    {
        public List<ClassModel> Classes { get; set; }
        public List<ListMemberModel> Mems { get; set; }
    }
}