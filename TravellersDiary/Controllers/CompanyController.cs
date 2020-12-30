using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravellersDiary.Handlers.Company;
using TravellersDiary.Models.Company;

namespace TravellersDiary.Controllers
{
    public class CompanyController : Controller
    {
        // GET: Company
        public ActionResult Index()
        {

            CompanyHandler companyHandler = new CompanyHandler();
            return View(companyHandler.GetCompanyList());
        }
        public ActionResult CreateCompany(CreateCompany model)
        {
            CompanyHandler companyHandler = new CompanyHandler();
            companyHandler.CreateCompany(model);
            return RedirectToAction("Index", "Company");
        }
    }
}