using DAL.DataAccessTools;
using DAL.DataAccessTools.CustomRepositories;
using Models;
using Models.CustomModels.ClassModels;
using Models.CustomModels.MemberModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class MemberBL
    {
        public void Insert(Member member)
        {
            UnitOfWork unitOfWork = new UnitOfWork();
            GenericRepository<Member> genericRepository = unitOfWork.Repository<Member>();
            genericRepository.Insert(member);
            unitOfWork.Save();
        }

        public void Update(Member member)
        {
            UnitOfWork unitOfWork = new UnitOfWork();
            GenericRepository<Member> genericRepository = unitOfWork.Repository<Member>();
            genericRepository.Update(member);
            unitOfWork.Save();
        }

        public void Datete(Member member)
        {
            UnitOfWork unitOfWork = new UnitOfWork();
            GenericRepository<Member> genericRepository = unitOfWork.Repository<Member>();
            genericRepository.Delete(member);
            unitOfWork.Save();
        }

        public void Datete(int Id)
        {
            UnitOfWork unitOfWork = new UnitOfWork();
            GenericRepository<Member> genericRepository = unitOfWork.Repository<Member>();
            genericRepository.Delete(Id);
            unitOfWork.Save();
        }

        public Member Read(int Id)
        {
            UnitOfWork unitOfWork = new UnitOfWork();
            GenericRepository<Member> genericRepository = unitOfWork.Repository<Member>();
            Member member = new Member();
            member = genericRepository.Read(Id);
            //unitOfWork.Save();
            return member;
        }

        public List<Member> Read()
        {
            UnitOfWork unitOfWork = new UnitOfWork();
            GenericRepository<Member> genericRepository = unitOfWork.Repository<Member>();
            List<Member> members = new List<Member>();
            members = genericRepository.Read();
            return members;
        }

        public List<MemCustomModel> MembersForList()
        {
            MemberRepository repository = new MemberRepository();
            List<MemCustomModel> memsList = repository.MembersForList();

            return memsList;
        }

        public void Enrollment(Member member, int classId)
        {
            MemberRepository repository = new MemberRepository();
            repository.Enrollment(member ,classId);

        }

        public List<ClassCustomModel> GetClasses(int memId)
        {
            MemberRepository repository = new MemberRepository();
            List<ClassCustomModel> classes = repository.GetClasses(memId);
            return classes;
        }
    }
}
