using BLL;
using GymManagmentSystem.Models.ClassModels;
using System;
using System.Web;
using System.Web.Mvc;

namespace GymManagmentSystem.ModelBinding
{
    public class ClassModelBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            HttpRequestBase request = controllerContext.HttpContext.Request;

            TitleBL titeBL = new TitleBL();
            string sportName = titeBL.GetSportName(int.Parse(request.Form.Get("sSports")));

            ClassModel classModel = new ClassModel
            {
                SportName = sportName,
                TrainerId = int.Parse(request.Form.Get("sTrainers")),
                Hours = request.Form.Get("sHours"),
                Days = request.Form.Get("sDays"),
                Membership = int.Parse(request.Form.Get("txtMembership")),
                Hall = request.Form.Get("txtHall"),
                MaxCount = int.Parse(request.Form.Get("txtMax"))
            };

            if (!string.IsNullOrEmpty(request.Form.Get("txtStartDate")))
            {
                classModel.StartDate = request.Form.Get("txtStartDate");
            }

            if (!string.IsNullOrEmpty(request.Form.Get("txtEndDate")))
            {
                classModel.EndDate = request.Form.Get("txtEndDate");
            }
            
            return classModel;
        }
    }
}