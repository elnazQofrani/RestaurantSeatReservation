using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataAccess.Repository;
using Business.Core;
using DataAccess.Entities;
using Business.Enums;

namespace CustomerCRUD.Controllers
{

    public class HomeController : Controller
    {
        ICustomer custLogic;
        IErrorMessageHandling errorMessageHandling;

        public HomeController(IErrorMessageHandling _errorMessageHandling, ICustomer _custLogic)
        {
            errorMessageHandling = _errorMessageHandling;
            custLogic = _custLogic;
        }

        public ActionResult Index()
        {
            var modelCustomer = custLogic.CustmoerList();

            return View(modelCustomer);
        }


        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// Creating a customer
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>

        [HttpPost]
        public ActionResult Create(DataAccess.Entities.Customer model)
        {
            if (ModelState.IsValid)
            {
                custLogic.AddCustomer(model);
                ViewBag.SuccesMessage = errorMessageHandling.GetMessage(StatusMessage.Successful, StatusOperation.Create);
            }
            else
            {
                ViewData["ErrorCreateMessage"] = errorMessageHandling.GetMessage(StatusMessage.Eror, StatusOperation.Create);
                RedirectToAction("Create");
            }
            return View(model);
        }
        /// <summary>
        /// Getting ID for editing customer
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id != null)
            {

                var model = custLogic.GetCustomerById(id.Value);
                if (model != null)
                {

                    return View(model);
                }
            }
            ViewData["ErrorMessage"] = errorMessageHandling.GetMessage(StatusMessage.Eror, StatusOperation.Update);

            return RedirectToAction("Index");
        }

        /// <summary>
        /// Editing customer
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>

        [HttpPost]
        public ActionResult Edit(DataAccess.Entities.Customer model)
        {
            if (ModelState.IsValid)
            {
                var customer = custLogic.GetCustomerById(model.Id);
                custLogic.CustomerEdit(customer);
                ViewBag.Message = errorMessageHandling.GetMessage(StatusMessage.Successful, StatusOperation.Update);
            }

            return View();
        }


        /// <summary>
        /// Deleting customer
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Delete(int? id)
        {
            if (id != null)
            {
                var model = custLogic.GetCustomerById(id.Value);

                if (model != null)
                {
                    if (custLogic.RemoveCustomer(model))
                    {
                        ViewData["ErrorMessage"] = errorMessageHandling.GetMessage(StatusMessage.Successful, StatusOperation.Delete);
                    }

                }
                else
                {
                    ViewData["ErrorMessage"] = "Record couldnot find";
                }
            }
            else
            {
                ViewData["ErrorMessage"] = "ID couldnot find";
            }

            return RedirectToAction("Index");
        }

    }

}