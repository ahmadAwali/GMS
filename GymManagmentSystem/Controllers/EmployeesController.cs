using BLL;
using GymManagmentSystem.Models.EmployeeModels;
using Models;
using Models.CustomModels.EmployeeModel;
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;

namespace GymManagmentSystem.Controllers
{
    public class EmployeesController : Controller
    {
        // GET: Employees
        public ActionResult Index()
        {
            EmployeeBL employeeBL = new EmployeeBL();
            List<EmpCustomModel> employees = employeeBL.GetEmployees();

            return View("List", employees);
        }

        public ActionResult Insert(string id)
        {
            ViewBag.Title = "Insert";
            return View();
        }

        public ActionResult Save(FormCollection fc, HttpPostedFileBase personImage, HttpPostedFileBase idImage, string empId)
        {
            // String validation
            if (string.IsNullOrEmpty(Request.Form["txtFirstName"]) || string.IsNullOrEmpty(Request.Form["txtSecondName"]) || string.IsNullOrEmpty(Request.Form["txtThirdName"]) ||
                 string.IsNullOrEmpty(Request.Form["txtNationalId"]) || string.IsNullOrEmpty(Request.Form["txtNationalId"]) || string.IsNullOrEmpty(Request.Form["txtPhoneNumber1"]))
            {
                //TO DO :: Config it later
            }

            // Check birth date 
            if ((DateTime.Now.Year - Convert.ToDateTime(Request.Form["txtBirthDate"]).Year) < 20)
            {
                // TO DO :: config trainer minimum age later
            }

            EmployeeBL employeeBL = new EmployeeBL();
            try
            {
                bool isTrainer = false;
                if (Request.Form["cbIsTrainer"] != null)
                {
                    isTrainer = true;
                }
                else
                {
                    isTrainer = false;
                }

                if (empId != null)
                {
                    Employee employee = new Employee();
                    int id = int.Parse(empId);
                    employee = employeeBL.Read(id);

                    if(personImage != null)
                    {
                        byte[] personByets = new byte[personImage.ContentLength];
                        personImage.InputStream.Read(personByets, 0, personImage.ContentLength);

                        employee.Image = personByets;
                    }

                    if(idImage != null)
                    {
                        byte[] idByets = new byte[idImage.ContentLength];
                        idImage.InputStream.Read(idByets, 0, idImage.ContentLength);

                        employee.IdentityImage = idByets;
                    }

                    employee.Name1 = Request.Form["txtFirstName"];
                    employee.Name2 = Request.Form["txtSecondName"];
                    employee.Name3 = Request.Form["txtThirdName"];
                    employee.Name4 = Request.Form["txtFourthName"];
                    employee.Gender = Request.Form["ddlGender"];
                    employee.NationalID = Request.Form["txtNationalId"];
                    employee.PhoneNo1 = Request.Form["txtPhoneNumber1"];
                    employee.PhoneNo2 = Request.Form["txtPhoneNumber2"];
                    employee.Email = Request.Form["txtEmail"];
                    employee.BirthDate = Convert.ToDateTime(Request.Form["txtBirthDate"]);
                    employee.MartialState = Request.Form["ddlMartialState"];
                    employee.Salary = int.Parse(Request.Form["txtSalary"]);
                    employee.TitleID = int.Parse(Request.Form["sTitles"]);
                    employee.IsTrainer = isTrainer;
                    employee.Address = Request.Form["txtAddress"];
                    employee.AddedBy = 1;//TO DO :: config it later
                    employee.AddedOn = DateTime.Now;

                    employeeBL.Update(employee);


                }
                else
                {
                    Employee employee = new Employee
                    {
                        Name1 = Request.Form["txtFirstName"],
                        Name2 = Request.Form["txtSecondName"],
                        Name3 = Request.Form["txtThirdName"],
                        Name4 = Request.Form["txtFourthName"],
                        Gender = Request.Form["ddlGender"],
                        NationalID = Request.Form["txtNationalId"],
                        PhoneNo1 = Request.Form["txtPhoneNumber1"],
                        PhoneNo2 = Request.Form["txtPhoneNumber2"],
                        Email = Request.Form["txtEmail"],
                        BirthDate = Convert.ToDateTime(Request.Form["txtBirthDate"]).Date,
                        MartialState = Request.Form["ddlMartialState"],
                        Address = Request.Form["txtAddress"],
                        Salary = int.Parse(Request.Form["txtSalary"]),
                        TitleID = int.Parse(Request.Form["sTitles"]),
                        IsTrainer = isTrainer,
                        AddedBy = 1,//TO DO :: config it later
                        AddedOn = DateTime.Now,
                    };
                    byte[] personByets = new byte[personImage.ContentLength];
                    personImage.InputStream.Read(personByets, 0, personImage.ContentLength);

                    byte[] idByets = new byte[idImage.ContentLength];
                    idImage.InputStream.Read(idByets, 0, idImage.ContentLength);

                    employee.Image = personByets;
                    employee.IdentityImage = idByets;
                    employeeBL.Insert(employee);
                }

            }
            catch (Exception ex)
            {
                throw ex; // TO DO :: Config it later
            }


            List<EmpCustomModel> employees = employeeBL.GetEmployees();

            return View("List", employees);

        }

        [HttpPost]
        public void Delete(string id)
        {
            try
            {
                ClassBL classBL = new ClassBL();
                classBL.Datete(int.Parse(id));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet]
        public ActionResult Update(string id)
        {
            ViewBag.id = id;
            return View("Insert");
        }

        [HttpGet]
        public ActionResult GetTitles(string isTran)
        {
            List<TitlesOfEmp> empTitles = new List<TitlesOfEmp>();
            List<Title> titles = new List<Title>();
            TitleBL titleBL = new TitleBL();

            if (isTran == null)
            {
                titles = titleBL.Read();
            }
            else
            {
                bool isTrainer = bool.Parse(isTran);
                titles = titleBL.GetTitles(isTrainer);
            }

            foreach (var item in titles)
            {
                empTitles.Add(new TitlesOfEmp
                {
                    ID = item.ID,
                    Name = item.Name,
                    IsSport = item.IsSport
                });
            }

            JsonResult json = Json(empTitles, JsonRequestBehavior.AllowGet);
            return json;
        }

        [HttpGet]
        public JsonResult GetEmployee(string empId)
        {
            int id = int.Parse(empId);
            EmployeeBL employeeBL = new EmployeeBL();
            Employee employee = new Employee();
            employee = employeeBL.Read(id);

            EmployeeModel empModel = new EmployeeModel
            {
                ID = employee.ID,
                Name1 = employee.Name1,
                Name2 = employee.Name2,
                Name3 = employee.Name3,
                Name4 = employee.Name4,
                Gender = employee.Gender,
                AddedBy = employee.AddedBy,
                AddedOn = employee.AddedOn,
                Address = employee.Address,
                BirthDate = employee.BirthDate.ToString(),
                Email = employee.Email,
                IdentityImage = Convert.ToBase64String(employee.IdentityImage),
                Image = Convert.ToBase64String(employee.Image),
                IsTrainer = employee.IsTrainer,
                MartialState = employee.MartialState,
                ModifiedBy = employee.ModifiedBy,
                ModifiedOn = employee.ModifiedOn,
                NationalID = employee.NationalID,
                PhoneNo1 = employee.PhoneNo1,
                PhoneNo2 = employee.PhoneNo2,
                Salary = employee.Salary,
                TitleID = employee.TitleID
            };


            JsonResult json = Json(empModel, JsonRequestBehavior.AllowGet);
            return json;
        }
    }
}