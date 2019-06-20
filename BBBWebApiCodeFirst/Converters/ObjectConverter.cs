using BBBWebApiCodeFirst.DataTransferObjects;
using BBBWebApiCodeFirst.Interfaces;
using BBBWebApiCodeFirst.Handler;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Collections;
using System.Collections.ObjectModel;

namespace BBBWebApiCodeFirst.Converters
{
    public class ObjectConverter : IObjectConverter
    {
        private JArray daysArray = JArray.Parse(@"['Monday', 'Tuesday', 'Wednesday', 'Thursday', 'Friday', 'Saturday', 'Sunday' ]");
        private JArray weekendArray = JArray.Parse(@"['Saturday', 'Sunday' ]");
        private JArray weekdayArray = JArray.Parse(@"['Monday', 'Tuesday', 'Wednesday', 'Thursday', 'Friday']");
        private JArray periodArray = JArray.Parse(@"['Morning', 'Afternoon', 'Evening', 'Night']");
        private JArray activityArray = JArray.Parse(@"['Live', 'Work', 'Commuters', 'Passers-by', 'Leisure']");
        JArray yAxisArray = new JArray();

        JArray morningArray = new JArray();
        JArray afternoonArray = new JArray();
        JArray eveningArray = new JArray();
        JArray nightArray = new JArray();

        JArray liveArray = new JArray();
        JArray workArray = new JArray();
        JArray leisureArray = new JArray();
        JArray commuteArray = new JArray();
        JArray passerByArray = new JArray();

        JArray yAxisActivityJArray = new JArray();
        JArray yAxisPeriodJArray = new JArray();
        

        int[] yAxisActivityArray = new int[5];
        int[] yAxisPeriodArray = new int[4];

        int[] yAxisActivityArrayMonday = new int[5];
        int[] yAxisActivityArrayTuesday = new int[5];
        int[] yAxisActivityArrayWednesday = new int[5];
        int[] yAxisActivityArrayThursday = new int[5];
        int[] yAxisActivityArrayFriday = new int[5];
        int[] yAxisActivityArraySaturday = new int[5];
        int[] yAxisActivityArraySunday = new int[5];

        int[] yAxisPeriodArrayMonday = new int[4];
        int[] yAxisPeriodArrayTuesday = new int[4];
        int[] yAxisPeriodArrayWednesday = new int[4];
        int[] yAxisPeriodArrayThursday = new int[4];
        int[] yAxisPeriodArrayFriday = new int[4];
        int[] yAxisPeriodArraySaturday = new int[4];
        int[] yAxisPeriodArraySunday = new int[4];

       

        int[] yAxisActivityArrayLive = new int[5];
        int[] yAxisActivityArrayWork = new int[5];
        int[] yAxisActivityArrayCommute = new int[5];
        int[] yAxisActivityArrayPasserBy = new int[5];
        int[] yAxisActivityArrayLeisure = new int[5];

        int[] yAxisPeriodArrayMorning = new int[5];
        int[] yAxisPeriodArrayAfternoon = new int[5];
        int[] yAxisPeriodArrayEvening = new int[5];
        int[] yAxisPeriodArrayNight = new int[5];

        int[] yAxisActivityArrayWeekendLive = new int[2];
        int[] yAxisActivityArrayWeekendWork = new int[2];
        int[] yAxisActivityArrayWeekendCommute = new int[2];
        int[] yAxisActivityArrayWeekendPasserBy = new int[2];
        int[] yAxisActivityArrayWeekendLeisure = new int[2];

        int[] yAxisPeriodArrayWeekendMorning = new int[2];
        int[] yAxisPeriodArrayWeekendAfternoon = new int[2];
        int[] yAxisPeriodArrayWeekendEvening = new int[2];
        int[] yAxisPeriodArrayWeekendNight = new int[2];

        int[] yAxisActivityArrayFullDaysLive = new int[7];
        int[] yAxisActivityArrayFullDaysWork = new int[7];
        int[] yAxisActivityArrayFullDaysCommute = new int[7];
        int[] yAxisActivityArrayFullDaysPasserBy = new int[7];
        int[] yAxisActivityArrayFullDaysLeisure = new int[7];

        int[] yAxisPeriodArrayFullDaysMorning = new int[7];
        int[] yAxisPeriodArrayFullDaysAfternoon = new int[7];
        int[] yAxisPeriodArrayFullDaysEvening = new int[7];
        int[] yAxisPeriodArrayFullDaysNight = new int[7];

        int[] yAxisActivityByPeriodLiveArray = new int[4];
        int[] yAxisActivityByPeriodWorkArray = new int[4];
        int[] yAxisActivityByPeriodCommuteArray = new int[4];
        int[] yAxisActivityByPeriodPasserbyArray = new int[4];
        int[] yAxisActivityByPeriodLeisureArray = new int[4];



        public ObjectConverter()
        {

        }



        public JObject BydayJson(List<BydayDTO> list)
        {

            var obj = new JObject();
            JArray objArray = new JArray();

            foreach (var item in list)
            {
                var individualObj = new JObject();
                individualObj.Add("day", item.Day);
                individualObj.Add("hour", item.Hour);
                individualObj.Add("people", item.People);
                objArray.Add(individualObj);
            }

            obj.Add("data", objArray);

            return obj;
        }

        public JObject WeekdaysJson(List<WeekdaysDTO> list)
        {
            var obj = new JObject();
            JArray objArray = new JArray();

            foreach (var item in list)
            {
                var individualObj = new JObject();
                individualObj.Add("id_day", item.IdDay);
                individualObj.Add("day", item.Day);
                individualObj.Add("category", item.Category);
                individualObj.Add("people", item.People);
                objArray.Add(individualObj);
            }

            obj.Add("data", objArray);


            return obj;
        }

        public JObject FulldaysJson(List<FullDaysDTO> list)
        {
            var obj = new JObject();
            JArray objArray = new JArray();

            foreach (var item in list)
            {
                var individualObj = new JObject();
                individualObj.Add("id_day", item.IdDay);
                individualObj.Add("title", "Full Days");
                individualObj.Add("yAxis", item.People);
                objArray.Add(individualObj);
            }
            obj.Add("data", objArray);

            return obj;
        }

