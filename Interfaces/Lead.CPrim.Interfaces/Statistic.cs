using System.Collections.Generic;

namespace Lead.CPrim.Interfaces
{
    public class ProductQuantityStatistic
    {
        private string day1 = "08:00 - 09:00";
        private string day2 = "09:00 - 10:00";
        private string day3 = "10:00 - 11:00";
        private string day4 = "11:00 - 12:00";
        private string day5 = "12:00 - 13:00";
        private string day6 = "13:00 - 14:00";
        private string day7 = "14:00 - 15:00";
        private string day8 = "15:00 - 16:00";
        private string day9 = "16:00 - 17:00";
        private string day10 = "17:00 - 18:00";
        private string day11 = "18:00 - 19:00";
        private string day12 = "19:00 - 20:00";
        
        private string night1 = "20:00 - 21:00";
        private string night2 = "21:00 - 22:00";
        private string night3 = "22:00 - 23:00";
        private string night4 = "23:00 - 00:00";
        private string night5 = "00:00 - 01:00";
        private string night6 = "01:00 - 02:00";
        private string night7 = "02:00 - 03:00";
        private string night8 = "03:00 - 04:00";
        private string night9 = "04:00 - 05:00";
        private string night10 = "05:00 - 06:00";
        private string night11 = "06:00 - 07:00";
        private string night12 = "07:00 - 08:00";

        public List<string> ListDay { get; set; }
        public List<string> ListNight { get; set; }

        public ProductQuantityStatistic()
        {
            ListDay = new List<string>();
            ListNight = new List<string>();

            ListDay.Add(day1);
            ListDay.Add(day2);
            ListDay.Add(day3);
            ListDay.Add(day4);
            ListDay.Add(day5);
            ListDay.Add(day6);
            ListDay.Add(day7);
            ListDay.Add(day8);
            ListDay.Add(day9);
            ListDay.Add(day10);
            ListDay.Add(day11);
            ListDay.Add(day12);

            ListNight.Add(night1);
            ListNight.Add(night2);
            ListNight.Add(night3);
            ListNight.Add(night4);
            ListNight.Add(night5);
            ListNight.Add(night6);
            ListNight.Add(night7);
            ListNight.Add(night8);
            ListNight.Add(night9);
            ListNight.Add(night10);
            ListNight.Add(night11);
            ListNight.Add(night12);
        }
    }
}
