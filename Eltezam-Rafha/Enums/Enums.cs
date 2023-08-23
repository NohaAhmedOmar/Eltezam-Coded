namespace Eltezam_Coded.Enums
{
    public static class Enums
    {
        public static class Grade
        {
            public static string A { get; set; } = "ممتاز";
            public static string B { get; set; } = "جيدجدا";
            public static string C { get; set; } = "جيد";
            public static string D { get; set; } = "مقبول";
            public static Dictionary<string,string> GetGrades()=>
                         new Dictionary<string, string> 
                         { {nameof(A),A }, { nameof(B), B } , { nameof(C),C}, { nameof(D), D } };
            
        }
        public static class AppraisalType
        {
            public static string TrialPeriodEvaluation { get; set; } = "تقييم فترة التجربة";
            public static string AnnualPerformanceEvaluation { get; set; } = "التقييم السنوي";
            public static string Other { get; set; } = "غير محدد";
            public static List<string> GetAppraisalTypes() =>
                new List<string> { TrialPeriodEvaluation, AnnualPerformanceEvaluation, Other };
        }
        public enum TransactionType
        {
            Add, Update, Delete
        }  
        public enum PositionStatusType
        {
            Occupied, Unoccupied
        }

    }
}
