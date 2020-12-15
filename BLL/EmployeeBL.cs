using DAL.DataAccessTools;
using DAL.DataAccessTools.CustomRepositories;
using Models;
using Models.CustomModels.ClassModels;
using Models.CustomModels.EmployeeModel;
using System;
using System.Collections.Generic;

namespace BLL
{
    public class EmployeeBL
    {
        private readonly GMSDBContext _dbContext;
        private GenericRepository<Employee> repository;

        public EmployeeBL()
        {
            _dbContext = new GMSDBContext();
            repository = new GenericRepository<Employee>(_dbContext);
        }
        public void Insert(Employee employee)
        {
            try
            {
                UnitOfWork unitOfWork = new UnitOfWork();
                repository.Insert(employee);
                unitOfWork.Save();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void Update(Employee employee)
        {
            try
            {
                UnitOfWork unitOfWork = new UnitOfWork();
                repository.Update(employee);
                unitOfWork.Save();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void Datete(Employee employee)
        {
            try
            {
                UnitOfWork unitOfWork = new UnitOfWork();
                repository.Delete(employee);
                unitOfWork.Save();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void Datete(int Id)
        {
            try
            {
                UnitOfWork unitOfWork = new UnitOfWork();
                repository.Delete(Id);
                unitOfWork.Save();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public Employee Read(int Id)
        {
            try
            {
                UnitOfWork unitOfWork = new UnitOfWork();
                Employee employee = new Employee();
                employee = repository.Read(Id);
                return employee;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public List<Employee> Read()
        {
            try
            {
                UnitOfWork unitOfWork = new UnitOfWork();
                List<Employee> employees = new List<Employee>();
                employees = repository.Read();
                return employees;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public List<EmpCustomModel> GetEmployees()
        {
            try
            {
                EmployeeRepository employeeRepository = new EmployeeRepository();
                
                var list = employeeRepository.GetEmployees();
                return list;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public byte[] GetIdImages(int id)
        {
            EmployeeRepository employeeRepository = new EmployeeRepository();

            byte[] idImage = employeeRepository.GetIdImages(id);

            return idImage;
        }

        public byte[] GetImages(int id)
        {
            EmployeeRepository employeeRepository = new EmployeeRepository();

            byte[] image = employeeRepository.GetImages(id);

            return image;
        }

        public List<ClassCustomModel> GetClasses(int memId)
        {
            MemberRepository repository = new MemberRepository();
            List<ClassCustomModel> classes = repository.GetClasses(memId);
            return classes;
        }

        public Dictionary<int, string> GetTrainers(int sportId)
        {
            EmployeeRepository employeeRepository = new EmployeeRepository();
            Dictionary<int, string> trainers = employeeRepository.GetTrainers(sportId);

            return trainers;
        }
    }
}
