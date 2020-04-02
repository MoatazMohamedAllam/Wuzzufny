using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Wuzzufny.Models;
using System.Data.Entity;
using Wuzzufny.ViewModels;

namespace Wuzzufny.Controllers
{
    [AuthorizeEmployee]
    public class EmployeesController : MyBaseController
    {
        private  readonly ApplicationDbContext _context;

        public EmployeesController()
        {
            _context = new ApplicationDbContext();

        }
        

        public ActionResult GetAll()
        {
            var allProfiles = _context.Employees.ToList();
            return View(allProfiles);
        }
        
        
        public ActionResult Create()
        {
            //ViewBag.MilitaryStatus = new SelectList(new[]
            //                                            {"Not Applicable", 
            //                                             "Exempted",
            //                                             "Completed",
            //                                             "Postponed" });
            var userId = User.Identity.GetUserId();


            var CheckIfUserIsEmployee = _context.Users.Where(u => u.Id==userId && u.RoleId ==1).FirstOrDefault();
            var CheckIfEmployeeHasProfile = _context.Employees.Where(e => e.Id == userId).FirstOrDefault();
           

            if (CheckIfEmployeeHasProfile == null && CheckIfUserIsEmployee != null)
            {
                var milits = GetMilitaries();
                var viewModel = new EmployeeProfileViewModel();
                viewModel.Militaries = GetSelectListItems(milits);


                return View(viewModel);
            }

            return Content("you have already create a profile! ");
        }


        [HttpPost]
        public ActionResult Create(EmployeeProfileViewModel viewModel, HttpPostedFileBase upload)
        {
            var milits = GetMilitaries();

            viewModel.Militaries = GetSelectListItems(milits);

            var userId = User.Identity.GetUserId();
            var employeeProfile = _context.Employees.Include(e => e.User).Where(e => e.Id == userId).FirstOrDefault();


            if (ModelState.IsValid && employeeProfile == null)
            {

                string path = Path.Combine(Server.MapPath("~/Images/Employees"), upload.FileName);
                upload.SaveAs(path);
                var employee = new Employee
                {
                    Id = userId,
                    FirstName = viewModel.FirstName,
                    LastName = viewModel.LastName,
                    birthDate = new DateTime(viewModel.Year, viewModel.Month, viewModel.Day),
                    Year = viewModel.Year,
                    Month = viewModel.Month,
                    Day = viewModel.Day,
                    MaritalStatus = viewModel.MaritalStatus,
                    MilitaryStatus = viewModel.MilitaryStatus,
                    Gender = viewModel.Gender,
                    ProfileImage = upload.FileName,
                    UserId = userId
                };

                _context.Employees.Add(employee);
                _context.SaveChanges();

                ViewBag.UserProfile = null;
                ViewBag.comProfile = null;
                ViewBag.empProfile = employeeProfile;

                return RedirectToAction("Index", "Home");
            }

            return View(viewModel);
        }

        [ProfileRequired]
        public ActionResult Update(string id)
        {
            var userId = User.Identity.GetUserId();
            var milites = GetMilitaries();

            var profile = _context.Employees.Where(e => e.Id == id && id ==userId).FirstOrDefault();
            if (profile == null)
            {
                return RedirectToAction("Create","Employees");
            }

            var viewModel = new EmployeeProfileViewModel
            {
                FirstName = profile.FirstName,
                LastName = profile.LastName,
                birthDate = profile.birthDate,
                Year = profile.Year,
                Month = profile.Month,
                Day = profile.Day,
                Gender = profile.Gender,
                MaritalStatus = profile.MaritalStatus,
                MilitaryStatus = profile.MilitaryStatus,
                ProfileImage = profile.ProfileImage,
                Militaries = GetSelectListItems(milites)
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(EmployeeProfileViewModel viewModel, HttpPostedFileBase upload)
        {
            if (ModelState.IsValid)
            {
                if (upload != null)
                {
                    string oldPath = viewModel.ProfileImage;
                    if (oldPath != null)
                    {
                        System.IO.File.Delete(oldPath);
                    }
                    string path = Path.Combine(Server.MapPath("~/Images/Employees"), upload.FileName);
                    upload.SaveAs(path);
                    viewModel.ProfileImage = upload.FileName;
                }
            }
            // _context.Entry(viewModel).State = EntityState.Modified;

            var profile = _context.Employees.Single(e => e.Id == viewModel.Id);


            profile.FirstName = viewModel.FirstName;
            profile.LastName = viewModel.LastName;
            profile.birthDate = new DateTime(viewModel.Year, viewModel.Month, viewModel.Day);
            profile.Year = viewModel.Year;
            profile.Month = viewModel.Month;
            profile.Day = viewModel.Day;
            profile.Gender = viewModel.Gender;
            profile.MaritalStatus = viewModel.MaritalStatus;
            profile.MilitaryStatus = viewModel.MilitaryStatus;
            profile.ProfileImage = viewModel.ProfileImage;

            _context.SaveChanges();

            viewModel.Militaries = GetSelectListItems(GetMilitaries());
            return RedirectToAction("GetAll");



            //var profile = _context.Employees.Single(e => e.Id == viewModel.Id);

            //profile.FirstName = viewModel.FirstName;
            //profile.LastName = viewModel.LastName;
            //profile.BirthDate = viewModel.BirthDate;
            //profile.Year = viewModel.Year;
            //profile.Month = viewModel.Month;
            //profile.Day = viewModel.Day;
            //profile.Gender = viewModel.Gender;
            //profile.MaritalStatus = viewModel.MaritalStatus;
            //profile.MilitaryStatus = viewModel.MilitaryStatus;
            //profile.ProfileImage = viewModel.ProfileImage;

            //return View(viewModel);

        }

        [HttpGet]
        public ActionResult GetRequestsStatus()
        {
            var userId = User.Identity.GetUserId();

            var applyRequests = _context.JobRequests
                                        .Include(r => r.Job)
                                        .Include(r => r.Company)
                                        .Where(r => r.EmployeeId == userId)
                                        .ToList();

            return View(applyRequests);
        }


       


        private IEnumerable<string> GetMilitaries()
        {
            return new List<string>
            {
                "Not Applicable",
                "Exempted",
                "Completed",
                "Postponed"
            };
        }

        
    }
}