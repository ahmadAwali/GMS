using Models;
using Models.CustomModels.ClassModels;
using Models.CustomModels.MemberModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DataAccessTools.CustomRepositories
{
    public class MemberRepository
    {
        #region Attributes

        private readonly GMSDBContext _dbcontext;
        private IDbSet<Member> Entity;

        #endregion

        public MemberRepository()
        {
            _dbcontext = new GMSDBContext();
            Entity = _dbcontext.Set<Member>();
        }

        #region Methods

        public List<MemCustomModel> MembersForList()
        {
            var list = Entity.Select(p => new { p.ID, p.Image, p.Name1, p.Name2, p.Name4, p.MembershipStart, p.MembershipExpired, p.PhoneNo1}).ToList();
            List<MemCustomModel> members = new List<MemCustomModel>();

            foreach(var item in list)
            {
                members.Add(new MemCustomModel
                {
                    Id = item.ID,
                    Name = item.Name1 + " " + item.Name2 + " " + item.Name4,
                    StartDate = item.MembershipStart,
                    ExbiryDate = item.MembershipExpired,
                    PhoneNumber = item.PhoneNo1,
                    Image = item.Image
                });
            }

            return members;
        }

        public void Enrollment(Member member, int classId)
        {
            IDbSet<Member> memberEntity = _dbcontext.Set<Member>();
            IDbSet<Class> classEntity = _dbcontext.Set<Class>();

            Class @class = new Class();
            @class = classEntity.Where(i => i.ID == classId).FirstOrDefault();

            @class.Count += 1;

            memberEntity.Add(member);
            member.Classes = new List<Class>();
            member.Classes.Add(@class);

            _dbcontext.SaveChanges();

        }

        /// <summary>
        /// Get the Classes that enrolled with this member
        /// </summary>
        /// <param name="memId">enrolled member id</param>
        /// <returns></returns>
        public List<ClassCustomModel> GetClasses(int memId)
        {
            List<ClassCustomModel> classes = new List<ClassCustomModel>();
            var sportsList = Entity
                .Where(i => i.ID == memId)
                .Include(c => c.Classes)
                .Select(c => c.Classes.Select(i => new { i.ID, i.Name, i.Employee.Name1, i.Employee.Name4, i.Days, i.Hours }))
                .ToList();

            foreach (var item in sportsList[0])//لازم تتعدل هيك غلط يا خرى
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

        #endregion
    }
}
