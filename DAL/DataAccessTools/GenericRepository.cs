using Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace DAL.DataAccessTools
{
    public class GenericRepository<Type> where Type : BaseEntity
    {
        #region Attributes

        private readonly GMSDBContext _dbContext;
        private IDbSet<Type> Entity;

        #endregion Attributes

        public GenericRepository(GMSDBContext gMSDBContext)
        {
            _dbContext = gMSDBContext;
            Entity = _dbContext.Set<Type>();
        }

        #region Methods

        public void Insert(Type entity)
        {
            try
            {
                entity.AddedOn = DateTime.Now;
                Entity.Add(entity);
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void Update(Type entity)
        {
            try
            {
                
                entity.ModifiedOn = DateTime.Now;
                entity.AddedOn = GetAddedDate(entity.ID);
                _dbContext.Entry(entity).State = EntityState.Modified;
                _dbContext.SaveChanges();
            }
            catch (InvalidOperationException ex)
            {
                throw ex;
            }
        }

        public void Delete(Type entity)
        {
            try
            {
                Entity.Remove(entity);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void Delete(int Id)
        {
            try
            {
                Entity.Remove(Read(Id));
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public Type Read(int Id)
        {
            try
            {
                Type entity = Entity.Find(Id);
                return entity;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public List<Type> Read()
        {
            try
            { 
                return Entity.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        private DateTime GetAddedDate(int id)
        {
            return Entity.Where(i => i.ID == id).Select(d => d.AddedOn).FirstOrDefault();
        }
        
        #endregion Methods
    }
}
