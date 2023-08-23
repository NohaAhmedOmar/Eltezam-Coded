using Eltezam_Coded.DTOs;
using FluentValidation;

namespace ElTezam_Coded_WebApp.Validators
{
    public class EmployeeValidator: AbstractValidator<EmployeeDTO>
    {
        public EmployeeValidator()
        {
            RuleFor(x=>x.FirstNameAr).Length(1,100);
            RuleFor(x=>x.SecondNameAr).Length(1,100);
            RuleFor(x=>x.ThirdNameAr).Length(1,100).When(x=> !string.IsNullOrEmpty(x.ThirdNameAr));
            RuleFor(x=>x.LastNameAr).Length(1,100); 
            RuleFor(x=>x.FirstNameEn).Length(1,100);
            RuleFor(x=>x.SecondNameEn).Length(1,100);
            RuleFor(x=>x.ThirdNameEn).Length(1,100).When(x=> !string.IsNullOrEmpty(x.ThirdNameAr));
            RuleFor(x=>x.LastNameEn).Length(1,100);
            RuleFor(x=>x.BirthDate).NotNull();
            RuleFor(x=>x.EmailAddress).Length(1,254);
            RuleFor(x=>x.NationalID).Length(10);
        }
    }
}
