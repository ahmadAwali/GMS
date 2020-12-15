using Models;
using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Reflection;

namespace DAL.DataAccessTools
{
    public class GMSDBContext : DbContext
    {
        public GMSDBContext() { }
        public IDbSet<Type> Entity<Type>() where Type : BaseEntity
        {
            return base.Set<Type>();
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            var listOfMap = Assembly.GetExecutingAssembly().GetTypes()
                .Where(type => !string.IsNullOrEmpty(type.Namespace) &&
                type.BaseType.IsGenericType && type.BaseType.IsGenericType
                && type.BaseType.GetGenericTypeDefinition() == typeof(EntityTypeConfiguration<>));

            foreach (var item in listOfMap)
            {
                dynamic mapInstance = Activator.CreateInstance(item);
                modelBuilder.Configurations.Add(mapInstance);
            }

            base.OnModelCreating(modelBuilder);
        }
    }
}
