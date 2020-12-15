using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DataAccessTools
{
    public class UnitOfWork
    {
        private readonly GMSDBContext _dbContext;
        private Dictionary<string, object> repository;
        public UnitOfWork()
        {
            _dbContext = new GMSDBContext();
        }

        public void Save()
        {
            _dbContext.SaveChanges();
            _dbContext.Dispose();
        }

        public void End()
        {
            _dbContext.Dispose();
        }

        public GenericRepository<Type> Repository<Type>() where Type : BaseEntity
        {
            if (repository == null)
                repository = new Dictionary<string, object>();

            string type = typeof(Type).Name;

            if (!repository.ContainsKey(type))
            {
                var repo = typeof(GenericRepository<>);
                var repositoryInstance = Activator.CreateInstance(repo.MakeGenericType(typeof(Type)), _dbContext);
                repository.Add(type, repositoryInstance);
            }
            return (GenericRepository<Type>)repository[type];
        }
    }
}
