using AutoMapper;
using Eltezam_Coded.DomainModels;
using Eltezam_Coded.DTOs;
using System.Xml.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace Eltezam_Coded.Services
{
    [ServiceContract]
    public interface IEmployeeService
    {
        [OperationContract]
         ResponseModel SubmitEmployeeInfo(EmployeeDTO employeeDTO);
        [OperationContract]
        ResponseModel SubmitEmployeeVacationInfo(EmployeeVacationDTO employeeVacationDTO);
        [OperationContract] 
        ResponseModel SubmitEmployeeQualificationInfo(EmployeeQualificationDTO employeeQualificationDTO); 
        [OperationContract] 
        ResponseModel SubmitEmployeePayslipInfo(EmployeePaymentDTO employeePaymentDTO); 
        [OperationContract] 
        ResponseModel SubmitEmployeeAppraisalInfo(EmployeeAppraisalInfoDTO employeeAppraisalInfoDTO);
        [OperationContract] 
        ResponseModel SubmitEmployeeHistoricalInfo(EmployeeJobDTO employeeJobDTO);


    }   
    public class EmployeeService: IEmployeeService
    {
        private CodedContext context;
        private IMapper mapper;
        public EmployeeService()
        {

        }
        public EmployeeService(IMapper mapper)
        {
            this.context = new CodedContext();
            this.mapper = mapper;
        }

        public ResponseModel SubmitEmployeeAppraisalInfo(EmployeeAppraisalInfoDTO employeeAppraisalInfoDTO)
        {
            var employeeAppraisalInfo=mapper.Map<EmployeeAppraisalInfo>(employeeAppraisalInfoDTO);
            context.EmployeeAppraisalInfos.Add(employeeAppraisalInfo);
            var res = context.SaveChanges();
            return res == 1 ? new ResponseModel { IsSuccess = true, StatusCode = 201 } : new ResponseModel { IsSuccess = false, StatusCode = 400 };
        }

        public ResponseModel SubmitEmployeeHistoricalInfo(EmployeeJobDTO employeeJobDTO)
        {
            var employeeJob=mapper.Map<EmployeeJob>(employeeJobDTO);
            context.EmployeeJobs.Add(employeeJob);
            var res = context.SaveChanges();
            return res == 1 ? new ResponseModel { IsSuccess = true, StatusCode = 201 } : new ResponseModel { IsSuccess = false, StatusCode = 400 };
        }

        public ResponseModel SubmitEmployeeInfo(EmployeeDTO employeeDTO)
        {
            var employee = mapper.Map<Employee>(employeeDTO);
            context.Employees.Add(employee);
            var res = context.SaveChanges();
            return res == 1 ? new ResponseModel { IsSuccess = true, StatusCode = 201 } : new ResponseModel { IsSuccess = false, StatusCode = 400 };
        }

        public ResponseModel SubmitEmployeePayslipInfo(EmployeePaymentDTO employeePaymentDTO)
        {
            var employeePayment=mapper.Map<EmployeePayment>(employeePaymentDTO);
            context.EmployeePayments.Add(employeePayment);
            var res = context.SaveChanges();
            return res == 1 ? new ResponseModel { IsSuccess = true, StatusCode = 201 } : new ResponseModel { IsSuccess = false, StatusCode = 400 };
        }

        public ResponseModel SubmitEmployeeQualificationInfo(EmployeeQualificationDTO employeeQualificationDTO)
        {
            var employeeQualification=mapper.Map<EmployeeQualification>(employeeQualificationDTO);      
            context.EmployeeQualifications.Add(employeeQualification);  
            var res = context.SaveChanges();
            return res == 1 ? new ResponseModel { IsSuccess = true, StatusCode = 201 } : new ResponseModel { IsSuccess = false, StatusCode = 400 };

        }

        public ResponseModel SubmitEmployeeVacationInfo(EmployeeVacationDTO employeeVacationDTO)
        {
            var employeeVacation = mapper.Map<EmployeeVacation>(employeeVacationDTO);
            context.EmployeeVacations.Add(employeeVacation);    
            var res = context.SaveChanges();
            return res == 1 ? new ResponseModel { IsSuccess = true, StatusCode = 201 } : new ResponseModel { IsSuccess = false, StatusCode = 400 };
        }
    }
}