        public JObject ByDayPeriodJson(List<ByDayPeriodDTO> list)
        {
            var obj = new JObject();
            JArray objArray = new JArray();

            foreach (var item in list)
            {
                var individualObj = new JObject();

                individualObj.Add("id", item.IdDay);
                individualObj.Add("title", item.Day);
                individualObj.Add("xAxis", item.NamePeriod);
                individualObj.Add("yAxis", item.People);
                objArray.Add(individualObj);
            }
            obj.Add("data", objArray);

            return obj;
        }


        public JObject FullDaysByPeriodJson(List<FullDaysByPeriodDTO> list)
        {
            var obj = new JObject();

            foreach (var item in list)
            {

                if (item.IdDay == 1)
                {
                    if (item.NamePeriod == "Morning")
                    {
                        morningArray.Insert(0, item.People);
                    }
                    if (item.NamePeriod == "Afternoon")
                    {
                        afternoonArray.Insert(0, item.People);
                    }
                    if (item.NamePeriod == "Evening")
                    {
                        eveningArray.Insert(0, item.People);
                    }
                    if (item.NamePeriod == "Night")
                    {
                        nightArray.Insert(0, item.People);
                    }
                }
                if (item.IdDay == 2)
                {
                    if (item.NamePeriod == "Morning")
                    {
                        morningArray.Insert(1, item.People);
                    }
                    if (item.NamePeriod == "Afternoon")
                    {
                        afternoonArray.Insert(1, item.People);
                    }
                    if (item.NamePeriod == "Evening")
                    {
                        eveningArray.Insert(1, item.People);
                    }
                    if (item.NamePeriod == "Night")
                    {
                        nightArray.Insert(1, item.People);
                    }
                }
                if (item.IdDay == 3)
                {
                    if (item.NamePeriod == "Morning")
                    {
                        morningArray.Insert(2, item.People);
                    }
                    if (item.NamePeriod == "Afternoon")
                    {
                        afternoonArray.Insert(2, item.People);
                    }
                    if (item.NamePeriod == "Evening")
                    {
                        eveningArray.Insert(2, item.People);
                    }
                    if (item.NamePeriod == "Night")
                    {
                        nightArray.Insert(2, item.People);
                    }
                }
                if (item.IdDay == 4)
                {
                    if (item.NamePeriod == "Morning")
                    {
                        morningArray.Insert(3, item.People);
                    }
                    if (item.NamePeriod == "Afternoon")
                    {
                        afternoonArray.Insert(3, item.People);
                    }
                    if (item.NamePeriod == "Evening")
                    {
                        eveningArray.Insert(3, item.People);
                    }
                    if (item.NamePeriod == "Night")
                    {
                        nightArray.Insert(3, item.People);
                    }
                }
                if (item.IdDay == 5)
                {
                    if (item.NamePeriod == "Morning")
                    {
                        morningArray.Insert(4, item.People);
                    }
                    if (item.NamePeriod == "Afternoon")
                    {
                        afternoonArray.Insert(4, item.People);
                    }
                    if (item.NamePeriod == "Evening")
                    {
                        eveningArray.Insert(4, item.People);
                    }
                    if (item.NamePeriod == "Night")
                    {
                        nightArray.Insert(4, item.People);
                    }
                }
                if (item.IdDay == 6)
                {
                    if (item.NamePeriod == "Morning")
                    {
                        morningArray.Insert(5, item.People);
                    }
                    if (item.NamePeriod == "Afternoon")
                    {
                        afternoonArray.Insert(5, item.People);
                    }
                    if (item.NamePeriod == "Evening")
                    {
                        eveningArray.Insert(5, item.People);
                    }
                    if (item.NamePeriod == "Night")
                    {
                        nightArray.Insert(5, item.People);
                    }
                }
                if (item.IdDay == 7)
                {
                    if (item.NamePeriod == "Morning")
                    {
                        morningArray.Insert(6, item.People);
                    }
                    if (item.NamePeriod == "Afternoon")
                    {
                        afternoonArray.Insert(6, item.People);
                    }
                    if (item.NamePeriod == "Evening")
                    {
                        eveningArray.Insert(6, item.People);
                    }
                    if (item.NamePeriod == "Night")
                    {
                        nightArray.Insert(6, item.People);
                    }
                }

            }

            yAxisArray.Insert(0, morningArray);
            yAxisArray.Insert(1, afternoonArray);
            yAxisArray.Insert(2, eveningArray);
            yAxisArray.Insert(3, nightArray);

            obj.Add("title", "Full Days by period");
            obj.Add("xAxis", daysArray);
            obj.Add("legend", periodArray);
            obj.Add("yAxis", yAxisArray);

            JObject finalObj = new JObject();
            finalObj.Add("data", obj);

            return finalObj;
        }

        public JObject WeekDayByPeriodJson(List<WeekDayByPeriodDTO> list)
        {
            var obj = new JObject();

            foreach (var item in list)
            {

                if (item.IdDay == 1)
                {
                    if (item.NamePeriod == "Morning")
                    {
                        morningArray.Insert(0, item.People);
                    }
                    if (item.NamePeriod == "Afternoon")
                    {
                        afternoonArray.Insert(0, item.People);
                    }
                    if (item.NamePeriod == "Evening")
                    {
                        eveningArray.Insert(0, item.People);
                    }
                    if (item.NamePeriod == "Night")
                    {
                        nightArray.Insert(0, item.People);
                    }
                }
                if (item.IdDay == 2)
                {
                    if (item.NamePeriod == "Morning")
                    {
                        morningArray.Insert(1, item.People);
                    }
                    if (item.NamePeriod == "Afternoon")
                    {
                        afternoonArray.Insert(1, item.People);
                    }
                    if (item.NamePeriod == "Evening")
                    {
                        eveningArray.Insert(1, item.People);
                    }
                    if (item.NamePeriod == "Night")
                    {
                        nightArray.Insert(1, item.People);
                    }
                }
                if (item.IdDay == 3)
                {
                    if (item.NamePeriod == "Morning")
                    {
                        morningArray.Insert(2, item.People);
                    }
                    if (item.NamePeriod == "Afternoon")
                    {
                        afternoonArray.Insert(2, item.People);
                    }
                    if (item.NamePeriod == "Evening")
                    {
                        eveningArray.Insert(2, item.People);
                    }
                    if (item.NamePeriod == "Night")
                    {
                        nightArray.Insert(2, item.People);
                    }
                }
                if (item.IdDay == 4)
                {
                    if (item.NamePeriod == "Morning")
                    {
                        morningArray.Insert(3, item.People);
                    }
                    if (item.NamePeriod == "Afternoon")
                    {
                        afternoonArray.Insert(3, item.People);
                    }
                    if (item.NamePeriod == "Evening")
                    {
                        eveningArray.Insert(3, item.People);
                    }
                    if (item.NamePeriod == "Night")
                    {
                        nightArray.Insert(3, item.People);
                    }
                }
                if (item.IdDay == 5)
                {
                    if (item.NamePeriod == "Morning")
                    {
                        morningArray.Insert(4, item.People);
                    }
                    if (item.NamePeriod == "Afternoon")
                    {
                        afternoonArray.Insert(4, item.People);
                    }
                    if (item.NamePeriod == "Evening")
                    {
                        eveningArray.Insert(4, item.People);
                    }
                    if (item.NamePeriod == "Night")
                    {
                        nightArray.Insert(4, item.People);
                    }
                } 
            }

            yAxisArray.Insert(0, morningArray);
            yAxisArray.Insert(1, afternoonArray);
            yAxisArray.Insert(2, eveningArray);
            yAxisArray.Insert(3, nightArray);

            obj.Add("title", "Week Days by period");
            obj.Add("xAxis", weekdayArray);
            obj.Add("legend", periodArray);
            obj.Add("yAxis", yAxisArray);

            JObject finalObj = new JObject();
            finalObj.Add("data", obj);

            return finalObj;
        }

