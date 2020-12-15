using DAL.DataAccessTools;
using Models;
using Models.CustomModels.ClassModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            int memId = 4014;
            GMSDBContext context = new GMSDBContext();
            Member member = new Member();
            var entityClass = context.Set<Class>();
            var entityMember = context.Set<Member>();


            List<ClassCustomModel> classes = new List<ClassCustomModel>();


            //var sportsList = (from c in entityClass
            //                  join m in entityMember on c.Members equals c.UserID
            //                  where c.ClientID == yourDescriptionObject.ClientID
            //                  select a.Balance)
            //  .SingleOrDefault();





            var sportsList =
                entityMember
                .Where(i=>i.ID == memId)
                .Include(c => c.Classes)
                .Select(c => c.Classes.Select(i => new { i.ID, i.Name, i.Employee.Name1, i.Employee.Name4, i.Days, i.Hours }))
                .ToList();

            var y = 12;


        }
    }
}
