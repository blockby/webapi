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
        private JArray activityArray = JArray.Parse(@"['Living', 'Working', 'Commuters', 'Passer-by', 'Leisure/Fun']");

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


        public JObject getInsideFullDayByPeriodJson(List<DayByTypeDTO> list)
        {
            obj = new JObject();

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
            

            obj.Add("title", "All Week by Periods");
            obj.Add("xAxis", daysArray);
            obj.Add("legend", insidePeriodArray);
            obj.Add("yAxis", yAxisArray);

            finalObj = new JObject();

            finalObj.Add("data", obj);
            return finalObj;
        }

        public JObject getOutsideFullDayByPeriodJson(List<DayByTypeDTO> list)
        {
            obj = new JObject();

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

            obj.Add("title", "All Week by Periods");
            obj.Add("xAxis", daysArray);
            obj.Add("legend", outsidePeriodArray);
            obj.Add("yAxis", yAxisArray);

            finalObj = new JObject();

            finalObj.Add("data", obj);
            return finalObj;
        }

        public JObject getInsideWeekDayByPeriodJson(List<DayByTypeDTO> list)
        {
            obj = new JObject();

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

            obj.Add("title", "Weekdays by Periods");
            obj.Add("xAxis", weekdayArray);
            obj.Add("legend", insidePeriodArray);
            obj.Add("yAxis", yAxisArray);

            finalObj = new JObject();
            finalObj.Add("data", obj);
            return finalObj;
        }

        public JObject getOutsideWeekDayByPeriodJson(List<DayByTypeDTO> list)
        {
            obj = new JObject();

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

            obj.Add("title", "Weekdays by Periods");
            obj.Add("xAxis", weekdayArray);
            obj.Add("legend", outsidePeriodArray);
            obj.Add("yAxis", yAxisArray);

            finalObj = new JObject();
            finalObj.Add("data", obj);
            return finalObj;
        }

    }
}
