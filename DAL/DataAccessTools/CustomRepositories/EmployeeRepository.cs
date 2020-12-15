using Models;
using Models.CustomModels.ClassModels;
using Models.CustomModels.EmployeeModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace DAL.DataAccessTools.CustomRepositories
{
    public class EmployeeRepository
    {
        #region Attribute

        private readonly GMSDBContext _dbContext;
        private IDbSet<Employee> Entity;

        #endregion

        public EmployeeRepository()
        {
            _dbContext = new GMSDBContext();
            Entity = _dbContext.Set<Employee>();
        }

        #region Methods

        public List<EmpCustomModel> GetEmployees()
        {
            try
            {
                List<EmpCustomModel> employees = new List<EmpCustomModel>();
                var list = Entity.Select(p => new
                {
                    p.ID,
                    p.Name1,
                    p.Name2,
                    p.Name4,
                    p.BirthDate,
                    p.PhoneNo1,
                    p.Email,
                    p.TitleID,
                    p.Image,
                    p.IsTrainer,
                }).ToList();
                TitleRepository titleRepository = new TitleRepository();
                foreach (var item in list)
                {
                    string titleName = titleRepository.GetTitleName(item.TitleID);
                    employees.Add(new EmpCustomModel
                    {
                        Id = item.ID,
                        Name = item.Name1 + " " + item.Name2 + " " + item.Name4,
                        BirthDate = item.BirthDate,
                        Phone = item.PhoneNo1,
                        Email = item.Email,
                        TitleName = titleName,
                        IsTrainer = item.IsTrainer.ToString(),
                        Image = item.Image
                    });
                }
                return employees;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public byte[] GetIdImages(int id)
        {
            byte[] idImage = Entity.Where(p => p.ID == id).Select(p => p.IdentityImage).First();

            return idImage;
        }

        public byte[] GetImages(int id)
        {
            byte[] image = Entity.Where(p => p.ID == id).Select(p => p.Image).First();

            return image;
        }

        public Dictionary<int, string> GetTrainers(int sportId)
        {
            var trainersList = Entity.Where(t => t.TitleID == sportId)
                .Select(p => new { p.ID, p.Name1, p.Name2, p.Name4 }).ToList();
            

            Dictionary<int, string> trainers = new Dictionary<int, string>();

            foreach (var item in trainersList)
            {
                trainers.Add(item.ID, item.Name1 + " " + item.Name2 + " " + item.Name4);
            }

            return trainers;
        }
        #endregion
    }
}
