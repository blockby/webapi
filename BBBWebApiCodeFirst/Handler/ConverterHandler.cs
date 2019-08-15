using BBBWebApiCodeFirst.DataTransferObjects;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BBBWebApiCodeFirst.Handler
{
    public class ConverterHandler
    {

        private JArray daysArray = JArray.Parse(@"['Monday', 'Tuesday', 'Wednesday', 'Thursday', 'Friday', 'Saturday', 'Sunday' ]");
        private JArray weekendArray = JArray.Parse(@"['Saturday', 'Sunday' ]");
        private JArray weekdayArray = JArray.Parse(@"['Monday', 'Tuesday', 'Wednesday', 'Thursday', 'Friday']");
        private JArray outsidePeriodArray = JArray.Parse(@"['Morning', 'Afternoon', 'Evening', 'Night']");
        private JArray insidePeriodArray = JArray.Parse(@"['Morning', 'Midday', 'Afternoon']");
        private JArray outsideActivityArray = JArray.Parse(@"['Living', 'Working', 'Commuters', 'Passer-by', 'Leisure']");
        private JArray insideCustomerActivityArray = JArray.Parse(@"['Take-away Customers', 'Sit-down Customers']");
        private JArray insideTransactionActivityArray = JArray.Parse(@"['Transaction Time 1-5 minutes', 'Transaction Time over 5-10 minutes']");
        
        private JObject obj;
        private JObject finalObj;

        JArray yAxisArray = new JArray();

        public string getDayById(string id_day)
        {
            if (id_day == "1")
            {
                return "Monday";
            }
            if (id_day == "2")
            {
                return "Tuesday";
            }
            if (id_day == "3")
            {
                return "Wednesday";
            }
            if (id_day == "4")
            {
                return "Thursday";
            }
            if (id_day == "5")
            {
                return "Friday";
            }
            if (id_day == "6")
            {
                return "Saturday";
            }
            if (id_day == "7")
            {
                return "Sunday";
            }
            else
            {
                return null;
            }
        }


        public JArray getInsideFullDayByPeriodJArray (List<DayByTypeDTO> list)
        {
            JArray morningArray = new JArray();
            JArray middayArray = new JArray();
            JArray afternoonArray = new JArray();
            
            foreach (var item in list)
            {
                if (item.IdDay == 1)
                {
                    if (item.Type == "Morning")
                    {
                        morningArray.Insert(0, item.People);
                    }
                    if (item.Type == "Midday")
                    {
                        middayArray.Insert(0, item.People);
                    }
                    if (item.Type == "Afternoon")
                    {
                        afternoonArray.Insert(0, item.People);
                    }                    
                }
                if (item.IdDay == 2)
                {
                    if (item.Type == "Morning")
                    {
                        morningArray.Insert(1, item.People);
                    }
                    if (item.Type == "Midday")
                    {
                        middayArray.Insert(1, item.People);
                    }
                    if (item.Type == "Afternoon")
                    {
                        afternoonArray.Insert(1, item.People);
                    }
                }
                if (item.IdDay == 3)
                {
                    if (item.Type == "Morning")
                    {
                        morningArray.Insert(2, item.People);
                    }
                    if (item.Type == "Midday")
                    {
                        middayArray.Insert(2, item.People);
                    }
                    if (item.Type == "Afternoon")
                    {
                        afternoonArray.Insert(2, item.People);
                    }
                }
                if (item.IdDay == 4)
                {
                    if (item.Type == "Morning")
                    {
                        morningArray.Insert(3, item.People);
                    }
                    if (item.Type == "Midday")
                    {
                        middayArray.Insert(3, item.People);
                    }
                    if (item.Type == "Afternoon")
                    {
                        afternoonArray.Insert(3, item.People);
                    }
                }
                if (item.IdDay == 5)
                {
                    if (item.Type == "Morning")
                    {
                        morningArray.Insert(4, item.People);
                    }
                    if (item.Type == "Midday")
                    {
                        middayArray.Insert(4, item.People);
                    }
                    if (item.Type == "Afternoon")
                    {
                        afternoonArray.Insert(4, item.People);
                    }
                }
                if (item.IdDay == 6)
                {
                    if (item.Type == "Morning")
                    {
                        morningArray.Insert(5, item.People);
                    }
                    if (item.Type == "Midday")
                    {
                        middayArray.Insert(5, item.People);
                    }
                    if (item.Type == "Afternoon")
                    {
                        afternoonArray.Insert(5, item.People);
                    }
                }
                if (item.IdDay == 7)
                {
                    if (item.Type == "Morning")
                    {
                        morningArray.Insert(6, item.People);
                    }
                    if (item.Type == "Midday")
                    {
                        middayArray.Insert(6, item.People);
                    }
                    if (item.Type == "Afternoon")
                    {
                        afternoonArray.Insert(6, item.People);
                    }
                }
            }

            yAxisArray.Insert(0, morningArray);
            yAxisArray.Insert(1, middayArray);
            yAxisArray.Insert(2, afternoonArray);

            return yAxisArray;
        }


        public JArray getOutsideFullDayByPeriodJArray(List<DayByTypeDTO> list)
        {           

            JArray morningArray = new JArray();
            JArray afternoonArray = new JArray();
            JArray eveningArray = new JArray();
            JArray nightArray = new JArray();

            foreach (var item in list)
            {
                if (item.IdDay == 1)
                {
                    if (item.Type == "Morning")
                    {
                        morningArray.Insert(0, item.People);
                    }
                    if (item.Type == "Afternoon")
                    {
                        afternoonArray.Insert(0, item.People);
                    }
                    if (item.Type == "Evening")
                    {
                        eveningArray.Insert(0, item.People);
                    }
                    if (item.Type == "Night")
                    {
                        nightArray.Insert(0, item.People);
                    }
                }
                if (item.IdDay == 2)
                {
                    if (item.Type == "Morning")
                    {
                        morningArray.Insert(1, item.People);
                    }
                    if (item.Type == "Afternoon")
                    {
                        afternoonArray.Insert(1, item.People);
                    }
                    if (item.Type == "Evening")
                    {
                        eveningArray.Insert(1, item.People);
                    }
                    if (item.Type == "Night")
                    {
                        nightArray.Insert(1, item.People);
                    }
                }
                if (item.IdDay == 3)
                {
                    if (item.Type == "Morning")
                    {
                        morningArray.Insert(2, item.People);
                    }
                    if (item.Type == "Afternoon")
                    {
                        afternoonArray.Insert(2, item.People);
                    }
                    if (item.Type == "Evening")
                    {
                        eveningArray.Insert(2, item.People);
                    }
                    if (item.Type == "Night")
                    {
                        nightArray.Insert(2, item.People);
                    }
                }
                if (item.IdDay == 4)
                {
                    if (item.Type == "Morning")
                    {
                        morningArray.Insert(3, item.People);
                    }
                    if (item.Type == "Afternoon")
                    {
                        afternoonArray.Insert(3, item.People);
                    }
                    if (item.Type == "Evening")
                    {
                        eveningArray.Insert(3, item.People);
                    }
                    if (item.Type == "Night")
                    {
                        nightArray.Insert(3, item.People);
                    }
                }
                if (item.IdDay == 5)
                {
                    if (item.Type == "Morning")
                    {
                        morningArray.Insert(4, item.People);
                    }
                    if (item.Type == "Afternoon")
                    {
                        afternoonArray.Insert(4, item.People);
                    }
                    if (item.Type == "Evening")
                    {
                        eveningArray.Insert(4, item.People);
                    }
                    if (item.Type == "Night")
                    {
                        nightArray.Insert(4, item.People);
                    }
                }
                if (item.IdDay == 6)
                {
                    if (item.Type == "Morning")
                    {
                        morningArray.Insert(5, item.People);
                    }
                    if (item.Type == "Afternoon")
                    {
                        afternoonArray.Insert(5, item.People);
                    }
                    if (item.Type == "Evening")
                    {
                        eveningArray.Insert(5, item.People);
                    }
                    if (item.Type == "Night")
                    {
                        nightArray.Insert(5, item.People);
                    }
                }
                if (item.IdDay == 7)
                {
                    if (item.Type == "Morning")
                    {
                        morningArray.Insert(6, item.People);
                    }
                    if (item.Type == "Afternoon")
                    {
                        afternoonArray.Insert(6, item.People);
                    }
                    if (item.Type == "Evening")
                    {
                        eveningArray.Insert(6, item.People);
                    }
                    if (item.Type == "Night")
                    {
                        nightArray.Insert(6, item.People);
                    }
                }
            }

            yAxisArray.Insert(0, morningArray);
            yAxisArray.Insert(1, afternoonArray);
            yAxisArray.Insert(2, eveningArray);
            yAxisArray.Insert(3, nightArray);
                        
            return yAxisArray;
        }


        public JArray GetInsideWeekDayByPeriodJArray(List<DayByTypeDTO> list)
        {
            JArray morningArray = new JArray();
            JArray afternoonArray = new JArray();
            JArray middayArray = new JArray();

            foreach (var item in list)
            {
                if (item.IdDay == 1)
                {
                    if (item.Type == "Morning")
                    {
                        morningArray.Insert(0, item.People);
                    }
                    if (item.Type == "Midday")
                    {
                        middayArray.Insert(0, item.People);
                    }
                    if (item.Type == "Afternoon")
                    {
                        afternoonArray.Insert(0, item.People);
                    }
                }
                if (item.IdDay == 2)
                {
                    if (item.Type == "Morning")
                    {
                        morningArray.Insert(1, item.People);
                    }
                    if (item.Type == "Midday")
                    {
                        middayArray.Insert(1, item.People);
                    }
                    if (item.Type == "Afternoon")
                    {
                        afternoonArray.Insert(1, item.People);
                    }
                }
                if (item.IdDay == 3)
                {
                    if (item.Type == "Morning")
                    {
                        morningArray.Insert(2, item.People);
                    }
                    if (item.Type == "Midday")
                    {
                        middayArray.Insert(2, item.People);
                    }
                    if (item.Type == "Afternoon")
                    {
                        afternoonArray.Insert(2, item.People);
                    }
                }
                if (item.IdDay == 4)
                {
                    if (item.Type == "Morning")
                    {
                        morningArray.Insert(3, item.People);
                    }
                    if (item.Type == "Midday")
                    {
                        middayArray.Insert(3, item.People);
                    }
                    if (item.Type == "Afternoon")
                    {
                        afternoonArray.Insert(3, item.People);
                    }
                }
                if (item.IdDay == 5)
                {
                    if (item.Type == "Morning")
                    {
                        morningArray.Insert(4, item.People);
                    }
                    if (item.Type == "Midday")
                    {
                        middayArray.Insert(4, item.People);
                    }
                    if (item.Type == "Afternoon")
                    {
                        afternoonArray.Insert(4, item.People);
                    }
                }
            }

            yAxisArray.Insert(0, morningArray);
            yAxisArray.Insert(1, middayArray);
            yAxisArray.Insert(2, afternoonArray);

            return yAxisArray;           
        }

        public JArray GetOutsideWeekDayByPeriodJArray(List<DayByTypeDTO> list)
        {
            JArray morningArray = new JArray();
            JArray afternoonArray = new JArray();
            JArray eveningArray = new JArray();
            JArray nightArray = new JArray();

            foreach (var item in list)
            {
                if (item.IdDay == 1)
                {
                    if (item.Type == "Morning")
                    {
                        morningArray.Insert(0, item.People);
                    }
                    if (item.Type == "Afternoon")
                    {
                        afternoonArray.Insert(0, item.People);
                    }
                    if (item.Type == "Evening")
                    {
                        eveningArray.Insert(0, item.People);
                    }
                    if (item.Type == "Night")
                    {
                        nightArray.Insert(0, item.People);
                    }
                }
                if (item.IdDay == 2)
                {
                    if (item.Type == "Morning")
                    {
                        morningArray.Insert(1, item.People);
                    }
                    if (item.Type == "Afternoon")
                    {
                        afternoonArray.Insert(1, item.People);
                    }
                    if (item.Type == "Evening")
                    {
                        eveningArray.Insert(1, item.People);
                    }
                    if (item.Type == "Night")
                    {
                        nightArray.Insert(1, item.People);
                    }
                }
                if (item.IdDay == 3)
                {
                    if (item.Type == "Morning")
                    {
                        morningArray.Insert(2, item.People);
                    }
                    if (item.Type == "Afternoon")
                    {
                        afternoonArray.Insert(2, item.People);
                    }
                    if (item.Type == "Evening")
                    {
                        eveningArray.Insert(2, item.People);
                    }
                    if (item.Type == "Night")
                    {
                        nightArray.Insert(2, item.People);
                    }
                }
                if (item.IdDay == 4)
                {
                    if (item.Type == "Morning")
                    {
                        morningArray.Insert(3, item.People);
                    }
                    if (item.Type == "Afternoon")
                    {
                        afternoonArray.Insert(3, item.People);
                    }
                    if (item.Type == "Evening")
                    {
                        eveningArray.Insert(3, item.People);
                    }
                    if (item.Type == "Night")
                    {
                        nightArray.Insert(3, item.People);
                    }
                }
                if (item.IdDay == 5)
                {
                    if (item.Type == "Morning")
                    {
                        morningArray.Insert(4, item.People);
                    }
                    if (item.Type == "Afternoon")
                    {
                        afternoonArray.Insert(4, item.People);
                    }
                    if (item.Type == "Evening")
                    {
                        eveningArray.Insert(4, item.People);
                    }
                    if (item.Type == "Night")
                    {
                        nightArray.Insert(4, item.People);
                    }
                }
            }

            yAxisArray.Insert(0, morningArray);
            yAxisArray.Insert(1, afternoonArray);
            yAxisArray.Insert(2, eveningArray);
            yAxisArray.Insert(3, nightArray);

            return yAxisArray;            
        }


        public JArray GetInsideWeekendByPeriodJArray(List<DayByTypeDTO> list)
        {
            JArray morningArray = new JArray();
            JArray afternoonArray = new JArray();
            JArray middayArray = new JArray();         

            foreach (var item in list)
            {

                if (item.IdDay == 6)
                {
                    if (item.Type == "Morning")
                    {
                        morningArray.Insert(0, item.People);
                    }
                    if (item.Type == "Midday")
                    {
                        middayArray.Insert(0, item.People);
                    }
                    if (item.Type == "Afternoon")
                    {
                        afternoonArray.Insert(0, item.People);
                    }
                }
                if (item.IdDay == 7)
                {
                    if (item.Type == "Morning")
                    {
                        morningArray.Insert(0, item.People);
                    }
                    if (item.Type == "Midday")
                    {
                        middayArray.Insert(0, item.People);
                    }
                    if (item.Type == "Afternoon")
                    {
                        afternoonArray.Insert(0, item.People);
                    }
                }
            }

            yAxisArray.Insert(0, morningArray);
            yAxisArray.Insert(1, afternoonArray);
            yAxisArray.Insert(2, middayArray);

            return yAxisArray;     
        }

        public JArray getOutsideWeekendByPeriodJArray(List<DayByTypeDTO> list)
        {            

            JArray morningArray = new JArray();
            JArray afternoonArray = new JArray();
            JArray eveningArray = new JArray();
            JArray nightArray = new JArray();

            foreach (var item in list)
            {
                if (item.IdDay == 6)
                {
                    if (item.Type == "Morning")
                    {
                        morningArray.Insert(0, item.People);
                    }
                    if (item.Type == "Afternoon")
                    {
                        afternoonArray.Insert(0, item.People);
                    }
                    if (item.Type == "Evening")
                    {
                        eveningArray.Insert(0, item.People);
                    }
                    if (item.Type == "Night")
                    {
                        nightArray.Insert(0, item.People);
                    }
                }
                if (item.IdDay == 7)
                {
                    if (item.Type == "Morning")
                    {
                        morningArray.Insert(1, item.People);
                    }
                    if (item.Type == "Afternoon")
                    {
                        afternoonArray.Insert(1, item.People);
                    }
                    if (item.Type == "Evening")
                    {
                        eveningArray.Insert(1, item.People);
                    }
                    if (item.Type == "Night")
                    {
                        nightArray.Insert(1, item.People);
                    }
                }
            }

            yAxisArray.Insert(0, morningArray);
            yAxisArray.Insert(1, afternoonArray);
            yAxisArray.Insert(2, eveningArray);
            yAxisArray.Insert(3, nightArray);

            return yAxisArray;            
        }

        public JArray GetInsideCustomerFullDaysByActivityJArray(List<DayByTypeDTO> list)
        {         
            JArray takeAwayArray = new JArray();
            JArray sitDownArray = new JArray();            

            foreach (var item in list)
            {
                if (item.IdDay == 1)
                {
                    if (item.Type == "Take_away Customers")
                    {
                        takeAwayArray.Insert(0, item.People);
                    }
                    if (item.Type == "Sit-down Customers")
                    {
                        sitDownArray.Insert(0, item.People);
                    }                    
                }
                if (item.IdDay == 2)
                {
                    if (item.Type == "Take_away Customers")
                    {
                        takeAwayArray.Insert(1, item.People);
                    }
                    if (item.Type == "Sit-down Customers")
                    {
                        sitDownArray.Insert(1, item.People);
                    }                    
                }
                if (item.IdDay == 3)
                {
                    if (item.Type == "Take_away Customers")
                    {
                        takeAwayArray.Insert(2, item.People);
                    }
                    if (item.Type == "Sit-down Customers")
                    {
                        sitDownArray.Insert(2, item.People);
                    }                    
                }
                if (item.IdDay == 4)
                {
                    if (item.Type == "Take_away Customers")
                    {
                        takeAwayArray.Insert(3, item.People);
                    }
                    if (item.Type == "Sit-down Customers")
                    {
                        sitDownArray.Insert(3, item.People);
                    }                    
                }
                if (item.IdDay == 5)
                {
                    if (item.Type == "Take_away Customers")
                    {
                        takeAwayArray.Insert(4, item.People);
                    }
                    if (item.Type == "Sit-down Customers")
                    {
                        sitDownArray.Insert(4, item.People);
                    }                    
                }
                if (item.IdDay == 6)
                {
                    if (item.Type == "Take_away Customers")
                    {
                        takeAwayArray.Insert(5, item.People);
                    }
                    if (item.Type == "Sit-down Customers")
                    {
                        sitDownArray.Insert(5, item.People);
                    }                    
                }
                if (item.IdDay == 7)
                {
                    if (item.Type == "Take_away Customers")
                    {
                        takeAwayArray.Insert(6, item.People);
                    }
                    if (item.Type == "Sit-down Customers")
                    {
                        sitDownArray.Insert(6, item.People);
                    }                    
                }
            }

            yAxisArray.Insert(0, takeAwayArray);
            yAxisArray.Insert(1, sitDownArray);

            return yAxisArray;            
        }

        public JArray GetInsideTransactionFullDaysByActivityJArray(List<DayByTypeDTO> list)
        {            

            JArray shortTransactionArray = new JArray();
            JArray longTransactionArray = new JArray();

            foreach (var item in list)
            {
                if (item.IdDay == 1)
                {
                    if (item.Type == "Transaction time 1-5 min")
                    {
                        shortTransactionArray.Insert(0, item.People);
                    }
                    if (item.Type == "Transaction time 5-10 min")
                    {
                        longTransactionArray.Insert(0, item.People);
                    }
                }
                if (item.IdDay == 2)
                {                    
                    if (item.Type == "Transaction time 1-5 min")
                    {
                        shortTransactionArray.Insert(1, item.People);
                    }
                    if (item.Type == "Transaction time 5-10 min")
                    {
                        longTransactionArray.Insert(1, item.People);
                    }
                }
                if (item.IdDay == 3)
                {                    
                    if (item.Type == "Transaction time 1-5 min")
                    {
                        shortTransactionArray.Insert(2, item.People);
                    }
                    if (item.Type == "Transaction time 5-10 min")
                    {
                        longTransactionArray.Insert(2, item.People);
                    }
                }
                if (item.IdDay == 4)
                {                    
                    if (item.Type == "Transaction time 1-5 min")
                    {
                        shortTransactionArray.Insert(3, item.People);
                    }
                    if (item.Type == "Transaction time 5-10 min")
                    {
                        longTransactionArray.Insert(3, item.People);
                    }
                }
                if (item.IdDay == 5)
                {                    
                    if (item.Type == "Transaction time 1-5 min")
                    {
                        shortTransactionArray.Insert(4, item.People);
                    }
                    if (item.Type == "Transaction time 5-10 min")
                    {
                        longTransactionArray.Insert(4, item.People);
                    }
                }
                if (item.IdDay == 6)
                {                    
                    if (item.Type == "Transaction time 1-5 min")
                    {
                        shortTransactionArray.Insert(5, item.People);
                    }
                    if (item.Type == "Transaction time 5-10 min")
                    {
                        longTransactionArray.Insert(5, item.People);
                    }
                }
                if (item.IdDay == 7)
                {                    
                    if (item.Type == "Transaction time 1-5 min")
                    {
                        shortTransactionArray.Insert(6, item.People);
                    }
                    if (item.Type == "Transaction time 5-10 min")
                    {
                        longTransactionArray.Insert(6, item.People);
                    }
                }
            }

            yAxisArray.Insert(0, shortTransactionArray);
            yAxisArray.Insert(1, longTransactionArray);                  

            return yAxisArray;
        }


        public JArray getOutsideFullDaysByActivityJArray(List<DayByTypeDTO> list)
        {
            JArray liveArray = new JArray();
            JArray workArray = new JArray();
            JArray commuteArray = new JArray();
            JArray passerByArray = new JArray();
            JArray leisureArray = new JArray();

            foreach (var item in list)
            {
                if (item.IdDay == 1)
                {
                    if (item.Type == "Live")
                    {
                        liveArray.Insert(0, item.People);
                    }
                    if (item.Type == "Work")
                    {
                        workArray.Insert(0, item.People);
                    }
                    if (item.Type == "Leisure/Fun")
                    {
                        leisureArray.Insert(0, item.People);
                    }
                    if (item.Type == "Commute")
                    {
                        commuteArray.Insert(0, item.People);
                    }
                    if (item.Type == "Passer-by")
                    {
                        passerByArray.Insert(0, item.People);
                    }
                }
                if (item.IdDay == 2)
                {
                    if (item.Type == "Live")
                    {
                        liveArray.Insert(1, item.People);
                    }
                    if (item.Type == "Work")
                    {
                        workArray.Insert(1, item.People);
                    }
                    if (item.Type == "Leisure/Fun")
                    {
                        leisureArray.Insert(1, item.People);
                    }
                    if (item.Type == "Commute")
                    {
                        commuteArray.Insert(1, item.People);
                    }
                    if (item.Type == "Passer-by")
                    {
                        passerByArray.Insert(1, item.People);
                    }
                }
                if (item.IdDay == 3)
                {
                    if (item.Type == "Live")
                    {
                        liveArray.Insert(2, item.People);
                    }
                    if (item.Type == "Work")
                    {
                        workArray.Insert(2, item.People);
                    }
                    if (item.Type == "Leisure/Fun")
                    {
                        leisureArray.Insert(2, item.People);
                    }
                    if (item.Type == "Commute")
                    {
                        commuteArray.Insert(2, item.People);
                    }
                    if (item.Type == "Passer-by")
                    {
                        passerByArray.Insert(2, item.People);
                    }
                }
                if (item.IdDay == 4)
                {
                    if (item.Type == "Live")
                    {
                        liveArray.Insert(3, item.People);
                    }
                    if (item.Type == "Work")
                    {
                        workArray.Insert(3, item.People);
                    }
                    if (item.Type == "Leisure/Fun")
                    {
                        leisureArray.Insert(3, item.People);
                    }
                    if (item.Type == "Commute")
                    {
                        commuteArray.Insert(3, item.People);
                    }
                    if (item.Type == "Passer-by")
                    {
                        passerByArray.Insert(3, item.People);
                    }
                }
                if (item.IdDay == 5)
                {
                    if (item.Type == "Live")
                    {
                        liveArray.Insert(4, item.People);
                    }
                    if (item.Type == "Work")
                    {
                        workArray.Insert(4, item.People);
                    }
                    if (item.Type == "Leisure/Fun")
                    {
                        leisureArray.Insert(4, item.People);
                    }
                    if (item.Type == "Commute")
                    {
                        commuteArray.Insert(4, item.People);
                    }
                    if (item.Type == "Passer-by")
                    {
                        passerByArray.Insert(4, item.People);
                    }
                }
                if (item.IdDay == 6)
                {
                    if (item.Type == "Live")
                    {
                        liveArray.Insert(5, item.People);
                    }
                    if (item.Type == "Work")
                    {
                        workArray.Insert(5, item.People);
                    }
                    if (item.Type == "Leisure/Fun")
                    {
                        leisureArray.Insert(5, item.People);
                    }
                    if (item.Type == "Commute")
                    {
                        commuteArray.Insert(5, item.People);
                    }
                    if (item.Type == "Passer-by")
                    {
                        passerByArray.Insert(5, item.People);
                    }
                }
                if (item.IdDay == 7)
                {
                    if (item.Type == "Live")
                    {
                        liveArray.Insert(6, item.People);
                    }
                    if (item.Type == "Work")
                    {
                        workArray.Insert(6, item.People);
                    }
                    if (item.Type == "Leisure/Fun")
                    {
                        leisureArray.Insert(6, item.People);
                    }
                    if (item.Type == "Commute")
                    {
                        commuteArray.Insert(6, item.People);
                    }
                    if (item.Type == "Passer-by")
                    {
                        passerByArray.Insert(6, item.People);
                    }
                }
            }

            yAxisArray.Insert(0, liveArray);
            yAxisArray.Insert(1, workArray);
            yAxisArray.Insert(2, commuteArray);
            yAxisArray.Insert(3, passerByArray);
            yAxisArray.Insert(4, leisureArray);

            return yAxisArray;
        }


        public JArray GetByDaysByActivityJArray(List<DayByTypeDTO> list)
        {           
            JArray objArray = new JArray();            

            foreach (var item in list)
            {
                JObject jObject = new JObject();
                jObject.Add("id", item.IdDay);
                jObject.Add("title", item.Day + " by Activities");
                jObject.Add("xAxis", item.Type);
                jObject.Add("yAxis", item.People);
                objArray.Add(jObject);
            }
            return objArray;          
        }
 

        public JArray GetInsideCustomerWeekDaysByActivityJArray(List<DaysByActivityDTO> list)
        {
            JArray takeAwayArray = new JArray();
            JArray sitDownArray = new JArray();

            foreach (var item in list)
            {
                if (item.IdDay == 1)
                {
                    if (item.NameActivity == "Take_away Customers")
                    {
                        takeAwayArray.Insert(0, item.People);
                    }
                    if (item.NameActivity == "Sit-down Customers")
                    {
                        sitDownArray.Insert(0, item.People);
                    }                    
                }
                if (item.IdDay == 2)
                {
                    if (item.NameActivity == "Take_away Customers")
                    {
                        takeAwayArray.Insert(1, item.People);
                    }
                    if (item.NameActivity == "Sit-down Customers")
                    {
                        sitDownArray.Insert(1, item.People);
                    }
                }
                if (item.IdDay == 3)
                {
                    if (item.NameActivity == "Take_away Customers")
                    {
                        takeAwayArray.Insert(2, item.People);
                    }
                    if (item.NameActivity == "Sit-down Customers")
                    {
                        sitDownArray.Insert(2, item.People);
                    }
                }
                if (item.IdDay == 4)
                {
                    if (item.NameActivity == "Take_away Customers")
                    {
                        takeAwayArray.Insert(3, item.People);
                    }
                    if (item.NameActivity == "Sit-down Customers")
                    {
                        sitDownArray.Insert(3, item.People);
                    }
                }
                if (item.IdDay == 5)
                {
                    if (item.NameActivity == "Take_away Customers")
                    {
                        takeAwayArray.Insert(4, item.People);
                    }
                    if (item.NameActivity == "Sit-down Customers")
                    {
                        sitDownArray.Insert(4, item.People);
                    }
                }
            }

            yAxisArray.Insert(0, takeAwayArray);
            yAxisArray.Insert(1, sitDownArray);

            return yAxisArray;
        }

        public JArray getInsideTransactionWeekDaysByActivityJArray(List<DaysByActivityDTO> list)
        {           
            JArray shortTransactionArray = new JArray();
            JArray longTransactionArray = new JArray();
                        
            foreach (var item in list)
            {
                if (item.IdDay == 1)
                {                    
                    if (item.NameActivity == "Transaction time 1-5 min")
                    {
                        shortTransactionArray.Insert(0, item.People);
                    }
                    if (item.NameActivity == "Transaction time 5-10 min")
                    {
                        longTransactionArray.Insert(0, item.People);
                    }
                }
                if (item.IdDay == 2)
                {                    
                    if (item.NameActivity == "Transaction time 1-5 min")
                    {
                        shortTransactionArray.Insert(1, item.People);
                    }
                    if (item.NameActivity == "Transaction time 5-10 min")
                    {
                        longTransactionArray.Insert(1, item.People);
                    }
                }
                if (item.IdDay == 3)
                {                    
                    if (item.NameActivity == "Transaction time 1-5 min")
                    {
                        shortTransactionArray.Insert(2, item.People);
                    }
                    if (item.NameActivity == "Transaction time 5-10 min")
                    {
                        longTransactionArray.Insert(2, item.People);
                    }
                }
                if (item.IdDay == 4)
                {                    
                    if (item.NameActivity == "Transaction time 1-5 min")
                    {
                        shortTransactionArray.Insert(3, item.People);
                    }
                    if (item.NameActivity == "Transaction time 5-10 min")
                    {
                        longTransactionArray.Insert(3, item.People);
                    }
                }
                if (item.IdDay == 5)
                {                    
                    if (item.NameActivity == "Transaction time 1-5 min")
                    {
                        shortTransactionArray.Insert(4, item.People);
                    }
                    if (item.NameActivity == "Transaction time 5-10 min")
                    {
                        longTransactionArray.Insert(4, item.People);
                    }
                }
            }
            
            yAxisArray.Insert(0, shortTransactionArray);
            yAxisArray.Insert(1, longTransactionArray);

            return yAxisArray;           
        }


        public JArray GetOutsideWeekDaysByActivityJArray(List<DaysByActivityDTO> list)
        {
            JArray liveArray = new JArray();
            JArray workArray = new JArray();
            JArray leisureArray = new JArray();
            JArray commuteArray = new JArray();
            JArray passerByArray = new JArray();

            foreach (var item in list)
            {
                if (item.IdDay == 1)
                {
                    if (item.NameActivity == "Live")
                    {
                        liveArray.Insert(0, item.People);
                    }
                    if (item.NameActivity == "Work")
                    {
                        workArray.Insert(0, item.People);
                    }
                    if (item.NameActivity == "Leisure/Fun")
                    {
                        leisureArray.Insert(0, item.People);
                    }
                    if (item.NameActivity == "Commute")
                    {
                        commuteArray.Insert(0, item.People);
                    }
                    if (item.NameActivity == "Passer-by")
                    {
                        passerByArray.Insert(0, item.People);
                    }
                }
                if (item.IdDay == 2)
                {
                    if (item.NameActivity == "Live")
                    {
                        liveArray.Insert(1, item.People);
                    }
                    if (item.NameActivity == "Work")
                    {
                        workArray.Insert(1, item.People);
                    }
                    if (item.NameActivity == "Leisure/Fun")
                    {
                        leisureArray.Insert(1, item.People);
                    }
                    if (item.NameActivity == "Commute")
                    {
                        commuteArray.Insert(1, item.People);
                    }
                    if (item.NameActivity == "Passer-by")
                    {
                        passerByArray.Insert(1, item.People);
                    }
                }
                if (item.IdDay == 3)
                {
                    if (item.NameActivity == "Live")
                    {
                        liveArray.Insert(2, item.People);
                    }
                    if (item.NameActivity == "Work")
                    {
                        workArray.Insert(2, item.People);
                    }
                    if (item.NameActivity == "Leisure/Fun")
                    {
                        leisureArray.Insert(2, item.People);
                    }
                    if (item.NameActivity == "Commute")
                    {
                        commuteArray.Insert(2, item.People);
                    }
                    if (item.NameActivity == "Passer-by")
                    {
                        passerByArray.Insert(2, item.People);
                    }
                }
                if (item.IdDay == 4)
                {
                    if (item.NameActivity == "Live")
                    {
                        liveArray.Insert(3, item.People);
                    }
                    if (item.NameActivity == "Work")
                    {
                        workArray.Insert(3, item.People);
                    }
                    if (item.NameActivity == "Leisure/Fun")
                    {
                        leisureArray.Insert(3, item.People);
                    }
                    if (item.NameActivity == "Commute")
                    {
                        commuteArray.Insert(3, item.People);
                    }
                    if (item.NameActivity == "Passer-by")
                    {
                        passerByArray.Insert(3, item.People);
                    }
                }
                if (item.IdDay == 5)
                {
                    if (item.NameActivity == "Live")
                    {
                        liveArray.Insert(4, item.People);
                    }
                    if (item.NameActivity == "Work")
                    {
                        workArray.Insert(4, item.People);
                    }
                    if (item.NameActivity == "Commute")
                    {
                        commuteArray.Insert(4, item.People);
                    }
                    if (item.NameActivity == "Passer-by")
                    {
                        passerByArray.Insert(4, item.People);
                    }
                    if (item.NameActivity == "Leisure/Fun")
                    {
                        leisureArray.Insert(4, item.People);
                    }
                }
            }

            yAxisArray.Insert(0, liveArray);
            yAxisArray.Insert(1, workArray);
            yAxisArray.Insert(2, commuteArray);
            yAxisArray.Insert(3, passerByArray);
            yAxisArray.Insert(4, leisureArray);

            return yAxisArray;
        }


        public JArray GetInsideCustomerWeekendByActivityJArray(List<DaysByActivityDTO> list)
        {
            JArray takeAwayArray = new JArray();
            JArray sitDownArray = new JArray();
            
            foreach (var item in list)
            {
                if (item.IdDay == 6)
                {
                    if (item.NameActivity == "Take_away Customers")
                    {
                        takeAwayArray.Insert(0, item.People);
                    }
                    if (item.NameActivity == "Sit-down Customers")
                    {
                        sitDownArray.Insert(0, item.People);
                    }                    
                }
                if (item.IdDay == 7)
                {
                    if (item.NameActivity == "Take_away Customers")
                    {
                        takeAwayArray.Insert(1, item.People);
                    }
                    if (item.NameActivity == "Sit-down Customers")
                    {
                        sitDownArray.Insert(1, item.People);
                    }                    
                }                
            }

            yAxisArray.Insert(0, takeAwayArray);
            yAxisArray.Insert(1, sitDownArray);

            return yAxisArray;           
        }


        public JArray GetInsideTransactionWeekendByActivityJArray(List<DaysByActivityDTO> list)
        {
            JArray shortTransactionArray = new JArray();
            JArray longTransactionArray = new JArray();

            foreach (var item in list)
            {
                if (item.IdDay == 6)
                {                    
                    if (item.NameActivity == "Transaction time 1-5 min")
                    {
                        shortTransactionArray.Insert(0, item.People);
                    }
                    if (item.NameActivity == "Transaction time 5-10 min")
                    {
                        longTransactionArray.Insert(0, item.People);
                    }
                }
                if (item.IdDay == 7)
                {
                    if (item.NameActivity == "Transaction time 1-5 min")
                    {
                        shortTransactionArray.Insert(1, item.People);
                    }
                    if (item.NameActivity == "Transaction time 5-10 min")
                    {
                        longTransactionArray.Insert(1, item.People);
                    }
                }
            }
            yAxisArray.Insert(0, shortTransactionArray);
            yAxisArray.Insert(1, longTransactionArray);

            return yAxisArray;           
        }


        public JArray GetOutsideWeekendByActivityJArray(List<DaysByActivityDTO> list)
        {
            JArray liveArray = new JArray();
            JArray workArray = new JArray();
            JArray leisureArray = new JArray();
            JArray commuteArray = new JArray();
            JArray passerByArray = new JArray();

            foreach (var item in list)
            {
                if (item.IdDay == 6)
                {
                    if (item.NameActivity == "Live")
                    {
                        liveArray.Insert(0, item.People);
                    }
                    if (item.NameActivity == "Work")
                    {
                        workArray.Insert(0, item.People);
                    }
                    if (item.NameActivity == "Commute")
                    {
                        commuteArray.Insert(0, item.People);
                    }
                    if (item.NameActivity == "Passer-by")
                    {
                        passerByArray.Insert(0, item.People);
                    }
                    if (item.NameActivity == "Leisure/Fun")
                    {
                        leisureArray.Insert(0, item.People);
                    }
                }
                if (item.IdDay == 7)
                {
                    if (item.NameActivity == "Live")
                    {
                        liveArray.Insert(1, item.People);
                    }
                    if (item.NameActivity == "Work")
                    {
                        workArray.Insert(1, item.People);
                    }
                    if (item.NameActivity == "Commute")
                    {
                        commuteArray.Insert(1, item.People);
                    }
                    if (item.NameActivity == "Passer-by")
                    {
                        passerByArray.Insert(1, item.People);
                    }
                    if (item.NameActivity == "Leisure/Fun")
                    {
                        leisureArray.Insert(1, item.People);
                    }
                }
            }

            yAxisArray.Insert(0, liveArray);
            yAxisArray.Insert(1, workArray);
            yAxisArray.Insert(2, commuteArray);
            yAxisArray.Insert(3, passerByArray);
            yAxisArray.Insert(4, leisureArray);

            return yAxisArray;
        }


        public JArray GetInsideCustomerByDayByPeriodByActivityJArray(List<ByDayByPeriodByActivityDTO> list, string day)
        {

            int[] yAxisActivityByPeriodLiveArray = new int[3];
            int[] yAxisActivityByPeriodWorkArray = new int[3];

            foreach (var item in list)
            {
                if (item.NamePeriod == "Morning")
                {
                    if (item.Type == "Take_away Customers")
                    {
                        yAxisActivityByPeriodLiveArray[0] = item.People;
                    }
                    if (item.Type == "Sit-down Customers")
                    {
                        yAxisActivityByPeriodWorkArray[0] = item.People;
                    }                                        
                }
                if (item.NamePeriod == "Midday")
                {
                    if (item.Type == "Take_away Customers")
                    {
                        yAxisActivityByPeriodLiveArray[1] = item.People;
                    }
                    if (item.Type == "Sit-down Customers")
                    {
                        yAxisActivityByPeriodWorkArray[1] = item.People;
                    }                    
                }
                if (item.NamePeriod == "Afternoon")
                {
                    if (item.Type == "Take_away Customers")
                    {
                        yAxisActivityByPeriodLiveArray[2] = item.People;
                    }
                    if (item.Type == "Sit-down Customers")
                    {
                        yAxisActivityByPeriodWorkArray[2] = item.People;
                    }                    
                }                
            }

            JArray yAxisArray = new JArray();
            yAxisArray.Insert(0, JArray.FromObject(yAxisActivityByPeriodLiveArray));
            yAxisArray.Insert(1, JArray.FromObject(yAxisActivityByPeriodWorkArray));
            return yAxisArray;
        }

        public JArray GetInsideTransactionByDayByPeriodByActivityJArray(List<ByDayByPeriodByActivityDTO> list, string day)
        {            
            int[] yAxisActivityByPeriodCommuteArray = new int[3];
            int[] yAxisActivityByPeriodPasserbyArray = new int[3];

            foreach (var item in list)
            {
                if (item.NamePeriod == "Morning")
                {                    
                    if (item.Type == "Transaction time 1-5 min")
                    {
                        yAxisActivityByPeriodCommuteArray[0] = item.People;
                    }
                    if (item.Type == "Transaction time 5-10 min")
                    {
                        yAxisActivityByPeriodPasserbyArray[0] = item.People;
                    }
                }
                if (item.NamePeriod == "Midday")
                {
                    if (item.Type == "Transaction time 1-5 min")
                    {
                        yAxisActivityByPeriodCommuteArray[1] = item.People;
                    }
                    if (item.Type == "Transaction time 5-10 min")
                    {
                        yAxisActivityByPeriodPasserbyArray[1] = item.People;
                    }
                }
                if (item.NamePeriod == "Afternoon")
                {                    
                    if (item.Type == "Transaction time 1-5 min")
                    {
                        yAxisActivityByPeriodCommuteArray[2] = item.People;
                    }
                    if (item.Type == "Transaction time 5-10 min")
                    {
                        yAxisActivityByPeriodPasserbyArray[2] = item.People;
                    }
                }
            }
            
            yAxisArray.Insert(0, JArray.FromObject(yAxisActivityByPeriodCommuteArray));
            yAxisArray.Insert(1, JArray.FromObject(yAxisActivityByPeriodPasserbyArray));
            
            return yAxisArray;
        }


        public JArray GetOutsideByDayByPeriodByActivityJArray(List<ByDayByPeriodByActivityDTO> list, string day)
        {            
            int[] yAxisActivityByPeriodLiveArray = new int[4];
            int[] yAxisActivityByPeriodWorkArray = new int[4];
            int[] yAxisActivityByPeriodCommuteArray = new int[4];
            int[] yAxisActivityByPeriodPasserbyArray = new int[4];
            int[] yAxisActivityByPeriodLeisureArray = new int[4];


            foreach (var item in list)
            {
                if (item.NamePeriod == "Morning")
                {
                    if (item.Type == "Live")
                    {
                        yAxisActivityByPeriodLiveArray[0] = item.People;
                    }
                    if (item.Type == "Work")
                    {
                        yAxisActivityByPeriodWorkArray[0] = item.People;
                    }
                    if (item.Type == "Commute")
                    {
                        yAxisActivityByPeriodCommuteArray[0] = item.People;
                    }
                    if (item.Type == "Passer-by")
                    {
                        yAxisActivityByPeriodPasserbyArray[0] = item.People;
                    }
                    if (item.Type == "Leisure/Fun")
                    {
                        yAxisActivityByPeriodLeisureArray[0] = item.People;
                    }
                }
                if (item.NamePeriod == "Afternoon")
                {
                    if (item.Type == "Live")
                    {
                        yAxisActivityByPeriodLiveArray[1] = item.People;
                    }
                    if (item.Type == "Work")
                    {
                        yAxisActivityByPeriodWorkArray[1] = item.People;
                    }
                    if (item.Type == "Commute")
                    {
                        yAxisActivityByPeriodCommuteArray[1] = item.People;
                    }
                    if (item.Type == "Passer-by")
                    {
                        yAxisActivityByPeriodPasserbyArray[1] = item.People;
                    }
                    if (item.Type == "Leisure/Fun")
                    {
                        yAxisActivityByPeriodLeisureArray[1] = item.People;
                    }
                }
                if (item.NamePeriod == "Evening")
                {
                    if (item.Type == "Live")
                    {
                        yAxisActivityByPeriodLiveArray[2] = item.People;
                    }
                    if (item.Type == "Work")
                    {
                        yAxisActivityByPeriodWorkArray[2] = item.People;
                    }
                    if (item.Type == "Commute")
                    {
                        yAxisActivityByPeriodCommuteArray[2] = item.People;
                    }
                    if (item.Type == "Passer-by")
                    {
                        yAxisActivityByPeriodPasserbyArray[2] = item.People;
                    }
                    if (item.Type == "Leisure/Fun")
                    {
                        yAxisActivityByPeriodLeisureArray[2] = item.People;
                    }
                }
                if (item.NamePeriod == "Night")
                {
                    if (item.Type == "Live")
                    {
                        yAxisActivityByPeriodLiveArray[3] = item.People;
                    }
                    if (item.Type == "Work")
                    {
                        yAxisActivityByPeriodWorkArray[3] = item.People;
                    }
                    if (item.Type == "Commute")
                    {
                        yAxisActivityByPeriodCommuteArray[3] = item.People;
                    }
                    if (item.Type == "Passer-by")
                    {
                        yAxisActivityByPeriodPasserbyArray[3] = item.People;
                    }
                    if (item.Type == "Leisure/Fun")
                    {
                        yAxisActivityByPeriodLeisureArray[3] = item.People;
                    }
                }
            }
            
            yAxisArray.Insert(0, JArray.FromObject(yAxisActivityByPeriodLiveArray));
            yAxisArray.Insert(1, JArray.FromObject(yAxisActivityByPeriodWorkArray));
            yAxisArray.Insert(2, JArray.FromObject(yAxisActivityByPeriodCommuteArray));
            yAxisArray.Insert(3, JArray.FromObject(yAxisActivityByPeriodPasserbyArray));
            yAxisArray.Insert(4, JArray.FromObject(yAxisActivityByPeriodLeisureArray));

            return yAxisArray;
        }

        public List<int[][]> GetInsideCustomerFullDaysByPeriodByActivityJArray(List<ByDayByPeriodByActivityDTO> list)
        {
            int[] yAxisPeriodArrayMorningLiveFullDays = new int[7];
            int[] yAxisPeriodArrayMiddayLiveFullDays = new int[7];
            int[] yAxisPeriodArrayAfternoonLiveFullDays = new int[7];                   

            int[] yAxisPeriodArrayMorningWorkFullDays = new int[7];          
            int[] yAxisPeriodArrayMiddayWorkFullDays = new int[7];
            int[] yAxisPeriodArrayAfternoonWorkFullDays = new int[7];

            foreach (var item in list)
            {
                if (item.Type == "Take_away Customers")
                {
                    if (item.NamePeriod == "Morning")
                    {
                        if (item.Day == "Monday")
                        {
                            yAxisPeriodArrayMorningLiveFullDays[0] = item.People;
                        }
                        if (item.Day == "Tuesday")
                        {
                            yAxisPeriodArrayMorningLiveFullDays[1] = item.People;
                        }
                        if (item.Day == "Wednesday")
                        {
                            yAxisPeriodArrayMorningLiveFullDays[2] = item.People;
                        }
                        if (item.Day == "Thursday")
                        {
                            yAxisPeriodArrayMorningLiveFullDays[3] = item.People;
                        }
                        if (item.Day == "Friday")
                        {
                            yAxisPeriodArrayMorningLiveFullDays[4] = item.People;
                        }
                        if (item.Day == "Saturday")
                        {
                            yAxisPeriodArrayMorningLiveFullDays[5] = item.People;
                        }
                        if (item.Day == "Sunday")
                        {
                            yAxisPeriodArrayMorningLiveFullDays[6] = item.People;
                        }
                    }
                    if (item.NamePeriod == "Midday")
                    {
                        if (item.Day == "Monday")
                        {
                            yAxisPeriodArrayMiddayLiveFullDays[0] = item.People;
                        }
                        if (item.Day == "Tuesday")
                        {
                            yAxisPeriodArrayMiddayLiveFullDays[1] = item.People;
                        }
                        if (item.Day == "Wednesday")
                        {
                            yAxisPeriodArrayMiddayLiveFullDays[2] = item.People;
                        }
                        if (item.Day == "Thursday")
                        {
                            yAxisPeriodArrayMiddayLiveFullDays[3] = item.People;
                        }
                        if (item.Day == "Friday")
                        {
                            yAxisPeriodArrayMiddayLiveFullDays[4] = item.People;
                        }
                        if (item.Day == "Saturday")
                        {
                            yAxisPeriodArrayMiddayLiveFullDays[5] = item.People;
                        }
                        if (item.Day == "Sunday")
                        {
                            yAxisPeriodArrayMiddayLiveFullDays[6] = item.People;
                        }
                    }
                    if (item.NamePeriod == "Afternoon")
                    {
                        if (item.Day == "Monday")
                        {
                            yAxisPeriodArrayAfternoonLiveFullDays[0] = item.People;
                        }
                        if (item.Day == "Tuesday")
                        {
                            yAxisPeriodArrayAfternoonLiveFullDays[1] = item.People;
                        }
                        if (item.Day == "Wednesday")
                        {
                            yAxisPeriodArrayAfternoonLiveFullDays[2] = item.People;
                        }
                        if (item.Day == "Thursday")
                        {
                            yAxisPeriodArrayAfternoonLiveFullDays[3] = item.People;
                        }
                        if (item.Day == "Friday")
                        {
                            yAxisPeriodArrayAfternoonLiveFullDays[4] = item.People;
                        }
                        if (item.Day == "Saturday")
                        {
                            yAxisPeriodArrayAfternoonLiveFullDays[5] = item.People;
                        }
                        if (item.Day == "Sunday")
                        {
                            yAxisPeriodArrayAfternoonLiveFullDays[6] = item.People;
                        }
                    }                    
                }
                if (item.Type == "Sit-down Customers")
                {
                    if (item.NamePeriod == "Morning")
                    {
                        if (item.Day == "Monday")
                        {
                            yAxisPeriodArrayMorningWorkFullDays[0] = item.People;
                        }
                        if (item.Day == "Tuesday")
                        {
                            yAxisPeriodArrayMorningWorkFullDays[1] = item.People;
                        }
                        if (item.Day == "Wednesday")
                        {
                            yAxisPeriodArrayMorningWorkFullDays[2] = item.People;
                        }
                        if (item.Day == "Thursday")
                        {
                            yAxisPeriodArrayMorningWorkFullDays[3] = item.People;
                        }
                        if (item.Day == "Friday")
                        {
                            yAxisPeriodArrayMorningWorkFullDays[4] = item.People;
                        }
                        if (item.Day == "Saturday")
                        {
                            yAxisPeriodArrayMorningWorkFullDays[5] = item.People;
                        }
                        if (item.Day == "Sunday")
                        {
                            yAxisPeriodArrayMorningWorkFullDays[6] = item.People;
                        }
                    }
                    if (item.NamePeriod == "Midday")
                    {
                        if (item.Day == "Monday")
                        {
                            yAxisPeriodArrayMiddayWorkFullDays[0] = item.People;
                        }
                        if (item.Day == "Tuesday")
                        {
                            yAxisPeriodArrayMiddayWorkFullDays[1] = item.People;
                        }
                        if (item.Day == "Wednesday")
                        {
                            yAxisPeriodArrayMiddayWorkFullDays[2] = item.People;
                        }
                        if (item.Day == "Thursday")
                        {
                            yAxisPeriodArrayMiddayWorkFullDays[3] = item.People;
                        }
                        if (item.Day == "Friday")
                        {
                            yAxisPeriodArrayMiddayWorkFullDays[4] = item.People;
                        }
                        if (item.Day == "Saturday")
                        {
                            yAxisPeriodArrayMiddayWorkFullDays[5] = item.People;
                        }
                        if (item.Day == "Sunday")
                        {
                            yAxisPeriodArrayMiddayWorkFullDays[6] = item.People;
                        }
                    }
                    if (item.NamePeriod == "Afternoon")
                    {
                        if (item.Day == "Monday")
                        {
                            yAxisPeriodArrayAfternoonWorkFullDays[0] = item.People;
                        }
                        if (item.Day == "Tuesday")
                        {
                            yAxisPeriodArrayAfternoonWorkFullDays[1] = item.People;
                        }
                        if (item.Day == "Wednesday")
                        {
                            yAxisPeriodArrayAfternoonWorkFullDays[2] = item.People;
                        }
                        if (item.Day == "Thursday")
                        {
                            yAxisPeriodArrayAfternoonWorkFullDays[3] = item.People;
                        }
                        if (item.Day == "Friday")
                        {
                            yAxisPeriodArrayAfternoonWorkFullDays[4] = item.People;
                        }
                        if (item.Day == "Saturday")
                        {
                            yAxisPeriodArrayAfternoonWorkFullDays[5] = item.People;
                        }
                        if (item.Day == "Sunday")
                        {
                            yAxisPeriodArrayAfternoonWorkFullDays[6] = item.People;
                        }
                    }                    
                }             
            }

            int[][] jaggedArrayLive = new int[3][];
            int[][] jaggedArrayWork = new int[3][];
         

            jaggedArrayLive[0] = yAxisPeriodArrayMorningLiveFullDays;         
            jaggedArrayLive[1] = yAxisPeriodArrayMiddayLiveFullDays;
            jaggedArrayLive[2] = yAxisPeriodArrayAfternoonLiveFullDays;

            jaggedArrayWork[0] = yAxisPeriodArrayMorningWorkFullDays;
            jaggedArrayWork[2] = yAxisPeriodArrayAfternoonWorkFullDays;
            jaggedArrayWork[1] = yAxisPeriodArrayMiddayWorkFullDays;
            
            
            
            List<int[][]> listData = new List<int[][]>(5);

            listData.Add(jaggedArrayLive);
            listData.Add(jaggedArrayWork);

            return listData;
        }


        public List<int[][]> GetInsideTransactionFullDaysByPeriodByActivityJArray(List<ByDayByPeriodByActivityDTO> list)
        {
            int[] yAxisPeriodArrayMorningLiveFullDays = new int[7];
            int[] yAxisPeriodArrayAfternoonLiveFullDays = new int[7];
            int[] yAxisPeriodArrayMiddayLiveFullDays = new int[7];

            int[] yAxisPeriodArrayMorningWorkFullDays = new int[7];
            int[] yAxisPeriodArrayAfternoonWorkFullDays = new int[7];
            int[] yAxisPeriodArrayMiddayWorkFullDays = new int[7];

            foreach (var item in list)
            {                
                if (item.Type == "Transaction time 1-5 min")
                {
                    if (item.NamePeriod == "Morning")
                    {
                        if (item.Day == "Monday")
                        {
                            yAxisPeriodArrayMorningLiveFullDays[0] = item.People;
                        }
                        if (item.Day == "Tuesday")
                        {
                            yAxisPeriodArrayMorningLiveFullDays[1] = item.People;
                        }
                        if (item.Day == "Wednesday")
                        {
                            yAxisPeriodArrayMorningLiveFullDays[2] = item.People;
                        }
                        if (item.Day == "Thursday")
                        {
                            yAxisPeriodArrayMorningLiveFullDays[3] = item.People;
                        }
                        if (item.Day == "Friday")
                        {
                            yAxisPeriodArrayMorningLiveFullDays[4] = item.People;
                        }
                        if (item.Day == "Saturday")
                        {
                            yAxisPeriodArrayMorningLiveFullDays[5] = item.People;
                        }
                        if (item.Day == "Sunday")
                        {
                            yAxisPeriodArrayMorningLiveFullDays[6] = item.People;
                        }
                    }
                    if (item.NamePeriod == "Midday")
                    {
                        if (item.Day == "Monday")
                        {
                            yAxisPeriodArrayMiddayLiveFullDays[0] = item.People;
                        }
                        if (item.Day == "Tuesday")
                        {
                            yAxisPeriodArrayMiddayLiveFullDays[1] = item.People;
                        }
                        if (item.Day == "Wednesday")
                        {
                            yAxisPeriodArrayMiddayLiveFullDays[2] = item.People;
                        }
                        if (item.Day == "Thursday")
                        {
                            yAxisPeriodArrayMiddayLiveFullDays[3] = item.People;
                        }
                        if (item.Day == "Friday")
                        {
                            yAxisPeriodArrayMiddayLiveFullDays[4] = item.People;
                        }
                        if (item.Day == "Saturday")
                        {
                            yAxisPeriodArrayMiddayLiveFullDays[5] = item.People;
                        }
                        if (item.Day == "Sunday")
                        {
                            yAxisPeriodArrayMiddayLiveFullDays[6] = item.People;
                        }
                    }
                    if (item.NamePeriod == "Afternoon")
                    {
                        if (item.Day == "Monday")
                        {
                            yAxisPeriodArrayAfternoonLiveFullDays[0] = item.People;
                        }
                        if (item.Day == "Tuesday")
                        {
                            yAxisPeriodArrayAfternoonLiveFullDays[1] = item.People;
                        }
                        if (item.Day == "Wednesday")
                        {
                            yAxisPeriodArrayAfternoonLiveFullDays[2] = item.People;
                        }
                        if (item.Day == "Thursday")
                        {
                            yAxisPeriodArrayAfternoonLiveFullDays[3] = item.People;
                        }
                        if (item.Day == "Friday")
                        {
                            yAxisPeriodArrayAfternoonLiveFullDays[4] = item.People;
                        }
                        if (item.Day == "Saturday")
                        {
                            yAxisPeriodArrayAfternoonLiveFullDays[5] = item.People;
                        }
                        if (item.Day == "Sunday")
                        {
                            yAxisPeriodArrayAfternoonLiveFullDays[6] = item.People;
                        }
                    }                    
                }
                if (item.Type == "Transaction time 5-10 min")
                {
                    if (item.NamePeriod == "Morning")
                    {
                        if (item.Day == "Monday")
                        {
                            yAxisPeriodArrayMorningWorkFullDays[0] = item.People;
                        }
                        if (item.Day == "Tuesday")
                        {
                            yAxisPeriodArrayMorningWorkFullDays[1] = item.People;
                        }
                        if (item.Day == "Wednesday")
                        {
                            yAxisPeriodArrayMorningWorkFullDays[2] = item.People;
                        }
                        if (item.Day == "Thursday")
                        {
                            yAxisPeriodArrayMorningWorkFullDays[3] = item.People;
                        }
                        if (item.Day == "Friday")
                        {
                            yAxisPeriodArrayMorningWorkFullDays[4] = item.People;
                        }
                        if (item.Day == "Saturday")
                        {
                            yAxisPeriodArrayMorningWorkFullDays[5] = item.People;
                        }
                        if (item.Day == "Sunday")
                        {
                            yAxisPeriodArrayMorningWorkFullDays[6] = item.People;
                        }
                    }
                    if (item.NamePeriod == "Midday")
                    {
                        if (item.Day == "Monday")
                        {
                            yAxisPeriodArrayMiddayWorkFullDays[0] = item.People;
                        }
                        if (item.Day == "Tuesday")
                        {
                            yAxisPeriodArrayMiddayWorkFullDays[1] = item.People;
                        }
                        if (item.Day == "Wednesday")
                        {
                            yAxisPeriodArrayMiddayWorkFullDays[2] = item.People;
                        }
                        if (item.Day == "Thursday")
                        {
                            yAxisPeriodArrayMiddayWorkFullDays[3] = item.People;
                        }
                        if (item.Day == "Friday")
                        {
                            yAxisPeriodArrayMiddayWorkFullDays[4] = item.People;
                        }
                        if (item.Day == "Saturday")
                        {
                            yAxisPeriodArrayMiddayWorkFullDays[5] = item.People;
                        }
                        if (item.Day == "Sunday")
                        {
                            yAxisPeriodArrayMiddayWorkFullDays[6] = item.People;
                        }
                    }
                    if (item.NamePeriod == "Afternoon")
                    {
                        if (item.Day == "Monday")
                        {
                            yAxisPeriodArrayAfternoonWorkFullDays[0] = item.People;
                        }
                        if (item.Day == "Tuesday")
                        {
                            yAxisPeriodArrayAfternoonWorkFullDays[1] = item.People;
                        }
                        if (item.Day == "Wednesday")
                        {
                            yAxisPeriodArrayAfternoonWorkFullDays[2] = item.People;
                        }
                        if (item.Day == "Thursday")
                        {
                            yAxisPeriodArrayAfternoonWorkFullDays[3] = item.People;
                        }
                        if (item.Day == "Friday")
                        {
                            yAxisPeriodArrayAfternoonWorkFullDays[4] = item.People;
                        }
                        if (item.Day == "Saturday")
                        {
                            yAxisPeriodArrayAfternoonWorkFullDays[5] = item.People;
                        }
                        if (item.Day == "Sunday")
                        {
                            yAxisPeriodArrayAfternoonWorkFullDays[6] = item.People;
                        }
                    }                    
                }
            }

            int[][] jaggedArrayLive = new int[3][];
            int[][] jaggedArrayWork = new int[3][];

            jaggedArrayLive[0] = yAxisPeriodArrayMorningLiveFullDays;
            jaggedArrayLive[1] = yAxisPeriodArrayMiddayLiveFullDays;
            jaggedArrayLive[2] = yAxisPeriodArrayAfternoonLiveFullDays;
            
            jaggedArrayWork[0] = yAxisPeriodArrayMorningWorkFullDays;
            jaggedArrayWork[1] = yAxisPeriodArrayMiddayWorkFullDays;
            jaggedArrayWork[2] = yAxisPeriodArrayAfternoonWorkFullDays;
                       
            List<int[][]> listData = new List<int[][]>(5);

            listData.Add(jaggedArrayLive);
            listData.Add(jaggedArrayWork);

            return listData;
        }


        public List<int[][]> GetOutsideFullDaysByPeriodByActivityJArray(List<ByDayByPeriodByActivityDTO> list)
        {
            int[] yAxisPeriodArrayMorningLiveFullDays = new int[7];
            int[] yAxisPeriodArrayAfternoonLiveFullDays = new int[7];
            int[] yAxisPeriodArrayEveningLiveFullDays = new int[7];
            int[] yAxisPeriodArrayNightLiveFullDays = new int[7];

            int[] yAxisPeriodArrayMorningWorkFullDays = new int[7];
            int[] yAxisPeriodArrayAfternoonWorkFullDays = new int[7];
            int[] yAxisPeriodArrayEveningWorkFullDays = new int[7];
            int[] yAxisPeriodArrayNightWorkFullDays = new int[7];

            int[] yAxisPeriodArrayMorningCommuteFullDays = new int[7];
            int[] yAxisPeriodArrayAfternoonCommuteFullDays = new int[7];
            int[] yAxisPeriodArrayEveningCommuteFullDays = new int[7];
            int[] yAxisPeriodArrayNightCommuteFullDays = new int[7];

            int[] yAxisPeriodArrayMorningPasserByFullDays = new int[7];
            int[] yAxisPeriodArrayAfternoonPasserByFullDays = new int[7];
            int[] yAxisPeriodArrayEveningPasserByFullDays = new int[7];
            int[] yAxisPeriodArrayNightPasserByFullDays = new int[7];

            int[] yAxisPeriodArrayMorningLeisureFullDays = new int[7];
            int[] yAxisPeriodArrayAfternoonLeisureFullDays = new int[7];
            int[] yAxisPeriodArrayEveningLeisureFullDays = new int[7];
            int[] yAxisPeriodArrayNightLeisureFullDays = new int[7];


            foreach (var item in list)
            {
                if (item.Type == "Live")
                {
                    if (item.NamePeriod == "Morning")
                    {
                        if (item.Day == "Monday")
                        {
                            yAxisPeriodArrayMorningLiveFullDays[0] = item.People;
                        }
                        if (item.Day == "Tuesday")
                        {
                            yAxisPeriodArrayMorningLiveFullDays[1] = item.People;
                        }
                        if (item.Day == "Wednesday")
                        {
                            yAxisPeriodArrayMorningLiveFullDays[2] = item.People;
                        }
                        if (item.Day == "Thursday")
                        {
                            yAxisPeriodArrayMorningLiveFullDays[3] = item.People;
                        }
                        if (item.Day == "Friday")
                        {
                            yAxisPeriodArrayMorningLiveFullDays[4] = item.People;
                        }
                        if (item.Day == "Saturday")
                        {
                            yAxisPeriodArrayMorningLiveFullDays[5] = item.People;
                        }
                        if (item.Day == "Sunday")
                        {
                            yAxisPeriodArrayMorningLiveFullDays[6] = item.People;
                        }
                    }
                    if (item.NamePeriod == "Afternoon")
                    {
                        if (item.Day == "Monday")
                        {
                            yAxisPeriodArrayAfternoonLiveFullDays[0] = item.People;
                        }
                        if (item.Day == "Tuesday")
                        {
                            yAxisPeriodArrayAfternoonLiveFullDays[1] = item.People;
                        }
                        if (item.Day == "Wednesday")
                        {
                            yAxisPeriodArrayAfternoonLiveFullDays[2] = item.People;
                        }
                        if (item.Day == "Thursday")
                        {
                            yAxisPeriodArrayAfternoonLiveFullDays[3] = item.People;
                        }
                        if (item.Day == "Friday")
                        {
                            yAxisPeriodArrayAfternoonLiveFullDays[4] = item.People;
                        }
                        if (item.Day == "Saturday")
                        {
                            yAxisPeriodArrayAfternoonLiveFullDays[5] = item.People;
                        }
                        if (item.Day == "Sunday")
                        {
                            yAxisPeriodArrayAfternoonLiveFullDays[6] = item.People;
                        }
                    }
                    if (item.NamePeriod == "Evening")
                    {
                        if (item.Day == "Monday")
                        {
                            yAxisPeriodArrayEveningLiveFullDays[0] = item.People;
                        }
                        if (item.Day == "Tuesday")
                        {
                            yAxisPeriodArrayEveningLiveFullDays[1] = item.People;
                        }
                        if (item.Day == "Wednesday")
                        {
                            yAxisPeriodArrayEveningLiveFullDays[2] = item.People;
                        }
                        if (item.Day == "Thursday")
                        {
                            yAxisPeriodArrayEveningLiveFullDays[3] = item.People;
                        }
                        if (item.Day == "Friday")
                        {
                            yAxisPeriodArrayEveningLiveFullDays[4] = item.People;
                        }
                        if (item.Day == "Saturday")
                        {
                            yAxisPeriodArrayEveningLiveFullDays[5] = item.People;
                        }
                        if (item.Day == "Sunday")
                        {
                            yAxisPeriodArrayEveningLiveFullDays[6] = item.People;
                        }
                    }
                    if (item.NamePeriod == "Night")
                    {
                        if (item.Day == "Monday")
                        {
                            yAxisPeriodArrayNightLiveFullDays[0] = item.People;
                        }
                        if (item.Day == "Tuesday")
                        {
                            yAxisPeriodArrayNightLiveFullDays[1] = item.People;
                        }
                        if (item.Day == "Wednesday")
                        {
                            yAxisPeriodArrayNightLiveFullDays[2] = item.People;
                        }
                        if (item.Day == "Thursday")
                        {
                            yAxisPeriodArrayNightLiveFullDays[3] = item.People;
                        }
                        if (item.Day == "Friday")
                        {
                            yAxisPeriodArrayNightLiveFullDays[4] = item.People;
                        }
                        if (item.Day == "Saturday")
                        {
                            yAxisPeriodArrayNightLiveFullDays[5] = item.People;
                        }
                        if (item.Day == "Sunday")
                        {
                            yAxisPeriodArrayNightLiveFullDays[6] = item.People;
                        }
                    }
                }
                if (item.Type == "Work")
                {
                    if (item.NamePeriod == "Morning")
                    {
                        if (item.Day == "Monday")
                        {
                            yAxisPeriodArrayMorningWorkFullDays[0] = item.People;
                        }
                        if (item.Day == "Tuesday")
                        {
                            yAxisPeriodArrayMorningWorkFullDays[1] = item.People;
                        }
                        if (item.Day == "Wednesday")
                        {
                            yAxisPeriodArrayMorningWorkFullDays[2] = item.People;
                        }
                        if (item.Day == "Thursday")
                        {
                            yAxisPeriodArrayMorningWorkFullDays[3] = item.People;
                        }
                        if (item.Day == "Friday")
                        {
                            yAxisPeriodArrayMorningWorkFullDays[4] = item.People;
                        }
                        if (item.Day == "Saturday")
                        {
                            yAxisPeriodArrayMorningWorkFullDays[5] = item.People;
                        }
                        if (item.Day == "Sunday")
                        {
                            yAxisPeriodArrayMorningWorkFullDays[6] = item.People;
                        }
                    }
                    if (item.NamePeriod == "Afternoon")
                    {
                        if (item.Day == "Monday")
                        {
                            yAxisPeriodArrayAfternoonWorkFullDays[0] = item.People;
                        }
                        if (item.Day == "Tuesday")
                        {
                            yAxisPeriodArrayAfternoonWorkFullDays[1] = item.People;
                        }
                        if (item.Day == "Wednesday")
                        {
                            yAxisPeriodArrayAfternoonWorkFullDays[2] = item.People;
                        }
                        if (item.Day == "Thursday")
                        {
                            yAxisPeriodArrayAfternoonWorkFullDays[3] = item.People;
                        }
                        if (item.Day == "Friday")
                        {
                            yAxisPeriodArrayAfternoonWorkFullDays[4] = item.People;
                        }
                        if (item.Day == "Saturday")
                        {
                            yAxisPeriodArrayAfternoonWorkFullDays[5] = item.People;
                        }
                        if (item.Day == "Sunday")
                        {
                            yAxisPeriodArrayAfternoonWorkFullDays[6] = item.People;
                        }
                    }
                    if (item.NamePeriod == "Evening")
                    {
                        if (item.Day == "Monday")
                        {
                            yAxisPeriodArrayEveningWorkFullDays[0] = item.People;
                        }
                        if (item.Day == "Tuesday")
                        {
                            yAxisPeriodArrayEveningWorkFullDays[1] = item.People;
                        }
                        if (item.Day == "Wednesday")
                        {
                            yAxisPeriodArrayEveningWorkFullDays[2] = item.People;
                        }
                        if (item.Day == "Thursday")
                        {
                            yAxisPeriodArrayEveningWorkFullDays[3] = item.People;
                        }
                        if (item.Day == "Friday")
                        {
                            yAxisPeriodArrayEveningWorkFullDays[4] = item.People;
                        }
                        if (item.Day == "Saturday")
                        {
                            yAxisPeriodArrayEveningWorkFullDays[5] = item.People;
                        }
                        if (item.Day == "Sunday")
                        {
                            yAxisPeriodArrayEveningWorkFullDays[6] = item.People;
                        }
                    }
                    if (item.NamePeriod == "Night")
                    {
                        if (item.Day == "Monday")
                        {
                            yAxisPeriodArrayNightWorkFullDays[0] = item.People;
                        }
                        if (item.Day == "Tuesday")
                        {
                            yAxisPeriodArrayNightWorkFullDays[1] = item.People;
                        }
                        if (item.Day == "Wednesday")
                        {
                            yAxisPeriodArrayNightWorkFullDays[2] = item.People;
                        }
                        if (item.Day == "Thursday")
                        {
                            yAxisPeriodArrayNightWorkFullDays[3] = item.People;
                        }
                        if (item.Day == "Friday")
                        {
                            yAxisPeriodArrayNightWorkFullDays[4] = item.People;
                        }
                        if (item.Day == "Saturday")
                        {
                            yAxisPeriodArrayNightWorkFullDays[5] = item.People;
                        }
                        if (item.Day == "Sunday")
                        {
                            yAxisPeriodArrayNightWorkFullDays[6] = item.People;
                        }
                    }
                }
                if (item.Type == "Commute")
                {
                    if (item.NamePeriod == "Morning")
                    {
                        if (item.Day == "Monday")
                        {
                            yAxisPeriodArrayMorningCommuteFullDays[0] = item.People;
                        }
                        if (item.Day == "Tuesday")
                        {
                            yAxisPeriodArrayMorningCommuteFullDays[1] = item.People;
                        }
                        if (item.Day == "Wednesday")
                        {
                            yAxisPeriodArrayMorningCommuteFullDays[2] = item.People;
                        }
                        if (item.Day == "Thursday")
                        {
                            yAxisPeriodArrayMorningCommuteFullDays[3] = item.People;
                        }
                        if (item.Day == "Friday")
                        {
                            yAxisPeriodArrayMorningCommuteFullDays[4] = item.People;
                        }
                        if (item.Day == "Saturday")
                        {
                            yAxisPeriodArrayMorningCommuteFullDays[5] = item.People;
                        }
                        if (item.Day == "Sunday")
                        {
                            yAxisPeriodArrayMorningCommuteFullDays[6] = item.People;
                        }
                    }
                    if (item.NamePeriod == "Afternoon")
                    {
                        if (item.Day == "Monday")
                        {
                            yAxisPeriodArrayAfternoonCommuteFullDays[0] = item.People;
                        }
                        if (item.Day == "Tuesday")
                        {
                            yAxisPeriodArrayAfternoonCommuteFullDays[1] = item.People;
                        }
                        if (item.Day == "Wednesday")
                        {
                            yAxisPeriodArrayAfternoonCommuteFullDays[2] = item.People;
                        }
                        if (item.Day == "Thursday")
                        {
                            yAxisPeriodArrayAfternoonCommuteFullDays[3] = item.People;
                        }
                        if (item.Day == "Friday")
                        {
                            yAxisPeriodArrayAfternoonCommuteFullDays[4] = item.People;
                        }
                        if (item.Day == "Saturday")
                        {
                            yAxisPeriodArrayAfternoonCommuteFullDays[5] = item.People;
                        }
                        if (item.Day == "Sunday")
                        {
                            yAxisPeriodArrayAfternoonCommuteFullDays[6] = item.People;
                        }
                    }
                    if (item.NamePeriod == "Evening")
                    {
                        if (item.Day == "Monday")
                        {
                            yAxisPeriodArrayEveningCommuteFullDays[0] = item.People;
                        }
                        if (item.Day == "Tuesday")
                        {
                            yAxisPeriodArrayEveningCommuteFullDays[1] = item.People;
                        }
                        if (item.Day == "Wednesday")
                        {
                            yAxisPeriodArrayEveningCommuteFullDays[2] = item.People;
                        }
                        if (item.Day == "Thursday")
                        {
                            yAxisPeriodArrayEveningCommuteFullDays[3] = item.People;
                        }
                        if (item.Day == "Friday")
                        {
                            yAxisPeriodArrayEveningCommuteFullDays[4] = item.People;
                        }
                        if (item.Day == "Saturday")
                        {
                            yAxisPeriodArrayEveningCommuteFullDays[5] = item.People;
                        }
                        if (item.Day == "Sunday")
                        {
                            yAxisPeriodArrayEveningCommuteFullDays[6] = item.People;
                        }
                    }
                    if (item.NamePeriod == "Night")
                    {
                        if (item.Day == "Monday")
                        {
                            yAxisPeriodArrayNightCommuteFullDays[0] = item.People;
                        }
                        if (item.Day == "Tuesday")
                        {
                            yAxisPeriodArrayNightCommuteFullDays[1] = item.People;
                        }
                        if (item.Day == "Wednesday")
                        {
                            yAxisPeriodArrayNightCommuteFullDays[2] = item.People;
                        }
                        if (item.Day == "Thursday")
                        {
                            yAxisPeriodArrayNightCommuteFullDays[3] = item.People;
                        }
                        if (item.Day == "Friday")
                        {
                            yAxisPeriodArrayNightCommuteFullDays[4] = item.People;
                        }
                        if (item.Day == "Saturday")
                        {
                            yAxisPeriodArrayNightCommuteFullDays[5] = item.People;
                        }
                        if (item.Day == "Sunday")
                        {
                            yAxisPeriodArrayNightCommuteFullDays[6] = item.People;
                        }
                    }
                }
                if (item.Type == "Passer-by")
                {
                    if (item.NamePeriod == "Morning")
                    {
                        if (item.Day == "Monday")
                        {
                            yAxisPeriodArrayMorningPasserByFullDays[0] = item.People;
                        }
                        if (item.Day == "Tuesday")
                        {
                            yAxisPeriodArrayMorningPasserByFullDays[1] = item.People;
                        }
                        if (item.Day == "Wednesday")
                        {
                            yAxisPeriodArrayMorningPasserByFullDays[2] = item.People;
                        }
                        if (item.Day == "Thursday")
                        {
                            yAxisPeriodArrayMorningPasserByFullDays[3] = item.People;
                        }
                        if (item.Day == "Friday")
                        {
                            yAxisPeriodArrayMorningPasserByFullDays[4] = item.People;
                        }
                        if (item.Day == "Saturday")
                        {
                            yAxisPeriodArrayMorningPasserByFullDays[5] = item.People;
                        }
                        if (item.Day == "Sunday")
                        {
                            yAxisPeriodArrayMorningPasserByFullDays[6] = item.People;
                        }
                    }
                    if (item.NamePeriod == "Afternoon")
                    {
                        if (item.Day == "Monday")
                        {
                            yAxisPeriodArrayAfternoonPasserByFullDays[0] = item.People;
                        }
                        if (item.Day == "Tuesday")
                        {
                            yAxisPeriodArrayAfternoonPasserByFullDays[1] = item.People;
                        }
                        if (item.Day == "Wednesday")
                        {
                            yAxisPeriodArrayAfternoonPasserByFullDays[2] = item.People;
                        }
                        if (item.Day == "Thursday")
                        {
                            yAxisPeriodArrayAfternoonPasserByFullDays[3] = item.People;
                        }
                        if (item.Day == "Friday")
                        {
                            yAxisPeriodArrayAfternoonPasserByFullDays[4] = item.People;
                        }
                        if (item.Day == "Saturday")
                        {
                            yAxisPeriodArrayAfternoonPasserByFullDays[5] = item.People;
                        }
                        if (item.Day == "Sunday")
                        {
                            yAxisPeriodArrayAfternoonPasserByFullDays[6] = item.People;
                        }
                    }
                    if (item.NamePeriod == "Evening")
                    {
                        if (item.Day == "Monday")
                        {
                            yAxisPeriodArrayEveningPasserByFullDays[0] = item.People;
                        }
                        if (item.Day == "Tuesday")
                        {
                            yAxisPeriodArrayEveningPasserByFullDays[1] = item.People;
                        }
                        if (item.Day == "Wednesday")
                        {
                            yAxisPeriodArrayEveningPasserByFullDays[2] = item.People;
                        }
                        if (item.Day == "Thursday")
                        {
                            yAxisPeriodArrayEveningPasserByFullDays[3] = item.People;
                        }
                        if (item.Day == "Friday")
                        {
                            yAxisPeriodArrayEveningPasserByFullDays[4] = item.People;
                        }
                        if (item.Day == "Saturday")
                        {
                            yAxisPeriodArrayEveningPasserByFullDays[5] = item.People;
                        }
                        if (item.Day == "Sunday")
                        {
                            yAxisPeriodArrayEveningPasserByFullDays[6] = item.People;
                        }
                    }
                    if (item.NamePeriod == "Night")
                    {
                        if (item.Day == "Monday")
                        {
                            yAxisPeriodArrayNightPasserByFullDays[0] = item.People;
                        }
                        if (item.Day == "Tuesday")
                        {
                            yAxisPeriodArrayNightPasserByFullDays[1] = item.People;
                        }
                        if (item.Day == "Wednesday")
                        {
                            yAxisPeriodArrayNightPasserByFullDays[2] = item.People;
                        }
                        if (item.Day == "Thursday")
                        {
                            yAxisPeriodArrayNightPasserByFullDays[3] = item.People;
                        }
                        if (item.Day == "Friday")
                        {
                            yAxisPeriodArrayNightPasserByFullDays[4] = item.People;
                        }
                        if (item.Day == "Saturday")
                        {
                            yAxisPeriodArrayNightPasserByFullDays[5] = item.People;
                        }
                        if (item.Day == "Sunday")
                        {
                            yAxisPeriodArrayNightPasserByFullDays[6] = item.People;
                        }
                    }
                }
                if (item.Type == "Leisure/Fun")
                {
                    if (item.NamePeriod == "Morning")
                    {
                        if (item.Day == "Monday")
                        {
                            yAxisPeriodArrayMorningLeisureFullDays[0] = item.People;
                        }
                        if (item.Day == "Tuesday")
                        {
                            yAxisPeriodArrayMorningLeisureFullDays[1] = item.People;
                        }
                        if (item.Day == "Wednesday")
                        {
                            yAxisPeriodArrayMorningLeisureFullDays[2] = item.People;
                        }
                        if (item.Day == "Thursday")
                        {
                            yAxisPeriodArrayMorningLeisureFullDays[3] = item.People;
                        }
                        if (item.Day == "Friday")
                        {
                            yAxisPeriodArrayMorningLeisureFullDays[4] = item.People;
                        }
                        if (item.Day == "Saturday")
                        {
                            yAxisPeriodArrayMorningLeisureFullDays[5] = item.People;
                        }
                        if (item.Day == "Sunday")
                        {
                            yAxisPeriodArrayMorningLeisureFullDays[6] = item.People;
                        }
                    }
                    if (item.NamePeriod == "Afternoon")
                    {
                        if (item.Day == "Monday")
                        {
                            yAxisPeriodArrayAfternoonLeisureFullDays[0] = item.People;
                        }
                        if (item.Day == "Tuesday")
                        {
                            yAxisPeriodArrayAfternoonLeisureFullDays[1] = item.People;
                        }
                        if (item.Day == "Wednesday")
                        {
                            yAxisPeriodArrayAfternoonLeisureFullDays[2] = item.People;
                        }
                        if (item.Day == "Thursday")
                        {
                            yAxisPeriodArrayAfternoonLeisureFullDays[3] = item.People;
                        }
                        if (item.Day == "Friday")
                        {
                            yAxisPeriodArrayAfternoonLeisureFullDays[4] = item.People;
                        }
                        if (item.Day == "Saturday")
                        {
                            yAxisPeriodArrayAfternoonLeisureFullDays[5] = item.People;
                        }
                        if (item.Day == "Sunday")
                        {
                            yAxisPeriodArrayAfternoonLeisureFullDays[6] = item.People;
                        }
                    }
                    if (item.NamePeriod == "Evening")
                    {
                        if (item.Day == "Monday")
                        {
                            yAxisPeriodArrayEveningLeisureFullDays[0] = item.People;
                        }
                        if (item.Day == "Tuesday")
                        {
                            yAxisPeriodArrayEveningLeisureFullDays[1] = item.People;
                        }
                        if (item.Day == "Wednesday")
                        {
                            yAxisPeriodArrayEveningLeisureFullDays[2] = item.People;
                        }
                        if (item.Day == "Thursday")
                        {
                            yAxisPeriodArrayEveningLeisureFullDays[3] = item.People;
                        }
                        if (item.Day == "Friday")
                        {
                            yAxisPeriodArrayEveningLeisureFullDays[4] = item.People;
                        }
                        if (item.Day == "Saturday")
                        {
                            yAxisPeriodArrayEveningLeisureFullDays[5] = item.People;
                        }
                        if (item.Day == "Sunday")
                        {
                            yAxisPeriodArrayEveningLeisureFullDays[6] = item.People;
                        }
                    }
                    if (item.NamePeriod == "Night")
                    {
                        if (item.Day == "Monday")
                        {
                            yAxisPeriodArrayNightLeisureFullDays[0] = item.People;
                        }
                        if (item.Day == "Tuesday")
                        {
                            yAxisPeriodArrayNightLeisureFullDays[1] = item.People;
                        }
                        if (item.Day == "Wednesday")
                        {
                            yAxisPeriodArrayNightLeisureFullDays[2] = item.People;
                        }
                        if (item.Day == "Thursday")
                        {
                            yAxisPeriodArrayNightLeisureFullDays[3] = item.People;
                        }
                        if (item.Day == "Friday")
                        {
                            yAxisPeriodArrayNightLeisureFullDays[4] = item.People;
                        }
                        if (item.Day == "Saturday")
                        {
                            yAxisPeriodArrayNightLeisureFullDays[5] = item.People;
                        }
                        if (item.Day == "Sunday")
                        {
                            yAxisPeriodArrayNightLeisureFullDays[6] = item.People;
                        }
                    }
                }
            }

            int[][] jaggedArrayLive = new int[4][];
            int[][] jaggedArrayWork = new int[4][];
            int[][] jaggedArrayCommute = new int[4][];
            int[][] jaggedArrayPasserBy = new int[4][];
            int[][] jaggedArrayLeisure = new int[4][];

            jaggedArrayLive[0] = yAxisPeriodArrayMorningLiveFullDays;
            jaggedArrayLive[1] = yAxisPeriodArrayAfternoonLiveFullDays;
            jaggedArrayLive[2] = yAxisPeriodArrayEveningLiveFullDays;
            jaggedArrayLive[3] = yAxisPeriodArrayNightLiveFullDays;

            jaggedArrayWork[0] = yAxisPeriodArrayMorningWorkFullDays;
            jaggedArrayWork[1] = yAxisPeriodArrayAfternoonWorkFullDays;
            jaggedArrayWork[2] = yAxisPeriodArrayEveningWorkFullDays;
            jaggedArrayWork[3] = yAxisPeriodArrayNightWorkFullDays;

            jaggedArrayCommute[0] = yAxisPeriodArrayMorningCommuteFullDays;
            jaggedArrayCommute[1] = yAxisPeriodArrayAfternoonCommuteFullDays;
            jaggedArrayCommute[2] = yAxisPeriodArrayEveningCommuteFullDays;
            jaggedArrayCommute[3] = yAxisPeriodArrayNightCommuteFullDays;

            jaggedArrayPasserBy[0] = yAxisPeriodArrayMorningPasserByFullDays;
            jaggedArrayPasserBy[1] = yAxisPeriodArrayAfternoonPasserByFullDays;
            jaggedArrayPasserBy[2] = yAxisPeriodArrayEveningPasserByFullDays;
            jaggedArrayPasserBy[3] = yAxisPeriodArrayNightPasserByFullDays;

            jaggedArrayLeisure[0] = yAxisPeriodArrayMorningLeisureFullDays;
            jaggedArrayLeisure[1] = yAxisPeriodArrayAfternoonLeisureFullDays;
            jaggedArrayLeisure[2] = yAxisPeriodArrayEveningLeisureFullDays;
            jaggedArrayLeisure[3] = yAxisPeriodArrayNightLeisureFullDays;


            List<int[][]> listData = new List<int[][]>(5);

            listData.Add(jaggedArrayLive);
            listData.Add(jaggedArrayWork);
            listData.Add(jaggedArrayCommute);
            listData.Add(jaggedArrayPasserBy);
            listData.Add(jaggedArrayLeisure);

            return listData;
        }


        public List<int[][]> GetInsideCustomerWeekDaysByPeriodByActivityJArray(List<ByDayByPeriodByActivityDTO> list)
        {
            int[] yAxisPeriodArrayMorningLive = new int[5];
            int[] yAxisPeriodArrayMiddayLive = new int[5];
            int[] yAxisPeriodArrayAfternoonLive = new int[5];                       

            int[] yAxisPeriodArrayMorningWork = new int[5];
            int[] yAxisPeriodArrayMiddayWork = new int[5];
            int[] yAxisPeriodArrayAfternoonWork = new int[5];         
                       

            foreach (var item in list)
            {
                if (item.Type == "Take_away Customers")
                {
                    if (item.NamePeriod == "Morning")
                    {
                        if (item.IdDay == 1)
                        {
                            yAxisPeriodArrayMorningLive[0] = item.People;
                        }
                        if (item.IdDay == 2)
                        {
                            yAxisPeriodArrayMorningLive[1] = item.People;
                        }
                        if (item.IdDay == 3)
                        {
                            yAxisPeriodArrayMorningLive[2] = item.People;
                        }
                        if (item.IdDay == 4)
                        {
                            yAxisPeriodArrayMorningLive[3] = item.People;
                        }
                        if (item.IdDay == 5)
                        {
                            yAxisPeriodArrayMorningLive[4] = item.People;
                        }
                    }
                    if (item.NamePeriod == "Midday")
                    {
                        if (item.IdDay == 1)
                        {
                            yAxisPeriodArrayMiddayLive[0] = item.People;
                        }
                        if (item.IdDay == 2)
                        {
                            yAxisPeriodArrayMiddayLive[1] = item.People;
                        }
                        if (item.IdDay == 3)
                        {
                            yAxisPeriodArrayMiddayLive[2] = item.People;
                        }
                        if (item.IdDay == 4)
                        {
                            yAxisPeriodArrayMiddayLive[3] = item.People;
                        }
                        if (item.IdDay == 5)
                        {
                            yAxisPeriodArrayMiddayLive[4] = item.People;
                        }
                    }
                    if (item.NamePeriod == "Afternoon")
                    {
                        if (item.IdDay == 1)
                        {
                            yAxisPeriodArrayAfternoonLive[0] = item.People;
                        }
                        if (item.IdDay == 2)
                        {
                            yAxisPeriodArrayAfternoonLive[1] = item.People;
                        }
                        if (item.IdDay == 3)
                        {
                            yAxisPeriodArrayAfternoonLive[2] = item.People;
                        }
                        if (item.IdDay == 4)
                        {
                            yAxisPeriodArrayAfternoonLive[3] = item.People;
                        }
                        if (item.IdDay == 5)
                        {
                            yAxisPeriodArrayAfternoonLive[4] = item.People;
                        }
                    }
                }
                if (item.Type == "Sit-down Customers")
                {
                    if (item.NamePeriod == "Morning")
                    {
                        if (item.IdDay == 1)
                        {
                            yAxisPeriodArrayMorningWork[0] = item.People;
                        }
                        if (item.IdDay == 2)
                        {
                            yAxisPeriodArrayMorningWork[1] = item.People;
                        }
                        if (item.IdDay == 3)
                        {
                            yAxisPeriodArrayMorningWork[2] = item.People;
                        }
                        if (item.IdDay == 4)
                        {
                            yAxisPeriodArrayMorningWork[3] = item.People;
                        }
                        if (item.IdDay == 5)
                        {
                            yAxisPeriodArrayMorningWork[4] = item.People;
                        }
                    }
                    if (item.NamePeriod == "Midday")
                    {
                        if (item.IdDay == 1)
                        {
                            yAxisPeriodArrayMiddayWork[0] = item.People;
                        }
                        if (item.IdDay == 2)
                        {
                            yAxisPeriodArrayMiddayWork[1] = item.People;
                        }
                        if (item.IdDay == 3)
                        {
                            yAxisPeriodArrayMiddayWork[2] = item.People;
                        }
                        if (item.IdDay == 4)
                        {
                            yAxisPeriodArrayMiddayWork[3] = item.People;
                        }
                        if (item.IdDay == 5)
                        {
                            yAxisPeriodArrayMiddayWork[4] = item.People;
                        }
                    }
                    if (item.NamePeriod == "Afternoon")
                    {
                        if (item.IdDay == 1)
                        {
                            yAxisPeriodArrayAfternoonWork[0] = item.People;
                        }
                        if (item.IdDay == 2)
                        {
                            yAxisPeriodArrayAfternoonWork[1] = item.People;
                        }
                        if (item.IdDay == 3)
                        {
                            yAxisPeriodArrayAfternoonWork[2] = item.People;
                        }
                        if (item.IdDay == 4)
                        {
                            yAxisPeriodArrayAfternoonWork[3] = item.People;
                        }
                        if (item.IdDay == 5)
                        {
                            yAxisPeriodArrayAfternoonWork[4] = item.People;
                        }
                    }                    
                }                
            }

            int[][] jaggedArrayLive = new int[3][];
            int[][] jaggedArrayWork = new int[3][];

            jaggedArrayLive[0] = yAxisPeriodArrayMorningLive;
            jaggedArrayLive[1] = yAxisPeriodArrayMiddayLive;
            jaggedArrayLive[2] = yAxisPeriodArrayAfternoonLive;
            
            
            jaggedArrayWork[0] = yAxisPeriodArrayMorningWork;
            jaggedArrayWork[1] = yAxisPeriodArrayMiddayWork;
            jaggedArrayWork[2] = yAxisPeriodArrayAfternoonWork;

            List<int[][]> listData = new List<int[][]>(5);

            listData.Add(jaggedArrayLive);
            listData.Add(jaggedArrayWork);

            return listData;
        }


        public List<int[][]> GetInsideTransactionWeekDaysByPeriodByActivityJArray(List<ByDayByPeriodByActivityDTO> list)
        {
            int[] yAxisPeriodArrayMorningLive = new int[5];
            int[] yAxisPeriodArrayMiddayLive = new int[5];
            int[] yAxisPeriodArrayAfternoonLive = new int[5];
            
            int[] yAxisPeriodArrayMorningWork = new int[5];
            int[] yAxisPeriodArrayMiddayWork = new int[5];
            int[] yAxisPeriodArrayAfternoonWork = new int[5];            

            int[][] jaggedArrayLive = new int[3][];
            int[][] jaggedArrayWork = new int[3][];
            

            foreach (var item in list)
            {
                if (item.Type == "Transaction time 1-5 min")
                {
                    if (item.NamePeriod == "Morning")
                    {
                        if (item.IdDay == 1)
                        {
                            yAxisPeriodArrayMorningLive[0] = item.People;
                        }
                        if (item.IdDay == 2)
                        {
                            yAxisPeriodArrayMorningLive[1] = item.People;
                        }
                        if (item.IdDay == 3)
                        {
                            yAxisPeriodArrayMorningLive[2] = item.People;
                        }
                        if (item.IdDay == 4)
                        {
                            yAxisPeriodArrayMorningLive[3] = item.People;
                        }
                        if (item.IdDay == 5)
                        {
                            yAxisPeriodArrayMorningLive[4] = item.People;
                        }
                    }
                    if (item.NamePeriod == "Midday")
                    {
                        if (item.IdDay == 1)
                        {
                            yAxisPeriodArrayMiddayLive[0] = item.People;
                        }
                        if (item.IdDay == 2)
                        {
                            yAxisPeriodArrayMiddayLive[1] = item.People;
                        }
                        if (item.IdDay == 3)
                        {
                            yAxisPeriodArrayMiddayLive[2] = item.People;
                        }
                        if (item.IdDay == 4)
                        {
                            yAxisPeriodArrayMiddayLive[3] = item.People;
                        }
                        if (item.IdDay == 5)
                        {
                            yAxisPeriodArrayMiddayLive[4] = item.People;
                        }
                    }
                    if (item.NamePeriod == "Afternoon")
                    {
                        if (item.IdDay == 1)
                        {
                            yAxisPeriodArrayAfternoonLive[0] = item.People;
                        }
                        if (item.IdDay == 2)
                        {
                            yAxisPeriodArrayAfternoonLive[1] = item.People;
                        }
                        if (item.IdDay == 3)
                        {
                            yAxisPeriodArrayAfternoonLive[2] = item.People;
                        }
                        if (item.IdDay == 4)
                        {
                            yAxisPeriodArrayAfternoonLive[3] = item.People;
                        }
                        if (item.IdDay == 5)
                        {
                            yAxisPeriodArrayAfternoonLive[4] = item.People;
                        }
                    }
                }
                if (item.Type == "Transaction time 5-10 min")
                {
                    if (item.NamePeriod == "Morning")
                    {
                        if (item.IdDay == 1)
                        {
                            yAxisPeriodArrayMorningWork[0] = item.People;
                        }
                        if (item.IdDay == 2)
                        {
                            yAxisPeriodArrayMorningWork[1] = item.People;
                        }
                        if (item.IdDay == 3)
                        {
                            yAxisPeriodArrayMorningWork[2] = item.People;
                        }
                        if (item.IdDay == 4)
                        {
                            yAxisPeriodArrayMorningWork[3] = item.People;
                        }
                        if (item.IdDay == 5)
                        {
                            yAxisPeriodArrayMorningWork[4] = item.People;
                        }
                    }
                    if (item.NamePeriod == "Midday")
                    {
                        if (item.IdDay == 1)
                        {
                            yAxisPeriodArrayMiddayWork[0] = item.People;
                        }
                        if (item.IdDay == 2)
                        {
                            yAxisPeriodArrayMiddayWork[1] = item.People;
                        }
                        if (item.IdDay == 3)
                        {
                            yAxisPeriodArrayMiddayWork[2] = item.People;
                        }
                        if (item.IdDay == 4)
                        {
                            yAxisPeriodArrayMiddayWork[3] = item.People;
                        }
                        if (item.IdDay == 5)
                        {
                            yAxisPeriodArrayMiddayWork[4] = item.People;
                        }
                    }
                    if (item.NamePeriod == "Afternoon")
                    {
                        if (item.IdDay == 1)
                        {
                            yAxisPeriodArrayAfternoonWork[0] = item.People;
                        }
                        if (item.IdDay == 2)
                        {
                            yAxisPeriodArrayAfternoonWork[1] = item.People;
                        }
                        if (item.IdDay == 3)
                        {
                            yAxisPeriodArrayAfternoonWork[2] = item.People;
                        }
                        if (item.IdDay == 4)
                        {
                            yAxisPeriodArrayAfternoonWork[3] = item.People;
                        }
                        if (item.IdDay == 5)
                        {
                            yAxisPeriodArrayAfternoonWork[4] = item.People;
                        }
                    }
                }                
            }

            jaggedArrayLive[0] = yAxisPeriodArrayMorningLive;            
            jaggedArrayLive[1] = yAxisPeriodArrayMiddayLive;
            jaggedArrayLive[2] = yAxisPeriodArrayAfternoonLive;

            jaggedArrayWork[0] = yAxisPeriodArrayMorningWork;
            jaggedArrayWork[1] = yAxisPeriodArrayMiddayWork;
            jaggedArrayWork[2] = yAxisPeriodArrayAfternoonWork;
                       
            
            List<int[][]> listData = new List<int[][]>(5);

            listData.Add(jaggedArrayLive);
            listData.Add(jaggedArrayWork);

            return listData;
        }


        public List<int[][]> GetOutsideWeekDaysByPeriodByActivityJArray(List<ByDayByPeriodByActivityDTO> list)
        {
            int[] yAxisPeriodArrayMorningLive = new int[5];
            int[] yAxisPeriodArrayAfternoonLive = new int[5];
            int[] yAxisPeriodArrayEveningLive = new int[5];
            int[] yAxisPeriodArrayNightLive = new int[5];

            int[] yAxisPeriodArrayMorningWork = new int[5];
            int[] yAxisPeriodArrayAfternoonWork = new int[5];
            int[] yAxisPeriodArrayEveningWork = new int[5];
            int[] yAxisPeriodArrayNightWork = new int[5];

            int[] yAxisPeriodArrayMorningCommute = new int[5];
            int[] yAxisPeriodArrayAfternoonCommute = new int[5];
            int[] yAxisPeriodArrayEveningCommute = new int[5];
            int[] yAxisPeriodArrayNightCommute = new int[5];

            int[] yAxisPeriodArrayMorningPasserBy = new int[5];
            int[] yAxisPeriodArrayAfternoonPasserBy = new int[5];
            int[] yAxisPeriodArrayEveningPasserBy = new int[5];
            int[] yAxisPeriodArrayNightPasserBy = new int[5];

            int[] yAxisPeriodArrayMorningLeisure = new int[5];
            int[] yAxisPeriodArrayAfternoonLeisure = new int[5];
            int[] yAxisPeriodArrayEveningLeisure = new int[5];
            int[] yAxisPeriodArrayNightLeisure = new int[5];

            int[][] jaggedArrayLive = new int[4][];
            int[][] jaggedArrayWork = new int[4][];
            int[][] jaggedArrayCommute = new int[4][];
            int[][] jaggedArrayPasserBy = new int[4][];
            int[][] jaggedArrayLeisure = new int[4][];

            foreach (var item in list)
            {
                if (item.Type == "Live")
                {
                    if (item.NamePeriod == "Morning")
                    {
                        if (item.IdDay == 1)
                        {
                            yAxisPeriodArrayMorningLive[0] = item.People;
                        }
                        if (item.IdDay == 2)
                        {
                            yAxisPeriodArrayMorningLive[1] = item.People;
                        }
                        if (item.IdDay == 3)
                        {
                            yAxisPeriodArrayMorningLive[2] = item.People;
                        }
                        if (item.IdDay == 4)
                        {
                            yAxisPeriodArrayMorningLive[3] = item.People;
                        }
                        if (item.IdDay == 5)
                        {
                            yAxisPeriodArrayMorningLive[4] = item.People;
                        }
                    }
                    if (item.NamePeriod == "Afternoon")
                    {
                        if (item.IdDay == 1)
                        {
                            yAxisPeriodArrayAfternoonLive[0] = item.People;
                        }
                        if (item.IdDay == 2)
                        {
                            yAxisPeriodArrayAfternoonLive[1] = item.People;
                        }
                        if (item.IdDay == 3)
                        {
                            yAxisPeriodArrayAfternoonLive[2] = item.People;
                        }
                        if (item.IdDay == 4)
                        {
                            yAxisPeriodArrayAfternoonLive[3] = item.People;
                        }
                        if (item.IdDay == 5)
                        {
                            yAxisPeriodArrayAfternoonLive[4] = item.People;
                        }
                    }
                    if (item.NamePeriod == "Evening")
                    {
                        if (item.IdDay == 1)
                        {
                            yAxisPeriodArrayEveningLive[0] = item.People;
                        }
                        if (item.IdDay == 2)
                        {
                            yAxisPeriodArrayEveningLive[1] = item.People;
                        }
                        if (item.IdDay == 3)
                        {
                            yAxisPeriodArrayEveningLive[2] = item.People;
                        }
                        if (item.IdDay == 4)
                        {
                            yAxisPeriodArrayEveningLive[3] = item.People;
                        }
                        if (item.IdDay == 5)
                        {
                            yAxisPeriodArrayEveningLive[4] = item.People;
                        }
                    }
                    if (item.NamePeriod == "Night")
                    {
                        if (item.IdDay == 1)
                        {
                            yAxisPeriodArrayNightLive[0] = item.People;
                        }
                        if (item.IdDay == 2)
                        {
                            yAxisPeriodArrayNightLive[1] = item.People;
                        }
                        if (item.IdDay == 3)
                        {
                            yAxisPeriodArrayNightLive[2] = item.People;
                        }
                        if (item.IdDay == 4)
                        {
                            yAxisPeriodArrayNightLive[3] = item.People;
                        }
                        if (item.IdDay == 5)
                        {
                            yAxisPeriodArrayNightLive[4] = item.People;
                        }
                    }
                }
                if (item.Type == "Work")
                {
                    if (item.NamePeriod == "Morning")
                    {
                        if (item.IdDay == 1)
                        {
                            yAxisPeriodArrayMorningWork[0] = item.People;
                        }
                        if (item.IdDay == 2)
                        {
                            yAxisPeriodArrayMorningWork[1] = item.People;
                        }
                        if (item.IdDay == 3)
                        {
                            yAxisPeriodArrayMorningWork[2] = item.People;
                        }
                        if (item.IdDay == 4)
                        {
                            yAxisPeriodArrayMorningWork[3] = item.People;
                        }
                        if (item.IdDay == 5)
                        {
                            yAxisPeriodArrayMorningWork[4] = item.People;
                        }
                    }
                    if (item.NamePeriod == "Afternoon")
                    {
                        if (item.IdDay == 1)
                        {
                            yAxisPeriodArrayAfternoonWork[0] = item.People;
                        }
                        if (item.IdDay == 2)
                        {
                            yAxisPeriodArrayAfternoonWork[1] = item.People;
                        }
                        if (item.IdDay == 3)
                        {
                            yAxisPeriodArrayAfternoonWork[2] = item.People;
                        }
                        if (item.IdDay == 4)
                        {
                            yAxisPeriodArrayAfternoonWork[3] = item.People;
                        }
                        if (item.IdDay == 5)
                        {
                            yAxisPeriodArrayAfternoonWork[4] = item.People;
                        }
                    }
                    if (item.NamePeriod == "Evening")
                    {
                        if (item.IdDay == 1)
                        {
                            yAxisPeriodArrayEveningWork[0] = item.People;
                        }
                        if (item.IdDay == 2)
                        {
                            yAxisPeriodArrayEveningWork[1] = item.People;
                        }
                        if (item.IdDay == 3)
                        {
                            yAxisPeriodArrayEveningWork[2] = item.People;
                        }
                        if (item.IdDay == 4)
                        {
                            yAxisPeriodArrayEveningWork[3] = item.People;
                        }
                        if (item.IdDay == 5)
                        {
                            yAxisPeriodArrayEveningWork[4] = item.People;
                        }
                    }
                    if (item.NamePeriod == "Night")
                    {
                        if (item.IdDay == 1)
                        {
                            yAxisPeriodArrayNightWork[0] = item.People;
                        }
                        if (item.IdDay == 2)
                        {
                            yAxisPeriodArrayNightWork[1] = item.People;
                        }
                        if (item.IdDay == 3)
                        {
                            yAxisPeriodArrayNightWork[2] = item.People;
                        }
                        if (item.IdDay == 4)
                        {
                            yAxisPeriodArrayNightWork[3] = item.People;
                        }
                        if (item.IdDay == 5)
                        {
                            yAxisPeriodArrayNightWork[4] = item.People;
                        }
                    }
                }
                if (item.Type == "Commute")
                {
                    if (item.NamePeriod == "Morning")
                    {
                        if (item.IdDay == 1)
                        {
                            yAxisPeriodArrayMorningCommute[0] = item.People;
                        }
                        if (item.IdDay == 2)
                        {
                            yAxisPeriodArrayMorningCommute[1] = item.People;
                        }
                        if (item.IdDay == 3)
                        {
                            yAxisPeriodArrayMorningCommute[2] = item.People;
                        }
                        if (item.IdDay == 4)
                        {
                            yAxisPeriodArrayMorningCommute[3] = item.People;
                        }
                        if (item.IdDay == 5)
                        {
                            yAxisPeriodArrayMorningCommute[4] = item.People;
                        }
                    }
                    if (item.NamePeriod == "Afternoon")
                    {
                        if (item.IdDay == 1)
                        {
                            yAxisPeriodArrayAfternoonCommute[0] = item.People;
                        }
                        if (item.IdDay == 2)
                        {
                            yAxisPeriodArrayAfternoonCommute[1] = item.People;
                        }
                        if (item.IdDay == 3)
                        {
                            yAxisPeriodArrayAfternoonCommute[2] = item.People;
                        }
                        if (item.IdDay == 4)
                        {
                            yAxisPeriodArrayAfternoonCommute[3] = item.People;
                        }
                        if (item.IdDay == 5)
                        {
                            yAxisPeriodArrayAfternoonCommute[4] = item.People;
                        }
                    }
                    if (item.NamePeriod == "Evening")
                    {
                        if (item.IdDay == 1)
                        {
                            yAxisPeriodArrayEveningCommute[0] = item.People;
                        }
                        if (item.IdDay == 2)
                        {
                            yAxisPeriodArrayEveningCommute[1] = item.People;
                        }
                        if (item.IdDay == 3)
                        {
                            yAxisPeriodArrayEveningCommute[2] = item.People;
                        }
                        if (item.IdDay == 4)
                        {
                            yAxisPeriodArrayEveningCommute[3] = item.People;
                        }
                        if (item.IdDay == 5)
                        {
                            yAxisPeriodArrayEveningCommute[4] = item.People;
                        }
                    }
                    if (item.NamePeriod == "Night")
                    {
                        if (item.IdDay == 1)
                        {
                            yAxisPeriodArrayNightCommute[0] = item.People;
                        }
                        if (item.IdDay == 2)
                        {
                            yAxisPeriodArrayNightCommute[1] = item.People;
                        }
                        if (item.IdDay == 3)
                        {
                            yAxisPeriodArrayNightCommute[2] = item.People;
                        }
                        if (item.IdDay == 4)
                        {
                            yAxisPeriodArrayNightCommute[3] = item.People;
                        }
                        if (item.IdDay == 5)
                        {
                            yAxisPeriodArrayNightCommute[4] = item.People;
                        }
                    }
                }
                if (item.Type == "Passer-by")
                {
                    if (item.NamePeriod == "Morning")
                    {
                        if (item.IdDay == 1)
                        {
                            yAxisPeriodArrayMorningPasserBy[0] = item.People;
                        }
                        if (item.IdDay == 2)
                        {
                            yAxisPeriodArrayMorningPasserBy[1] = item.People;
                        }
                        if (item.IdDay == 3)
                        {
                            yAxisPeriodArrayMorningPasserBy[2] = item.People;
                        }
                        if (item.IdDay == 4)
                        {
                            yAxisPeriodArrayMorningPasserBy[3] = item.People;
                        }
                        if (item.IdDay == 5)
                        {
                            yAxisPeriodArrayMorningPasserBy[4] = item.People;
                        }
                    }
                    if (item.NamePeriod == "Afternoon")
                    {
                        if (item.IdDay == 1)
                        {
                            yAxisPeriodArrayAfternoonPasserBy[0] = item.People;
                        }
                        if (item.IdDay == 2)
                        {
                            yAxisPeriodArrayAfternoonPasserBy[1] = item.People;
                        }
                        if (item.IdDay == 3)
                        {
                            yAxisPeriodArrayAfternoonPasserBy[2] = item.People;
                        }
                        if (item.IdDay == 4)
                        {
                            yAxisPeriodArrayAfternoonPasserBy[3] = item.People;
                        }
                        if (item.IdDay == 5)
                        {
                            yAxisPeriodArrayAfternoonPasserBy[4] = item.People;
                        }
                    }
                    if (item.NamePeriod == "Evening")
                    {
                        if (item.IdDay == 1)
                        {
                            yAxisPeriodArrayEveningPasserBy[0] = item.People;
                        }
                        if (item.IdDay == 2)
                        {
                            yAxisPeriodArrayEveningPasserBy[1] = item.People;
                        }
                        if (item.IdDay == 3)
                        {
                            yAxisPeriodArrayEveningPasserBy[2] = item.People;
                        }
                        if (item.IdDay == 4)
                        {
                            yAxisPeriodArrayEveningPasserBy[3] = item.People;
                        }
                        if (item.IdDay == 5)
                        {
                            yAxisPeriodArrayEveningPasserBy[4] = item.People;
                        }
                    }
                    if (item.NamePeriod == "Night")
                    {
                        if (item.IdDay == 1)
                        {
                            yAxisPeriodArrayNightPasserBy[0] = item.People;
                        }
                        if (item.IdDay == 2)
                        {
                            yAxisPeriodArrayNightPasserBy[1] = item.People;
                        }
                        if (item.IdDay == 3)
                        {
                            yAxisPeriodArrayNightPasserBy[2] = item.People;
                        }
                        if (item.IdDay == 4)
                        {
                            yAxisPeriodArrayNightPasserBy[3] = item.People;
                        }
                        if (item.IdDay == 5)
                        {
                            yAxisPeriodArrayNightPasserBy[4] = item.People;
                        }
                    }
                }
                if (item.Type == "Leisure/Fun")
                {
                    if (item.NamePeriod == "Morning")
                    {
                        if (item.IdDay == 1)
                        {
                            yAxisPeriodArrayMorningLeisure[0] = item.People;
                        }
                        if (item.IdDay == 2)
                        {
                            yAxisPeriodArrayMorningLeisure[1] = item.People;
                        }
                        if (item.IdDay == 3)
                        {
                            yAxisPeriodArrayMorningLeisure[2] = item.People;
                        }
                        if (item.IdDay == 4)
                        {
                            yAxisPeriodArrayMorningLeisure[3] = item.People;
                        }
                        if (item.IdDay == 5)
                        {
                            yAxisPeriodArrayMorningLeisure[4] = item.People;
                        }
                    }
                    if (item.NamePeriod == "Afternoon")
                    {
                        if (item.IdDay == 1)
                        {
                            yAxisPeriodArrayAfternoonLeisure[0] = item.People;
                        }
                        if (item.IdDay == 2)
                        {
                            yAxisPeriodArrayAfternoonLeisure[1] = item.People;
                        }
                        if (item.IdDay == 3)
                        {
                            yAxisPeriodArrayAfternoonLeisure[2] = item.People;
                        }
                        if (item.IdDay == 4)
                        {
                            yAxisPeriodArrayAfternoonLeisure[3] = item.People;
                        }
                        if (item.IdDay == 5)
                        {
                            yAxisPeriodArrayAfternoonLeisure[4] = item.People;
                        }
                    }
                    if (item.NamePeriod == "Evening")
                    {
                        if (item.IdDay == 1)
                        {
                            yAxisPeriodArrayEveningLeisure[0] = item.People;
                        }
                        if (item.IdDay == 2)
                        {
                            yAxisPeriodArrayEveningLeisure[1] = item.People;
                        }
                        if (item.IdDay == 3)
                        {
                            yAxisPeriodArrayEveningLeisure[2] = item.People;
                        }
                        if (item.IdDay == 4)
                        {
                            yAxisPeriodArrayEveningLeisure[3] = item.People;
                        }
                        if (item.IdDay == 5)
                        {
                            yAxisPeriodArrayEveningLeisure[4] = item.People;
                        }
                    }
                    if (item.NamePeriod == "Night")
                    {
                        if (item.IdDay == 1)
                        {
                            yAxisPeriodArrayNightLeisure[0] = item.People;
                        }
                        if (item.IdDay == 2)
                        {
                            yAxisPeriodArrayNightLeisure[1] = item.People;
                        }
                        if (item.IdDay == 3)
                        {
                            yAxisPeriodArrayNightLeisure[2] = item.People;
                        }
                        if (item.IdDay == 4)
                        {
                            yAxisPeriodArrayNightLeisure[3] = item.People;
                        }
                        if (item.IdDay == 5)
                        {
                            yAxisPeriodArrayNightLeisure[4] = item.People;
                        }
                    }
                }
            }


            jaggedArrayLive[0] = yAxisPeriodArrayMorningLive;
            jaggedArrayLive[1] = yAxisPeriodArrayAfternoonLive;
            jaggedArrayLive[2] = yAxisPeriodArrayEveningLive;
            jaggedArrayLive[3] = yAxisPeriodArrayNightLive;

            jaggedArrayWork[0] = yAxisPeriodArrayMorningWork;
            jaggedArrayWork[1] = yAxisPeriodArrayAfternoonWork;
            jaggedArrayWork[2] = yAxisPeriodArrayEveningWork;
            jaggedArrayWork[3] = yAxisPeriodArrayNightWork;

            jaggedArrayCommute[0] = yAxisPeriodArrayMorningCommute;
            jaggedArrayCommute[1] = yAxisPeriodArrayAfternoonCommute;
            jaggedArrayCommute[2] = yAxisPeriodArrayEveningCommute;
            jaggedArrayCommute[3] = yAxisPeriodArrayNightCommute;

            jaggedArrayPasserBy[0] = yAxisPeriodArrayMorningPasserBy;
            jaggedArrayPasserBy[1] = yAxisPeriodArrayAfternoonPasserBy;
            jaggedArrayPasserBy[2] = yAxisPeriodArrayEveningPasserBy;
            jaggedArrayPasserBy[3] = yAxisPeriodArrayNightPasserBy;

            jaggedArrayLeisure[0] = yAxisPeriodArrayMorningLeisure;
            jaggedArrayLeisure[1] = yAxisPeriodArrayAfternoonLeisure;
            jaggedArrayLeisure[2] = yAxisPeriodArrayEveningLeisure;
            jaggedArrayLeisure[3] = yAxisPeriodArrayNightLeisure;
            

            List<int[][]> listData = new List<int[][]>(5);

            listData.Add(jaggedArrayLive);
            listData.Add(jaggedArrayWork);
            listData.Add(jaggedArrayCommute);
            listData.Add(jaggedArrayPasserBy);
            listData.Add(jaggedArrayLeisure);

            return listData;
        }

        public List<int[][]> GetInsideCustomerWeekendByPeriodByActivityJArray(List<ByDayByPeriodByActivityDTO> list)
        {
            int[] yAxisPeriodArrayMorningLiveWeekend = new int[2];
            int[] yAxisPeriodArrayMiddayLiveWeekend = new int[2];
            int[] yAxisPeriodArrayAfternoonLiveWeekend = new int[2];
            
            int[] yAxisPeriodArrayMorningWorkWeekend = new int[2];
            int[] yAxisPeriodArrayMiddayWorkWeekend = new int[2];
            int[] yAxisPeriodArrayAfternoonWorkWeekend = new int[2];
            
            foreach (var item in list)
            {
                if (item.Type == "Take_away Customers")
                {
                    if (item.NamePeriod == "Morning")
                    {
                        if (item.Day == "Saturday")
                        {
                            yAxisPeriodArrayMorningLiveWeekend[0] = item.People;
                        }
                        if (item.Day == "Sunday")
                        {
                            yAxisPeriodArrayMorningLiveWeekend[1] = item.People;
                        }
                    }                    
                    if (item.NamePeriod == "Midday")
                    {
                        if (item.Day == "Saturday")
                        {
                            yAxisPeriodArrayMiddayLiveWeekend[0] = item.People;
                        }
                        if (item.Day == "Sunday")
                        {
                            yAxisPeriodArrayMiddayLiveWeekend[1] = item.People;
                        }
                    }
                    if (item.NamePeriod == "Afternoon")
                    {
                        if (item.Day == "Saturday")
                        {
                            yAxisPeriodArrayAfternoonLiveWeekend[0] = item.People;
                        }
                        if (item.Day == "Sunday")
                        {
                            yAxisPeriodArrayAfternoonLiveWeekend[1] = item.People;
                        }
                    }
                }
                if (item.Type == "Sit-down Customers")
                {
                    if (item.NamePeriod == "Morning")
                    {
                        if (item.Day == "Saturday")
                        {
                            yAxisPeriodArrayMorningWorkWeekend[0] = item.People;
                        }
                        if (item.Day == "Sunday")
                        {
                            yAxisPeriodArrayMorningWorkWeekend[1] = item.People;
                        }
                    }
                    if (item.NamePeriod == "Midday")
                    {
                        if (item.Day == "Saturday")
                        {
                            yAxisPeriodArrayMiddayWorkWeekend[0] = item.People;
                        }
                        if (item.Day == "Sunday")
                        {
                            yAxisPeriodArrayMiddayWorkWeekend[1] = item.People;
                        }
                    }
                    if (item.NamePeriod == "Afternoon")
                    {
                        if (item.Day == "Saturday")
                        {
                            yAxisPeriodArrayAfternoonWorkWeekend[0] = item.People;
                        }
                        if (item.Day == "Sunday")
                        {
                            yAxisPeriodArrayAfternoonWorkWeekend[1] = item.People;
                        }
                    }                    
                }                
            }

            int[][] jaggedArrayLiveWeekend = new int[3][];
            int[][] jaggedArrayWorkWeekend = new int[3][];
            
            jaggedArrayLiveWeekend[0] = yAxisPeriodArrayMorningLiveWeekend;            
            jaggedArrayLiveWeekend[1] = yAxisPeriodArrayMiddayLiveWeekend;
            jaggedArrayLiveWeekend[2] = yAxisPeriodArrayAfternoonLiveWeekend;


            jaggedArrayWorkWeekend[0] = yAxisPeriodArrayMorningWorkWeekend;
            jaggedArrayWorkWeekend[1] = yAxisPeriodArrayMiddayWorkWeekend;
            jaggedArrayWorkWeekend[2] = yAxisPeriodArrayAfternoonWorkWeekend;
            
            List<int[][]> listData = new List<int[][]>(5);

            listData.Add(jaggedArrayLiveWeekend);
            listData.Add(jaggedArrayWorkWeekend);

            return listData;                        
        }


        public List<int[][]> GetInsideTransactionWeekendByPeriodByActivityJArray(List<ByDayByPeriodByActivityDTO> list)
        {
            int[] yAxisPeriodArrayMorningLiveWeekend = new int[2];
            int[] yAxisPeriodArrayMiddayLiveWeekend = new int[2];
            int[] yAxisPeriodArrayAfternoonLiveWeekend = new int[2];
            
            int[] yAxisPeriodArrayMorningWorkWeekend = new int[2];
            int[] yAxisPeriodArrayMiddayWorkWeekend = new int[2];
            int[] yAxisPeriodArrayAfternoonWorkWeekend = new int[2];
             

            foreach (var item in list)
            {
                if (item.Type == "Transaction time 1-5 min")
                {
                    if (item.NamePeriod == "Morning")
                    {
                        if (item.Day == "Saturday")
                        {
                            yAxisPeriodArrayMorningLiveWeekend[0] = item.People;
                        }
                        if (item.Day == "Sunday")
                        {
                            yAxisPeriodArrayMorningLiveWeekend[1] = item.People;
                        }
                    }
                    if (item.NamePeriod == "Midday")
                    {
                        if (item.Day == "Saturday")
                        {
                            yAxisPeriodArrayMiddayLiveWeekend[0] = item.People;
                        }
                        if (item.Day == "Sunday")
                        {
                            yAxisPeriodArrayMiddayLiveWeekend[1] = item.People;
                        }
                    }
                    if (item.NamePeriod == "Afternoon")
                    {
                        if (item.Day == "Saturday")
                        {
                            yAxisPeriodArrayAfternoonLiveWeekend[0] = item.People;
                        }
                        if (item.Day == "Sunday")
                        {
                            yAxisPeriodArrayAfternoonLiveWeekend[1] = item.People;
                        }
                    }
                }
                if (item.Type == "Transaction time 5-10 min")
                {
                    if (item.NamePeriod == "Morning")
                    {
                        if (item.Day == "Saturday")
                        {
                            yAxisPeriodArrayMorningWorkWeekend[0] = item.People;
                        }
                        if (item.Day == "Sunday")
                        {
                            yAxisPeriodArrayMorningWorkWeekend[1] = item.People;
                        }
                    }
                    if (item.NamePeriod == "Midday")
                    {
                        if (item.Day == "Saturday")
                        {
                            yAxisPeriodArrayMiddayWorkWeekend[0] = item.People;
                        }
                        if (item.Day == "Sunday")
                        {
                            yAxisPeriodArrayMiddayWorkWeekend[1] = item.People;
                        }
                    }
                    if (item.NamePeriod == "Afternoon")
                    {
                        if (item.Day == "Saturday")
                        {
                            yAxisPeriodArrayAfternoonWorkWeekend[0] = item.People;
                        }
                        if (item.Day == "Sunday")
                        {
                            yAxisPeriodArrayAfternoonWorkWeekend[1] = item.People;
                        }
                    }
                }                
            }

            int[][] jaggedArrayLiveWeekend = new int[3][];
            int[][] jaggedArrayWorkWeekend = new int[3][];
            
            jaggedArrayLiveWeekend[0] = yAxisPeriodArrayMorningLiveWeekend;
            jaggedArrayLiveWeekend[1] = yAxisPeriodArrayMiddayLiveWeekend;
            jaggedArrayLiveWeekend[2] = yAxisPeriodArrayAfternoonLiveWeekend;
            
            jaggedArrayWorkWeekend[0] = yAxisPeriodArrayMorningWorkWeekend;
            jaggedArrayWorkWeekend[1] = yAxisPeriodArrayMiddayWorkWeekend;
            jaggedArrayWorkWeekend[2] = yAxisPeriodArrayAfternoonWorkWeekend;
            
            List<int[][]> listData = new List<int[][]>(5);

            listData.Add(jaggedArrayLiveWeekend);
            listData.Add(jaggedArrayWorkWeekend);

            return listData;       
        }


        public List<int[][]> GetOutsideWeekendByPeriodByActivityJArray(List<ByDayByPeriodByActivityDTO> list)
        {
            int[] yAxisPeriodArrayMorningLiveWeekend = new int[2];
            int[] yAxisPeriodArrayAfternoonLiveWeekend = new int[2];
            int[] yAxisPeriodArrayEveningLiveWeekend = new int[2];
            int[] yAxisPeriodArrayNightLiveWeekend = new int[2];

            int[] yAxisPeriodArrayMorningWorkWeekend = new int[2];
            int[] yAxisPeriodArrayAfternoonWorkWeekend = new int[2];
            int[] yAxisPeriodArrayEveningWorkWeekend = new int[2];
            int[] yAxisPeriodArrayNightWorkWeekend = new int[2];

            int[] yAxisPeriodArrayMorningCommuteWeekend = new int[2];
            int[] yAxisPeriodArrayAfternoonCommuteWeekend = new int[2];
            int[] yAxisPeriodArrayEveningCommuteWeekend = new int[2];
            int[] yAxisPeriodArrayNightCommuteWeekend = new int[2];

            int[] yAxisPeriodArrayMorningPasserByWeekend = new int[2];
            int[] yAxisPeriodArrayAfternoonPasserByWeekend = new int[2];
            int[] yAxisPeriodArrayEveningPasserByWeekend = new int[2];
            int[] yAxisPeriodArrayNightPasserByWeekend = new int[2];

            int[] yAxisPeriodArrayMorningLeisureWeekend = new int[2];
            int[] yAxisPeriodArrayAfternoonLeisureWeekend = new int[2];
            int[] yAxisPeriodArrayEveningLeisureWeekend = new int[2];
            int[] yAxisPeriodArrayNightLeisureWeekend = new int[2];


            foreach (var item in list)
            {
                if (item.Type == "Live")
                {
                    if (item.NamePeriod == "Morning")
                    {
                        if (item.Day == "Saturday")
                        {
                            yAxisPeriodArrayMorningLiveWeekend[0] = item.People;
                        }
                        if (item.Day == "Sunday")
                        {
                            yAxisPeriodArrayMorningLiveWeekend[1] = item.People;
                        }                        
                    }
                    if (item.NamePeriod == "Afternoon")
                    {
                        if (item.Day == "Saturday")
                        {
                            yAxisPeriodArrayAfternoonLiveWeekend[0] = item.People;
                        }
                        if (item.Day == "Sunday")
                        {
                            yAxisPeriodArrayAfternoonLiveWeekend[1] = item.People;
                        }                        
                    }
                    if (item.NamePeriod == "Evening")
                    {
                        if (item.Day == "Saturday")
                        {
                            yAxisPeriodArrayEveningLiveWeekend[0] = item.People;
                        }
                        if (item.Day == "Sunday")
                        {
                            yAxisPeriodArrayEveningLiveWeekend[1] = item.People;
                        }
                    }
                    if (item.NamePeriod == "Night")
                    {
                        if (item.Day == "Saturday")
                        {
                            yAxisPeriodArrayNightLiveWeekend[0] = item.People;
                        }
                        if (item.Day == "Sunday")
                        {
                            yAxisPeriodArrayNightLiveWeekend[1] = item.People;
                        }
                    }
                }
                if (item.Type == "Work")
                {
                    if (item.NamePeriod == "Morning")
                    {
                        if (item.Day == "Saturday")
                        {
                            yAxisPeriodArrayMorningWorkWeekend[0] = item.People;
                        }
                        if (item.Day == "Sunday")
                        {
                            yAxisPeriodArrayMorningWorkWeekend[1] = item.People;
                        }
                    }
                    if (item.NamePeriod == "Afternoon")
                    {
                        if (item.Day == "Saturday")
                        {
                            yAxisPeriodArrayAfternoonWorkWeekend[0] = item.People;
                        }
                        if (item.Day == "Sunday")
                        {
                            yAxisPeriodArrayAfternoonWorkWeekend[1] = item.People;
                        }
                    }
                    if (item.NamePeriod == "Evening")
                    {
                        if (item.Day == "Saturday")
                        {
                            yAxisPeriodArrayEveningWorkWeekend[0] = item.People;
                        }
                        if (item.Day == "Sunday")
                        {
                            yAxisPeriodArrayEveningWorkWeekend[1] = item.People;
                        }
                    }
                    if (item.NamePeriod == "Night")
                    {
                        if (item.Day == "Saturday")
                        {
                            yAxisPeriodArrayNightWorkWeekend[0] = item.People;
                        }
                        if (item.Day == "Sunday")
                        {
                            yAxisPeriodArrayNightWorkWeekend[1] = item.People;
                        }
                    }
                }
                if (item.Type == "Commute")
                {
                    if (item.NamePeriod == "Morning")
                    {
                        if (item.Day == "Saturday")
                        {
                            yAxisPeriodArrayMorningCommuteWeekend[0] = item.People;
                        }
                        if (item.Day == "Sunday")
                        {
                            yAxisPeriodArrayMorningCommuteWeekend[1] = item.People;
                        }
                    }
                    if (item.NamePeriod == "Afternoon")
                    {
                        if (item.Day == "Saturday")
                        {
                            yAxisPeriodArrayAfternoonCommuteWeekend[0] = item.People;
                        }
                        if (item.Day == "Sunday")
                        {
                            yAxisPeriodArrayAfternoonCommuteWeekend[1] = item.People;
                        }
                    }
                    if (item.NamePeriod == "Evening")
                    {
                        if (item.Day == "Saturday")
                        {
                            yAxisPeriodArrayEveningCommuteWeekend[0] = item.People;
                        }
                        if (item.Day == "Sunday")
                        {
                            yAxisPeriodArrayEveningCommuteWeekend[1] = item.People;
                        }
                    }
                    if (item.NamePeriod == "Night")
                    {
                        if (item.Day == "Saturday")
                        {
                            yAxisPeriodArrayNightCommuteWeekend[0] = item.People;
                        }
                        if (item.Day == "Sunday")
                        {
                            yAxisPeriodArrayNightCommuteWeekend[1] = item.People;
                        }
                    }
                }
                if (item.Type == "Passer-by")
                {
                    if (item.NamePeriod == "Morning")
                    {
                        if (item.Day == "Saturday")
                        {
                            yAxisPeriodArrayMorningPasserByWeekend[0] = item.People;
                        }
                        if (item.Day == "Sunday")
                        {
                            yAxisPeriodArrayMorningPasserByWeekend[1] = item.People;
                        }
                    }
                    if (item.NamePeriod == "Afternoon")
                    {
                        if (item.Day == "Saturday")
                        {
                            yAxisPeriodArrayAfternoonPasserByWeekend[0] = item.People;
                        }
                        if (item.Day == "Sunday")
                        {
                            yAxisPeriodArrayAfternoonPasserByWeekend[1] = item.People;
                        }
                    }
                    if (item.NamePeriod == "Evening")
                    {
                        if (item.Day == "Saturday")
                        {
                            yAxisPeriodArrayEveningPasserByWeekend[0] = item.People;
                        }
                        if (item.Day == "Sunday")
                        {
                            yAxisPeriodArrayEveningPasserByWeekend[1] = item.People;
                        }
                    }
                    if (item.NamePeriod == "Night")
                    {
                        if (item.Day == "Saturday")
                        {
                            yAxisPeriodArrayNightPasserByWeekend[0] = item.People;
                        }
                        if (item.Day == "Sunday")
                        {
                            yAxisPeriodArrayNightPasserByWeekend[1] = item.People;
                        }
                    }
                }
                if (item.Type == "Leisure/Fun")
                {
                    if (item.NamePeriod == "Morning")
                    {
                        if (item.Day == "Saturday")
                        {
                            yAxisPeriodArrayMorningLeisureWeekend[0] = item.People;
                        }
                        if (item.Day == "Sunday")
                        {
                            yAxisPeriodArrayMorningLeisureWeekend[1] = item.People;
                        }
                    }
                    if (item.NamePeriod == "Afternoon")
                    {
                        if (item.Day == "Saturday")
                        {
                            yAxisPeriodArrayAfternoonLeisureWeekend[0] = item.People;
                        }
                        if (item.Day == "Sunday")
                        {
                            yAxisPeriodArrayAfternoonLeisureWeekend[1] = item.People;
                        }
                    }
                    if (item.NamePeriod == "Evening")
                    {
                        if (item.Day == "Saturday")
                        {
                            yAxisPeriodArrayEveningLeisureWeekend[0] = item.People;
                        }
                        if (item.Day == "Sunday")
                        {
                            yAxisPeriodArrayEveningLeisureWeekend[1] = item.People;
                        }
                    }
                    if (item.NamePeriod == "Night")
                    {
                        if (item.Day == "Saturday")
                        {
                            yAxisPeriodArrayNightLeisureWeekend[0] = item.People;
                        }
                        if (item.Day == "Sunday")
                        {
                            yAxisPeriodArrayNightLeisureWeekend[1] = item.People;
                        }
                    }
                }
            }

            int[][] jaggedArrayLiveWeekend = new int[4][];
            int[][] jaggedArrayWorkWeekend = new int[4][];
            int[][] jaggedArrayCommuteWeekend = new int[4][];
            int[][] jaggedArrayPasserByWeekend = new int[4][];
            int[][] jaggedArrayLeisureWeekend = new int[4][];

            jaggedArrayLiveWeekend[0] = yAxisPeriodArrayMorningLiveWeekend;
            jaggedArrayLiveWeekend[1] = yAxisPeriodArrayAfternoonLiveWeekend;
            jaggedArrayLiveWeekend[2] = yAxisPeriodArrayEveningLiveWeekend;
            jaggedArrayLiveWeekend[3] = yAxisPeriodArrayNightLiveWeekend;

            jaggedArrayWorkWeekend[0] = yAxisPeriodArrayMorningWorkWeekend;
            jaggedArrayWorkWeekend[1] = yAxisPeriodArrayAfternoonWorkWeekend;
            jaggedArrayWorkWeekend[2] = yAxisPeriodArrayEveningWorkWeekend;
            jaggedArrayWorkWeekend[3] = yAxisPeriodArrayNightWorkWeekend;

            jaggedArrayCommuteWeekend[0] = yAxisPeriodArrayMorningCommuteWeekend;
            jaggedArrayCommuteWeekend[1] = yAxisPeriodArrayAfternoonCommuteWeekend;
            jaggedArrayCommuteWeekend[2] = yAxisPeriodArrayEveningCommuteWeekend;
            jaggedArrayCommuteWeekend[3] = yAxisPeriodArrayNightCommuteWeekend;

            jaggedArrayPasserByWeekend[0] = yAxisPeriodArrayMorningPasserByWeekend;
            jaggedArrayPasserByWeekend[1] = yAxisPeriodArrayAfternoonPasserByWeekend;
            jaggedArrayPasserByWeekend[2] = yAxisPeriodArrayEveningPasserByWeekend;
            jaggedArrayPasserByWeekend[3] = yAxisPeriodArrayNightPasserByWeekend;

            jaggedArrayLeisureWeekend[0] = yAxisPeriodArrayMorningLeisureWeekend;
            jaggedArrayLeisureWeekend[1] = yAxisPeriodArrayAfternoonLeisureWeekend;
            jaggedArrayLeisureWeekend[2] = yAxisPeriodArrayEveningLeisureWeekend;
            jaggedArrayLeisureWeekend[3] = yAxisPeriodArrayNightLeisureWeekend;



            List<int[][]> listData = new List<int[][]>(5);

            listData.Add(jaggedArrayLiveWeekend);
            listData.Add(jaggedArrayWorkWeekend);
            listData.Add(jaggedArrayCommuteWeekend);
            listData.Add(jaggedArrayPasserByWeekend);
            listData.Add(jaggedArrayLeisureWeekend);

            return listData;

            
        }


        public JObject GetAllWeekByHoursJson(List<BydayDTO> list, string spec)
        {
            JArray xJArray = new JArray();
            JArray zJArray = new JArray();
            var individualObj = new JObject();
            List<int> yArray = new List<int>(168);
            
            if (spec == "inside")
            {
                xJArray = getInsideXArray();
                zJArray = getInsideZArray();
            }
            else if (spec == "outside")
            {
                xJArray = getOutsideXArray();
                zJArray = getOutsideZArray();
            }
            
            foreach (var item in list)
            {
                yArray.Add(item.People);
            }

            JArray yJArray = JArray.FromObject(yArray);
            individualObj.Add("title", "All Week by Hours");
            
            individualObj.Add("x", xJArray);
            individualObj.Add("y", yJArray);
            individualObj.Add("z", zJArray);

            obj.Add("data", individualObj);
            return obj;
        }


        public JArray getOutsideXArray()
        {
            JArray xArray = new JArray();

            for (int i = 0; i < 24; i++)
            {
                xArray.Add("Monday");
            }
            for (int i = 0; i < 24; i++)
            {
                xArray.Add("Tuesday");
            }
            for (int i = 0; i < 24; i++)
            {
                xArray.Add("Wednesday");
            }
            for (int i = 0; i < 24; i++)
            {
                xArray.Add("Thursday");
            }
            for (int i = 0; i < 24; i++)
            {
                xArray.Add("Friday");
            }
            for (int i = 0; i < 24; i++)
            {
                xArray.Add("Saturday");
            }
            for (int i = 0; i < 24; i++)
            {
                xArray.Add("Sunday");
            }
            return xArray;
        }

        public JArray getOutsideZArray()
        {
            JArray zArray = new JArray();

            for (int i = 0; i < 7; i++)
            {
                for (int x = 0; x < 24; x++)
                {
                    zArray.Add(x);
                }
            }
            return zArray;
        }

        public JArray getInsideXArray()
        {
            JArray xArray = new JArray();

            for (int i = 7; i < 18; i++)
            {
                xArray.Add("Monday");
            }
            for (int i = 7; i < 18; i++)
            {
                xArray.Add("Tuesday");
            }
            for (int i = 7; i < 18; i++)
            {
                xArray.Add("Wednesday");
            }
            for (int i = 7; i < 18; i++)
            {
                xArray.Add("Thursday");
            }
            for (int i = 7; i < 18; i++)
            {
                xArray.Add("Friday");
            }
            for (int i = 7; i < 17; i++)
            {
                xArray.Add("Saturday");
            }
            for (int i = 7; i < 16; i++)
            {
                xArray.Add("Sunday");
            }
            return xArray;
        }


        public JArray getInsideZArray()
        {
            JArray zArray = new JArray();

            for (int i = 7; i < 18; i++)
            {
                zArray.Add(i);
            }
            for (int i = 7; i < 18; i++)
            {
                zArray.Add(i);
            }
            for (int i = 7; i < 18; i++)
            {
                zArray.Add(i);
            }
            for (int i = 7; i < 18; i++)
            {
                zArray.Add(i);
            }
            for (int i = 7; i < 18; i++)
            {
                zArray.Add(i);
            }
            for (int i = 8; i < 17; i++)
            {
                zArray.Add(i);
            }
            for (int i = 8; i < 16; i++)
            {
                zArray.Add(i);
            }
            return zArray;
        }
    }
}