        public JObject WeekendByPeriodJson(List<WeekendByPeriodDTO> list)
        {
            var obj = new JObject();

            foreach (var item in list)
            {

                if (item.IdDay == 6)
                {
                    if (item.NamePeriod == "Morning")
                    {
                        morningArray.Insert(0, item.People);
                    }
                    if (item.NamePeriod == "Afternoon")
                    {
                        afternoonArray.Insert(0, item.People);
                    }
                    if (item.NamePeriod == "Evening")
                    {
                        eveningArray.Insert(0, item.People);
                    }
                    if (item.NamePeriod == "Night")
                    {
                        nightArray.Insert(0, item.People);
                    }
                }
                if (item.IdDay == 7)
                {
                    if (item.NamePeriod == "Morning")
                    {
                        morningArray.Insert(1, item.People);
                    }
                    if (item.NamePeriod == "Afternoon")
                    {
                        afternoonArray.Insert(1, item.People);
                    }
                    if (item.NamePeriod == "Evening")
                    {
                        eveningArray.Insert(1, item.People);
                    }
                    if (item.NamePeriod == "Night")
                    {
                        nightArray.Insert(1, item.People);
                    }
                }
            }

            yAxisArray.Insert(0, morningArray);
            yAxisArray.Insert(1, afternoonArray);
            yAxisArray.Insert(2, eveningArray);
            yAxisArray.Insert(3, nightArray);

            obj.Add("title", "Weekend by period");
            obj.Add("xAxis", weekendArray);
            obj.Add("legend", periodArray);
            obj.Add("yAxis", yAxisArray);

            JObject finalObj = new JObject();
            finalObj.Add("data", obj);

            return finalObj;
        }


        public JObject ByDayByActivityJson(List<ByDayByActivityDTO> list)
        {
            var obj = new JObject();
            JArray objArray = new JArray();

            foreach (var item in list)
            {
                var individualObj = new JObject();

                if (item.IdDay == 1)
                {
                    individualObj.Add("id", item.IdDay);
                    individualObj.Add("title", "Monday by Activity");
                    individualObj.Add("xAxis", item.NameActivity);
                    individualObj.Add("yAxis", item.People);
                }
                else if (item.IdDay == 2)
                {
                    individualObj.Add("id", item.IdDay);
                    individualObj.Add("title", "Tuesday by Activity");
                    individualObj.Add("xAxis", item.NameActivity);
                    individualObj.Add("yAxis", item.People);
                }
                else if (item.IdDay == 3)
                {
                    individualObj.Add("id", item.IdDay);
                    individualObj.Add("title", "Wednesday by Activity");
                    individualObj.Add("xAxis", item.NameActivity);
                    individualObj.Add("yAxis", item.People);
                }
                else if (item.IdDay == 4)
                {
                    individualObj.Add("id", item.IdDay);
                    individualObj.Add("title", "Thursday by Activity");
                    individualObj.Add("xAxis", item.NameActivity);
                    individualObj.Add("yAxis", item.People);
                }
                else if (item.IdDay == 5)
                {
                    individualObj.Add("id", item.IdDay);
                    individualObj.Add("title", "Friday by Activity");
                    individualObj.Add("xAxis", item.NameActivity);
                    individualObj.Add("yAxis", item.People);
                }
                else if (item.IdDay == 6)
                {
                    individualObj.Add("id", item.IdDay);
                    individualObj.Add("title", "Saturday by Activity");
                    individualObj.Add("xAxis", item.NameActivity);
                    individualObj.Add("yAxis", item.People);
                }
                else if (item.IdDay == 7)
                {
                    individualObj.Add("id", item.IdDay);
                    individualObj.Add("title", "Sunday by Activity");
                    individualObj.Add("xAxis", item.NameActivity);
                    individualObj.Add("yAxis", item.People);
                }


                objArray.Add(individualObj);
            }
            obj.Add("data", objArray);

            return obj;
        }

