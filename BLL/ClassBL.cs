using DAL.DataAccessTools;
using DAL.DataAccessTools.CustomRepositories;
using Models;
using Models.CustomModels.ClassModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ClassBL
    {
        public void Insert(Class @class)
        {
            UnitOfWork unitOfWork = new UnitOfWork();
            GenericRepository<Class> genericRepository = unitOfWork.Repository<Class>();
            genericRepository.Insert(@class);
            unitOfWork.Save();
        }

        public void Update(Class @class)
        {
            UnitOfWork unitOfWork = new UnitOfWork();
            GenericRepository<Class> genericRepository = unitOfWork.Repository<Class>();
            genericRepository.Update(@class);
            unitOfWork.Save();
        }

        public void Datete(Class @class)
        {
            UnitOfWork unitOfWork = new UnitOfWork();
            GenericRepository<Class> genericRepository = unitOfWork.Repository<Class>();
            genericRepository.Delete(@class);
            unitOfWork.Save();
        }

        public void Datete(int Id)
        {
            UnitOfWork unitOfWork = new UnitOfWork();
            GenericRepository<Class> genericRepository = unitOfWork.Repository<Class>();
            genericRepository.Delete(Id);
            unitOfWork.Save();
        }

        public Class Read(int Id)
        {
            UnitOfWork unitOfWork = new UnitOfWork();
            GenericRepository<Class> genericRepository = unitOfWork.Repository<Class>();
            Class @class = new Class();
            @class = genericRepository.Read(Id);
            unitOfWork.End();
            return @class;
        }

        public List<Class> Read()
        {
            ClassRepository repository = new ClassRepository();
            List<Class> classes = repository.Read();
            return classes;
        }

        public List<ClassCustomModel> GetClasses()
        {
            ClassRepository repository = new ClassRepository();
            List<ClassCustomModel> classes = repository.GetClasses();
            return classes;
        }

        public string[] GetUnavailableTimes(int trainerId, string days)
        {
            ClassRepository classRepository = new ClassRepository();
            string[] classesTime = classRepository.GetUnavailableTimes(trainerId, days);

            return classesTime;
        }
    }
}
