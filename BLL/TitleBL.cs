using DAL.DataAccessTools;
using DAL.DataAccessTools.CustomRepositories;
using Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class TitleBL
    {
        public void Insert(Title title)
        {
            UnitOfWork unitOfWork = new UnitOfWork();
            GenericRepository<Title> genericRepository = unitOfWork.Repository<Title>();
            genericRepository.Insert(title);
            unitOfWork.Save();
        }

        public void Update(Title title)
        {
            UnitOfWork unitOfWork = new UnitOfWork();
            GenericRepository<Title> genericRepository = unitOfWork.Repository<Title>();
            genericRepository.Update(title);
            unitOfWork.Save();
        }

        public void Datete(Title title)
        {
            UnitOfWork unitOfWork = new UnitOfWork();
            GenericRepository<Title> genericRepository = unitOfWork.Repository<Title>();
            genericRepository.Delete(title);
            unitOfWork.Save();
        }

        public void Datete(int Id)
        {
            UnitOfWork unitOfWork = new UnitOfWork();
            GenericRepository<Title> genericRepository = unitOfWork.Repository<Title>();
            genericRepository.Delete(Id);
            unitOfWork.Save();
        }

        public Title Read(int Id)
        {
            UnitOfWork unitOfWork = new UnitOfWork();
            GenericRepository<Title> genericRepository = unitOfWork.Repository<Title>();
            Title title = new Title();
            title = genericRepository.Read(Id);
            unitOfWork.Save();
            return title;
        }
        
        public List<Title> Read()
        {
            UnitOfWork unitOfWork = new UnitOfWork();
            GenericRepository<Title> genericRepository = unitOfWork.Repository<Title>();
            List<Title> titles = genericRepository.Read();
            return titles;
        }

        public List<Title> GetTitles(bool isTrainer)
        {
            TitleRepository titleRepository = new TitleRepository();
            List<Title> titles = titleRepository.GetTitles(isTrainer);
            titleRepository.Dispose();
            return titles;
        }

        public Dictionary<int, string> GetSports()
        {
            TitleRepository titleRepository = new TitleRepository();
            Dictionary<int, string> sports = titleRepository.GetSports();
            titleRepository.Dispose();
            return sports;
        }

        public string GetSportName(int id)
        {
            TitleRepository titleRepository = new TitleRepository();
            string titleName = titleRepository.GetTitleName(id);
            titleRepository.Dispose();
            return titleName;
        }
        
    }
}
