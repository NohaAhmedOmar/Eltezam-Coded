using Eltezam_Coded.DTOs;
using Eltezam_Coded.Services;
using ElTezam_Coded_WebApp.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace ElTezam_Coded_WebApp.APIControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeService employeeService;
        public EmployeesController(IEmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }
        [HttpGet("GetEmployeesView")]
        public async Task<ActionResult> GetEmployeesView()
        {
            var result = await employeeService.GetEmployeesView();
            return Ok(result);
        }
        [HttpGet("GetEmployeesPaysView")]
        public async Task<ActionResult> GetEmployeesPaysView()
        {
            var result = await employeeService.GetEmployeesPaysView();
            return Ok(result);
        }
        [HttpGet("GetEmployeesVacationsView")]
        public async Task<ActionResult> GetEmployeesVacationsView()
        {
            var result = await employeeService.GetEmployeesVacationsView();
            return Ok(result);
        }
        [HttpGet("GetEmployeesAppraisalsView")]
        public async Task<ActionResult> GetEmployeesAppraisalsView()
        {
            var result = await employeeService.GetEmployeesAppraisalsView();
            return Ok(result);
        }
        [HttpGet("GetEmployeesQualificationsView")]
        public async Task<ActionResult> GetEmployeesQualificationsView()
        {
            var result = await employeeService.GetEmployeesQualificationsView();
            return Ok(result);
        }
        [HttpGet("GetEmployeeHistoricalView")]
        public async Task<ActionResult> GetEmployeeHistoricalView()
        {
            var result = await employeeService.GetEmployeeHistoricalView();
            return Ok(result);
        }
        [HttpGet("GetJobView")]
        public async Task<ActionResult> GetJobView()
        {
            var result = await employeeService.GetJobView();
            return Ok(result);
        }
        [HttpGet("GetEmployees")]
        public async Task<ActionResult> GetEmployees()
        {
            var result = await employeeService.GetEmployees();
            return Ok(result);
        }
        [HttpPost("PostEmployee")]
        public async Task<ActionResult> PostEmployee(EmployeeDTO employeeDTO)
        {
            var result = await employeeService.SubmitEmployeeInfo(employeeDTO);
            return result.IsSuccess ? Created(nameof(PostEmployee), result) : BadRequest(result);
        }
        [HttpPost("PostEmployeeVacation")]
        public async Task<ActionResult> PostEmployeeVacation(EmployeeVacationDTO employeeVacationDTO)
        {
            var result = await employeeService.SubmitEmployeeVacationInfo(employeeVacationDTO);
            return result.IsSuccess ? Created(nameof(PostEmployee), result) : BadRequest(result);
        }
        [HttpPost("PostEmployeeVacations")]
        public async Task<ActionResult> PostEmployeeVacations(List<EmployeeVacationDTO> employeeVacationDTOs)
        {
            var result = await employeeService.SubmitEmployeeVacationInfo(employeeVacationDTOs);
            return result.IsSuccess ? Created(nameof(PostEmployee), result) : BadRequest(result);
        }
        [HttpPost("PostEmployeeQualification")]
        public async Task<ActionResult> PostEmployeeQualification(EmployeeQualificationDTO employeeQualificationDTO)
        {
            var result = await employeeService.SubmitEmployeeQualificationInfo(employeeQualificationDTO);
            return result.IsSuccess ? Created(nameof(PostEmployee), result) : BadRequest(result);
        }
        [HttpPost("PostEmployeeQualifications")]
        public async Task<ActionResult> PostEmployeeQualifications(List<EmployeeQualificationDTO> employeeQualificationDTOs)
        {
            var result = await employeeService.SubmitEmployeeQualificationInfo(employeeQualificationDTOs);
            return result.IsSuccess ? Created(nameof(PostEmployee), result) : BadRequest(result);
        }
        [HttpPost("PostEmployeePays")]
        public async Task<ActionResult> PostEmployeePays(EmployeePaymentDTO employeePaymentDTO)
        {
            var result = await employeeService.SubmitEmployeePaysInfo(employeePaymentDTO);
            return result.IsSuccess ? Created(nameof(PostEmployee), result) : BadRequest(result);
        }
        [HttpPost("PostEmployeeAppraisal")]
        public async Task<ActionResult> PostEmployeeAppraisal(EmployeeAppraisalInfoDTO employeeAppraisalInfoDTO)
        {
            var result = await employeeService.SubmitEmployeeAppraisalInfo(employeeAppraisalInfoDTO);
            return result.IsSuccess ? Created(nameof(PostEmployee), result) : BadRequest(result);
        }
        [HttpPost("PostEmployeeHistoricalInfo")]
        public async Task<ActionResult> PostEmployeeHistoricalInfo(EmployeeJobDTO employeeJobDTO)
        {
            var result = await employeeService.SubmitEmployeeHistoricalInfo(employeeJobDTO);
            return result.IsSuccess ? Created(nameof(PostEmployee), result) : BadRequest(result);
        }
        [HttpPost("PostJob")]
        public async Task<ActionResult> PostJob(JobDTO jobDTO)
        {
            var result = await employeeService.SubmitJobInfo(jobDTO);
            return result.IsSuccess ? Created(nameof(PostEmployee), result) : BadRequest(result);
        }
        [HttpPost("BulkDeleteEmployees")]
        public async Task<ActionResult> BulkDeleteEmployees(List<long> Ids)
        {
            var result = await employeeService.BulkDeleteEmployee(Ids);
            return result.IsSuccess ? NoContent() : BadRequest(result);
        }
        [HttpPost("BulkDeleteEmployeeVacation")]
        public async Task<ActionResult> BulkDeleteEmployeeVacation(List<int> Ids)
        {
            var result = await employeeService.BulkDeleteEmployeeVacation(Ids);
            return result.IsSuccess ? NoContent() : BadRequest(result);
        }
        [HttpPost("BulkDeleteEmployeeQualification")]
        public async Task<ActionResult> BulkDeleteEmployeeQualification(List<int> Ids)
        {
            var result = await employeeService.BulkDeleteEmployeeQualification(Ids);
            return result.IsSuccess ? NoContent() : BadRequest(result);
        }
        [HttpPost("BulkDeleteEmployeePays")]
        public async Task<ActionResult> BulkDeleteEmployeePays(List<int> Ids)
        {
            var result = await employeeService.BulkDeleteEmployeePays(Ids);
            return result.IsSuccess ? NoContent() : BadRequest(result);
        }
        [HttpPost("BulkDeleteEmployeeAppraisal")]
        public async Task<ActionResult> BulkDeleteEmployeeAppraisal(List<int> Ids)
        {
            var result = await employeeService.BulkDeleteEmployeeAppraisal(Ids);
            return result.IsSuccess ? NoContent() : BadRequest(result);
        }
        [HttpPost("BulkDeleteEmployeeHistorical")]
        public async Task<ActionResult> BulkDeleteEmployeeHistorical(List<int> Ids)
        {
            var result = await employeeService.BulkDeleteEmployeeHistorical(Ids);
            return result.IsSuccess ? NoContent() : BadRequest(result);
        }
        [HttpPost("BulkDeleteJob")]
        public async Task<ActionResult> BulkDeleteJob(List<int> Ids)
        {
            var result = await employeeService.BulkDeleteJob(Ids);
            return result.IsSuccess ? NoContent() : BadRequest(result);
        }
    }
}
