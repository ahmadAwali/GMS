using Models;
using Models.CustomModels.ClassModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DataAccessTools.CustomRepositories
{
    public class ClassRepository
    {
        #region Attribute

        private readonly GMSDBContext _dbContext;
        private IDbSet<Class> Entity;

        #endregion

        public ClassRepository()
        {
            _dbContext = new GMSDBContext();
            Entity = _dbContext.Set<Class>();
        }

        #region Methods

        public List<ClassCustomModel> GetClasses()
        {
            List<ClassCustomModel> classes = new List<ClassCustomModel>();
            var sportsList = Entity.Select(i => new { i.ID, i.Name, i.Employee.Name1, i.Employee.Name4, i.Days, i.Hours }).ToList();

            foreach (var item in sportsList)
            {
                string name = item.Name;
                name = name.Substring(0, name.IndexOf("Trainer") - 1);
                classes.Add(new ClassCustomModel
                {
                    Id = item.ID,
                    Name = name,
                    DayTime = item.Days + "/" + item.Hours,
                    Trainer = item.Name1 + " " + item.Name4
                });
            }

            return classes;

        }

        public string[] GetUnavailableTimes(int trainerId, string days)
        {
            try
            {
                string[] classesTime;
                classesTime = Entity.Where(t => t.EmployeeId == trainerId && t.Days == days).Select(h => h.Hours).ToArray();

                if (classesTime.Any())
                {
                    return classesTime;
                }
                else
                {
                    return null;
                }
            }
            catch // TO DO handle the exiption
            {
                return null;
            }
        }

        public List<Class> Read()
        {
            try
            {
                return Entity.Include(e=>e.Employee).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        #endregion
    }
}
