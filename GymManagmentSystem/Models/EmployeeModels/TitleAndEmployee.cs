using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Models;

namespace GymManagmentSystem.Models.EmployeeModels
{
    public class TitleAndEmployee
    {
        public List<TitlesOfEmp> titles { get; set; }
        public Employee employee { get; set; }
    }
}