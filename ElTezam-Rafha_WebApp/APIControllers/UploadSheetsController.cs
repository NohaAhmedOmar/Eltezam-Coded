using ElTezam_Coded_WebApp.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace ElTezam_Coded_WebApp.APIControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UploadSheetsController : ControllerBase
    {
        private readonly IUploadExcelSheetService uploadExcelSheetService;
        public UploadSheetsController(IUploadExcelSheetService uploadExcelSheetService)
        {
            this.uploadExcelSheetService = uploadExcelSheetService;

        }
        [HttpPost("PostEmployeesExcelSheet")]
        public async Task<IActionResult> PostEmployeesExcelSheet([FromForm] IFormFile Sheet)
        {

            var result = await uploadExcelSheetService.PostExcelSheet(Sheet, Eltezam_Coded.Enums.AllEnums.Table.Employees);
            return result.StatusCode == 201 ? Ok(result) : BadRequest(result);
        }
        [HttpPost("PostEmployeePaysExcelSheet")]
        public async Task<IActionResult> PostEmployeePaysExcelSheet([FromForm] IFormFile Sheet)
        {

            var result = await uploadExcelSheetService.PostExcelSheet(Sheet, Eltezam_Coded.Enums.AllEnums.Table.EmployeePayments);
            return result.StatusCode == 201 ? Ok(result) : BadRequest(result);
        }
        [HttpPost("PostEmployeeAppraisalsExcelSheet")]
        public async Task<IActionResult> PostEmployeeAppraisalsExcelSheet([FromForm] IFormFile Sheet)
        {

            var result = await uploadExcelSheetService.PostExcelSheet(Sheet, Eltezam_Coded.Enums.AllEnums.Table.EmployeeAppraisalInfo);
            return result.StatusCode == 201 ? Ok(result) : BadRequest(result);
        }
        [HttpPost("PostEmployeeQualificationsExcelSheet")]
        public async Task<IActionResult> PostEmployeeQualificationsExcelSheet([FromForm] IFormFile Sheet)
        {

            var result = await uploadExcelSheetService.PostExcelSheet(Sheet, Eltezam_Coded.Enums.AllEnums.Table.EmployeeQualifications);
            return result.StatusCode == 201 ? Ok(result) : BadRequest(result);
        }
        [HttpPost("PostEmployeeVacationsExcelSheet")]
        public async Task<IActionResult> PostEmployeeVacationsExcelSheet([FromForm] IFormFile Sheet)
        {

            var result = await uploadExcelSheetService.PostExcelSheet(Sheet, Eltezam_Coded.Enums.AllEnums.Table.EmployeeVacations);
            return result.StatusCode == 201 ? Ok(result) : BadRequest(result);
        }
        [HttpPost("PostEmloyeeHistoricalInfoExcelSheet")]
        public async Task<IActionResult> PostEmloyeeHistoricalInfoExcelSheet([FromForm] IFormFile Sheet)
        {

            var result = await uploadExcelSheetService.PostExcelSheet(Sheet, Eltezam_Coded.Enums.AllEnums.Table.EmployeeJobs);
            return result.StatusCode == 201 ? Ok(result) : BadRequest(result);
        }
        [HttpPost("PostJobsExcelSheet")]
        public async Task<IActionResult> PostJobsExcelSheet([FromForm] IFormFile Sheet)
        {
            try
            {
                var result = await uploadExcelSheetService.PostExcelSheet(Sheet, Eltezam_Coded.Enums.AllEnums.Table.Jobs);
                return result.StatusCode == 201 ? Ok(result) : BadRequest(result);
            }
            catch (Exception ex)
            {
                return Problem();
            }
        }
        [HttpPost("PostCodesExcelSheet")]
        public async Task<IActionResult> PostCodesExcelSheet([FromForm] IFormFile Sheet)
        {

            var result = await uploadExcelSheetService.PostExcelSheet(Sheet, Eltezam_Coded.Enums.AllEnums.Table.Codes);
            return result.StatusCode == 201 ? Ok(result) : BadRequest(result);
        }
    }
}
