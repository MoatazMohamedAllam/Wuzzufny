using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Wuzzufny.Models;
using Wuzzufny.ViewModels;

namespace Wuzzufny.Controllers
{
    [AuthorizeCompany]
    public class CompaniesController : MyBaseController
    {
        
         private ApplicationDbContext _context;
        

        public CompaniesController()
        {
            _context = new ApplicationDbContext();
        }

        

        
        public ActionResult Create()
        {
            
            var userId = User.Identity.GetUserId();


            var CheckIfUserIsCompany = _context.Users.Where(u => u.Id == userId && u.RoleId == 2).FirstOrDefault();
            var CheckIfCompanyHasProfile = _context.Companies.Where(e => e.Id == userId).FirstOrDefault();


            if (CheckIfCompanyHasProfile == null && CheckIfUserIsCompany != null)
            {

                var companySize = GetCompanySize();
                var aboutUsHearing = GetHearAboutUs();
                var industries = GetIndustryCompany();

                var viewModel = new CompanyProfileViewModel();

                viewModel.CompanySizes = GetSelectListItems(companySize);
                viewModel.AboutUsHearing = GetSelectListItems(aboutUsHearing);
                viewModel.CompanyIndustries = GetSelectListItems(industries);

                ViewBag.CountryList = GetCountries();


                return View(viewModel);
            }
            return Content("you have already create a profile!");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CompanyProfileViewModel viewModel,HttpPostedFileBase logoUpload)
        {
            var companySize = GetCompanySize();
            var aboutUsHearing = GetHearAboutUs();
            var industries = GetIndustryCompany();

            viewModel.CompanySizes = GetSelectListItems(companySize);
            viewModel.AboutUsHearing = GetSelectListItems(aboutUsHearing);
            viewModel.CompanyIndustries = GetSelectListItems(industries);

            ViewBag.CountryList = GetCountries();





            var userId = User.Identity.GetUserId();

            var companyProfile = _context.Companies.Where(c => c.Id == userId).FirstOrDefault();

            if (ModelState.IsValid && companyProfile == null)
            {
                //string bannerPath = Path.Combine(Server.MapPath("~/Images/Companies/Banners"), bannerUpload.FileName);
                //bannerUpload.SaveAs(bannerPath);
                if (logoUpload != null)
                {
                    string logoPath = Path.Combine(Server.MapPath("~/Images/Companies/Logos"), logoUpload.FileName);
                    logoUpload.SaveAs(logoPath);
                }

                var company = new Company
                {
                    Id = userId,
                    FirstName = viewModel.FirstName,
                    LastName = viewModel.LastName,
                    Title = viewModel.Title,
                    JobRule = viewModel.JobRule,
                    CompanyName = viewModel.CompanyName,
                    CompanySize = viewModel.CompanySize,
                    CompanyIndustry = viewModel.CompanyIndustry,
                    CompanyURL = viewModel.CompanyURL,
                    PhoneNo = viewModel.PhoneNo,
                    Country = viewModel.Country,
                    CompanyLogo = logoUpload.FileName,
                    Companybanner = viewModel.Companybanner,
                    HearAboutUs = viewModel.HearAboutUs,
                    MobileNo = viewModel.MobileNo,
                    UserId = userId
                };
                

                _context.Companies.Add(company);
                _context.SaveChanges();

                return RedirectToAction("Index", "Home");
            }

            return View(viewModel);
        }