        public JObject FullDaysByActivityJson(List<FullDaysByActivityDTO> list)
        {
            var obj = new JObject();

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
                    if (item.NameActivity == "Leisure")
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
                    if (item.NameActivity == "Leisure")
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
                    if (item.NameActivity == "Leisure")
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
                    if (item.NameActivity == "Leisure")
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
                    if (item.NameActivity == "Leisure")
                    {
                        leisureArray.Insert(4, item.People);
                    }
                    if (item.NameActivity == "Commute")
                    {
                        commuteArray.Insert(4, item.People);
                    }
                    if (item.NameActivity == "Passer-by")
                    {
                        passerByArray.Insert(4, item.People);
                    }
                }
                if (item.IdDay == 6)
                {
                    if (item.NameActivity == "Live")
                    {
                        liveArray.Insert(5, item.People);
                    }
                    if (item.NameActivity == "Work")
                    {
                        workArray.Insert(5, item.People);
                    }
                    if (item.NameActivity == "Leisure")
                    {
                        leisureArray.Insert(5, item.People);
                    }
                    if (item.NameActivity == "Commute")
                    {
                        commuteArray.Insert(5, item.People);
                    }
                    if (item.NameActivity == "Passer-by")
                    {
                        passerByArray.Insert(5, item.People);
                    }
                }
                if (item.IdDay == 7)
                {
                    if (item.NameActivity == "Live")
                    {
                        liveArray.Insert(6, item.People);
                    }
                    if (item.NameActivity == "Work")
                    {
                        workArray.Insert(6, item.People);
                    }
                    if (item.NameActivity == "Leisure")
                    {
                        leisureArray.Insert(6, item.People);
                    }
                    if (item.NameActivity == "Commute")
                    {
                        commuteArray.Insert(6, item.People);
                    }
                    if (item.NameActivity == "Passer-by")
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

            obj.Add("title", "Full Days by Activity");
            obj.Add("xAxis", daysArray);
            obj.Add("legend", periodArray);
            obj.Add("yAxis", yAxisArray);

            JObject finalObj = new JObject();
            finalObj.Add("data", obj);

            return finalObj;
        }

        public JObject WeekDaysByActivityJson(List<WeekDaysByActivityDTO> list)
        {
            var obj = new JObject();

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
                    if (item.NameActivity == "Leisure")
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
                    if (item.NameActivity == "Leisure")
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
                    if (item.NameActivity == "Leisure")
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
                    if (item.NameActivity == "Leisure")
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
                    if (item.NameActivity == "Leisure")
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

            obj.Add("title", "Week Days by Activity");
            obj.Add("xAxis", weekdayArray);
            obj.Add("legend", periodArray);
            obj.Add("yAxis", yAxisArray);

            JObject finalObj = new JObject();
            finalObj.Add("data", obj);

            return finalObj;
        }

        public JObject WeekendByActivityJson(List<WeekendByActivityDTO> list)
        {
            var obj = new JObject();

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
                    if (item.NameActivity == "Leisure")
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
                    if (item.NameActivity == "Leisure")
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

            obj.Add("title", "Weekend by Activity");
            obj.Add("xAxis", weekendArray);
            obj.Add("legend", periodArray);
            obj.Add("yAxis", yAxisArray);

            JObject finalObj = new JObject();
            finalObj.Add("data", obj);

            return finalObj;
        }


        public JObject ByDayByPeriodByActivityJson(List<ByDayByPeriodByActivityDTO> list, string day)
        {
            var obj = new JObject();
            ConverterHandler converterHandler = new ConverterHandler();
            string dayToConcat = converterHandler.getDayById(day);
            string title = "" + dayToConcat + " by Periods & By Activities";
            JArray xAxisArray = new JArray();
            xAxisArray.Add(dayToConcat);


            foreach (var item in list)
            {
                if (item.NamePeriod == "Morning")
                {
                    if (item.NameActivity == "Live")
                    {
                        yAxisActivityByPeriodLiveArray[0] = item.People;
                    }
                    if (item.NameActivity == "Work")
                    {
                        yAxisActivityByPeriodWorkArray[0] = item.People;
                    }
                    if (item.NameActivity == "Commute")
                    {
                        yAxisActivityByPeriodCommuteArray[0] = item.People;
                    }
                    if (item.NameActivity == "Passer-by")
                    {
                        yAxisActivityByPeriodPasserbyArray[0] = item.People;
                    }
                    if (item.NameActivity == "Leisure")
                    {
                        yAxisActivityByPeriodLeisureArray[0] = item.People;
                    }
                }
                if (item.NamePeriod == "Afternoon")
                {
                    if (item.NameActivity == "Live")
                    {
                        yAxisActivityByPeriodLiveArray[1] = item.People;
                    }
                    if (item.NameActivity == "Work")
                    {
                        yAxisActivityByPeriodWorkArray[1] = item.People;
                    }
                    if (item.NameActivity == "Commute")
                    {
                        yAxisActivityByPeriodCommuteArray[1] = item.People;
                    }
                    if (item.NameActivity == "Passer-by")
                    {
                        yAxisActivityByPeriodPasserbyArray[1] = item.People;
                    }
                    if (item.NameActivity == "Leisure")
                    {
                        yAxisActivityByPeriodLeisureArray[1] = item.People;
                    }
                }
                if (item.NamePeriod == "Evening")
                {
                    if (item.NameActivity == "Live")
                    {
                        yAxisActivityByPeriodLiveArray[2] = item.People;
                    }
                    if (item.NameActivity == "Work")
                    {
                        yAxisActivityByPeriodWorkArray[2] = item.People;
                    }
                    if (item.NameActivity == "Commute")
                    {
                        yAxisActivityByPeriodCommuteArray[2] = item.People;
                    }
                    if (item.NameActivity == "Passer-by")
                    {
                        yAxisActivityByPeriodPasserbyArray[2] = item.People;
                    }
                    if (item.NameActivity == "Leisure")
                    {
                        yAxisActivityByPeriodLeisureArray[2] = item.People;
                    }
                }
                if (item.NamePeriod == "Night")
                {
                    if (item.NameActivity == "Live")
                    {
                        yAxisActivityByPeriodLiveArray[3] = item.People;
                    }
                    if (item.NameActivity == "Work")
                    {
                        yAxisActivityByPeriodWorkArray[3] = item.People;
                    }
                    if (item.NameActivity == "Commute")
                    {
                        yAxisActivityByPeriodCommuteArray[3] = item.People;
                    }
                    if (item.NameActivity == "Passer-by")
                    {
                        yAxisActivityByPeriodPasserbyArray[3] = item.People;
                    }
                    if (item.NameActivity == "Leisure")
                    {
                        yAxisActivityByPeriodLeisureArray[3] = item.People;
                    }
                }
            }

            JArray yAxisArray = new JArray();
            yAxisArray.Insert(0, JArray.FromObject(yAxisActivityByPeriodLiveArray));
            yAxisArray.Insert(1, JArray.FromObject(yAxisActivityByPeriodWorkArray));
            yAxisArray.Insert(2, JArray.FromObject(yAxisActivityByPeriodCommuteArray));
            yAxisArray.Insert(3, JArray.FromObject(yAxisActivityByPeriodPasserbyArray));
            yAxisArray.Insert(4, JArray.FromObject(yAxisActivityByPeriodLeisureArray));
            

            obj.Add("title", title);
            obj.Add("xAxis", periodArray);
            obj.Add("legend", activityArray);            
            obj.Add("yAxisActivity", yAxisArray);            

            JObject finalObj = new JObject();
            finalObj.Add("data", obj);

            return finalObj;
        }

