using Eltezam_Coded.DomainModels;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Reflection;
using System.ServiceModel;

namespace Eltezam_Coded.Services
{
    [ServiceContract]

    public interface IDropDownsService
    {
        //  object GetDropDown<T>(Expression<Func<T, object>>? selector, Expression<Func<T, bool>>? filter) where T : class;
        [OperationContract]
        object GetGradeDropDown();  
        [OperationContract]
        object GetPositionStatusTypeDropDown();  
        [OperationContract]
        object GetAppraisalTypeDropDown(); 
        [OperationContract]
        object GetJobTypeDropDown();
        [OperationContract]
        object GetBloodTypeDropDown();   
        [OperationContract]
        object GetReligionTypeDropDown();  
        [OperationContract]
        object GetVacationDropDown(); 
        [OperationContract]
        object GetConsolidationSetDropDown(); 
        [OperationContract]
        object GetElementCodeDropDown(); 
        [OperationContract]
        object GetQualificationCodeDropDown();  
        [OperationContract]
        object GetMajorDropDown();  
    }
    public class DropDownsService:IDropDownsService
    {
        private readonly CodedContext context;
        public DropDownsService()
        {
            context = new CodedContext();
        }

        public object GetAppraisalTypeDropDown() =>
            Enums.Enums.AppraisalType.GetAppraisalTypes();
        
        private object GetDropDown<T> (Expression<Func<T, T>>? selector , Expression<Func<T, bool>> ?filter ) where T : class
        {
            if (selector != null && filter != null)
                return context.Set<T>().Where(filter).Select(selector).AsNoTracking().ToList();
            else if (selector != null)
                return context.Set<T>().Select(selector).AsNoTracking().ToList();
            else if (filter != null)
                return context.Set<T>().Where(filter).AsNoTracking().ToList();
            else
                return context.Set<T>().AsNoTracking().ToList();
        }
        private object GetEnumDropDown<E>() where E: System.Enum
        {
            List<string> collection = new();
            var values = System.Enum.GetValues(typeof(E));
            foreach (var value in values)
                collection.Add(value.ToString());
            return collection;
        }
        public object GetGradeDropDown()
        {
            //  var grades = Enum.GetValues(typeof(Enums.Enums.Grade));
             var grades = Enums.Enums.Grade.GetGrades();
            return grades.AsEnumerable().Select(x=>x.Value).ToList();
        }

        public object GetPositionStatusTypeDropDown() =>
            GetEnumDropDown<Enums.Enums.PositionStatusType>();

        public  object GetJobTypeDropDown() =>
            GetDropDown<DomainModels.Enum>(x => new DomainModels.Enum { EnumId = x.EnumId,  EnumValue= x.EnumValue }, x => x.CategoryId == 2);

        public object GetBloodTypeDropDown()=>
            GetDropDown<DomainModels.Enum>(x => new DomainModels.Enum { EnumId = x.EnumId, EnumValue = x.EnumValue }, x => x.CategoryId == 3);

        public object GetReligionTypeDropDown()=>
            GetDropDown<DomainModels.Enum>(x => new DomainModels.Enum { EnumId = x.EnumId, EnumValue = x.EnumValue }, x => x.CategoryId == 4);

        public object GetVacationDropDown()=>
            GetDropDown<DomainModels.Enum>(x => new DomainModels.Enum { EnumId = x.EnumId, EnumValue = x.EnumValue }, x => x.CategoryId == 5);

        public object GetConsolidationSetDropDown()=>
            GetDropDown<DomainModels.Enum>(x => new DomainModels.Enum { EnumId = x.EnumId, EnumValue = x.EnumValue }, x => x.CategoryId == 6);

        public object GetElementCodeDropDown()=>
            GetDropDown<DomainModels.Enum>(x => new DomainModels.Enum { EnumId = x.EnumId, EnumValue = x.EnumValue }, x => x.CategoryId == 7);

        public object GetQualificationCodeDropDown()=>
             GetDropDown<DomainModels.Enum>(x => new DomainModels.Enum { EnumId = x.EnumId, EnumValue = x.EnumValue }, x => x.CategoryId == 8);

        public object GetMajorDropDown()=>
             GetDropDown<DomainModels.Enum>(x => new DomainModels.Enum { EnumId = x.EnumId, EnumValue = x.EnumValue }, x => x.CategoryId == 9);

    }
}
