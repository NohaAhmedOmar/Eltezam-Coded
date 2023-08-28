using ElTezam_Coded_WebApp.ViewModels;

namespace Eltezam_Coded.Enums
{
    public static class AllEnums
    {
        public static class Grade
        {
            public static string A { get; set; } = "ممتاز";
            public static string B { get; set; } = "جيدجدا";
            public static string C { get; set; } = "جيد";
            public static string D { get; set; } = "مقبول";
            public static object GetGrades() =>
                         new List<DropDownModel>
                         {new DropDownModel {Id=nameof(A),Value=A }, new DropDownModel {Id=nameof(B),Value=B } ,new DropDownModel {Id=nameof(C),Value=C },new DropDownModel {Id=nameof(D),Value=D } };

        }
        public static class QualificationStatus
        {
            public static string Completed { get; set; } = "إنهاء بنجاح";
            public static string OnGoing { get; set; } = "مستمر";
            public static string Stopped { get; set; } = "موقوف";
            public static object GetQualificationStatus() =>
                         new List<DropDownModel>
                         {new DropDownModel {Id=nameof(Completed),Value=Completed }, new DropDownModel {Id=nameof(OnGoing),Value=OnGoing } ,new DropDownModel {Id=nameof(Stopped),Value=Stopped } };

        }
        public static class AppraisalType
        {
            public static string TrialPeriodEvaluation { get; set; } = "تقييم فترة التجربة";
            public static string AnnualPerformanceEvaluation { get; set; } = "التقييم السنوي";
            public static string Other { get; set; } = "غير محدد";
            public static List<DropDownModel> GetAppraisalTypes() =>
                new List<DropDownModel> { new DropDownModel { Id = nameof(TrialPeriodEvaluation), Value = TrialPeriodEvaluation }, new DropDownModel { Id = nameof(AnnualPerformanceEvaluation), Value = AnnualPerformanceEvaluation }, new DropDownModel { Id = nameof(Other), Value = Other } };
        }
        public static class MaritalStatusType
        {
            public static int Single { get; set; } = 30030;
            public static int Married { get; set; } = 30031;
            public static int Divorced { get; set; } = 30032;
            public static int Widowed { get; set; } = 30033;
            public static int Undefined { get; set; } = 30034;
            public static List<DropDownModel> GetMaritalStatusType() =>
                new List<DropDownModel> { new DropDownModel { Id = nameof(Single), Value = Single }, new DropDownModel { Id = nameof(Married), Value = Married }, new DropDownModel { Id = nameof(Divorced), Value = Divorced }, new DropDownModel { Id = nameof(Undefined), Value = Undefined }, new DropDownModel { Id = nameof(Widowed), Value = Widowed } };
            public static string SearchMaritalStatus(int value) =>
                GetMaritalStatusType().Where(x => (int)x.Value == value).Select(x => x.Id.ToString()).SingleOrDefault();
        }
        public static class HealthStatusType
        {
            public static int Healthy { get; set; } = 30035;
            public static int Blind { get; set; } = 30036;
            public static int Dumb { get; set; } = 30037;
            public static int Deaf { get; set; } = 30038;
            public static int Mental_Handicaps { get; set; } = 30039;
            public static int Mobility_Disability { get; set; } = 30040;
            public static int Missing_Parties { get; set; } = 30041;
            public static int Speech_Difficulty { get; set; } = 30042;
            public static int Other { get; set; } = 30043;
            public static List<DropDownModel> GetHealthStatusType() =>
                new List<DropDownModel> { new DropDownModel { Id=nameof(Healthy),Value= Healthy }, new DropDownModel { Id=nameof(Blind),Value= Blind },
                    new DropDownModel {Id=nameof(Dumb),Value= Dumb },
                    new DropDownModel {Id=nameof(Deaf),Value= Deaf }, new DropDownModel {Id=nameof(Mental_Handicaps),Value= Mental_Handicaps },
                    new DropDownModel {Id=nameof(Mobility_Disability),Value= Mobility_Disability } ,new DropDownModel {Id=nameof(Speech_Difficulty),Value= Speech_Difficulty },new DropDownModel {Id=nameof(Other),Value= Other } };
            public static string SearchHealthStatusType(int value)
            {
                var res = GetHealthStatusType().Where(x => (int)x.Value == value)
                .Select(x => x.Id.ToString()).SingleOrDefault();
                return res.Length > 7 ? res.Split('_')[0] + " " + res.Split('_')[1] : res;

            }

        }
        public static class ReligionType
        {
            public static int Muslim { get; set; } = 27034;
            public static int Christian { get; set; } = 27035;
            public static int Other { get; set; } = 27036;

            public static List<DropDownModel> GetReligionType() =>
                new List<DropDownModel> { new DropDownModel { Id=nameof(Muslim),Value= Muslim }, new DropDownModel { Id=nameof(Christian),Value= Christian },
                    new DropDownModel {Id=nameof(Other),Value= Other } };
            public static string SearchReligionType(int value) =>
          GetReligionType().Where(x => (int)x.Value == value).Select(x => x.Id.ToString()).SingleOrDefault();

        }
        public enum TransactionType
        {
            Add, Update, Delete
        }
        public enum PositionStatusType
        {
            Occupied, Unoccupied
        }
        public enum ElementClassificationType
        {
            Deduction, Paid
        }
        public enum Table
        {
            Employees, EmployeeVacations, EmployeeQualifications, EmployeePayments, EmployeeJobs, EmployeeAppraisalInfo, Jobs, Codes, Enums
        }

    }
}
