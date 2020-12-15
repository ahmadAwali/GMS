using BLL;
using GymManagmentSystem.ModelBinding;
using GymManagmentSystem.Models.MemberModels;
using Models;
using Models.CustomModels.ClassModels;
using Models.CustomModels.MemberModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GymManagmentSystem.Controllers
{
    public class MembersController : Controller
    {
        // GET: Members
        public ActionResult Index()
        {
            return View("List", GetMembers());
        }

        public ActionResult Insert()
        {
            return View();
        }

        public ActionResult Save([ModelBinder(typeof(MemberBinding))] MemberModel memberModel,
            HttpPostedFileBase personImage, HttpPostedFileBase idImage, string memberId)
        {

            Member member = new Member
            {
                Name1 = memberModel.Name1,
                Name2 = memberModel.Name2,
                Name3 = memberModel.Name3,
                Name4 = memberModel.Name4,
                Gender = memberModel.Gender,
                NationalID = memberModel.NationalID,
                BirthDate = memberModel.BirthDate,
                MartialState = memberModel.MartialState,
                Address = memberModel.Address,
                PhoneNo1 = memberModel.PhoneNo1,
                PhoneNo2 = memberModel.PhoneNo2,
                Email = memberModel.Email,
                //Balance = memberModel.Balance,
                MembershipExpired = memberModel.MembershipExpired,
                AddedBy = 1, //TO DO Config it later 


            };



            if (personImage != null)
            {
                byte[] personByets = new byte[personImage.ContentLength];
                personImage.InputStream.Read(personByets, 0, personImage.ContentLength);

                member.Image = personByets;
            }

            if (idImage != null)
            {
                byte[] idByets = new byte[idImage.ContentLength];
                idImage.InputStream.Read(idByets, 0, idImage.ContentLength);

                member.IdentityImage = idByets;
            }

            if (memberModel.IsStarted)
            {
                member.MembershipStart = DateTime.Now;
            }
            else
            {
                member.MembershipStart = memberModel.MembershipStart;
            }
            MemberBL memberBL = new MemberBL();
            if (memberId == null)
            {
                memberBL.Enrollment(member, memberModel.ClassId);
            }
            else
            {
                int id = int.Parse(memberId);
                member.ID = id;
                memberBL.Update(member);
            }

            return View("List", GetMembers());
        }

        [HttpGet]
        public JsonResult GetClasses()
        {
            ClassBL classBL = new ClassBL();
            List<ClassCustomModel> classes = new List<ClassCustomModel>();
            classes = classBL.GetClasses();

            JsonResult json = Json(classes, JsonRequestBehavior.AllowGet);
            return json;
        }

        [NonAction]
        private MemClassModel GetMembers()
        {
            MemberBL memberBL = new MemberBL();
            List<ListMemberModel> members = new List<ListMemberModel>();
            List<MemCustomModel> membersList = new List<MemCustomModel>();

            List<ClassModel> classes = new List<ClassModel>();
            List<ClassCustomModel> customClassModelList = new List<ClassCustomModel>();
            ClassBL classBL = new ClassBL();

            membersList = memberBL.MembersForList();
            foreach (var item in membersList)
            {
                List<ClassCustomModel> membClasses = memberBL.GetClasses(item.Id);
                members.Add(new ListMemberModel
                {
                    Id = item.Id,
                    Name = item.Name,
                    StartDate = item.StartDate,
                    ExbiryDate = item.ExbiryDate,
                    PhoneNumber = item.PhoneNumber,
                    Image = item.Image,
                    Classes = membClasses
                });
            }

            customClassModelList = classBL.GetClasses();

            foreach (var item in customClassModelList)
            {
                classes.Add(new ClassModel
                {
                    Id = item.Id,
                    Name = item.Name,
                    Trainer = item.Trainer,
                    DayTime = item.DayTime
                });
            }

            MemClassModel memAndClass = new MemClassModel
            {
                Mems = members,
                Classes = classes
            };

            return memAndClass;
        }

        [HttpGet]
        public ActionResult Enrollment(string classId, string memberId)
        {
            int clsId = int.Parse(classId);
            int memId = int.Parse(memberId);

            Class @class = new Class();
            Member member = new Member();

            ClassBL classBL = new ClassBL();
            MemberBL memberBL = new MemberBL();

            @class = classBL.Read(clsId);
            member = memberBL.Read(memId);

            @class.Members.Add(member);
            //member.Classes.Add(@class);

            classBL.Update(@class);
            //memberBL.Update(member);


            return null;
        }

        [HttpGet]
        public ActionResult Delete(string id)
        {
            MemberBL memberBL = new MemberBL();
            memberBL.Datete(int.Parse(id));

            return View("List", GetMembers());

        }

        [HttpGet]
        public ActionResult Update(string id)
        {
            ViewBag.id = id;
            return View("Insert");
        }

        [HttpGet]
        public JsonResult GetMember(string memId)
        {
            Member member = new Member();
            MemberBL memberBL = new MemberBL();
            member = memberBL.Read(int.Parse(memId));

            MemberModel memberModel = new MemberModel
            {
                Id = member.ID,
                Name1 = member.Name1,
                Name2 = member.Name2,
                Name3 = member.Name3,
                Name4 = member.Name4,
                Gender = member.Gender,
                NationalID = member.NationalID,
                PhoneNo1 = member.PhoneNo1,
                PhoneNo2 = member.PhoneNo2,
                Email = member.Email,
                Address = member.Address,
                
            };

            JsonResult json = Json(memberModel, JsonRequestBehavior.AllowGet);
            return json;
        }
    }
}