        [ProfileRequired]
        public ActionResult Update(string id)
        {
            var userId = User.Identity.GetUserId();
            var companySize = GetCompanySize();
            var aboutUsHearing = GetHearAboutUs();
            var industries = GetIndustryCompany();

            var profile = _context.Companies.Where(c => c.Id == id && id == userId).FirstOrDefault();
            if (profile == null)
            {
                return RedirectToAction("Create", "Companies");
            }

            var viewModel = new CompanyProfileViewModel
            {
                FirstName=profile.FirstName,
                LastName=profile.LastName,
                Companybanner=profile.Companybanner,
                CompanyLogo=profile.CompanyLogo,
                CompanyURL=profile.CompanyURL,
                CompanyName=profile.CompanyName,
                Country=profile.Country,
                JobRule=profile.JobRule,
                PhoneNo=profile.PhoneNo,
                MobileNo=profile.MobileNo,
                CompanySize=profile.CompanySize,
                CompanyIndustry=profile.CompanyIndustry,
                HearAboutUs=profile.HearAboutUs,
                Title=profile.Title,
                CompanySizes = GetSelectListItems(companySize),
                AboutUsHearing = GetSelectListItems(aboutUsHearing),
                CompanyIndustries = GetSelectListItems(industries),
                
        };

           

            ViewBag.CountryList = GetCountries();

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Update(CompanyProfileViewModel viewModel,HttpPostedFileBase logoUpload)
        {

            if (ModelState.IsValid)
            {
                if (logoUpload != null)
                {
                    var oldPath = viewModel.CompanyLogo;
                    if (oldPath != null)
                    {
                        System.IO.File.Delete(oldPath);
                    }
                    string path = Path.Combine(Server.MapPath("~/images/companies/logos"), logoUpload.FileName);
                    logoUpload.SaveAs(path);
                    viewModel.CompanyLogo = logoUpload.FileName;
                }
            }

            var companySize = GetCompanySize();
            var aboutUsHearing = GetHearAboutUs();
            var industries = GetIndustryCompany();

            viewModel.CompanySizes = GetSelectListItems(companySize);
            viewModel.AboutUsHearing = GetSelectListItems(aboutUsHearing);
            viewModel.CompanyIndustries = GetSelectListItems(industries);

            ViewBag.CountryList = GetCountries();


            var profile = _context.Companies.Single(c => c.Id == viewModel.Id);

            if (ModelState.IsValid)
            {
                profile.FirstName = viewModel.FirstName;
                profile.LastName = viewModel.LastName;
                profile.JobRule = viewModel.JobRule;
                profile.CompanyName = viewModel.CompanyName;
                profile.CompanySize = viewModel.CompanySize;
                profile.CompanyURL = viewModel.CompanyURL;
                profile.Country = viewModel.Country;
                profile.Companybanner = viewModel.Companybanner;
                profile.CompanyLogo = viewModel.CompanyLogo;
                profile.CompanyIndustry = viewModel.CompanyIndustry;
                profile.HearAboutUs = viewModel.HearAboutUs;
                profile.MobileNo = viewModel.MobileNo;
                profile.PhoneNo = viewModel.PhoneNo;
                profile.Title = viewModel.Title;

                _context.SaveChanges();

                return RedirectToAction("Index","Home");
            }
            return View(viewModel);
        }

        [ProfileRequired]
        public ActionResult PublishJob()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult PublishJob(JobViewModel viewModel)
        {
            var userId = User.Identity.GetUserId();
            var IsProfileCreated = _context.Companies.Any(e => e.Id == userId);

            if (!IsProfileCreated)
            {
                return RedirectToAction("Create","Companies");
            }

            var IfUserIsCompany = _context.Users.Where(e => e.Id == userId && e.RoleId == 2).FirstOrDefault();

            if (!ModelState.IsValid || IfUserIsCompany == null)
            {
                return View(viewModel);
            }

          

            var job = new Job
            {
                Description = viewModel.Description,
                Requirements = viewModel.Requirements,
                CareerLevel = viewModel.CareerLevel,
                ExperinceNeeded = viewModel.ExperinceNeeded,
                JobType = viewModel.JobType,
                Salary = viewModel.Salary,
                Language = viewModel.Language,
                Location = viewModel.Location,
                Vacancies = viewModel.Vacancies,
                Title=viewModel.Title,
                PublisherID = userId
            };

            _context.Jobs.Add(job);
            _context.SaveChanges();

            return RedirectToAction("Index","Home");
        }



        public ActionResult AllRequests()
        {
            var userId = User.Identity.GetUserId();

            var requests = _context.JobRequests
                                    .Include(e => e.Job)
                                    .Include(e => e.Employee)
                                    .Where(e => e.Company.Id == userId && e.RequestStatus =="pending")
                                    .ToList();

            return View(requests);
        }


        [AllowAnonymous]
        public ActionResult GetEmployeeProfile(string id,int requestID)
        {
            var profile = _context.Employees.Where(e => e.Id == id).Include(e => e.User).FirstOrDefault();
            var jobRequest = _context.JobRequests.Where(e => e.Id == requestID).FirstOrDefault();

            ViewBag.jobRequestID = jobRequest.Id;

            if (profile == null)
                return Content("something wrong!");

            return View(profile);
        }



        private IEnumerable<string> GetCompanySize()
        {
            return new List<string>
            {
                "1-10 employees",
                "11-50 employees",
                "51-100 employees",
                "101-500 employees",
                "501-1000 employees",
                "More than 1000 employees"
            };
        }

        private IEnumerable<string> GetHearAboutUs()
        {
            return new List<string>
            {
                "Friend / Referral",
                "Facebook",
                "Google Search",
                "LinkedIn",
                "Email",
                "Twitter",
                "Another Wewbsite",
                "TV",
                "Magazine",
                "Other",
            };
        }

        private IEnumerable<string> GetIndustryCompany()
        {
            return new List<string>
            {
                "Accounting",
                "Animation",
                "Banking",
                "Information Technology",
                "Computer Software",
                "Computer Hardware",
                "Computer Network",
                "Education",
                "Fine Art",
                "Sports",
                "Transportation",
            };
        }


        

    }
}