        public JObject ByWeekdaysByPeriodByActivityJson(List<ByWeekdaysByPeriodByActivityDTO> list)
        {
            var obj = new JObject();

            string title = "Weekdays by Periods By Activity";

            foreach (var item in list)
            {
                if (item.NameActivity == "Live")
                {
                    if (item.Day == "Monday")
                    {
                        yAxisActivityArrayLive[0] = item.People;
                    }
                    if (item.Day == "Tuesday")
                    {
                        yAxisActivityArrayLive[1] = item.People;
                    }
                    if (item.Day == "Wednesday")
                    {
                        yAxisActivityArrayLive[2] = item.People;
                    }
                    if (item.Day == "Thursday")
                    {
                        yAxisActivityArrayLive[3] = item.People;
                    }
                    if (item.Day == "Friday")
                    {
                        yAxisActivityArrayLive[4] = item.People;
                    }
                }
                if (item.NameActivity == "Work")
                {
                    if (item.Day == "Monday")
                    {
                        yAxisActivityArrayWork[0] = item.People;
                    }
                    if (item.Day == "Tuesday")
                    {
                        yAxisActivityArrayWork[1] = item.People;
                    }
                    if (item.Day == "Wednesday")
                    {
                        yAxisActivityArrayWork[2] = item.People;
                    }
                    if (item.Day == "Thursday")
                    {
                        yAxisActivityArrayWork[3] = item.People;
                    }
                    if (item.Day == "Friday")
                    {
                        yAxisActivityArrayWork[4] = item.People;
                    }
                }
                if (item.NameActivity == "Commute")
                {
                    if (item.Day == "Monday")
                    {
                        yAxisActivityArrayCommute[0] = item.People;
                    }
                    if (item.Day == "Tuesday")
                    {
                        yAxisActivityArrayCommute[1] = item.People;
                    }
                    if (item.Day == "Wednesday")
                    {
                        yAxisActivityArrayCommute[2] = item.People;
                    }
                    if (item.Day == "Thursday")
                    {
                        yAxisActivityArrayCommute[3] = item.People;
                    }
                    if (item.Day == "Friday")
                    {
                        yAxisActivityArrayCommute[4] = item.People;
                    }
                }
                if (item.NameActivity == "Passer-by")
                {
                    if (item.Day == "Monday")
                    {
                        yAxisActivityArrayPasserBy[0] = item.People;
                    }
                    if (item.Day == "Tuesday")
                    {
                        yAxisActivityArrayPasserBy[1] = item.People;
                    }
                    if (item.Day == "Wednesday")
                    {
                        yAxisActivityArrayPasserBy[2] = item.People;
                    }
                    if (item.Day == "Thursday")
                    {
                        yAxisActivityArrayPasserBy[3] = item.People;
                    }
                    if (item.Day == "Friday")
                    {
                        yAxisActivityArrayPasserBy[4] = item.People;
                    }
                }
                if (item.NameActivity == "Leisure")
                {
                    if (item.Day == "Monday")
                    {
                        yAxisActivityArrayLeisure[0] = item.People;
                    }
                    if (item.Day == "Tuesday")
                    {
                        yAxisActivityArrayLeisure[1] = item.People;
                    }
                    if (item.Day == "Wednesday")
                    {
                        yAxisActivityArrayLeisure[2] = item.People;
                    }
                    if (item.Day == "Thursday")
                    {
                        yAxisActivityArrayLeisure[3] = item.People;
                    }
                    if (item.Day == "Friday")
                    {
                        yAxisActivityArrayLeisure[4] = item.People;
                    }
                }
            }

            foreach (var item in list)
            {
                if (item.NamePeriod == "Morning")
                {
                    if (item.Day == "Monday")
                    {
                        yAxisPeriodArrayMorning[0] = item.People;
                    }
                    if (item.Day == "Tuesday")
                    {
                        yAxisPeriodArrayMorning[1] = item.People;
                    }
                    if (item.Day == "Wednesday")
                    {
                        yAxisPeriodArrayMorning[2] = item.People;
                    }
                    if (item.Day == "Thursday")
                    {
                        yAxisPeriodArrayMorning[3] = item.People;
                    }
                    if (item.Day == "Friday")
                    {
                        yAxisPeriodArrayMorning[4] = item.People;
                    }
                }
                if (item.NamePeriod == "Afternoon")
                {
                    if (item.Day == "Monday")
                    {
                        yAxisPeriodArrayAfternoon[0] = item.People;
                    }
                    if (item.Day == "Tuesday")
                    {
                        yAxisPeriodArrayAfternoon[1] = item.People;
                    }
                    if (item.Day == "Wednesday")
                    {
                        yAxisPeriodArrayAfternoon[2] = item.People;
                    }
                    if (item.Day == "Thursday")
                    {
                        yAxisPeriodArrayAfternoon[3] = item.People;
                    }
                    if (item.Day == "Friday")
                    {
                        yAxisPeriodArrayAfternoon[4] = item.People;
                    }
                }
                if (item.NamePeriod == "Evening")
                {
                    if (item.Day == "Monday")
                    {
                        yAxisPeriodArrayEvening[0] = item.People;
                    }
                    if (item.Day == "Tuesday")
                    {
                        yAxisPeriodArrayEvening[1] = item.People;
                    }
                    if (item.Day == "Wednesday")
                    {
                        yAxisPeriodArrayEvening[2] = item.People;
                    }
                    if (item.Day == "Thursday")
                    {
                        yAxisPeriodArrayEvening[3] = item.People;
                    }
                    if (item.Day == "Friday")
                    {
                        yAxisPeriodArrayEvening[4] = item.People;
                    }
                }
                if (item.NamePeriod == "Night")
                {
                    if (item.Day == "Monday")
                    {
                        yAxisPeriodArrayNight[0] = item.People;
                    }
                    if (item.Day == "Tuesday")
                    {
                        yAxisPeriodArrayNight[1] = item.People;
                    }
                    if (item.Day == "Wednesday")
                    {
                        yAxisPeriodArrayNight[2] = item.People;
                    }
                    if (item.Day == "Thursday")
                    {
                        yAxisPeriodArrayNight[3] = item.People;
                    }
                    if (item.Day == "Friday")
                    {
                        yAxisPeriodArrayNight[4] = item.People;
                    }
                }                
            }


            JArray yAxisActivityJArray = new JArray();
            JArray yAxisPeriodJArray = new JArray();

            obj.Add("title", title);
            obj.Add("xAxis", weekdayArray);
            obj.Add("legendActivities", activityArray);
            obj.Add("legendPeriod", periodArray);

            yAxisActivityJArray.Add(JArray.FromObject(yAxisActivityArrayLive));
            yAxisActivityJArray.Add(JArray.FromObject(yAxisActivityArrayWork));
            yAxisActivityJArray.Add(JArray.FromObject(yAxisActivityArrayCommute));
            yAxisActivityJArray.Add(JArray.FromObject(yAxisActivityArrayPasserBy));
            yAxisActivityJArray.Add(JArray.FromObject(yAxisActivityArrayLeisure));
            obj.Add("yAxisActivity", yAxisActivityJArray);

            yAxisPeriodJArray.Add(JArray.FromObject(yAxisPeriodArrayMorning));
            yAxisPeriodJArray.Add(JArray.FromObject(yAxisPeriodArrayAfternoon));
            yAxisPeriodJArray.Add(JArray.FromObject(yAxisPeriodArrayEvening));
            yAxisPeriodJArray.Add(JArray.FromObject(yAxisPeriodArrayNight));
            obj.Add("yAxisPeriods", yAxisPeriodJArray);

            JObject finalObj = new JObject();
            finalObj.Add("data", obj);

            return finalObj;
        }

