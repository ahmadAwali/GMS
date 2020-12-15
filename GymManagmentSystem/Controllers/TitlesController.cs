using BLL;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace GymManagmentSystem.Controllers
{
    public class TitlesController : Controller
    {
        // GET: Titles
        public ActionResult Index()
        {
            TitleBL titleBL = new TitleBL();
            List<Title> titles = titleBL.Read();

            return View("Titles", titles);
        }

        [HttpPost]
        public void Insert(string name, string isSport)
        {
            bool sport;
            if (isSport.ToLower() == "true")
            {
                sport = true;
            }
            else
            {
                sport = false;
            }
            Title title = new Title
            {
                IsSport = sport,
                AddedBy = 1, //TODO : change it later
                AddedOn = DateTime.Now
            };

            switch (isSport.ToLower())
            {
                case "true":
                    if (name.IndexOf(' ') == -1)
                    {
                        name = name + " Trainer";
                    }
                    else if(name.Split(' ').Last().ToLower() != "trainer")
                    {
                        name = name + " Trainer";
                    }
                    break;
            }
            
            title.Name = name;

            TitleBL titleBL = new TitleBL();
            titleBL.Insert(title);
        }

        [HttpPost]
        public void update(string id, string name)
        {

            Title title = new Title();
            TitleBL titleBL = new TitleBL();
            title = titleBL.Read(int.Parse(id));
            title.Name = name;
            title.ModifiedBy = 1;//TODO: Change it later
            title.ModifiedOn = DateTime.Now;

            titleBL.Update(title);
        }

        [HttpPost]
        public void Delete(string id)
        {
            TitleBL titleBL = new TitleBL();
            titleBL.Datete(int.Parse(id));
        }



    }
}