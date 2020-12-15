using DAL.DataAccessTools;
using Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace DAL.DataAccessTools.CustomRepositories
{
    public class TitleRepository
    {
        #region Attributes

        private readonly GMSDBContext _dbContext;
        private IDbSet<Title> Entity;

        #endregion

        public TitleRepository()
        {
            _dbContext = new GMSDBContext();
            Entity = _dbContext.Set<Title>();
        }

        #region Method

        public List<Title> GetTitles(bool isTrainer)
        {
            try
            {
                var titlesList = Entity.Where(s => s.IsSport == isTrainer).Select(p => new { p.ID, p.Name, p.IsSport }).ToList();
                List<Title> titles = new List<Title>();
                foreach (var item in titlesList)
                {
                    titles.Add(new Title
                    {
                        ID = item.ID,
                        Name = item.Name,
                        IsSport = item.IsSport
                    });
                }
                return titles;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public string GetTitleName(int titleId)
        {
            try
            {
                string titleName = (from t in Entity where t.ID == titleId select t.Name).First(); 
                    //Where(i => i.ID == titleId).Select(n => n.Name).ToString();
                return titleName;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Dictionary<int, string> GetSports()
        {
            Dictionary<int, string> sports = new Dictionary<int, string>();
            var sportsList =  Entity.Where(i => i.IsSport == true).Select(i => new { i.ID, i.Name }).ToList();

            foreach (var item in sportsList)
            {
                sports.Add(item.ID,item.Name);
            }

            return sports;

        }

        public string GetSportName(int id)
        {
            return Entity.Where(i => i.ID == id).Select(s => s.Name).FirstOrDefault();
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }
        #endregion

    }
}