        public JObject WeekendByPeriodByActivityJson(List<WeekendByPeriodByActivityDTO> list)
        {
            var obj = new JObject();

            string title = "Weekend by Periods By Activity";



            foreach (var item in list)
            {
                if (item.NameActivity == "Live")
                {
                    if (item.Day == "Saturday")
                    {
                        yAxisActivityArrayWeekendLive[0] = item.People;
                    }
                    if (item.Day == "Sunday")
                    {
                        yAxisActivityArrayWeekendLive[1] = item.People;
                    }
                }
                if (item.NameActivity == "Work")
                {
                    if (item.Day == "Saturday")
                    {
                        yAxisActivityArrayWeekendWork[0] = item.People;
                    }
                    if (item.Day == "Sunday")
                    {
                        yAxisActivityArrayWeekendWork[1] = item.People;
                    }
                }
                if (item.NameActivity == "Commute")
                {
                    if (item.Day == "Saturday")
                    {
                        yAxisActivityArrayWeekendCommute[0] = item.People;
                    }
                    if (item.Day == "Sunday")
                    {
                        yAxisActivityArrayWeekendCommute[1] = item.People;
                    }
                }
                if (item.NameActivity == "Passer-by")
                {
                    if (item.Day == "Saturday")
                    {
                        yAxisActivityArrayWeekendPasserBy[0] = item.People;
                    }
                    if (item.Day == "Sunday")
                    {
                        yAxisActivityArrayWeekendPasserBy[1] = item.People;
                    }
                }
                if (item.NameActivity == "Leisure")
                {
                    if (item.Day == "Saturday")
                    {
                        yAxisActivityArrayWeekendLeisure[0] = item.People;
                    }
                    if (item.Day == "Sunday")
                    {
                        yAxisActivityArrayWeekendLeisure[1] = item.People;
                    }
                }
            }

            foreach (var item in list)
            {
                if (item.NamePeriod == "Morning")
                {
                    if (item.Day == "Saturday")
                    {
                        yAxisPeriodArrayWeekendMorning[0] = item.People;
                    }
                    if (item.Day == "Sunday")
                    {
                        yAxisPeriodArrayWeekendMorning[1] = item.People;
                    }
                }
                if (item.NamePeriod == "Afternoon")
                {
                    if (item.Day == "Saturday")
                    {
                        yAxisPeriodArrayWeekendAfternoon[0] = item.People;
                    }
                    if (item.Day == "Sunday")
                    {
                        yAxisPeriodArrayWeekendAfternoon[1] = item.People;
                    }
                }
                if (item.NamePeriod == "Evening")
                {
                    if (item.Day == "Saturday")
                    {
                        yAxisPeriodArrayWeekendEvening[0] = item.People;
                    }
                    if (item.Day == "Sunday")
                    {
                        yAxisPeriodArrayWeekendEvening[1] = item.People;
                    }
                }
                if (item.NamePeriod == "Night")
                {
                    if (item.Day == "Saturday")
                    {
                        yAxisPeriodArrayWeekendNight[0] = item.People;
                    }
                    if (item.Day == "Sunday")
                    {
                        yAxisPeriodArrayWeekendNight[1] = item.People;
                    }
                }
            }


            JArray yAxisActivityJArray = new JArray();
            JArray yAxisPeriodJArray = new JArray();

            obj.Add("title", title);
            obj.Add("xAxis", weekendArray );
            obj.Add("legendActivities", activityArray);
            obj.Add("legendPeriod", periodArray);

            yAxisActivityJArray.Add(JArray.FromObject(yAxisActivityArrayWeekendLive));
            yAxisActivityJArray.Add(JArray.FromObject(yAxisActivityArrayWeekendWork));
            yAxisActivityJArray.Add(JArray.FromObject(yAxisActivityArrayWeekendCommute));
            yAxisActivityJArray.Add(JArray.FromObject(yAxisActivityArrayWeekendPasserBy));
            yAxisActivityJArray.Add(JArray.FromObject(yAxisActivityArrayWeekendLeisure));
            obj.Add("yAxisActivity", yAxisActivityJArray);

            yAxisPeriodJArray.Add(JArray.FromObject(yAxisPeriodArrayWeekendMorning));
            yAxisPeriodJArray.Add(JArray.FromObject(yAxisPeriodArrayWeekendAfternoon));
            yAxisPeriodJArray.Add(JArray.FromObject(yAxisPeriodArrayWeekendEvening));
            yAxisPeriodJArray.Add(JArray.FromObject(yAxisPeriodArrayWeekendNight));
            obj.Add("yAxisPeriods", yAxisPeriodJArray);
            JObject finalObj = new JObject();
            finalObj.Add("data", obj);

            return finalObj;
        }

