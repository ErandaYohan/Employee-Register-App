using Employee_Registration.Data;
using Employee_Registration.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Employee_Registration.Controllers
{
    public class HomeController : Controller
    {
        //Create Constructor to Access DbContect
        private readonly ILogger<HomeController> _logger;
        private readonly EmployeeRegistrationDbContext employeeRegistrationDbContext;
        public HomeController(ILogger<HomeController> logger, EmployeeRegistrationDbContext employeeRegisterDbContext)
        {
            _logger = logger;
            this.employeeRegistrationDbContext = employeeRegisterDbContext;
        }
        //Get All Employee Details To Home Page
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var employees = await employeeRegistrationDbContext.Employees.Include("Emails").Include("Mobile").Include("Address").ToListAsync();
            return View(employees);
        }
        //View Employee Details By ID
        [HttpGet]
        public async Task<IActionResult> ViewEmployeeDetails(Guid ID)
        {
            var emp = await employeeRegistrationDbContext.Employees.Include("Emails").Include("Mobile").Include("Address").Where(x => x.EmployeeId == ID).FirstOrDefaultAsync();
            return View(emp);
        }
    }
}