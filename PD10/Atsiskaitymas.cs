using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PD10
{
    class Atsiskaitymas
    {
        protected string module;
        protected string description;

        public string getModule(){ return module; }
        public string getDescription(){ return description;}

        //

        public void putModule(string mod) { module = mod; }
        public void putDescription(string des) { description = des; }
        
    }
    class Data : Atsiskaitymas
    {

        protected int month;
        protected string MONTH;
        protected int day;

        protected double leftDays;



        public int getMonth() { return month; }
        public int getDay() { return day; }
        public double getLeftDays() { return leftDays; }
        public string getMonthName() {
            switch (month)
            {
                case 1: MONTH = "Sausio"; break;
                case 2: MONTH = "Vasario"; break;
                case 3: MONTH = "Kovo"; break;
                case 4: MONTH = "Balandžio"; break;
                case 5: MONTH = "Gegužės"; break;
                case 6: MONTH = "Birželio"; break;
                case 7: MONTH = "Liepos"; break;
                case 8: MONTH = "Rugpjūčio"; break;
                case 9: MONTH = "Rugsėjo"; break;
                case 10: MONTH = "Spalio"; break;
                case 11: MONTH = "Lapkričio"; break;
                case 12: MONTH = "Gruodžio"; break;
            }

            return MONTH;
        }
        public int getMonthNumber()
        {
            switch (MONTH)
            {
                case "Sausio": month = 1; break;
                case "Vasario": month = 2; break;
                case "Kovo": month = 3; break;
                case "Balandžio": month = 4; break;
                case "Gegužės": month = 5; break;
                case "Birželio": month = 6; break;
                case "Liepos": month = 7; break;
                case "Rugpjūčio": month = 8; break;
                case "Rugsėjo": month = 9; break;
                case "Spalio": month = 10; break;
                case "Lapkričio": month = 11; break;
                case "Gruodžio": month = 12; break;
            }
            return month;
        }

        //
       
        public void putMonth(int mon) {month = mon; }
        public void putMONTH(string mon) { MONTH = mon; }


        public void putDay(int d) { day = d;}
        public void leftTime()
        {
            DateTime  dt = new DateTime(DateTime.Today.Year, month, day);
            leftDays = dt.Subtract(DateTime.Today).TotalDays;
            //leftDays = (dttd - DateTime.Today).TotalDays;
        }
    }
}