        public JObject FullDaysByPeriodByActivityJson(List<FullDaysByPeriodByActivityDTO> list)
        {
            var obj = new JObject();

            string title = "Full Days by Periods By Activity";

            foreach (var item in list)
            {
                if (item.NameActivity == "Live")
                {
                    if (item.Day == "Monday")
                    {
                        yAxisActivityArrayFullDaysLive[0] = item.People;
                    }
                    if (item.Day == "Tuesday")
                    {
                        yAxisActivityArrayFullDaysLive[1] = item.People;
                    }
                    if (item.Day == "Wednesday")
                    {
                        yAxisActivityArrayFullDaysLive[2] = item.People;
                    }
                    if (item.Day == "Thursday")
                    {
                        yAxisActivityArrayFullDaysLive[3] = item.People;
                    }
                    if (item.Day == "Friday")
                    {
                        yAxisActivityArrayFullDaysLive[4] = item.People;
                    }
                    if (item.Day == "Saturday")
                    {
                        yAxisActivityArrayFullDaysLive[5] = item.People;
                    }
                    if (item.Day == "Sunday")
                    {
                        yAxisActivityArrayFullDaysLive[6] = item.People;
                    }
                }
                if (item.NameActivity == "Work")
                {
                    if (item.Day == "Monday")
                    {
                        yAxisActivityArrayFullDaysWork[0] = item.People;
                    }
                    if (item.Day == "Tuesday")
                    {
                        yAxisActivityArrayFullDaysWork[1] = item.People;
                    }
                    if (item.Day == "Wednesday")
                    {
                        yAxisActivityArrayFullDaysWork[2] = item.People;
                    }
                    if (item.Day == "Thursday")
                    {
                        yAxisActivityArrayFullDaysWork[3] = item.People;
                    }
                    if (item.Day == "Friday")
                    {
                        yAxisActivityArrayFullDaysWork[4] = item.People;
                    }
                    if (item.Day == "Saturday")
                    {
                        yAxisActivityArrayFullDaysWork[5] = item.People;
                    }
                    if (item.Day == "Sunday")
                    {
                        yAxisActivityArrayFullDaysWork[6] = item.People;
                    }
                }
                if (item.NameActivity == "Commute")
                {
                    if (item.Day == "Monday")
                    {
                        yAxisActivityArrayFullDaysCommute[0] = item.People;
                    }
                    if (item.Day == "Tuesday")
                    {
                        yAxisActivityArrayFullDaysCommute[1] = item.People;
                    }
                    if (item.Day == "Wednesday")
                    {
                        yAxisActivityArrayFullDaysCommute[2] = item.People;
                    }
                    if (item.Day == "Thursday")
                    {
                        yAxisActivityArrayFullDaysCommute[3] = item.People;
                    }
                    if (item.Day == "Friday")
                    {
                        yAxisActivityArrayFullDaysCommute[4] = item.People;
                    }
                    if (item.Day == "Saturday")
                    {
                        yAxisActivityArrayFullDaysCommute[5] = item.People;
                    }
                    if (item.Day == "Sunday")
                    {
                        yAxisActivityArrayFullDaysCommute[6] = item.People;
                    }
                }
                if (item.NameActivity == "Passer-by")
                {
                    if (item.Day == "Monday")
                    {
                        yAxisActivityArrayFullDaysPasserBy[0] = item.People;
                    }
                    if (item.Day == "Tuesday")
                    {
                        yAxisActivityArrayFullDaysPasserBy[1] = item.People;
                    }
                    if (item.Day == "Wednesday")
                    {
                        yAxisActivityArrayFullDaysPasserBy[2] = item.People;
                    }
                    if (item.Day == "Thursday")
                    {
                        yAxisActivityArrayFullDaysPasserBy[3] = item.People;
                    }
                    if (item.Day == "Friday")
                    {
                        yAxisActivityArrayFullDaysPasserBy[4] = item.People;
                    }
                    if (item.Day == "Saturday")
                    {
                        yAxisActivityArrayFullDaysPasserBy[5] = item.People;
                    }
                    if (item.Day == "Sunday")
                    {
                        yAxisActivityArrayFullDaysPasserBy[6] = item.People;
                    }
                }
                if (item.NameActivity == "Leisure")
                {
                    if (item.Day == "Monday")
                    {
                        yAxisActivityArrayFullDaysLeisure[0] = item.People;
                    }
                    if (item.Day == "Tuesday")
                    {
                        yAxisActivityArrayFullDaysLeisure[1] = item.People;
                    }
                    if (item.Day == "Wednesday")
                    {
                        yAxisActivityArrayFullDaysLeisure[2] = item.People;
                    }
                    if (item.Day == "Thursday")
                    {
                        yAxisActivityArrayFullDaysLeisure[3] = item.People;
                    }
                    if (item.Day == "Friday")
                    {
                        yAxisActivityArrayFullDaysLeisure[4] = item.People;
                    }
                    if (item.Day == "Saturday")
                    {
                        yAxisActivityArrayFullDaysLeisure[5] = item.People;
                    }
                    if (item.Day == "Sunday")
                    {
                        yAxisActivityArrayFullDaysLeisure[6] = item.People;
                    }
                }
            }

            foreach (var item in list)
            {
                if (item.NamePeriod == "Morning")
                {
                    if (item.Day == "Monday")
                    {
                        yAxisPeriodArrayFullDaysMorning[0] = item.People;
                    }
                    if (item.Day == "Tuesday")
                    {
                        yAxisPeriodArrayFullDaysMorning[1] = item.People;
                    }
                    if (item.Day == "Wednesday")
                    {
                        yAxisPeriodArrayFullDaysMorning[2] = item.People;
                    }
                    if (item.Day == "Thursday")
                    {
                        yAxisPeriodArrayFullDaysMorning[3] = item.People;
                    }
                    if (item.Day == "Friday")
                    {
                        yAxisPeriodArrayFullDaysMorning[4] = item.People;
                    }
                    if (item.Day == "Saturday")
                    {
                        yAxisPeriodArrayFullDaysMorning[5] = item.People;
                    }
                    if (item.Day == "Sunday")
                    {
                        yAxisPeriodArrayFullDaysMorning[6] = item.People;
                    }
                }
                if (item.NamePeriod == "Afternoon")
                {
                    if (item.Day == "Monday")
                    {
                        yAxisPeriodArrayFullDaysAfternoon[0] = item.People;
                    }
                    if (item.Day == "Tuesday")
                    {
                        yAxisPeriodArrayFullDaysAfternoon[1] = item.People;
                    }
                    if (item.Day == "Wednesday")
                    {
                        yAxisPeriodArrayFullDaysAfternoon[2] = item.People;
                    }
                    if (item.Day == "Thursday")
                    {
                        yAxisPeriodArrayFullDaysAfternoon[3] = item.People;
                    }
                    if (item.Day == "Friday")
                    {
                        yAxisPeriodArrayFullDaysAfternoon[4] = item.People;
                    }
                    if (item.Day == "Saturday")
                    {
                        yAxisPeriodArrayFullDaysAfternoon[5] = item.People;
                    }
                    if (item.Day == "Sunday")
                    {
                        yAxisPeriodArrayFullDaysAfternoon[6] = item.People;
                    }
                }
                if (item.NamePeriod == "Evening")
                {
                    if (item.Day == "Monday")
                    {
                        yAxisPeriodArrayFullDaysEvening[0] = item.People;
                    }
                    if (item.Day == "Tuesday")
                    {
                        yAxisPeriodArrayFullDaysEvening[1] = item.People;
                    }
                    if (item.Day == "Wednesday")
                    {
                        yAxisPeriodArrayFullDaysEvening[2] = item.People;
                    }
                    if (item.Day == "Thursday")
                    {
                        yAxisPeriodArrayFullDaysEvening[3] = item.People;
                    }
                    if (item.Day == "Friday")
                    {
                        yAxisPeriodArrayFullDaysEvening[4] = item.People;
                    }
                    if (item.Day == "Saturday")
                    {
                        yAxisPeriodArrayFullDaysEvening[5] = item.People;
                    }
                    if (item.Day == "Sunday")
                    {
                        yAxisPeriodArrayFullDaysEvening[6] = item.People;
                    }
                }
                if (item.NamePeriod == "Night")
                {
                    if (item.Day == "Monday")
                    {
                        yAxisPeriodArrayFullDaysNight[0] = item.People;
                    }
                    if (item.Day == "Tuesday")
                    {
                        yAxisPeriodArrayFullDaysNight[1] = item.People;
                    }
                    if (item.Day == "Wednesday")
                    {
                        yAxisPeriodArrayFullDaysNight[2] = item.People;
                    }
                    if (item.Day == "Thursday")
                    {
                        yAxisPeriodArrayFullDaysNight[3] = item.People;
                    }
                    if (item.Day == "Friday")
                    {
                        yAxisPeriodArrayFullDaysNight[4] = item.People;
                    }
                    if (item.Day == "Saturday")
                    {
                        yAxisPeriodArrayFullDaysNight[5] = item.People;
                    }
                    if (item.Day == "Sunday")
                    {
                        yAxisPeriodArrayFullDaysNight[6] = item.People;
                    }
                }                
            }


            JArray yAxisActivityJArray = new JArray();
                JArray yAxisPeriodJArray = new JArray();

                obj.Add("title", title);
                obj.Add("xAxis", daysArray);
                obj.Add("legendActivities", activityArray);
                obj.Add("legendPeriod", periodArray);

                yAxisActivityJArray.Add(JArray.FromObject(yAxisActivityArrayFullDaysLive));
                yAxisActivityJArray.Add(JArray.FromObject(yAxisActivityArrayFullDaysWork));
                yAxisActivityJArray.Add(JArray.FromObject(yAxisActivityArrayFullDaysCommute));
                yAxisActivityJArray.Add(JArray.FromObject(yAxisActivityArrayFullDaysPasserBy));
                yAxisActivityJArray.Add(JArray.FromObject(yAxisActivityArrayFullDaysLeisure));
                obj.Add("yAxisActivity", yAxisActivityJArray);


                yAxisPeriodJArray.Add(JArray.FromObject(yAxisPeriodArrayFullDaysMorning));
                yAxisPeriodJArray.Add(JArray.FromObject(yAxisPeriodArrayFullDaysAfternoon));
                yAxisPeriodJArray.Add(JArray.FromObject(yAxisPeriodArrayFullDaysEvening));
                yAxisPeriodJArray.Add(JArray.FromObject(yAxisPeriodArrayFullDaysNight));                
                obj.Add("yAxisPeriods", yAxisPeriodJArray);

                JObject finalObj = new JObject();
                finalObj.Add("data", obj);

                return finalObj;
        }

