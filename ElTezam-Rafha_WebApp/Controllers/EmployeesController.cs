using Microsoft.AspNetCore.Mvc;

namespace ElTezam_Coded_WebApp.Controllers
{
    public class EmployeesController : Controller
    {
        public EmployeesController()
        {
            
        }
        public async Task< IActionResult> EmployeesView()
        {
            return View();
        }
        public async Task< IActionResult> EmployeesPaysView()
        {
            return View();
        }
        public async Task< IActionResult> EmployeesVacationsView()
        {
            return View();
        } 
        public async Task< IActionResult> EmployeesAppraisalsView()
        {
            return View();
        }
        public async Task< IActionResult> EmployeesQualificationsView()
        {
            return View();
        }
        public async Task< IActionResult> EmployeeHistoricalView()
        {
            return View();
        } 
        public async Task< IActionResult> JobView()
        {
            return View();
        }
        public async Task< IActionResult> RegisterEmployee()
        {
            return View();
        } 
        public async Task< IActionResult> RegisterEmployeeQualification()
        {
            return View();
        } 
        public async Task< IActionResult> RegisterEmployeeVacation()
        {
            return View();
        } 
        public async Task< IActionResult> RegisterEmployeePayment()
        {
            return View();
        } 
        public async Task< IActionResult> RegisterEmployeeAppraisal()
        {
            return View();
        } 
        public async Task< IActionResult> RegisterEmployeeHistorical()
        {
            return View();
        } 
        public async Task< IActionResult> RegisterJob()
        {
            return View();
        }
    }
}
