using System;
using System.Collections.Generic;
using System.Linq;

namespace ElTezam_Coded_WebApp.DateLocalization
{
    public static class DateLocalizationHub
    {
        private readonly static Dictionary<string, string> PreFixYear = new Dictionary<string, string>
        {
            {"19","أَلف و تِسْعُمِئَة" },
            {"20","أَلفان" }

        };

        private readonly static Dictionary<string, string> PostFixYears = new Dictionary<string, string>

        {
            {"1","واحد"},
            { "2","اثنان"},
            { "3","ثلاثة"},
            { "4","أربعة"},
            { "5","خمسة"},
            { "6","ستة"},
            { "7","سبعة"},
            { "8","ثمانية"},
            { "9","تسعة"},
            { "10","عشرة"},
            {"01","و واحد "},
            { "02","و اثنان"},
            { "03","و ثلاثة"},
            { "04","و أربعة"},
            { "05","و خمسة"},
            { "06","و ستة"},
            { "07","و سبعة"},
            { "08","و ثمانية"},
            { "09","و تسعة"},
            { "11","أحد عشر"},
            { "12","اثنا عشر"},
            { "13","ثلاثة عشر"},
            { "14", "أربعة عشر"},
            { "15","خمسة عشر"},
            { "16","ستة عشر"},
            { "17","سبعة عشر"},
            { "18","ثمانية عشر"},
            { "19","تسعة عشر"},
            { "20","عشرون"},
            { "21","واحد وعشرون"},
            { "22","اثنان وعشرون"},
            { "23","ثلاثة وعشرون"},
            { "24","أربعة وعشرون"},
            { "25","خمسة وعشرون"},
            { "26","ستة وعشرون"},
            { "27","سبعة وعشرون"},
            { "28","ثمانية وعشرون"},
            { "29","تسعة وعشرون"},
            { "30","ثلاثون"},
            { "31","واحد وثلاثون"},
            { "32","اثنان وثلاثون"},
            { "33","ثلاثة وثلاثون"},
            { "34","أربعة وثلاثون"},
            { "35","خمسة وثلاثون"},
            { "36","ستة وثلاثون"},
            { "37","سبعة وثلاثون"},
            { "38","ثمانية وثلاثون"},
            { "39","تسعة وثلاثون"},
            { "40","أربعون"},
            { "41","واحد وأربعون"},
            { "42","اثنان وأربعون"},
            { "43","ثلاثة وأربعون"},
            { "44","أربعة وأربعون"},
            { "45","خمسة وأربعون"},
            { "46","ستة وأربعون"},
            { "47","سبعة وأربعون"},
            { "48","ثمانية وأربعون"},
            { "49","تسعة وأربعون"},
            { "50","خمسون"},
            { "51","واحد وخمسون"},
            { "52","اثنان وخمسون"},
            { "53","ثلاثة وخمسون"},
            { "54","أربعة وخمسون"},
            { "55","خمسة وخمسون"},
            { "56","ستة وخمسون"},
            { "57","سبعة وخمسون"},
            { "58","ثمانية وخمسون"},
            { "59","تسعة وخمسون"},
            { "60","ستون"},
            { "61","واحد وستون"},
            { "62","اثنان وستون"},
            { "63","ثلاثة وستون"},
            { "64","أربعة وستون"},
            { "65","خمسة وستون"},
            { "66","ستة وستون"},
            { "67","سبعة وستون"},
            { "68","ثمانية وستون"},
            { "69","تسعة  وستون"},
            { "70","سبعون"},
            { "71","واحد وسبعون"},
            { "72","اثنان وسبعون"},
            { "73","ثلاثة وسبعون"},
            { "74","أربعة وسبعون"},
            { "75","خمسة وسبعون"},
            { "76","ستة وسبعون"},
            { "77","سبعة وسبعون"},
            { "78","ثمانية وسبعون"},
            { "79","تسعة وسبعون"},
            { "80","ثمانون"},
            { "81","واحد وثمانون"},
            { "82","اثنان وثمانون"},
            { "83","ثلاثة وثمانون"},
            { "84","أربعة وثمانون"},
            { "85","خمسة وثمانون"},
            { "86","ستة وثمانون"},
            { "87","سبعة وثمانون"},
            { "88","ثمانية وثمانون"},
            { "89","تسعة وثمانون"},
            { "90","تسعون"},
            { "91","واحد وتسعون"},
            { "92","اثنان وتسعون"},
            { "93","ثلاثة وتسعون"},
            { "94","أربعة وتسعون"},
            { "95","خمسة وتسعون"},
            { "96","ستة وتسعون"},
            { "97","سبعة وتسعون"},
            { "98","ثمانية وتسعون"},
            { "99","تسعة وتسعون"},
            { "100","مائة"},

        };

