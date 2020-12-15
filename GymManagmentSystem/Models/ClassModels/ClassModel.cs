using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GymManagmentSystem.Models.ClassModels
{
    public class ClassModel
    {
        public int Id { get; set; }
        public int TrainerId { get; set; }
        public string TrainerName { get; set; }
        public int SportId { get; set; }
        public string SportName { get; set; }
        public string Days { get; set; }
        public string Hours { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public decimal Membership { get; set; }
        public string Hall { get; set; }
        public int Count { get; set; }
        public int MaxCount { get; set; }
        public string[] HouersTime { get; set; } = StringArrays.Times;
        public string[] DaysTime { get; set; } = StringArrays.Days;
    }
}