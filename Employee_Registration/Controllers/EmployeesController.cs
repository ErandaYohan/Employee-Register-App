using Employee_Registration.Data;
using Employee_Registration.Models;
using Employee_Registration.Models.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Runtime.Intrinsics.X86;

namespace Employee_Registration.Controllers
{
    public class EmployeesController : Controller
    {
        //Create Constructor to Access DbContect
        private readonly EmployeeRegistrationDbContext employeeRegistrationDbContext;
        private readonly IWebHostEnvironment webHostEnvironment;
        public EmployeesController(EmployeeRegistrationDbContext employeeRegistrationDbContext, IWebHostEnvironment webHostEnvironment) 
        { 
            this.employeeRegistrationDbContext= employeeRegistrationDbContext;
            this.webHostEnvironment = webHostEnvironment;
        }
        //Get EmployeeAdd Details
        [HttpGet]
        public IActionResult EmployeeAdd()
        {
            return View();
        }
        //Post Employee Details to Employee Table,Email Table,Address Table,Mobile Table
        [HttpPost]
        public async Task<IActionResult> EmployeeAdd(AddEmployeeViewModel addEmployeeRequest) 
        {
            var employee = new Employee()
            {
                FirstName = addEmployeeRequest.FirstName,
                LastName = addEmployeeRequest.LastName,
                DateOfBirth = addEmployeeRequest.DateOfBirth,
                SSN = addEmployeeRequest.SSN,
                Emails = addEmployeeRequest.Emails,
                ImageFile = addEmployeeRequest.ImageFile,
                Mobile = addEmployeeRequest.Mobile,
                Address= addEmployeeRequest.Address

            };
            // Save Image to wwwroot / image
            string wwwRootPath = webHostEnvironment.WebRootPath;
            string fileName = Path.GetFileNameWithoutExtension(addEmployeeRequest.ImageFile.FileName);
            string extension = Path.GetExtension(employee.ImageFile.FileName);
            employee.ImagePath = fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
            string path = Path.Combine(wwwRootPath + "/Image/", fileName);
            using (var fileStream = new FileStream(path, FileMode.Create))
            {
                await employee.ImageFile.CopyToAsync(fileStream);
            }
            //Insert Record To Database
            await employeeRegistrationDbContext.Employees.AddAsync(employee);
            await employeeRegistrationDbContext.SaveChangesAsync();

            return RedirectToAction("index", "Home");
        }
        //Get EditEmployee Details
        [HttpGet]
        public async Task<IActionResult> EditEmployee(Guid ID)
        {
            var emp = await employeeRegistrationDbContext.Employees.Include("Emails").Include("Mobile").Include("Address").Where(x => x.EmployeeId == ID).FirstOrDefaultAsync();
            return View(emp);
        }
        //Post EditEmployee Details and Save to DB
        [HttpPost]
        public IActionResult EditEmployee(UpdateEmployeeViewModel Model)
        {
            //Check EmployeeId == model.EmployeeId
            var employee = employeeRegistrationDbContext.Employees.Include("Emails").Include("Mobile").Include("Address").Where(x => x.EmployeeId == Model.EmployeeId).FirstOrDefault();
            if (employee != null)
            {
                employee.FirstName= Model.FirstName;
                employee.LastName= Model.LastName;
                employee.DateOfBirth= Model.DateOfBirth;
                employee.SSN= Model.SSN;
                employee.Emails= Model.Emails;
                employee.Mobile = Model.Mobile;
                employee.Address= Model.Address;

                employeeRegistrationDbContext.SaveChanges();
                return RedirectToAction("Index", "Home"); ;
            }
            return RedirectToAction("Index", "Home");
        }
        //Delete Employee By ID
        [HttpPost]
        public async Task<IActionResult> DeleteEmployee(UpdateEmployeeViewModel Model)
        {
            var employee =  employeeRegistrationDbContext.Employees.Include("Emails").Include("Mobile").Include("Address").Where(x => x.EmployeeId == Model.EmployeeId).FirstOrDefault();
            if (employee != null)
            {
                employeeRegistrationDbContext.Employees.Remove(employee);
                await employeeRegistrationDbContext.SaveChangesAsync();

                return RedirectToAction("Index", "Home");
            }
            return RedirectToAction("Index", "Home");
        }
    }
}
 