using BLL;
using GymManagmentSystem.ModelBinding;
using GymManagmentSystem.Models.ClassModels;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GymManagmentSystem.Controllers
{
    public class ClassesController : Controller
    {
        // GET: Classes
        public ActionResult Index()
        {
            ClassBL classBL = new ClassBL();
            List<Class> classesList = new List<Class>();
            classesList = classBL.Read();

            List<ClassModel> classes = new List<ClassModel>();
            classes = FillModel(classesList);

            return View("List", classes);
        }

        public ActionResult Insert()
        {
            return View("Insert", new ClassModel());
        }

        public ActionResult Save([ModelBinder(typeof(ClassModelBinder))]ClassModel classModel, string classId)
        {
            Class @class = new Class
            {
                AddedOn = DateTime.Now,
                Name = classModel.SportName,
                Days = classModel.Days,
                Hours = classModel.Hours,
                AddedBy = 1,// TO DO :: change it later
                Cost = classModel.Membership,
                Hall = classModel.Hall,
                MaxCount = classModel.MaxCount,
                EmployeeId = classModel.TrainerId
            };

            if (classModel.StartDate != null)
            {
                @class.StartDate = DateTime.Parse(classModel.StartDate);
            }

            if (classModel.EndDate != null)
            {
                @class.EndDate = DateTime.Parse(classModel.EndDate);
            }

            ClassBL classBL = new ClassBL();
            if (string.IsNullOrEmpty(classId))
            {
                classBL.Insert(@class);
            }
            else
            {
                @class.ID = @class.ID = int.Parse(classId);
                classBL.Update(@class);
            }


            List<Class> classesList = new List<Class>();
            classesList = classBL.Read();

            List<ClassModel> classes = new List<ClassModel>();

            classes = FillModel(classesList);

            return View("List", classes);
        }

        [HttpGet]
        public JsonResult GetSports()
        {
            try
            {
                TitleBL titleBL = new TitleBL();
                Dictionary<int, string> sportsDic = titleBL.GetSports();
                List<SportModel> sports = new List<SportModel>();
                
                foreach (var item in sportsDic)
                {
                    SportModel sprt = new SportModel
                    {
                        Id = item.Key
                    };
                    string name = item.Value;
                    if (name.Split(' ').Last().ToLower() == "trainer")
                    {
                        sprt.Name = item.Value.Substring(0, name.IndexOf(name.Split(' ').Last()));
                    }
                    else
                    {
                        sprt.Name = item.Value;
                    }
                    sports.Add(sprt);
                }
                JsonResult json = Json(sports, JsonRequestBehavior.AllowGet);
                return json;
            }
            catch
            {
                throw;// TO DO :: config it latter
            }
        }

        [HttpGet]
        public JsonResult GetTrainers(string sportId)
        {
            EmployeeBL employeeBL = new EmployeeBL();
            Dictionary<int, string> trainersList = employeeBL.GetTrainers(int.Parse(sportId));

            List<TrainerModel> trainers = new List<TrainerModel>();
            foreach (var item in trainersList)
            {
                trainers.Add(new TrainerModel
                {
                    Id = item.Key,
                    Name = item.Value
                });
            }

            JsonResult json = Json(trainers, JsonRequestBehavior.AllowGet);
            return json;
        }

        [NonAction]
        private List<ClassModel> FillModel(List<Class> classesList)
        {
            Employee emp = new Employee();
            List<ClassModel> classes = new List<ClassModel>();
            foreach (var item in classesList)
            {
                emp = item.Employee;
                classes.Add(new ClassModel
                {
                    Id = item.ID,
                    SportName = item.Name,
                    Days = item.Days,
                    Hours = item.Hours,
                    Membership = item.Cost,
                    Hall = item.Hall,
                    Count = item.Count,
                    MaxCount = item.MaxCount,
                    TrainerId = item.EmployeeId,
                    TrainerName = emp.Name1 + " " + emp.Name2 + " " + emp.Name4
                });
            }

            return classes;
        }

        [HttpGet]
        public ActionResult Update(int id)
        {
            ViewBag.id = id;
            return View("Insert");
        }

        public void Delete(string id)
        {
            ClassBL classBL = new ClassBL();
            classBL.Datete(int.Parse(id));
        }

        public JsonResult GetClass(string sportId)
        {
            ClassBL classBL = new ClassBL();
            Class @class = new Class();
            @class = classBL.Read(int.Parse(sportId));

            ClassModel classModel = new ClassModel
            {
                Id = @class.ID,

                //SportId = @class.Employee.TitleID,
                //TrainerId = @class.EmployeeID,
                Days = @class.Days,
                Hours = @class.Hours,
                StartDate = @class.StartDate.ToString(),
                EndDate = @class.EndDate.ToString(),
                Membership = @class.Cost,
                Hall = @class.Hall,
                Count = @class.Count,
                MaxCount = @class.MaxCount,
            };

            JsonResult json = Json(classModel, JsonRequestBehavior.AllowGet);

            return json;
        }

        [HttpGet]
        public JsonResult GetUnavailableTimes(string trainerId, string days)
        {
            ClassBL classBL = new ClassBL();
            string[] classesTime = classBL.GetUnavailableTimes(int.Parse(trainerId), days);
            if (classesTime == null)
                return null;

            JsonResult json = Json(classesTime, JsonRequestBehavior.AllowGet);
            return json;
        }

    }
}