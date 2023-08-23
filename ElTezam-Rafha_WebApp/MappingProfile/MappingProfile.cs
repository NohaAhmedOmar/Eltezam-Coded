using AutoMapper;
using ElTezam_Coded_WebApp.DomainModels;
using Eltezam_Coded.DTOs;
using ElTezam_Coded_WebApp.DTOs;

namespace Eltezam_Coded.MappingProfile
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            MapEmployees();
        }
        void MapEmployees()
        {
            CreateMap<EmployeeDTO,Employee>()

                .ReverseMap();
            CreateMap<EmployeeJobDTO,EmployeeJob>()
               .ForMember(dest => dest.StepDate, src => src.MapFrom(src => DateTime.Parse(src.StepDate)))
               .ForMember(dest => dest.DecisionDate, src => src.MapFrom(src => DateTime.Parse(src.DecisionDate)))
               .ForMember(dest => dest.GradeDate, src => src.MapFrom(src => DateTime.Parse(src.GradeDate)))
               .ForMember(dest => dest.TransactionStartDate, src => src.MapFrom(src => DateTime.Parse(src.TransactionStartDate)))
               .ForMember(dest => dest.TransactionEndDate, src => src.MapFrom(src => DateTime.Parse(src.TransactionEndDate)))
               .ForMember(dest => dest.LastUpdateDate, src => src.MapFrom(src => DateTime.Parse(src.LastUpdateDate)))

               .ReverseMap();
            CreateMap<EmployeeAppraisalInfoDTO,EmployeeAppraisalInfo>()
                .ForMember(dest => dest.StartDate, src => src.MapFrom(src => DateTime.Parse(src.StartDate)))
                .ForMember(dest => dest.EndDate, src => src.MapFrom(src => DateTime.Parse(src.EndDate)))
                .ReverseMap();
            CreateMap<EmployeePaymentDTO,EmployeePayment>()
                               .ForMember(dest => dest.PaidDate, src => src.MapFrom(src => DateTime.Parse(src.PaidDate)))

                .ReverseMap();
            CreateMap<EmployeeQualificationDTO,EmployeeQualification>()
                .ForMember(dest => dest.GraduationDate, src => src.MapFrom(src => DateTime.Parse(src.GraduationDate)))
                .ReverseMap();
            CreateMap<EmployeeVacationDTO,EmployeeVacation>()
                .ForMember(dest => dest.StartDate, src => src.MapFrom(src => DateTime.Parse(src.StartDate)))
                .ForMember(dest => dest.EndDate, src => src.MapFrom(src => DateTime.Parse(src.EndDate)))
                .ForMember(dest => dest.DecisionDate, src => src.MapFrom(src => DateTime.Parse(src.DecisionDate)))
                .ReverseMap();
            CreateMap<JobDTO,Job>()
       
                .ReverseMap();
        }
    }
}
