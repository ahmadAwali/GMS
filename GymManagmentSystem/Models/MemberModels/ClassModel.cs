using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GymManagmentSystem.Models.MemberModels
{
    public class ClassModel
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Trainer { get; set; }
        public string DayTime { get; set; }

    }
}