        private readonly static Dictionary<int, string> Months = new Dictionary<int, string>
        {
             {1,"يناير"},
             {2,"فبراير"},
             {3,"مارس"},
             {4,"إبريل"},
             {5,"مايو"},
             {6,"يونيو"},
             {7,"يوليو"},
             {8,"أغسطس"},
             {9,"سبتمبر"},
             {10,"أكتوبر"},
             {11,"نوفمبر"},
             {12,"ديسمبر"},
        };

        private readonly static Dictionary<string, string> ArbaicNumbers = new Dictionary<string, string>
        {
            {"0","٠" },
            {"01","١" },
            {"02","٢" },
            {"03","٣" },
            {"04","٤" },
            {"05","٥" },
            {"06","٦" },
            {"07","٧" },
            {"08","٨" },
            {"09","٩" },
            {"1","١" },
            {"2","٢" },
            {"3","٣" },
            {"4","٤" },
            {"5","٥" },
            {"6","٦" },
            {"7","٧" },
            {"8","٨" },
            {"9","٩" },
            {"10","١٠" },
            {"11","١١" },
            {"12","١٢" },
            {"13","١٣" },
            {"14","١٤" },
            {"15","١٥" },
            {"16","١٦" },
            {"17","١٧" },
            {"18","١٨" },
            {"19","١٩" },
            {"20","٢٠" },
            {"21","٢١" },
            {"22","٢٢" },
            {"23","٢٣" },
            {"24","٢٤" },
            {"25","٢٥" },
            {"26","٢٦" },
            {"27","٢٧" },
            {"28","٢٨" },
            {"29","٢٩" },
            {"30","٣٠" },
            {"31","٣١" },

        };
        public static string SearchByPostFix(string Key) => PostFixYears.AsQueryable().Where(x => x.Key == Key).Select(x => x.Value).FirstOrDefault();
        public static string SearchByPreFix(string Key) => PreFixYear.AsQueryable().Where(x => x.Key == Key).Select(x => x.Value).FirstOrDefault();
        public static string SearchByMonths(int Key) => Months.AsQueryable().Where(x => x.Key == Key).Select(x => x.Value).FirstOrDefault();
        public static string SearchByNumbers(string Key) => ArbaicNumbers.AsQueryable().Where(x => x.Key == Key).Select(x => x.Value).SingleOrDefault();
        public static string ToStringLocalizeDate(this DateTime Date)
        {
            var date = Date.ToString().Split('-', '/', ' ');
            var year = date[2].ToCharArray();
            var ParsedDate = SearchByNumbers(year[0].ToString()) + SearchByNumbers(year[1].ToString()) + SearchByNumbers(year[2].ToString()) + SearchByNumbers(year[3].ToString()) + "/" + SearchByNumbers(date[0]) + "/" + SearchByNumbers(date[1]);
            return ParsedDate;
        }   
        public static string ToStringLocalizeDate(this DateTime? Date)
        {
            var date = Date.ToString().Split('-', '/', ' ');
            var year = date[2].ToCharArray();
            var ParsedDate = SearchByNumbers(year[0].ToString()) + SearchByNumbers(year[1].ToString()) + SearchByNumbers(year[2].ToString()) + SearchByNumbers(year[3].ToString()) + "/" + SearchByNumbers(date[0]) + "/" + SearchByNumbers(date[1]);
            return ParsedDate;
        }
        public static string LocalizeStringOfNumbers(this string Number)
        {
            var arrayOfNumbers=Number.ToCharArray();
            string LocalizedNumber = string.Empty;
            foreach (var number in arrayOfNumbers)
            {
                LocalizedNumber += SearchByNumbers(number.ToString());
            }
            return LocalizedNumber; 
        }
        public static string LocalizeAge(this string Age)
        {
            var arrayOfNumbers = Age.Split(':');
            string LocalizedAge = string.Empty;
            foreach (var item in arrayOfNumbers)
            {
                LocalizedAge += SearchByNumbers(item)+":";

            }
            return LocalizedAge.TrimEnd(':');

        }


    }
}