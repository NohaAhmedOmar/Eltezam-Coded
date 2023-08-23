using AutoMapper;
using Eltezam_Coded.DomainModels;
using Eltezam_Coded.DTOs;

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
                     .ForMember(dest => dest.BirthDate, src => src.MapFrom(src => DateTime.Parse(src.BirthDate)))
                     .ForMember(dest => dest.StepDate, src => src.MapFrom(src => DateTime.Parse(src.StepDate)))
                     .ForMember(dest => dest.FirstGradeDate, src => src.MapFrom(src => DateTime.Parse(src.FirstGradeDate)))
                     .ForMember(dest => dest.NextPromotionDate, src => src.MapFrom(src => DateTime.Parse(src.NextPromotionDate)))
                     .ForMember(dest => dest.GovernmentHireDate, src => src.MapFrom(src => DateTime.Parse(src.GovernmentHireDate)))
                     .ForMember(dest => dest.MinistryHireDate, src => src.MapFrom(src => DateTime.Parse(src.MinistryHireDate)))
                     .ForMember(dest => dest.TerminationDate, src => src.MapFrom(src => DateTime.Parse(src.TerminationDate)))
                     .ForMember(dest => dest.LastUpdateDate, src => src.MapFrom(src => DateTime.Parse(src.LastUpdateDate)))
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
            CreateMap<EmployeePaymentDTO,EmployeePayment>().ReverseMap();
            CreateMap<EmployeeQualificationDTO,EmployeeQualification>()
                .ForMember(dest => dest.GraduationDate, src => src.MapFrom(src => DateTime.Parse(src.GraduationDate)))
                .ReverseMap();
            CreateMap<EmployeeVacationDTO,EmployeeVacation>()
                .ForMember(dest => dest.StartDate, src => src.MapFrom(src => DateTime.Parse(src.StartDate)))
                .ForMember(dest => dest.EndDate, src => src.MapFrom(src => DateTime.Parse(src.EndDate)))
                .ForMember(dest => dest.DecisionDate, src => src.MapFrom(src => DateTime.Parse(src.DecisionDate)))
                .ReverseMap();
        }
    }
}
