using GymManagmentSystem.Models.MemberModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GymManagmentSystem.ModelBinding
{
    public class MemberBinding : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            HttpRequestBase request = controllerContext.HttpContext.Request;


            MemberModel memberModel = new MemberModel();

            memberModel.Name1 = request.Form.Get("txtFirstName");
            memberModel.Name2 = request.Form.Get("txtSecondName");
            memberModel.Name3 = request.Form.Get("txtThirdName");
            memberModel.Name4 = request.Form.Get("txtFourthName");
            memberModel.Gender = request.Form.Get("ddlGender");
            memberModel.NationalID = request.Form.Get("txtNationalId");
            memberModel.BirthDate = DateTime.Parse(request.Form.Get("txtBirthDate"));
            memberModel.MartialState = request.Form.Get("ddlMartialState");
            memberModel.ClassId = int.Parse(request.Form.Get("ddlClasses"));
            memberModel.Address = request.Form.Get("txtAddress");
            memberModel.PhoneNo1 = request.Form.Get("txtPhoneNumber1");
            memberModel.PhoneNo2 = request.Form.Get("txtPhoneNumber2");
            memberModel.Email = request.Form.Get("txtEmail");
            //memberModel.Balance = int.Parse(request.Form.Get("txtBalance"));
            memberModel.MembershipExpired = DateTime.Parse(request.Form.Get("txtMemberShipExpired"));
            memberModel.MembershipStart = DateTime.Now;//TO DO for Testing

            //bool isStarted = false;
            //if (request.Form.Get("cbStarted") != null)
            //{
            //    isStarted = true;
            //    memberModel.MembershipStart = DateTime.Now;
            //}
            //else
            //{
            //    memberModel.MembershipStart = DateTime.Parse(request.Form.Get("txtMembershipStart"));
            //}

            return memberModel;
        }
    }
}