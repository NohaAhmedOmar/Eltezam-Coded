using Eltezam_Coded.Enums;
using Eltezam_Coded.Extensions;
using Eltezam_Coded.Services;
using ElTezam_Coded_WebApp.DomainModels;
using ElTezam_Coded_WebApp.Services;
using Microsoft.AspNetCore.Mvc;
using System.Xml;

namespace ElTezam_Coded_WebApp.APIControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SendToServiceController : ControllerBase
    {
        private readonly ISendSoapRequestService sendSoapRequestService;
        private readonly IEmployeeService employeeService;

        public SendToServiceController(ISendSoapRequestService sendSoapRequestService, IEmployeeService employeeService)
        {
            this.sendSoapRequestService = sendSoapRequestService;
            this.employeeService = employeeService;
        }

        [HttpPost("SendEmployeeToService")]
        public async Task<IActionResult> SendEmployeeToService(List<long> Ids)
        {
            try
            {
                var results = await employeeService.GetEmployeesForSoap(Ids);
                foreach (var data in results)
                {
                    //var xmlbody = GenerateEmployeeInfoXML(data);
                    string body = @$"<soapenv:Envelope xmlns:soapenv=""http://schemas.xmlsoap.org/soap/envelope/"" xmlns:tem=""http://tempuri.org/"" xmlns:ver=""http://yefi.gov.sa/MCS/EltezamDataSchema/xml/schemas/version2.0"" xmlns:ver1=""http://yefi.gov.sa/PersonProfileCommonTypes/xml/schemas/version2.0"">
<soapenv:Header/>
<soapenv:Body>
<tem:SubmitEmployeeInfo>
<tem:employeeInfo>
<SubAgencyID>2122</SubAgencyID>
<EmployeeInfo>
<ver:EmployeeID>{data.EmployeeId}</ver:EmployeeID>
<ver:PersonalInfo>
<ver:PersonIdentifier>
<ver1:NationalID>{data.NationalId}</ver1:NationalID>
</ver:PersonIdentifier>
<ver:PersonNameAr>
<ver:FirstName>{data.FirstNameAr}</ver:FirstName>
<ver:SecondName>{data.SecondNameAr}</ver:SecondName>
<ver:LastName>{data.LastNameAr}</ver:LastName>
</ver:PersonNameAr>
<ver:BirthDate>{data.BirthDate}</ver:BirthDate>
<ver:Gender>{(data.Gender == 1 ? "M" : "F")}</ver:Gender>
<ver:NationalityCode>{data.NationalityCode}</ver:NationalityCode>
<ver:Religion>{AllEnums.ReligionType.SearchReligionType((int)data.Religion)}</ver:Religion>
<ver:MaritalStatus>{AllEnums.MaritalStatusType.SearchMaritalStatus(data.MaritalStatus)}</ver:MaritalStatus>
<ver:Healthstatus>{AllEnums.HealthStatusType.SearchHealthStatusType(data.Healthstatus)}</ver:Healthstatus>
</ver:PersonalInfo>
<ver:EmployeeStatusCode>{data.EmployeeStatusCode}</ver:EmployeeStatusCode>
<ver:JobInfo>
<ver:JobNumber>{data.JobNumber}</ver:JobNumber>
<ver:JobClassCode>{data.JobClassCode}</ver:JobClassCode>
<ver:JobNameCode>{data.JobNameCode}</ver:JobNameCode>
<ver:EmploymentTypeCode>{data.EmploymentTypeCode}</ver:EmploymentTypeCode>
<ver:RankCode>{data.RankCode}</ver:RankCode>
<ver:StepID>{data.StepId}</ver:StepID>
<ver:FirstGradeDate>{data.FirstGradeDate}</ver:FirstGradeDate>
<ver:JobOrganizationID>{data.JobOrganizationId}</ver:JobOrganizationID>
<ver:JobOrganizationName>{data.JobOrganizationName}</ver:JobOrganizationName>
<ver:BasicSalary>{data.BasicSalary}</ver:BasicSalary>
</ver:JobInfo>
<ver:LocationCode>{data.LocationCode}</ver:LocationCode>
<ver:MinistryHireDate>{data.MinistryHireDate}</ver:MinistryHireDate>
<ver:IsActive>{(data.IsActive ? "Yes" : "No")}</ver:IsActive>
</EmployeeInfo>
<LastUpdateDate>{data.FirstGradeDate}</LastUpdateDate>
</tem:employeeInfo>
</tem:SubmitEmployeeInfo>
</soapenv:Body>
</soapenv:Envelope>";

                    var result = await sendSoapRequestService.SendRequest("http://10.10.10.42/GSBExpress/Employment/MCSEltezamData/2.0/EltezamDataService.svc", body, "http://tempuri.org/IEltezamDataService/SubmitEmployeeInfo");

                    bool isSaved = await saveResponseNumber(1, data.EmployeeId, result.SOAPRequestNumber);
                }

                return Ok(results);
            }
            catch (Exception)
            {
                return Problem();
            }
        }
        private string GenerateEmployeeInfoXML(Employee data)
        {
            // Create an XmlDocument instance
            XmlDocument xmlDoc = new XmlDocument();

            // Create the root element (<soapenv:Envelope>)
            XmlElement envelopeElement = xmlDoc.CreateElement("soapenv", "Envelope", "http://schemas.xmlsoap.org/soap/envelope/");

            // Create a namespace manager to handle namespaces
            XmlNamespaceManager namespaceManager = new XmlNamespaceManager(xmlDoc.NameTable);
            namespaceManager.AddNamespace("tem", "http://tempuri.org/");
            namespaceManager.AddNamespace("ver", "http://yefi.gov.sa/MCS/EltezamDataSchema/xml/schemas/version2.0");
            namespaceManager.AddNamespace("ver1", "http://yefi.gov.sa/PersonProfileCommonTypes/xml/schemas/version2.0");

            // Create the <soapenv:Header/> element
            XmlElement headerElement = xmlDoc.CreateElement("soapenv", "Header", "http://schemas.xmlsoap.org/soap/envelope/");
            envelopeElement.AppendChild(headerElement);

            // Create the <soapenv:Body> element
            XmlElement bodyElement = xmlDoc.CreateElement("soapenv", "Body", "http://schemas.xmlsoap.org/soap/envelope/");
            envelopeElement.AppendChild(bodyElement);

            // Create the <tem:SubmitEmployeeAppraisalInfo> element
            XmlElement SubmitEmployee = xmlDoc.CreateElement("tem", "SubmitEmployeeInfo");
            bodyElement.AppendChild(SubmitEmployee);

            // Create the <tem:employeeAppraisalInfo> element
            XmlElement employeeInfo = xmlDoc.CreateElement("tem", "employeeInfo");
            SubmitEmployee.AppendChild(employeeInfo);

            // Create the <SubAgencyID> element
            XmlElement subAgencyIDElement = xmlDoc.CreateElement("SubAgencyID");
            subAgencyIDElement.InnerText = "2122";
            employeeInfo.AppendChild(subAgencyIDElement);

            XmlElement EmployeeInfo = xmlDoc.CreateElement("tem", "EmployeeInfo");
            employeeInfo.AppendChild(EmployeeInfo);

            XmlElement employeeIDElement = xmlDoc.CreateElement("ver", "EmployeeID");
            employeeIDElement.InnerText = $"{data.EmployeeId}";
            EmployeeInfo.AppendChild(employeeIDElement);

            // Create the <PersonIdentifier> element
            XmlElement PersonalInfo = xmlDoc.CreateElement("ver", "PersonalInfo");
            EmployeeInfo.AppendChild(PersonalInfo);

            XmlElement personIdentifierElement = xmlDoc.CreateElement("ver", "PersonIdentifier");
            PersonalInfo.AppendChild(personIdentifierElement);

            XmlElement nationalIDElement = xmlDoc.CreateElement("ver1", "NationalID");
            nationalIDElement.InnerText = $"{data.NationalId}";
            personIdentifierElement.AppendChild(nationalIDElement);

            XmlElement PersonNameAr = xmlDoc.CreateElement("ver", "PersonNameAr");
            PersonalInfo.AppendChild(PersonNameAr);

            XmlElement FirstName = xmlDoc.CreateElement("ver", "FirstName");
            FirstName.InnerText = $"{data.FirstNameAr}";
            PersonNameAr.AppendChild(FirstName);

            // Create the <ver1:StartDate> element
            XmlElement SecondNameAr = xmlDoc.CreateElement("ver", "SecondName");
            SecondNameAr.InnerText = $"{data.SecondNameAr}";
            PersonNameAr.AppendChild(SecondNameAr);

            XmlElement LastName = xmlDoc.CreateElement("ver", "LastName");
            LastName.InnerText = $"{data.LastNameAr}";
            PersonNameAr.AppendChild(LastName);

            // Create the <ver1:AppraisalTypeCode> element
            XmlElement BirthDate = xmlDoc.CreateElement("ver", "BirthDate");
            BirthDate.InnerText = $"{data.BirthDate}";
            PersonalInfo.AppendChild(BirthDate);

            // Create the <ver1:TransactionType> element
            XmlElement Gender = xmlDoc.CreateElement("ver", "Gender");
            Gender.InnerText = $"{(data.Gender == 1 ? "M" : "F")}";
            PersonalInfo.AppendChild(Gender);

            // Create the <ver1:Result> element
            XmlElement NationalityCode = xmlDoc.CreateElement("ver", "NationalityCode");
            NationalityCode.InnerText = $"{data.NationalityCode}";
            PersonalInfo.AppendChild(NationalityCode);

            // Create the <ver1:RatingCode> element
            XmlElement Religion = xmlDoc.CreateElement("ver", "Religion");
            Religion.InnerText = $"{AllEnums.ReligionType.SearchReligionType((int)data.Religion)}";
            PersonalInfo.AppendChild(Religion);

            XmlElement MaritalStatus = xmlDoc.CreateElement("ver", "MaritalStatus");
            MaritalStatus.InnerText = $"{AllEnums.MaritalStatusType.SearchMaritalStatus(data.MaritalStatus)}";
            PersonalInfo.AppendChild(MaritalStatus);

            XmlElement Healthstatus = xmlDoc.CreateElement("ver", "Healthstatus");
            Healthstatus.InnerText = $"{AllEnums.HealthStatusType.SearchHealthStatusType(data.Healthstatus)}";
            PersonalInfo.AppendChild(Healthstatus);

            XmlElement EmployeeStatusCode = xmlDoc.CreateElement("ver", "EmployeeStatusCode");
            EmployeeStatusCode.InnerText = $"{data.EmployeeStatusCode}";
            EmployeeInfo.AppendChild(EmployeeStatusCode);

            XmlElement JobInfo = xmlDoc.CreateElement("ver", "JobInfo");
            EmployeeInfo.AppendChild(JobInfo);

            XmlElement JobNumber = xmlDoc.CreateElement("ver", "JobNumber");
            JobNumber.InnerText = $"{data.JobNumber}";
            JobInfo.AppendChild(JobNumber);

            XmlElement JobClassCode = xmlDoc.CreateElement("ver", "JobClassCode");
            JobClassCode.InnerText = $"{data.JobClassCode}";
            JobInfo.AppendChild(JobClassCode);

            XmlElement JobNameCode = xmlDoc.CreateElement("ver", "JobNameCode");
            JobNameCode.InnerText = $"{data.JobNameCode}";
            JobInfo.AppendChild(JobNameCode);

            XmlElement EmploymentTypeCode = xmlDoc.CreateElement("ver", "EmploymentTypeCode");
            EmploymentTypeCode.InnerText = $"{data.EmploymentTypeCode}";
            JobInfo.AppendChild(EmploymentTypeCode);

            XmlElement RankCode = xmlDoc.CreateElement("ver", "RankCode");
            RankCode.InnerText = $"{data.RankCode}";
            JobInfo.AppendChild(RankCode);

            XmlElement StepID = xmlDoc.CreateElement("ver", "StepID");
            StepID.InnerText = $"{data.StepId}";
            JobInfo.AppendChild(StepID);

            XmlElement FirstGradeDate = xmlDoc.CreateElement("ver", "FirstGradeDate");
            FirstGradeDate.InnerText = $"{data.FirstGradeDate}";
            JobInfo.AppendChild(FirstGradeDate);

            XmlElement JobOrganizationID = xmlDoc.CreateElement("ver", "JobOrganizationID");
            JobOrganizationID.InnerText = $"{data.JobOrganizationId}";
            JobInfo.AppendChild(JobOrganizationID);

            XmlElement JobOrganizationName = xmlDoc.CreateElement("ver", "JobOrganizationName");
            JobOrganizationName.InnerText = $"{data.JobOrganizationName}";
            JobInfo.AppendChild(JobOrganizationName);

            XmlElement BasicSalary = xmlDoc.CreateElement("ver", "BasicSalary");
            BasicSalary.InnerText = $"{data.BasicSalary}";
            JobInfo.AppendChild(BasicSalary);

            XmlElement LocationCode = xmlDoc.CreateElement("ver", "LocationCode");
            LocationCode.InnerText = $"{data.LocationCode}";
            EmployeeInfo.AppendChild(LocationCode);

            XmlElement MinistryHireDate = xmlDoc.CreateElement("ver", "MinistryHireDate");
            MinistryHireDate.InnerText = $"{data.MinistryHireDate}";
            EmployeeInfo.AppendChild(MinistryHireDate);

            XmlElement IsActive = xmlDoc.CreateElement("ver", "IsActive");
            IsActive.InnerText = $"{(data.IsActive ? "Yes" : "No")}";
            EmployeeInfo.AppendChild(IsActive);

            XmlElement LastUpdateDate = xmlDoc.CreateElement("ver", "LastUpdateDate");
            LastUpdateDate.InnerText = $"{data.LastUpdateDate}";
            employeeInfo.AppendChild(LastUpdateDate);

            // Append the root element to the XML document
            xmlDoc.AppendChild(envelopeElement);
            return xmlDoc.OuterXml;
        }

        [HttpPost("SendAppraisalToService")]
        public async Task<IActionResult> SendAppraisalToService(List<long> Ids)
        {
            try
            {
                var results = await employeeService.GetAppraisalForSoap(Ids);
                foreach (var data in results)
                {
                    //String xmlStr = GenerateEmployeeAppraisalInfoXML(data);
                    string body = @$"<soapenv:Envelope xmlns:soapenv=""http://schemas.xmlsoap.org/soap/envelope/"" xmlns:tem=""http://tempuri.org/"" xmlns:ver=""http://yefi.gov.sa/PersonProfileCommonTypes/xml/schemas/version2.0"" xmlns:ver1=""http://yefi.gov.sa/MCS/EltezamDataSchema/xml/schemas/version2.0"">
<soapenv:Header/>
<soapenv:Body>
<tem:SubmitEmployeeAppraisalInfo>
<tem:employeeAppraisalInfo>
<SubAgencyID>1238</SubAgencyID>
<PersonIdentifier>
<ver:NationalID>{data.NationalId}</ver:NationalID>
</PersonIdentifier>
<EmployeeID>{data.EmployeeId}</EmployeeID>
<AppraisalInfo>
<ver1:AppraisalID>{data.AppraisalId}</ver1:AppraisalID>
<ver1:StartDate>{data.StartDate}</ver1:StartDate>
<ver1:EndDate>{data.EndDate}</ver1:EndDate>
<ver1:AppraisalTypeCode>{data.AppraisalTypeCode}</ver1:AppraisalTypeCode>
<ver1:TransactionType>{data.TransactionType}</ver1:TransactionType>
<ver1:Result>{data.Result}</ver1:Result>
<ver1:RatingCode>{data.RatingCode}</ver1:RatingCode>
</AppraisalInfo>
</tem:employeeAppraisalInfo>
</tem:SubmitEmployeeAppraisalInfo>
</soapenv:Body>
</soapenv:Envelope>";
                    var result = await sendSoapRequestService.SendRequest("http://10.10.10.42/GSBExpress/Employment/MCSEltezamData/2.0/EltezamDataService.svc", body, "http://tempuri.org/IEltezamDataService/SubmitEmployeeAppraisalInfo");
                    bool isSaved = await saveResponseNumber(2, data.AppraisalId, result.SOAPRequestNumber);
                }

                return Ok(results);
            }
            catch (Exception)
            {
                return Problem();
            }
        }

        private string GenerateEmployeeAppraisalInfoXML(EmployeeAppraisalInfo data)
        {
            // Create an XmlDocument instance
            XmlDocument xmlDoc = new XmlDocument();

            // Create the root element (<soapenv:Envelope>)
            XmlElement envelopeElement = xmlDoc.CreateElement("soapenv", "Envelope", "http://schemas.xmlsoap.org/soap/envelope/");

            // Create a namespace manager to handle namespaces
            XmlNamespaceManager namespaceManager = new XmlNamespaceManager(xmlDoc.NameTable);
            namespaceManager.AddNamespace("tem", "http://tempuri.org/");
            namespaceManager.AddNamespace("ver", "http://yefi.gov.sa/MCS/EltezamDataSchema/xml/schemas/version2.0");
            namespaceManager.AddNamespace("ver1", "http://yefi.gov.sa/PersonProfileCommonTypes/xml/schemas/version2.0");

            // Create the <soapenv:Header/> element
            XmlElement headerElement = xmlDoc.CreateElement("soapenv", "Header", "http://schemas.xmlsoap.org/soap/envelope/");
            envelopeElement.AppendChild(headerElement);

            // Create the <soapenv:Body> element
            XmlElement bodyElement = xmlDoc.CreateElement("soapenv", "Body", "http://schemas.xmlsoap.org/soap/envelope/");
            envelopeElement.AppendChild(bodyElement);

            XmlElement submitAppraisalInfoElement = xmlDoc.CreateElement("tem", "SubmitEmployeeAppraisalInfo");
            bodyElement.AppendChild(submitAppraisalInfoElement);

            XmlElement employeeAppraisalInfoElement = xmlDoc.CreateElement("tem", "employeeAppraisalInfo");
            submitAppraisalInfoElement.AppendChild(employeeAppraisalInfoElement);

            XmlElement subAgencyIDElement = xmlDoc.CreateElement("SubAgencyID");
            subAgencyIDElement.InnerText = "2122";
            employeeAppraisalInfoElement.AppendChild(subAgencyIDElement);

            XmlElement personIdentifierElement = xmlDoc.CreateElement("PersonIdentifier");
            employeeAppraisalInfoElement.AppendChild(personIdentifierElement);

            XmlElement nationalIDElement = xmlDoc.CreateElement("ver", "NationalID");
            nationalIDElement.InnerText = $"{data.NationalId}";
            personIdentifierElement.AppendChild(nationalIDElement);

            XmlElement employeeIDElement = xmlDoc.CreateElement("EmployeeID");
            employeeIDElement.InnerText = $"{data.EmployeeId}";
            employeeAppraisalInfoElement.AppendChild(employeeIDElement);

            XmlElement appraisalInfoElement = xmlDoc.CreateElement("AppraisalInfo");
            employeeAppraisalInfoElement.AppendChild(appraisalInfoElement);

            XmlElement appraisalIDElement = xmlDoc.CreateElement("ver1", "AppraisalID");
            appraisalIDElement.InnerText = $"{data.AppraisalId}";
            appraisalInfoElement.AppendChild(appraisalIDElement);

            XmlElement startDateElement = xmlDoc.CreateElement("ver1", "StartDate");
            startDateElement.InnerText = $"{data.StartDate}";
            appraisalInfoElement.AppendChild(startDateElement);

            XmlElement endDateElement = xmlDoc.CreateElement("ver1", "EndDate");
            endDateElement.InnerText = $"{data.EndDate}";
            appraisalInfoElement.AppendChild(endDateElement);

            XmlElement appraisalTypeCodeElement = xmlDoc.CreateElement("ver1", "AppraisalTypeCode");
            appraisalTypeCodeElement.InnerText = $"{data.AppraisalTypeCode}";
            appraisalInfoElement.AppendChild(appraisalTypeCodeElement);

            XmlElement transactionTypeElement = xmlDoc.CreateElement("ver1", "TransactionType");
            transactionTypeElement.InnerText = $"{data.TransactionType}";
            appraisalInfoElement.AppendChild(transactionTypeElement);

            XmlElement resultElement = xmlDoc.CreateElement("ver1", "Result");
            resultElement.InnerText = $"{data.Result}";
            appraisalInfoElement.AppendChild(resultElement);

            XmlElement ratingCodeElement = xmlDoc.CreateElement("ver1", "RatingCode");
            ratingCodeElement.InnerText = $"{data.RatingCode}";
            appraisalInfoElement.AppendChild(ratingCodeElement);

            // Append the root element to the XML document
            xmlDoc.AppendChild(envelopeElement);
            return xmlDoc.OuterXml;
        }

        [HttpPost("SendHistoricalInfoToService")]
        public async Task<IActionResult> SendHistoricalInfoToService(List<long> Ids)
        {
            try
            {
                var results = await employeeService.GetHistoricalInfoForSoap(Ids);
                foreach (var data in results)
                {
                    //var xmlbody = GenerateHistoricalInfoXML(data);
                    string body = @$"<soapenv:Envelope xmlns:soapenv=""http://schemas.xmlsoap.org/soap/envelope/"" xmlns:tem=""http://tempuri.org/"" xmlns:ver=""http://yefi.gov.sa/PersonProfileCommonTypes/xml/schemas/version2.0"">
<soapenv:Header/>
<soapenv:Body>
<tem:SubmitEmployeeHistoricalInfo>
<tem:employeeHistoricalInfo>
<SubAgencyID>1238</SubAgencyID>
<EmployeeID>{data.EmployeeId}</EmployeeID>
<PersonIdentifier>
<ver:NationalID>{data.NationalId}</ver:NationalID>
</PersonIdentifier>
<JobNumber>{data.JobNumber}</JobNumber>
<JobClassCode>{data.JobClassCode}</JobClassCode>
<JobNameCode>{data.JobNameCode}</JobNameCode>
<EmploymentTypeCode>{data.EmploymentTypeCode}</EmploymentTypeCode>
<RankCode>{data.RankCode}</RankCode>
<LocationCode>{data.LocationCode}</LocationCode>
<TransactionCode>{data.TransactionCode}</TransactionCode>
<TransactionStartDate>{data.TransactionStartDate}</TransactionStartDate>
<LastUpdateDate>{data.LastUpdateDate}</LastUpdateDate>
</tem:employeeHistoricalInfo>
</tem:SubmitEmployeeHistoricalInfo>
</soapenv:Body>
</soapenv:Envelope>";
                    var result = await sendSoapRequestService.SendRequest("http://10.10.10.42/GSBExpress/Employment/MCSEltezamData/2.0/EltezamDataService.svc", body, "http://tempuri.org/IEltezamDataService/SubmitEmployeeHistoricalInfo");
                    bool isSaved = await saveResponseNumber(3, data.Id, result.SOAPRequestNumber);
                }

                return Ok(results);

            }
            catch (Exception)
            {
                return Problem();
            }
        }
        private string GenerateHistoricalInfoXML(EmployeeJob data)
        {
            // Create an XmlDocument instance
            XmlDocument xmlDoc = new XmlDocument();

            // Create the root element (<soapenv:Envelope>)
            XmlElement envelopeElement = xmlDoc.CreateElement("soapenv", "Envelope", "http://schemas.xmlsoap.org/soap/envelope/");

            // Create a namespace manager to handle namespaces
            XmlNamespaceManager namespaceManager = new XmlNamespaceManager(xmlDoc.NameTable);
            namespaceManager.AddNamespace("tem", "http://tempuri.org/");
            namespaceManager.AddNamespace("ver", "http://yefi.gov.sa/MCS/EltezamDataSchema/xml/schemas/version2.0");
            namespaceManager.AddNamespace("ver1", "http://yefi.gov.sa/PersonProfileCommonTypes/xml/schemas/version2.0");

            // Create the <soapenv:Header/> element
            XmlElement headerElement = xmlDoc.CreateElement("soapenv", "Header", "http://schemas.xmlsoap.org/soap/envelope/");
            envelopeElement.AppendChild(headerElement);

            // Create the <soapenv:Body> element
            XmlElement bodyElement = xmlDoc.CreateElement("soapenv", "Body", "http://schemas.xmlsoap.org/soap/envelope/");
            envelopeElement.AppendChild(bodyElement);

            XmlElement SubmitEmployeeHistoricalInfo = xmlDoc.CreateElement("tem", "SubmitEmployeeHistoricalInfo");
            bodyElement.AppendChild(SubmitEmployeeHistoricalInfo);

            XmlElement employeeHistoricalInfo = xmlDoc.CreateElement("tem", "employeeHistoricalInfo");
            SubmitEmployeeHistoricalInfo.AppendChild(employeeHistoricalInfo);

            XmlElement subAgencyIDElement = xmlDoc.CreateElement("SubAgencyID");
            subAgencyIDElement.InnerText = "2122";
            employeeHistoricalInfo.AppendChild(subAgencyIDElement);

            XmlElement employeeIDElement = xmlDoc.CreateElement("EmployeeID");
            employeeIDElement.InnerText = $"{data.EmployeeId}";
            employeeHistoricalInfo.AppendChild(employeeIDElement);

            XmlElement personIdentifierElement = xmlDoc.CreateElement("PersonIdentifier");
            employeeHistoricalInfo.AppendChild(personIdentifierElement);

            XmlElement nationalIDElement = xmlDoc.CreateElement("ver", "NationalID");
            nationalIDElement.InnerText = $"{data.NationalId}";
            personIdentifierElement.AppendChild(nationalIDElement);

            XmlElement JobNumber = xmlDoc.CreateElement("JobNumber");
            JobNumber.InnerText = $"{data.JobNumber}";
            employeeHistoricalInfo.AppendChild(JobNumber);

            XmlElement JobClassCode = xmlDoc.CreateElement("JobClassCode");
            JobClassCode.InnerText = $"{data.JobClassCode}";
            employeeHistoricalInfo.AppendChild(JobClassCode);

            XmlElement JobNameCode = xmlDoc.CreateElement("JobNameCode");
            JobNameCode.InnerText = $"{data.JobNameCode}";
            employeeHistoricalInfo.AppendChild(JobNameCode);

            XmlElement EmploymentTypeCode = xmlDoc.CreateElement("EmploymentTypeCode");
            EmploymentTypeCode.InnerText = $"{data.EmploymentTypeCode}";
            employeeHistoricalInfo.AppendChild(EmploymentTypeCode);

            XmlElement RankCode = xmlDoc.CreateElement("RankCode");
            RankCode.InnerText = $"{data.RankCode}";
            employeeHistoricalInfo.AppendChild(RankCode);

            XmlElement LocationCode = xmlDoc.CreateElement("LocationCode");
            LocationCode.InnerText = $"{data.LocationCode}";
            employeeHistoricalInfo.AppendChild(LocationCode);

            XmlElement TransactionCode = xmlDoc.CreateElement("TransactionCode");
            TransactionCode.InnerText = $"{data.TransactionCode}";
            employeeHistoricalInfo.AppendChild(TransactionCode);

            XmlElement TransactionStartDate = xmlDoc.CreateElement("TransactionStartDate");
            TransactionStartDate.InnerText = $"{data.TransactionStartDate}";
            employeeHistoricalInfo.AppendChild(TransactionStartDate);

            XmlElement LastUpdateDate = xmlDoc.CreateElement("LastUpdateDate");
            LastUpdateDate.InnerText = $"{data.LastUpdateDate}";
            employeeHistoricalInfo.AppendChild(LastUpdateDate);

            // Append the root element to the XML document
            xmlDoc.AppendChild(envelopeElement);
            return xmlDoc.OuterXml;
        }

        [HttpPost("SendJobInfoToService")]
        public async Task<IActionResult> SendJobInfoToService(List<long> Ids)
        {
            try
            {
                var results = await employeeService.GetJobInfoForSoap(Ids);
                foreach (var data in results)
                {
                    //var xmlbody = GenerateJobInfoXML(data);
                    string body = string.Empty;
                    if (data.PositionStatus == AllEnums.PositionStatusType.Occupied.ToString())
                    {
                        body = @$"<soapenv:Envelope xmlns:soapenv=""http://schemas.xmlsoap.org/soap/envelope/"" xmlns:tem=""http://tempuri.org/"" xmlns:ver=""http://yefi.gov.sa/PersonProfileCommonTypes/xml/schemas/version2.0"">
<soapenv:Header/>
<soapenv:Body>
<tem:SubmitJobInfo>
<tem:jobInfo>
<SubAgencyID>1238</SubAgencyID>
<JobNumber>{data.JobNumber}</JobNumber>
<JobClassCode>{data.JobClassCode}</JobClassCode>
<JobNameCode>{data.JobNameCode}</JobNameCode>
<JobPositionCode>{data.JobPositionCode}</JobPositionCode>
<StartDate>{data.StartDate}</StartDate>
<PositionOrganizationID>{data.PositionOrganizationId}</PositionOrganizationID>
<PositionOrganizationName>{data.PositionOrganizationName}</PositionOrganizationName>
<PositionStatus>{data.PositionStatus}</PositionStatus>
<EmploymentTypeCode>{data.EmploymentTypeCode}</EmploymentTypeCode>
<RankCode>{data.RankCode}</RankCode>
<LocationCode>{data.LocationCode}</LocationCode>
<LastUpdateDate>{data.LastUpdateDate}</LastUpdateDate>
</tem:jobInfo>
</tem:SubmitJobInfo>
</soapenv:Body>
</soapenv:Envelope>";
                    }
                    else
                    {
                        body = @$"<soapenv:Envelope xmlns:soapenv=""http://schemas.xmlsoap.org/soap/envelope/"" xmlns:tem=""http://tempuri.org/"" xmlns:ver=""http://yefi.gov.sa/PersonProfileCommonTypes/xml/schemas/version2.0"">
<soapenv:Header/>
<soapenv:Body>
<tem:SubmitJobInfo>
<tem:jobInfo>
<SubAgencyID>1238</SubAgencyID>
<EmployeeID>{data.EmployeeId}</EmployeeID>
<PersonIdentifier>
<ver:NationalID>{data.NationalId}</ver:NationalID>
</PersonIdentifier>
<JobNumber>{data.JobNumber}</JobNumber>
<JobClassCode>{data.JobClassCode}</JobClassCode>
<JobNameCode>{data.JobNameCode}</JobNameCode>
<JobPositionCode>{data.JobPositionCode}</JobPositionCode>
<StartDate>{data.StartDate}</StartDate>
<PositionOrganizationID>{data.PositionOrganizationId}</PositionOrganizationID>
<PositionOrganizationName>{data.PositionOrganizationName}</PositionOrganizationName>
<PositionStatus>{data.PositionStatus}</PositionStatus>
<EmploymentTypeCode>{data.EmploymentTypeCode}</EmploymentTypeCode>
<RankCode>{data.RankCode}</RankCode>
<LocationCode>{data.LocationCode}</LocationCode>
<LastUpdateDate>{data.LastUpdateDate}</LastUpdateDate>
</tem:jobInfo>
</tem:SubmitJobInfo>
</soapenv:Body>
</soapenv:Envelope>";
                    }
                    var result = await sendSoapRequestService.SendRequest("http://10.10.10.42/GSBExpress/Employment/MCSEltezamData/2.0/EltezamDataService.svc", body, "http://tempuri.org/IEltezamDataService/SubmitJobInfo");
                    bool isSaved = await saveResponseNumber(4, (long)data.Id, result.SOAPRequestNumber);
                }

                return Ok(results);
            }
            catch (Exception)
            {
                return Problem();
            }
        }
        private string GenerateJobInfoXML(Job data)
        {
            // Create an XmlDocument instance
            XmlDocument xmlDoc = new XmlDocument();

            // Create the root element (<soapenv:Envelope>)
            XmlElement envelopeElement = xmlDoc.CreateElement("soapenv", "Envelope", "http://schemas.xmlsoap.org/soap/envelope/");

            // Create a namespace manager to handle namespaces
            XmlNamespaceManager namespaceManager = new XmlNamespaceManager(xmlDoc.NameTable);
            namespaceManager.AddNamespace("tem", "http://tempuri.org/");
            namespaceManager.AddNamespace("ver", "http://yefi.gov.sa/PersonProfileCommonTypes/xml/schemas/version2.0");
            namespaceManager.AddNamespace("ver1", "http://yefi.gov.sa/MCS/EltezamDataSchema/xml/schemas/version2.0");

            // Create the <soapenv:Header/> element
            XmlElement headerElement = xmlDoc.CreateElement("soapenv", "Header", "http://schemas.xmlsoap.org/soap/envelope/");
            envelopeElement.AppendChild(headerElement);

            // Create the <soapenv:Body> element
            XmlElement bodyElement = xmlDoc.CreateElement("soapenv", "Body", "http://schemas.xmlsoap.org/soap/envelope/");
            envelopeElement.AppendChild(bodyElement);

            // Create the <tem:SubmitEmployeeAppraisalInfo> element
            XmlElement SubmitJobInfo = xmlDoc.CreateElement("tem", "SubmitJobInfo", "http://tempuri.org/");
            bodyElement.AppendChild(SubmitJobInfo);

            // Create the <tem:employeeAppraisalInfo> element
            XmlElement jobInfo = xmlDoc.CreateElement("tem", "jobInfo", "http://tempuri.org/");
            SubmitJobInfo.AppendChild(jobInfo);


            // Create the <SubAgencyID> element
            XmlElement subAgencyIDElement = xmlDoc.CreateElement("SubAgencyID");
            subAgencyIDElement.InnerText = "2122";
            jobInfo.AppendChild(subAgencyIDElement);
            if (data.PositionStatus == AllEnums.PositionStatusType.Occupied.ToString())
            {
                XmlElement employeeIDElement = xmlDoc.CreateElement("EmployeeID");
                employeeIDElement.InnerText = $"{data.EmployeeId}";
                jobInfo.AppendChild(employeeIDElement);

                XmlElement personIdentifierElement = xmlDoc.CreateElement("PersonIdentifier");
                jobInfo.AppendChild(personIdentifierElement);

                // Create the comment inside <PersonIdentifier>
                XmlComment comment = xmlDoc.CreateComment("You have a CHOICE of the next 2 items at this level");
                personIdentifierElement.AppendChild(comment);

                // Create the <ver:NationalID> element
                XmlElement nationalIDElement = xmlDoc.CreateElement("ver", "NationalID", "http://yefi.gov.sa/PersonProfileCommonTypes/xml/schemas/version2.0");
                nationalIDElement.InnerText = $"{data.NationalId}";
                personIdentifierElement.AppendChild(nationalIDElement);

            }


            // Create the <EmployeeID> element


            // Create the <AppraisalInfo> element


            // Create the <ver1:AppraisalID> element
            XmlElement JobNumber = xmlDoc.CreateElement("JobNumber", "http://yefi.gov.sa/MCS/EltezamDataSchema/xml/schemas/version2.0");
            JobNumber.InnerText = $"{data.JobNumber}";
            jobInfo.AppendChild(JobNumber);

            // Create the <ver1:StartDate> element
            XmlElement JobClassCode = xmlDoc.CreateElement("JobClassCode", "http://yefi.gov.sa/MCS/EltezamDataSchema/xml/schemas/version2.0");
            JobClassCode.InnerText = $"{data.JobClassCode}";
            jobInfo.AppendChild(JobClassCode);

            // Create the <ver1:EndDate> element
            XmlElement JobNameCode = xmlDoc.CreateElement("JobNameCode", "http://yefi.gov.sa/MCS/EltezamDataSchema/xml/schemas/version2.0");
            JobNameCode.InnerText = $"{data.JobNameCode}";
            jobInfo.AppendChild(JobNameCode);
            XmlElement JobPositionCode = xmlDoc.CreateElement("JobPositionCode", "http://yefi.gov.sa/MCS/EltezamDataSchema/xml/schemas/version2.0");
            JobPositionCode.InnerText = $"{data.JobPositionCode}";
            jobInfo.AppendChild(JobPositionCode);
            XmlElement EmploymentTypeCode = xmlDoc.CreateElement("EmploymentTypeCode", "http://yefi.gov.sa/MCS/EltezamDataSchema/xml/schemas/version2.0");
            EmploymentTypeCode.InnerText = $"{data.EmploymentTypeCode}";
            jobInfo.AppendChild(EmploymentTypeCode);

            // Create the <ver1:AppraisalTypeCode> element
            XmlElement PositionOrganizationID = xmlDoc.CreateElement("PositionOrganizationID", "http://yefi.gov.sa/MCS/EltezamDataSchema/xml/schemas/version2.0");
            PositionOrganizationID.InnerText = $"{data.PositionOrganizationId}";
            jobInfo.AppendChild(PositionOrganizationID);

            // Create the <ver1:TransactionType> element
            XmlElement PositionOrganizationName = xmlDoc.CreateElement("PositionOrganizationName", "http://yefi.gov.sa/MCS/EltezamDataSchema/xml/schemas/version2.0");
            PositionOrganizationName.InnerText = $"{data.PositionOrganizationName}";
            jobInfo.AppendChild(PositionOrganizationName);

            // Create the <ver1:Result> element
            XmlElement PositionStatus = xmlDoc.CreateElement("PositionStatus", "http://yefi.gov.sa/MCS/EltezamDataSchema/xml/schemas/version2.0");
            PositionStatus.InnerText = $"{data.PositionStatus}";
            jobInfo.AppendChild(PositionStatus);

            // Create the <ver1:RatingCode> element
            XmlElement RankCode = xmlDoc.CreateElement("RankCode", "http://yefi.gov.sa/MCS/EltezamDataSchema/xml/schemas/version2.0");
            RankCode.InnerText = $"{data.RankCode}";
            jobInfo.AppendChild(RankCode);
            XmlElement LocationCode = xmlDoc.CreateElement("LocationCode", "http://yefi.gov.sa/MCS/EltezamDataSchema/xml/schemas/version2.0");
            LocationCode.InnerText = $"{data.LocationCode}";
            jobInfo.AppendChild(LocationCode);
            XmlElement LastUpdateDate = xmlDoc.CreateElement("LastUpdateDate", "http://yefi.gov.sa/MCS/EltezamDataSchema/xml/schemas/version2.0");
            LastUpdateDate.InnerText = $"{data.LastUpdateDate}";
            jobInfo.AppendChild(LastUpdateDate);

            // Append the root element to the XML document
            xmlDoc.AppendChild(envelopeElement);
            return xmlDoc.OuterXml;
        }

        [HttpPost("SendPayslipInfoToService")]
        public async Task<IActionResult> SendPayslipInfoToService(List<long> Ids)
        {
            try
            {
                var results = await employeeService.GetPayslipInfoForSoap(Ids);
                foreach (var data in results)
                {
                    //var xmlbody = GeneratePayslipInfoXML(data);
                    string body = @$"<soapenv:Envelope xmlns:soapenv=""http://schemas.xmlsoap.org/soap/envelope/"" xmlns:tem=""http://tempuri.org/"" xmlns:ver=""http://yefi.gov.sa/PersonProfileCommonTypes/xml/schemas/version2.0"" xmlns:ver1=""http://yefi.gov.sa/MCS/EltezamDataSchema/xml/schemas/version2.0"">
<soapenv:Header/>
<soapenv:Body>
<tem:SubmitEmployeePayslipInfo>
<tem:employeePayslipInfo>
<SubAgencyID>1238</SubAgencyID>
<EmployeeID>{data.EmployeeId}</EmployeeID>
<PersonIdentifier>
<ver:NationalID>{data.NationalId}</ver:NationalID>
</PersonIdentifier>
<EmployeeName>{data.EmployeeName}</EmployeeName>
<EmployeeJobInfo>
<ver1:EmploymentTypeCode>{data.EmploymentTypeCode}</ver1:EmploymentTypeCode>
<ver1:RankCode>{data.RankCode}</ver1:RankCode>
<ver1:StepID>{data.StepId}</ver1:StepID>
</EmployeeJobInfo>
<PayslipList>
<ver1:Payslip>
<ver1:ConsolidationSetID>{data.ConsolidationSetId}</ver1:ConsolidationSetID>
<ver1:ElementCode>{data.ElementCode}</ver1:ElementCode>
<ver1:Amount>{data.Amount}</ver1:Amount>
<ver1:ElementClassification>{data.ElementClassification}</ver1:ElementClassification>
</ver1:Payslip>
</PayslipList>
<NetPay>{data.NetPay}</NetPay>
<HijriMonth>{data.HijriMonth}</HijriMonth>
<GregorianMonth>{data.GregorianMonth}</GregorianMonth>
<HijriYear>{data.HijriYear}</HijriYear>
<GregorianYear>{data.GregorianYear}</GregorianYear>
<PaidDate>{data.PaidDate}</PaidDate>
</tem:employeePayslipInfo>
</tem:SubmitEmployeePayslipInfo>
</soapenv:Body>
</soapenv:Envelope>";

                    var result = await sendSoapRequestService.SendRequest("http://10.10.10.42/GSBExpress/Employment/MCSEltezamData/2.0/EltezamDataService.svc", body, "http://tempuri.org/IEltezamDataService/SubmitEmployeePayslipInfo");
                    bool isSaved = await saveResponseNumber(5, data.EmployeePayId, result.SOAPRequestNumber);
                }

                return Ok(results);
            }
            catch (Exception)
            {
                return Problem();
            }
        }
        private string GeneratePayslipInfoXML(EmployeePayment data)
        {
            // Create an XmlDocument instance
            XmlDocument xmlDoc = new XmlDocument();

            // Create the root element (<soapenv:Envelope>)
            XmlElement envelopeElement = xmlDoc.CreateElement("soapenv", "Envelope", "http://schemas.xmlsoap.org/soap/envelope/");

            // Create a namespace manager to handle namespaces
            XmlNamespaceManager namespaceManager = new XmlNamespaceManager(xmlDoc.NameTable);
            namespaceManager.AddNamespace("tem", "http://tempuri.org/");
            namespaceManager.AddNamespace("ver", "http://yefi.gov.sa/MCS/EltezamDataSchema/xml/schemas/version2.0");
            namespaceManager.AddNamespace("ver1", "http://yefi.gov.sa/PersonProfileCommonTypes/xml/schemas/version2.0");

            // Create the <soapenv:Header/> element
            XmlElement headerElement = xmlDoc.CreateElement("soapenv", "Header", "http://schemas.xmlsoap.org/soap/envelope/");
            envelopeElement.AppendChild(headerElement);

            // Create the <soapenv:Body> element
            XmlElement bodyElement = xmlDoc.CreateElement("soapenv", "Body", "http://schemas.xmlsoap.org/soap/envelope/");
            envelopeElement.AppendChild(bodyElement);

            XmlElement SubmitEmployeePayslipInfo = xmlDoc.CreateElement("tem", "SubmitEmployeePayslipInfo");
            bodyElement.AppendChild(SubmitEmployeePayslipInfo);

            XmlElement employeePayslipInfo = xmlDoc.CreateElement("tem", "employeePayslipInfo");
            SubmitEmployeePayslipInfo.AppendChild(employeePayslipInfo);

            XmlElement subAgencyIDElement = xmlDoc.CreateElement("SubAgencyID");
            subAgencyIDElement.InnerText = "2122";
            employeePayslipInfo.AppendChild(subAgencyIDElement);

            XmlElement employeeIDElement = xmlDoc.CreateElement("EmployeeID");
            employeeIDElement.InnerText = $"{data.EmployeeId}";
            employeePayslipInfo.AppendChild(employeeIDElement);

            XmlElement personIdentifierElement = xmlDoc.CreateElement("PersonIdentifier");
            employeePayslipInfo.AppendChild(personIdentifierElement);

            XmlElement nationalIDElement = xmlDoc.CreateElement("ver", "NationalID");
            nationalIDElement.InnerText = $"{data.NationalId}";
            personIdentifierElement.AppendChild(nationalIDElement);

            XmlElement EmployeeName = xmlDoc.CreateElement("EmployeeName");
            EmployeeName.InnerText = $"{data.EmployeeName}";
            employeePayslipInfo.AppendChild(EmployeeName);

            XmlElement EmployeeJobInfo = xmlDoc.CreateElement("EmployeeJobInfo");
            employeePayslipInfo.AppendChild(EmployeeJobInfo);

            XmlElement EmploymentTypeCode = xmlDoc.CreateElement("ver1", "EmploymentTypeCode");
            EmploymentTypeCode.InnerText = $"{data.EmploymentTypeCode}";
            EmployeeJobInfo.AppendChild(EmploymentTypeCode);

            XmlElement RankCode = xmlDoc.CreateElement("ver1", "RankCode");
            RankCode.InnerText = $"{data.RankCode}";
            EmployeeJobInfo.AppendChild(RankCode);

            XmlElement StepID = xmlDoc.CreateElement("ver1", "StepID");
            StepID.InnerText = $"{data.StepId}";
            EmployeeJobInfo.AppendChild(StepID);

            XmlElement PayslipList = xmlDoc.CreateElement("PayslipList");
            employeePayslipInfo.AppendChild(PayslipList);

            XmlElement Payslip = xmlDoc.CreateElement("ver1", "Payslip");
            PayslipList.AppendChild(Payslip);

            XmlElement ConsolidationSetID = xmlDoc.CreateElement("ver1", "ConsolidationSetID");
            ConsolidationSetID.InnerText = $"{data.ConsolidationSetId}";
            Payslip.AppendChild(ConsolidationSetID);

            XmlElement ElementCode = xmlDoc.CreateElement("ver1", "ElementCode");
            ElementCode.InnerText = $"{data.ElementCode}";
            Payslip.AppendChild(ElementCode);

            XmlElement Amount = xmlDoc.CreateElement("ver1", "Amount");
            Amount.InnerText = $"{data.Amount}";
            Payslip.AppendChild(Amount);

            XmlElement ElementClassification = xmlDoc.CreateElement("ver1", "ElementClassification");
            ElementClassification.InnerText = $"{data.ElementClassification}";
            Payslip.AppendChild(ElementClassification);

            XmlElement NetPay = xmlDoc.CreateElement("NetPay");
            NetPay.InnerText = $"{data.NetPay}";
            employeePayslipInfo.AppendChild(NetPay);

            XmlElement HijriMonth = xmlDoc.CreateElement("HijriMonth");
            HijriMonth.InnerText = $"{data.HijriMonth}";
            employeePayslipInfo.AppendChild(HijriMonth);

            XmlElement GregorianMonth = xmlDoc.CreateElement("GregorianMonth");
            GregorianMonth.InnerText = $"{data.GregorianMonth}";
            employeePayslipInfo.AppendChild(GregorianMonth);

            XmlElement HijriYear = xmlDoc.CreateElement("HijriYear");
            HijriYear.InnerText = $"{data.HijriYear}";
            employeePayslipInfo.AppendChild(HijriYear);

            XmlElement GregorianYear = xmlDoc.CreateElement("GregorianYear");
            GregorianYear.InnerText = $"{data.GregorianYear}";
            employeePayslipInfo.AppendChild(GregorianYear);

            XmlElement PaidDate = xmlDoc.CreateElement("PaidDate");
            PaidDate.InnerText = $"{data.PaidDate}";
            employeePayslipInfo.AppendChild(PaidDate);

            // Append the root element to the XML document
            xmlDoc.AppendChild(envelopeElement);
            return xmlDoc.OuterXml;
        }

        [HttpPost("SendQualificationInfoToService")]
        public async Task<IActionResult> SendQualificationInfoToService(List<long> Ids)
        {
            try
            {
                var results = await employeeService.GetQualificationInfoForSoap(Ids);
                foreach (var data in results)
                {
                    //var xmlbody = GenerateQualificationInfoXML(data);
                    string body = @$"<soapenv:Envelope xmlns:soapenv=""http://schemas.xmlsoap.org/soap/envelope/"" xmlns:tem=""http://tempuri.org/"" xmlns:ver=""http://yefi.gov.sa/PersonProfileCommonTypes/xml/schemas/version2.0"" xmlns:ver1=""http://yefi.gov.sa/MCS/EltezamDataSchema/xml/schemas/version2.0"">
<soapenv:Header/>
<soapenv:Body>
<tem:SubmitEmployeeQualificationInfo>
<tem:employeeQualificationInfo>
<SubAgencyID>1238</SubAgencyID>
<EmployeeID>{data.EmployeeId}</EmployeeID>
<PersonIdentifier>
<ver:NationalID>{data.NationalId}</ver:NationalID>
</PersonIdentifier>
<QualificationList>
<ver1:Qualification>
<ver1:QualificationID>{data.QualificationId}</ver1:QualificationID>
<ver1:QualificationCode>{data.QualificationCode}</ver1:QualificationCode>
<ver1:MajorCode>{data.MajorCode}</ver1:MajorCode>
<ver1:UniversityCode>{data.UniversityCode}</ver1:UniversityCode>
<ver1:TransactionType>{data.TransactionType}</ver1:TransactionType>
<ver1:QualificationStatus>{data.QualificationStatus}</ver1:QualificationStatus>
</ver1:Qualification>
</QualificationList>
</tem:employeeQualificationInfo>
</tem:SubmitEmployeeQualificationInfo>
</soapenv:Body>
</soapenv:Envelope>";

                    var result = await sendSoapRequestService.SendRequest("http://10.10.10.42/GSBExpress/Employment/MCSEltezamData/2.0/EltezamDataService.svc", body, "http://tempuri.org/IEltezamDataService/SubmitEmployeeQualificationInfo");
                    bool isSaved = await saveResponseNumber(6, data.QualificationId, result.SOAPRequestNumber);
                }

                return Ok(results);
            }
            catch (Exception)
            {
                return Problem();
            }
        }
        private string GenerateQualificationInfoXML(EmployeeQualification data)
        {
            // Create an XmlDocument instance
            XmlDocument xmlDoc = new XmlDocument();

            // Create the root element (<soapenv:Envelope>)
            XmlElement envelopeElement = xmlDoc.CreateElement("soapenv", "Envelope", "http://schemas.xmlsoap.org/soap/envelope/");

            // Create a namespace manager to handle namespaces
            XmlNamespaceManager namespaceManager = new XmlNamespaceManager(xmlDoc.NameTable);
            namespaceManager.AddNamespace("tem", "http://tempuri.org/");
            namespaceManager.AddNamespace("ver", "http://yefi.gov.sa/MCS/EltezamDataSchema/xml/schemas/version2.0");
            namespaceManager.AddNamespace("ver1", "http://yefi.gov.sa/PersonProfileCommonTypes/xml/schemas/version2.0");

            XmlElement headerElement = xmlDoc.CreateElement("soapenv", "Header");
            envelopeElement.AppendChild(headerElement);

            XmlElement bodyElement = xmlDoc.CreateElement("soapenv", "Body");
            envelopeElement.AppendChild(bodyElement);

            XmlElement SubmitEmployeeQualificationInfo = xmlDoc.CreateElement("tem", "SubmitEmployeeQualificationInfo");
            bodyElement.AppendChild(SubmitEmployeeQualificationInfo);

            XmlElement employeeQualificationInfo = xmlDoc.CreateElement("tem", "employeeQualificationInfo");
            SubmitEmployeeQualificationInfo.AppendChild(employeeQualificationInfo);

            // Create the <SubAgencyID> element
            XmlElement subAgencyIDElement = xmlDoc.CreateElement("SubAgencyID");
            subAgencyIDElement.InnerText = "2122";
            employeeQualificationInfo.AppendChild(subAgencyIDElement);

            XmlElement employeeIDElement = xmlDoc.CreateElement("EmployeeID");
            employeeIDElement.InnerText = $"{data.EmployeeId}";
            employeeQualificationInfo.AppendChild(employeeIDElement);

            XmlElement personIdentifierElement = xmlDoc.CreateElement("PersonIdentifier");
            employeeQualificationInfo.AppendChild(personIdentifierElement);

            XmlElement nationalIDElement = xmlDoc.CreateElement("ver", "NationalID", "http://yefi.gov.sa/PersonProfileCommonTypes/xml/schemas/version2.0");
            nationalIDElement.InnerText = $"{data.NationalId}";
            personIdentifierElement.AppendChild(nationalIDElement);

            XmlElement QualificationList = xmlDoc.CreateElement("QualificationList");
            employeeQualificationInfo.AppendChild(QualificationList);

            XmlElement Qualification = xmlDoc.CreateElement("ver1", "Qualification");
            QualificationList.AppendChild(Qualification);

            XmlElement QualificationID = xmlDoc.CreateElement("ver1", "QualificationID");
            QualificationID.InnerText = $"{data.QualificationId}";
            Qualification.AppendChild(QualificationID);

            XmlElement QualificationCode = xmlDoc.CreateElement("ver1", "QualificationCode");
            QualificationCode.InnerText = $"{data.QualificationCode}";
            Qualification.AppendChild(QualificationCode);

            XmlElement MajorCode = xmlDoc.CreateElement("ver1", "MajorCode");
            MajorCode.InnerText = $"{data.MajorCode}";
            Qualification.AppendChild(MajorCode);

            XmlElement UniversityCode = xmlDoc.CreateElement("ver1", "UniversityCode");
            UniversityCode.InnerText = $"{data.UniversityCode}";
            Qualification.AppendChild(UniversityCode);

            XmlElement TransactionType = xmlDoc.CreateElement("ver1", "TransactionType");
            TransactionType.InnerText = $"{data.TransactionType}";
            Qualification.AppendChild(TransactionType);

            XmlElement QualificationStatus = xmlDoc.CreateElement("ver1", "QualificationStatus");
            QualificationStatus.InnerText = $"{data.QualificationStatus}";
            Qualification.AppendChild(QualificationStatus);


            // Append the root element to the XML document
            xmlDoc.AppendChild(envelopeElement);
            return xmlDoc.OuterXml;
        }

        [HttpPost("SendVacationInfoToService")]
        public async Task<IActionResult> SendVacationInfoToService(List<long> Ids)
        {
            try
            {
                var results = await employeeService.GetVacationInfoForSoap(Ids);
                foreach (var data in results)
                {
                    //var xmlbody = GenerateVacationInfoXML(data);
                    var body = @$"<soapenv:Envelope xmlns:soapenv=""http://schemas.xmlsoap.org/soap/envelope/"" xmlns:tem=""http://tempuri.org/"" xmlns:ver=""http://yefi.gov.sa/PersonProfileCommonTypes/xml/schemas/version2.0"" xmlns:ver1=""http://yefi.gov.sa/MCS/EltezamDataSchema/xml/schemas/version2.0"">
<soapenv:Header/>
<soapenv:Body>
<tem:SubmitEmployeeVacationInfo>
<tem:employeeVacationInfo>
<SubAgencyID>1238</SubAgencyID>
<EmployeeID>{data.EmpoyeeId}</EmployeeID>
<PersonIdentifier>
<ver:NationalID>{data.NationalId}</ver:NationalID>
</PersonIdentifier>
<VacationList>
<ver1:Vacation>
<ver1:VacationID>{data.VacationId}</ver1:VacationID>
<ver1:StartDate>{data.StartDate}</ver1:StartDate>
<ver1:EndDate>{data.EndDate}</ver1:EndDate>
<ver1:Period>{data.Period}</ver1:Period>
<ver1:VacationCode>{data.VacationCode}</ver1:VacationCode>
<ver1:TransactionType>{data.TransactionType}</ver1:TransactionType>
</ver1:Vacation>
</VacationList>
</tem:employeeVacationInfo>
</tem:SubmitEmployeeVacationInfo>
</soapenv:Body>
</soapenv:Envelope>";

                    var result = await sendSoapRequestService.SendRequest("http://10.10.10.42/GSBExpress/Employment/MCSEltezamData/2.0/EltezamDataService.svc", body, "http://tempuri.org/IEltezamDataService/SubmitEmployeeVacationInfo");
                    bool isSaved = await saveResponseNumber(7, data.VacationId, result.SOAPRequestNumber);
                }

                return Ok(results);
            }
            catch (Exception)
            {
                return Problem();
            }
        }
        private string GenerateVacationInfoXML(EmployeeVacation data)
        {
            // Create an XmlDocument instance
            XmlDocument xmlDoc = new XmlDocument();

            // Create the root element (<soapenv:Envelope>)
            XmlElement envelopeElement = xmlDoc.CreateElement("soapenv", "Envelope", "http://schemas.xmlsoap.org/soap/envelope/");

            // Create a namespace manager to handle namespaces
            XmlNamespaceManager namespaceManager = new XmlNamespaceManager(xmlDoc.NameTable);
            namespaceManager.AddNamespace("tem", "http://tempuri.org/");
            namespaceManager.AddNamespace("ver", "http://yefi.gov.sa/MCS/EltezamDataSchema/xml/schemas/version2.0");
            namespaceManager.AddNamespace("ver1", "http://yefi.gov.sa/PersonProfileCommonTypes/xml/schemas/version2.0");

            XmlElement headerElement = xmlDoc.CreateElement("soapenv", "Header", "http://schemas.xmlsoap.org/soap/envelope/");
            envelopeElement.AppendChild(headerElement);

            XmlElement bodyElement = xmlDoc.CreateElement("soapenv", "Body", "http://schemas.xmlsoap.org/soap/envelope/");
            envelopeElement.AppendChild(bodyElement);

            XmlElement SubmitEmployeeVacationInfo = xmlDoc.CreateElement("tem", "SubmitEmployeeVacationInfo");
            bodyElement.AppendChild(SubmitEmployeeVacationInfo);

            XmlElement employeeVacationInfo = xmlDoc.CreateElement("tem", "employeeVacationInfo");
            SubmitEmployeeVacationInfo.AppendChild(employeeVacationInfo);

            XmlElement subAgencyIDElement = xmlDoc.CreateElement("SubAgencyID");
            subAgencyIDElement.InnerText = "2122";
            employeeVacationInfo.AppendChild(subAgencyIDElement);

            XmlElement employeeIDElement = xmlDoc.CreateElement("EmployeeID");
            employeeIDElement.InnerText = $"{data.EmpoyeeId}";
            employeeVacationInfo.AppendChild(employeeIDElement);

            XmlElement personIdentifierElement = xmlDoc.CreateElement("PersonIdentifier");
            employeeVacationInfo.AppendChild(personIdentifierElement);

            XmlElement nationalIDElement = xmlDoc.CreateElement("ver", "NationalID");
            nationalIDElement.InnerText = $"{data.NationalId}";
            personIdentifierElement.AppendChild(nationalIDElement);

            XmlElement VacationList = xmlDoc.CreateElement("VacationList");
            employeeVacationInfo.AppendChild(VacationList);

            XmlElement Vacation = xmlDoc.CreateElement("ver1", "Vacation");
            VacationList.AppendChild(Vacation);

            XmlElement VacationID = xmlDoc.CreateElement("ver1", "VacationID");
            VacationID.InnerText = $"{data.VacationId}";
            Vacation.AppendChild(VacationID);

            XmlElement StartDate = xmlDoc.CreateElement("ver1", "StartDate");
            StartDate.InnerText = $"{data.StartDate}";
            Vacation.AppendChild(StartDate);

            XmlElement EndDate = xmlDoc.CreateElement("ver1", "EndDate");
            EndDate.InnerText = $"{data.EndDate}";
            Vacation.AppendChild(EndDate);

            XmlElement Period = xmlDoc.CreateElement("ver1", "Period");
            Period.InnerText = $"{data.Period}";
            Vacation.AppendChild(Period);

            XmlElement VacationCode = xmlDoc.CreateElement("ver1", "VacationCode");
            VacationCode.InnerText = $"{data.VacationCode}";
            Vacation.AppendChild(VacationCode);

            XmlElement TransactionType = xmlDoc.CreateElement("ver1", "TransactionType");
            TransactionType.InnerText = $"{data.TransactionType}";
            Vacation.AppendChild(TransactionType);

            // Append the root element to the XML document
            xmlDoc.AppendChild(envelopeElement);
            return xmlDoc.OuterXml;
        }
        private async Task<bool> saveResponseNumber(int ServiceEntity, long Id, string? ResponseNumber)
        {
            bool result = false;

            try
            {
                if (!string.IsNullOrEmpty(ResponseNumber))
                {
                    result = await employeeService.SaveResponseNumber(ServiceEntity, Id, ResponseNumber);
                }
            }
            catch (Exception)
            {
                result = false;
            }
            return result;
        }
    }
}