using Eltezam_Coded.Enums;
using ElTezam_Coded_WebApp.DomainModels;
using ElTezam_Coded_WebApp.Services;
using Microsoft.AspNetCore.Mvc;
using static Eltezam_Coded.Enums.AllEnums;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ElTezam_Coded_WebApp.APIControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DropDownsController : ControllerBase
    {
        private readonly IDropDownService dropDownService;
        public DropDownsController(IDropDownService dropDownService)
        {
            this.dropDownService = dropDownService;
        }
        // GET: api/<DropDownsController>
        [HttpGet("GetGenderDropDown")]
        public async Task<ActionResult> GetGenderDropDown()
        {
            var data = await dropDownService
                .GetDropDown<DomainModels.Code>(x => new { Id = x.Id, Value = x.Value }, x => x.CategoryId == 8);
            return Ok(data);
        }
        [HttpGet("GetNationDropDown")]
        public async Task<ActionResult> GetNationDropDown()
        {
            var data = await dropDownService
                .GetDropDown<DomainModels.Nationality>(x => new { Id = x.NationalityCode, Value = x.NationalityDescription }, null);
            return Ok(data);
        }
        [HttpGet("GetJobTypeDropDown")]
        public async Task<ActionResult> GetJobTypeDropDown()
        {
            var data = await dropDownService
                .GetDropDown<DomainModels.Code>(x => new { Id = x.Id, Value = x.Value }, x => x.CategoryId == 9);
            return Ok(data);
        }
        [HttpGet("GetBloodTypeDropDown")]
        public async Task<ActionResult> GetBloodTypeDropDown()
        {
            var data = await dropDownService
                .GetDropDown<DomainModels.Code>(x => new { Id = x.Id, Value = x.Value }, x => x.CategoryId == 19);
            return Ok(data);
        }
        [HttpGet("GetReligionTypeDropDown")]
        public async Task<ActionResult> GetReligionTypeDropDown()
        {
            var data = await dropDownService
                .GetDropDown<DomainModels.Code>(x => new { Id = x.Id, Value = x.Value }, x => x.CategoryId == 11);
            return Ok(data);
        }
        [HttpGet("GetVacationTypeDropDown")]
        public async Task<ActionResult> GetVacationTypeDropDown()
        {
            var data = await dropDownService
                .GetDropDown<DomainModels.Code>(x => new { Id = x.Id, Value = x.Value }, x => x.CategoryId == 12);
            return Ok(data);
        }
        [HttpGet("GetMaritalStatusDropDown")]
        public async Task<ActionResult> GetMaritalStatusDropDown()
        {
            var data = await dropDownService
                .GetDropDown<DomainModels.Code>(x => new { Id = x.Id, Value = x.Value }, x => x.CategoryId == 17);
            return Ok(data);
        }
        [HttpGet("GetHealthStatusDropDown")]
        public async Task<ActionResult> GetHealthStatusDropDown()
        {
            var data = await dropDownService
                .GetDropDown<DomainModels.Code>(x => new { Id = x.Id, Value = x.Value }, x => x.CategoryId == 18);
            return Ok(data);
        }
        [HttpGet("GetVacationDropDown")]
        public async Task<ActionResult> GetVacationDropDown()
        {
            var data = await dropDownService
                .GetDropDown<DomainModels.Code>(x => new { Id = x.Id, Value = x.Value }, x => x.CategoryId == 12);
            return Ok(data);
        }
        [HttpGet("GetConsolidationSetDropDown")]
        public async Task<ActionResult> GetConsolidationSetDropDown()
        {
            var data = await dropDownService
                .GetDropDown<DomainModels.Code>(x => new { Id = x.Id, Value = x.Value }, x => x.CategoryId == 13);
            return Ok(data);
        }
        [HttpGet("GetElementCodeDropDown")]
        public async Task<ActionResult> GetElementCodeDropDown()
        {
            var data = await dropDownService
                .GetDropDown<DomainModels.Code>(x => new { Id = x.Id, Value = x.Value }, x => x.CategoryId == 14);
            return Ok(data);
        }
        [HttpGet("GetQualificationCodeDropDown")]
        public async Task<ActionResult> GetQualificationCodeDropDown()
        {
            var data = await dropDownService
                .GetDropDown<DomainModels.Code>(x => new { Id = x.Id, Value = x.Value }, x => x.CategoryId == 15);
            return Ok(data);
        }
        [HttpGet("GetMajorDropDown")]
        public async Task<ActionResult> GetMajorDropDown()
        {
            var data = await dropDownService
                .GetDropDown<DomainModels.Code>(x => new { Id = x.Id, Value = x.Value }, x => x.CategoryId == 16);
            return Ok(data);
        }
        [HttpGet("GetEmployeeStatusCodeDropDown")]
        public async Task<ActionResult> GetEmployeeStatusCodeDropDown()
        {
            var data = await dropDownService
                .GetDropDown<DomainModels.Code>(x => new { Id = x.Id, Value = x.Value }, x => x.CategoryId == 2);
            return Ok(data);
        }
        [HttpGet("GetUniversitiesDropDown")]
        public async Task<ActionResult> GetUniversitiesDropDown()
        {
            var data = await dropDownService
                .GetDropDown<DomainModels.University>(selector: x => new { Id = x.UniversityId, Value = x.UniversityName }, null);
            return Ok(data);
        }
        [HttpGet("GetGradesDropDown")]
        public async Task<ActionResult> GetGradesDropDown()
        {
            var data = AllEnums.Grade.GetGrades();
            return Ok(data);
        }
        [HttpGet("GetQualificationStatusDropDown")]
        public async Task<ActionResult> GetQualificationStatusDropDown()
        {
            var data = AllEnums.QualificationStatus.GetQualificationStatus();
            return Ok(data);
        }
        [HttpGet("GetRankCodeDropDown")]
        public async Task<ActionResult> GetRankCodeDropDown()
        {
            var data = await dropDownService
              .GetDropDown<DomainModels.Code>(selector: x => new { Id = x.Code1, Value = x.Value }, x => x.CategoryId == 1);
            return Ok(data);
        }
        [HttpGet("GetEmploymentTypeCodeDropDown")]
        public async Task<ActionResult> GetEmploymentTypeCodeDropDown()
        {
            var data = await dropDownService
              .GetDropDown<DomainModels.Code>(selector: x => new { Id = x.Code1, Value = x.Value }, x => x.CategoryId == 3);
            return Ok(data);
        }
        [HttpGet("GetActualJobNameCodeDropDown")]
        public async Task<ActionResult> GetActualJobNameCodeDropDown()
        {
            var data = await dropDownService
              .GetDropDown<DomainModels.Code>(selector: x => new { Id = x.Code1, Value = x.Value }, x => x.CategoryId == 4);
            return Ok(data);
        }
        [HttpGet("GetTransactionCodeDropDown")]
        public async Task<ActionResult> GetTransactionCodeDropDown()
        {
            var data = await dropDownService
              .GetDropDown<DomainModels.Code>(selector: x => new { Id = x.Code1, Value = x.Value }, x => x.CategoryId == 5);
            return Ok(data);
        }
        [HttpGet("GetTerminationCodeDropDown")]
        public async Task<ActionResult> GetTerminationCodeDropDown()
        {
            var data = await dropDownService
              .GetDropDown<DomainModels.Code>(selector: x => new { Id = x.Code1, Value = x.Value }, x => x.CategoryId == 6);
            return Ok(data);
        }
        [HttpGet("GetElementClassificationTypeDropDown")]
        public async Task<ActionResult> GetElementClassificationTypeDropDown()
        {
            var data = await dropDownService
              .GetEnumDropDown<ElementClassificationType>();
            return Ok(data);
        }
        [HttpGet("GetPositionStatusDropDown")]
        public async Task<ActionResult> GetPositionStatusDropDown()
        {
            var data = await dropDownService
              .GetEnumDropDown<PositionStatusType>();
            return Ok(data);
        }
        [HttpGet("GetAppraisalTypesDropDown")]
        public async Task<ActionResult> GetAppraisalTypesDropDown()
        {
            var data = AllEnums.AppraisalType.GetAppraisalTypes();
            return Ok(data);
        }
        [HttpGet("GetRegionsDropDown")]
        public async Task<ActionResult> GetRegionsDropDown()
        {
            var data = await dropDownService
                .GetDropDown<DomainModels.LocationCode>(selector: x => new { Id = x.RegionCode, Value = x.RegionName }, null);
            return Ok(data);
        }
        [HttpGet("GetGovernoratesDropDown/{RegionCode}")]
        public async Task<ActionResult> GetGovernoratesDropDown(string RegionCode)
        {
            var data = await dropDownService
        .GetDropDown<DomainModels.LocationCode>(selector: x => new { Id = x.GovernorateCode, Value = x.GovernorateName }, x => x.RegionCode == RegionCode);
            return Ok(data);
        }
        [HttpGet("GetLocationCodesDropDown/{Governorate}")]
        public async Task<ActionResult> GetLocationCodesDropDown(string Governorate)
        {
            var data = await dropDownService
        .GetDropDown<DomainModels.LocationCode>(selector: x => new { Id = x.Code, Value = x.LocationName }, x => x.GovernorateCode == Governorate);
            return Ok(data);
        }


    }
}