        public JObject WeekendJson(List<WeekendDTO> list)
        {
            var obj = new JObject();
           
            var individualObjSaturday = new JObject();
            var individualObjSunday = new JObject();


            foreach (var item in list)
            {
                if (item.Day == "Saturday")
                {
                    
                    individualObjSaturday.Add("id_day", item.IdDay);
                    individualObjSaturday.Add("day", item.Day);
                    individualObjSaturday.Add("category", "Weekend Day");
                    individualObjSaturday.Add("people", item.People);
                   
                }
                if (item.Day == "Sunday")
                {
                    
                    individualObjSunday.Add("id_day", item.IdDay);
                    individualObjSunday.Add("day", item.Day);
                    individualObjSunday.Add("category", "Weekend Day");
                    individualObjSunday.Add("people", item.People);
                }              
            }

            JArray individualObj = new JArray();
            individualObj.Add(individualObjSaturday);
            individualObj.Add(individualObjSunday);       
            

            obj.Add("data", individualObj);


            return obj;
        }

        public JObject AllWeekByHoursJson(List<AllWeekByHoursDTO> list)
        {
            var obj = new JObject();
            var individualObj = new JObject();
            List<int> yArray = new List<int>(168);            

            foreach (var item in list)
            {
                yArray.Add(item.People);
            }

            JArray yJArray = JArray.FromObject(yArray);

            individualObj.Add("title", "All week by hours");

            JArray xJArray = getXArray();
            individualObj.Add("x", xJArray);
            individualObj.Add("y", yJArray);

            obj.Add("data", individualObj);
            return obj;
        }

        public JArray getXArray()
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
    }
}

 
