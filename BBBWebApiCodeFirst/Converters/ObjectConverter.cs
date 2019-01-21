using BBBWebApiCodeFirst.DataTransferObjects;
using BBBWebApiCodeFirst.Interfaces;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BBBWebApiCodeFirst.Converters
{
    public class ObjectConverter: IObjectConverter
    {
        public ObjectConverter()
        {

        }

        public JObject MainChartDayJson(List<MainChartDTO> list)
        {
            var obj = new JObject();
            var series = HourlyPeopleJson(list);
            var labels = TimeJson();
            var day = DayJson(list);
            
            obj.Add("series", series);
            obj.Add("labels", labels);
            obj.Add("title", day);

            return obj;
        }

        public JObject HourlyPeopleJson(List<MainChartDTO> list)
        {
            var obj = new JObject();
            var series = new JObject();            

            foreach (var item in list)
            {
                if (item.HoursAct == 0)
                {
                    obj.Add("0", item.People);
                }
                if (item.HoursAct == 1)
                {
                    obj.Add("1", item.People);
                }
                if (item.HoursAct == 2)
                {
                    obj.Add("2", item.People);
                }
                if (item.HoursAct == 3)
                {
                    obj.Add("3", item.People);
                }
                if (item.HoursAct == 4)
                {
                    obj.Add("4", item.People);
                }
                if (item.HoursAct == 5)
                {
                    obj.Add("5", item.People);
                }
                if (item.HoursAct == 6)
                {
                    obj.Add("6", item.People);
                }
                if (item.HoursAct == 7)
                {
                    obj.Add("7", item.People);
                }
                if (item.HoursAct == 8)
                {
                    obj.Add("8", item.People);
                }
                if (item.HoursAct == 9)
                {
                    obj.Add("9", item.People);
                }
                if (item.HoursAct == 10)
                {
                    obj.Add("10", item.People);
                }
                if (item.HoursAct == 11)
                {
                    obj.Add("11", item.People);
                }
                if (item.HoursAct == 12)
                {
                    obj.Add("12", item.People);
                }
                if (item.HoursAct == 13)
                {
                    obj.Add("13", item.People);
                }
                if (item.HoursAct == 14)
                {
                    obj.Add("14", item.People);
                }
                if (item.HoursAct == 15)
                {
                    obj.Add("15", item.People);
                }
                if (item.HoursAct == 16)
                {
                    obj.Add("16", item.People);
                }
                if (item.HoursAct == 17)
                {
                    obj.Add("17", item.People);
                }
                if (item.HoursAct == 18)
                {
                    obj.Add("18", item.People);
                }
                if (item.HoursAct == 19)
                {
                    obj.Add("19", item.People);
                }
                if (item.HoursAct == 20)
                {
                    obj.Add("20", item.People);
                }
                if (item.HoursAct == 21)
                {
                    obj.Add("21", item.People);
                }
                if (item.HoursAct == 22)
                {
                    obj.Add("22", item.People);
                }
                if (item.HoursAct == 23)
                {
                    obj.Add("23", item.People);
                }
            }
            series.Add("serie0", obj);
            return series;
        }


        public JObject TimeJson()
        {
            var obj = new JObject();

            for (int i = 0; i < 24; i++)
            {
                string stringValue = i.ToString();
                int intValue = i;
                obj.Add(stringValue, intValue);
            }      
            return obj;
        }


        public JObject DayJson(List<MainChartDTO> list)
        {
            var obj = new JObject();

            foreach (var item in list)
            {                
                obj.Add("0", item.NameDay);                
                break;
            }

            return obj ;
        }

        public JObject MainChartWeekJson (List<MainChartDTO> list)
        {
            var obj = new JObject();
            var series = WeeklyPeopleJson(list);
            var labels = WeekDayJson();

            obj.Add("series", series);
            obj.Add("labels", labels);
            return obj;
        }

        public JObject WeeklyPeopleJson(List<MainChartDTO> list)
        {
            var obj = new JObject();
            var serie0 = new JObject(); var serie1 = new JObject();
            var serie2 = new JObject(); var serie3 = new JObject();
            var serie4 = new JObject(); var serie5 = new JObject();
            var serie6 = new JObject(); var serie7 = new JObject();
            var serie8 = new JObject(); var serie9 = new JObject();
            var serie10 = new JObject(); var serie11 = new JObject();
            var serie12 = new JObject(); var serie13 = new JObject();
            var serie14 = new JObject(); var serie15 = new JObject();
            var serie16 = new JObject(); var serie17 = new JObject();
            var serie18 = new JObject(); var serie19 = new JObject();
            var serie20 = new JObject(); var serie21 = new JObject();
            var serie22 = new JObject(); var serie23 = new JObject();

            foreach (var item in list)
            {
                if (item.HoursAct == 0 )
                {           
                    if (item.NameDay == "MON") {
                        serie0.Add("0", item.People);
                    }
                    if (item.NameDay == "TUE")
                    {
                        serie0.Add("1", item.People);
                    }
                    if (item.NameDay == "WED")
                    {
                        serie0.Add("2", item.People);
                    }
                    if (item.NameDay == "THU")
                    {
                        serie0.Add("3", item.People);
                    }
                    if (item.NameDay == "FRI")
                    {
                        serie0.Add("4", item.People);
                    }
                    if (item.NameDay == "SAT")
                    {
                        serie0.Add("5", item.People);
                    }
                    if (item.NameDay == "SUN")
                    {
                        serie0.Add("6", item.People);
                    }
                }
                if (item.HoursAct == 1)
                {
                    if (item.NameDay == "MON")
                    {
                        serie1.Add("0", item.People);
                    }
                    if (item.NameDay == "TUE")
                    {
                        serie1.Add("1", item.People);
                    }
                    if (item.NameDay == "WED")
                    {
                        serie1.Add("2", item.People);
                    }
                    if (item.NameDay == "THU")
                    {
                        serie1.Add("3", item.People);
                    }
                    if (item.NameDay == "FRI")
                    {
                        serie1.Add("4", item.People);
                    }
                    if (item.NameDay == "SAT")
                    {
                        serie1.Add("5", item.People);
                    }
                    if (item.NameDay == "SUN")
                    {
                        serie1.Add("6", item.People);
                    }
                }
                if (item.HoursAct == 2)
                {
                    if (item.NameDay == "MON")
                    {
                        serie2.Add("0", item.People);
                    }
                    if (item.NameDay == "TUE")
                    {
                        serie2.Add("1", item.People);
                    }
                    if (item.NameDay == "WED")
                    {
                        serie2.Add("2", item.People);
                    }
                    if (item.NameDay == "THU")
                    {
                        serie2.Add("3", item.People);
                    }
                    if (item.NameDay == "FRI")
                    {
                        serie2.Add("4", item.People);
                    }
                    if (item.NameDay == "SAT")
                    {
                        serie2.Add("5", item.People);
                    }
                    if (item.NameDay == "SUN")
                    {
                        serie2.Add("6", item.People);
                    }
                }
                if (item.HoursAct == 3)
                {
                    if (item.NameDay == "MON")
                    {
                        serie3.Add("0", item.People);
                    }
                    if (item.NameDay == "TUE")
                    {
                        serie3.Add("1", item.People);
                    }
                    if (item.NameDay == "WED")
                    {
                        serie3.Add("2", item.People);
                    }
                    if (item.NameDay == "THU")
                    {
                        serie3.Add("3", item.People);
                    }
                    if (item.NameDay == "FRI")
                    {
                        serie3.Add("4", item.People);
                    }
                    if (item.NameDay == "SAT")
                    {
                        serie3.Add("5", item.People);
                    }
                    if (item.NameDay == "SUN")
                    {
                        serie3.Add("6", item.People);
                    }
                }
                if (item.HoursAct == 4)
                {
                    if (item.NameDay == "MON")
                    {
                        serie4.Add("0", item.People);
                    }
                    if (item.NameDay == "TUE")
                    {
                        serie4.Add("1", item.People);
                    }
                    if (item.NameDay == "WED")
                    {
                        serie4.Add("2", item.People);
                    }
                    if (item.NameDay == "THU")
                    {
                        serie4.Add("3", item.People);
                    }
                    if (item.NameDay == "FRI")
                    {
                        serie4.Add("4", item.People);
                    }
                    if (item.NameDay == "SAT")
                    {
                        serie4.Add("5", item.People);
                    }
                    if (item.NameDay == "SUN")
                    {
                        serie4.Add("6", item.People);
                    }
                }
                if (item.HoursAct == 5)
                {
                    if (item.NameDay == "MON")
                    {
                        serie5.Add("0", item.People);
                    }
                    if (item.NameDay == "TUE")
                    {
                        serie5.Add("1", item.People);
                    }
                    if (item.NameDay == "WED")
                    {
                        serie5.Add("2", item.People);
                    }
                    if (item.NameDay == "THU")
                    {
                        serie5.Add("3", item.People);
                    }
                    if (item.NameDay == "FRI")
                    {
                        serie5.Add("4", item.People);
                    }
                    if (item.NameDay == "SAT")
                    {
                        serie5.Add("5", item.People);
                    }
                    if (item.NameDay == "SUN")
                    {
                        serie5.Add("6", item.People);
                    }
                }
                if (item.HoursAct == 6)
                {
                    if (item.NameDay == "MON")
                    {
                        serie6.Add("0", item.People);
                    }
                    if (item.NameDay == "TUE")
                    {
                        serie6.Add("1", item.People);
                    }
                    if (item.NameDay == "WED")
                    {
                        serie6.Add("2", item.People);
                    }
                    if (item.NameDay == "THU")
                    {
                        serie6.Add("3", item.People);
                    }
                    if (item.NameDay == "FRI")
                    {
                        serie6.Add("4", item.People);
                    }
                    if (item.NameDay == "SAT")
                    {
                        serie6.Add("5", item.People);
                    }
                    if (item.NameDay == "SUN")
                    {
                        serie6.Add("6", item.People);
                    }
                }
                if (item.HoursAct == 7)
                {
                    if (item.NameDay == "MON")
                    {
                        serie7.Add("0", item.People);
                    }
                    if (item.NameDay == "TUE")
                    {
                        serie7.Add("1", item.People);
                    }
                    if (item.NameDay == "WED")
                    {
                        serie7.Add("2", item.People);
                    }
                    if (item.NameDay == "THU")
                    {
                        serie7.Add("3", item.People);
                    }
                    if (item.NameDay == "FRI")
                    {
                        serie7.Add("4", item.People);
                    }
                    if (item.NameDay == "SAT")
                    {
                        serie7.Add("5", item.People);
                    }
                    if (item.NameDay == "SUN")
                    {
                        serie7.Add("6", item.People);
                    }
                }
                if (item.HoursAct == 8)
                {
                    if (item.NameDay == "MON")
                    {
                        serie8.Add("0", item.People);
                    }
                    if (item.NameDay == "TUE")
                    {
                        serie8.Add("1", item.People);
                    }
                    if (item.NameDay == "WED")
                    {
                        serie8.Add("2", item.People);
                    }
                    if (item.NameDay == "THU")
                    {
                        serie8.Add("3", item.People);
                    }
                    if (item.NameDay == "FRI")
                    {
                        serie8.Add("4", item.People);
                    }
                    if (item.NameDay == "SAT")
                    {
                        serie8.Add("5", item.People);
                    }
                    if (item.NameDay == "SUN")
                    {
                        serie8.Add("6", item.People);
                    }
                }
                if (item.HoursAct == 9)
                {
                    if (item.NameDay == "MON")
                    {
                        serie9.Add("0", item.People);
                    }
                    if (item.NameDay == "TUE")
                    {
                        serie9.Add("1", item.People);
                    }
                    if (item.NameDay == "WED")
                    {
                        serie9.Add("2", item.People);
                    }
                    if (item.NameDay == "THU")
                    {
                        serie9.Add("3", item.People);
                    }
                    if (item.NameDay == "FRI")
                    {
                        serie9.Add("4", item.People);
                    }
                    if (item.NameDay == "SAT")
                    {
                        serie9.Add("5", item.People);
                    }
                    if (item.NameDay == "SUN")
                    {
                        serie9.Add("6", item.People);
                    }
                }
                if (item.HoursAct == 10)
                {
                    if (item.NameDay == "MON")
                    {
                        serie10.Add("0", item.People);
                    }
                    if (item.NameDay == "TUE")
                    {
                        serie10.Add("1", item.People);
                    }
                    if (item.NameDay == "WED")
                    {
                        serie10.Add("2", item.People);
                    }
                    if (item.NameDay == "THU")
                    {
                        serie10.Add("3", item.People);
                    }
                    if (item.NameDay == "FRI")
                    {
                        serie10.Add("4", item.People);
                    }
                    if (item.NameDay == "SAT")
                    {
                        serie10.Add("5", item.People);
                    }
                    if (item.NameDay == "SUN")
                    {
                        serie10.Add("6", item.People);
                    }
                }
                if (item.HoursAct == 11)
                {
                    if (item.NameDay == "MON")
                    {
                        serie11.Add("0", item.People);
                    }
                    if (item.NameDay == "TUE")
                    {
                        serie11.Add("1", item.People);
                    }
                    if (item.NameDay == "WED")
                    {
                        serie11.Add("2", item.People);
                    }
                    if (item.NameDay == "THU")
                    {
                        serie11.Add("3", item.People);
                    }
                    if (item.NameDay == "FRI")
                    {
                        serie11.Add("4", item.People);
                    }
                    if (item.NameDay == "SAT")
                    {
                        serie11.Add("5", item.People);
                    }
                    if (item.NameDay == "SUN")
                    {
                        serie11.Add("6", item.People);
                    }
                }
                if (item.HoursAct == 12)
                {
                    if (item.NameDay == "MON")
                    {
                        serie12.Add("0", item.People);
                    }
                    if (item.NameDay == "TUE")
                    {
                        serie12.Add("1", item.People);
                    }
                    if (item.NameDay == "WED")
                    {
                        serie12.Add("2", item.People);
                    }
                    if (item.NameDay == "THU")
                    {
                        serie12.Add("3", item.People);
                    }
                    if (item.NameDay == "FRI")
                    {
                        serie12.Add("4", item.People);
                    }
                    if (item.NameDay == "SAT")
                    {
                        serie12.Add("5", item.People);
                    }
                    if (item.NameDay == "SUN")
                    {
                        serie12.Add("6", item.People);
                    }
                }
                if (item.HoursAct == 13)
                {
                    if (item.NameDay == "MON")
                    {
                        serie13.Add("0", item.People);
                    }
                    if (item.NameDay == "TUE")
                    {
                        serie13.Add("1", item.People);
                    }
                    if (item.NameDay == "WED")
                    {
                        serie13.Add("2", item.People);
                    }
                    if (item.NameDay == "THU")
                    {
                        serie13.Add("3", item.People);
                    }
                    if (item.NameDay == "FRI")
                    {
                        serie13.Add("4", item.People);
                    }
                    if (item.NameDay == "SAT")
                    {
                        serie13.Add("5", item.People);
                    }
                    if (item.NameDay == "SUN")
                    {
                        serie13.Add("6", item.People);
                    }
                }
                if (item.HoursAct == 14)
                {
                    if (item.NameDay == "MON")
                    {
                        serie14.Add("0", item.People);
                    }
                    if (item.NameDay == "TUE")
                    {
                        serie14.Add("1", item.People);
                    }
                    if (item.NameDay == "WED")
                    {
                        serie14.Add("2", item.People);
                    }
                    if (item.NameDay == "THU")
                    {
                        serie14.Add("3", item.People);
                    }
                    if (item.NameDay == "FRI")
                    {
                        serie14.Add("4", item.People);
                    }
                    if (item.NameDay == "SAT")
                    {
                        serie14.Add("5", item.People);
                    }
                    if (item.NameDay == "SUN")
                    {
                        serie14.Add("6", item.People);
                    }
                }
                if (item.HoursAct == 15)
                {
                    if (item.NameDay == "MON")
                    {
                        serie15.Add("0", item.People);
                    }
                    if (item.NameDay == "TUE")
                    {
                        serie15.Add("1", item.People);
                    }
                    if (item.NameDay == "WED")
                    {
                        serie15.Add("2", item.People);
                    }
                    if (item.NameDay == "THU")
                    {
                        serie15.Add("3", item.People);
                    }
                    if (item.NameDay == "FRI")
                    {
                        serie15.Add("4", item.People);
                    }
                    if (item.NameDay == "SAT")
                    {
                        serie15.Add("5", item.People);
                    }
                    if (item.NameDay == "SUN")
                    {
                        serie15.Add("6", item.People);
                    }
                }
                if (item.HoursAct == 16)
                {
                    if (item.NameDay == "MON")
                    {
                        serie16.Add("0", item.People);
                    }
                    if (item.NameDay == "TUE")
                    {
                        serie16.Add("1", item.People);
                    }
                    if (item.NameDay == "WED")
                    {
                        serie16.Add("2", item.People);
                    }
                    if (item.NameDay == "THU")
                    {
                        serie16.Add("3", item.People);
                    }
                    if (item.NameDay == "FRI")
                    {
                        serie16.Add("4", item.People);
                    }
                    if (item.NameDay == "SAT")
                    {
                        serie16.Add("5", item.People);
                    }
                    if (item.NameDay == "SUN")
                    {
                        serie16.Add("6", item.People);
                    }
                }
                if (item.HoursAct == 17)
                {
                    if (item.NameDay == "MON")
                    {
                        serie17.Add("0", item.People);
                    }
                    if (item.NameDay == "TUE")
                    {
                        serie17.Add("1", item.People);
                    }
                    if (item.NameDay == "WED")
                    {
                        serie17.Add("2", item.People);
                    }
                    if (item.NameDay == "THU")
                    {
                        serie17.Add("3", item.People);
                    }
                    if (item.NameDay == "FRI")
                    {
                        serie17.Add("4", item.People);
                    }
                    if (item.NameDay == "SAT")
                    {
                        serie17.Add("5", item.People);
                    }
                    if (item.NameDay == "SUN")
                    {
                        serie17.Add("6", item.People);
                    }
                }
                if (item.HoursAct == 18)
                {
                    if (item.NameDay == "MON")
                    {
                        serie18.Add("0", item.People);
                    }
                    if (item.NameDay == "TUE")
                    {
                        serie18.Add("1", item.People);
                    }
                    if (item.NameDay == "WED")
                    {
                        serie18.Add("2", item.People);
                    }
                    if (item.NameDay == "THU")
                    {
                        serie18.Add("3", item.People);
                    }
                    if (item.NameDay == "FRI")
                    {
                        serie18.Add("4", item.People);
                    }
                    if (item.NameDay == "SAT")
                    {
                        serie18.Add("5", item.People);
                    }
                    if (item.NameDay == "SUN")
                    {
                        serie18.Add("6", item.People);
                    }
                }
                if (item.HoursAct == 19)
                {
                    if (item.NameDay == "MON")
                    {
                        serie19.Add("0", item.People);
                    }
                    if (item.NameDay == "TUE")
                    {
                        serie19.Add("1", item.People);
                    }
                    if (item.NameDay == "WED")
                    {
                        serie19.Add("2", item.People);
                    }
                    if (item.NameDay == "THU")
                    {
                        serie19.Add("3", item.People);
                    }
                    if (item.NameDay == "FRI")
                    {
                        serie19.Add("4", item.People);
                    }
                    if (item.NameDay == "SAT")
                    {
                        serie19.Add("5", item.People);
                    }
                    if (item.NameDay == "SUN")
                    {
                        serie19.Add("6", item.People);
                    }
                }
                if (item.HoursAct == 20)
                {
                    if (item.NameDay == "MON")
                    {
                        serie20.Add("0", item.People);
                    }
                    if (item.NameDay == "TUE")
                    {
                        serie20.Add("1", item.People);
                    }
                    if (item.NameDay == "WED")
                    {
                        serie20.Add("2", item.People);
                    }
                    if (item.NameDay == "THU")
                    {
                        serie20.Add("3", item.People);
                    }
                    if (item.NameDay == "FRI")
                    {
                        serie20.Add("4", item.People);
                    }
                    if (item.NameDay == "SAT")
                    {
                        serie20.Add("5", item.People);
                    }
                    if (item.NameDay == "SUN")
                    {
                        serie20.Add("6", item.People);
                    }
                }
                if (item.HoursAct == 21)
                {
                    if (item.NameDay == "MON")
                    {
                        serie21.Add("0", item.People);
                    }
                    if (item.NameDay == "TUE")
                    {
                        serie21.Add("1", item.People);
                    }
                    if (item.NameDay == "WED")
                    {
                        serie21.Add("2", item.People);
                    }
                    if (item.NameDay == "THU")
                    {
                        serie21.Add("3", item.People);
                    }
                    if (item.NameDay == "FRI")
                    {
                        serie21.Add("4", item.People);
                    }
                    if (item.NameDay == "SAT")
                    {
                        serie21.Add("5", item.People);
                    }
                    if (item.NameDay == "SUN")
                    {
                        serie21.Add("6", item.People);
                    }
                }
                if (item.HoursAct == 22)
                {
                    if (item.NameDay == "MON")
                    {
                        serie22.Add("0", item.People);
                    }
                    if (item.NameDay == "TUE")
                    {
                        serie22.Add("1", item.People);
                    }
                    if (item.NameDay == "WED")
                    {
                        serie22.Add("2", item.People);
                    }
                    if (item.NameDay == "THU")
                    {
                        serie22.Add("3", item.People);
                    }
                    if (item.NameDay == "FRI")
                    {
                        serie22.Add("4", item.People);
                    }
                    if (item.NameDay == "SAT")
                    {
                        serie22.Add("5", item.People);
                    }
                    if (item.NameDay == "SUN")
                    {
                        serie22.Add("6", item.People);
                    }
                }
                if (item.HoursAct == 23)
                {
                    if (item.NameDay == "MON")
                    {
                        serie23.Add("0", item.People);
                    }
                    if (item.NameDay == "TUE")
                    {
                        serie23.Add("1", item.People);
                    }
                    if (item.NameDay == "WED")
                    {
                        serie23.Add("2", item.People);
                    }
                    if (item.NameDay == "THU")
                    {
                        serie23.Add("3", item.People);
                    }
                    if (item.NameDay == "FRI")
                    {
                        serie23.Add("4", item.People);
                    }
                    if (item.NameDay == "SAT")
                    {
                        serie23.Add("5", item.People);
                    }
                    if (item.NameDay == "SUN")
                    {
                        serie23.Add("6", item.People);
                    }
                }
            }
            obj.Add("serie0", serie0); obj.Add("serie1", serie1);
            obj.Add("serie2", serie2); obj.Add("serie3", serie3);
            obj.Add("serie4", serie4); obj.Add("serie5", serie5);
            obj.Add("serie6", serie6); obj.Add("serie7", serie7);
            obj.Add("serie8", serie8); obj.Add("serie9", serie9);
            obj.Add("serie10", serie10); obj.Add("serie11", serie11);
            obj.Add("serie12", serie12); obj.Add("serie13", serie14);
            obj.Add("serie14", serie14); obj.Add("serie15", serie15);
            obj.Add("serie16", serie16); obj.Add("serie17", serie17);
            obj.Add("serie18", serie18); obj.Add("serie19", serie19);
            obj.Add("serie20", serie20); obj.Add("serie21", serie21);
            obj.Add("serie22", serie22); obj.Add("serie23", serie23);
            return obj;
        }


        public JObject WeekDayJson()
        {
            var obj = new JObject();           
                
                    obj.Add("0", "MON");                
                    obj.Add("1", "TUE");
                    obj.Add("2","WED");
                    obj.Add("3", "THU");
                    obj.Add("4", "FRI");                
                    obj.Add("5", "SAT");      
                    obj.Add("6", "SUN");       
            
            return obj;
        }

        public JObject TopPeopleJson(List<TopDTO> list)
        {
            var obj = new JObject();

            var series = TopPeopleChart(list);
            var labels = TopZoneChart(list);

            obj.Add("series", series);
            obj.Add("labels", labels);
            
            return obj;

        }
        public JObject TopPeopleChart(List<TopDTO> list)
        {
            var obj = new JObject();
            var serie0 = new JObject();
            int i = 0;

            foreach (var item in list)
            {
                string x = Convert.ToString(i);
                obj.Add(x, item.People);
                i++;

            }
            serie0.Add("serie0", obj);
            return serie0;
        }

        public JObject TopZoneChart(List<TopDTO> list)
        {
            var obj = new JObject();
            int i = 0;

            foreach (var item in list)
            {
                string x = Convert.ToString(i);
                obj.Add(x, item.ZoneAct);
                i++;

            }
            return obj;
        }


        public JObject MinPeopleJson (List<TopDTO> list)
        {
            var obj = new JObject();

            var series = MinPeopleChart(list);
            var labels = MinZoneChart(list);

            obj.Add("series", series);
            obj.Add("labels", labels);

            return obj;
        }

        public JObject MinPeopleChart(List<TopDTO> list)
        {
            var obj = new JObject();
            var serie0 = new JObject();
            int i = 0;

            foreach (var item in list)
            {
                string x = Convert.ToString(i);
                obj.Add(x, item.People);
                i++;

            }
            serie0.Add("serie0", obj);

            return serie0;
        }

        public JObject MinZoneChart(List<TopDTO> list)
        {
            var obj = new JObject();
            int i = 0;

            foreach (var item in list)
            {
                string x = Convert.ToString(i);
                obj.Add(x, item.ZoneAct);
                i++;

            }
            return obj;
        }

        public JObject TableHomeDayJson(List<TableHomeDayDTO> list)
        {
            var obj = new JObject();            
            JArray objArray = new JArray();
            var index = 1;         

            foreach (TableHomeDayDTO item in list)
            {                
                var objInside = new JObject();
                objInside.Add("id", index++);
                objInside.Add("day", item.NameDay);
                objInside.Add("hour", item.HoursAct);
                objInside.Add("people", item.CountAct);
                objArray.Add(objInside);                
            }

            obj.Add("td", objArray);

            return obj;
        }

        public JObject TableHomeWeekJson(List<TableHomeWeekDTO> list)
        {
            var obj = new JObject();
            JArray objArray = new JArray();
            var index = 1;

            foreach (TableHomeWeekDTO item in list)
            {
                var objInside = new JObject();
                objInside.Add("id", index++);
                objInside.Add("day", item.NameDay);               
                objInside.Add("people", item.People);
                objArray.Add(objInside);
            }

            obj.Add("td", objArray);

            return obj;
        }

        public JObject TopDayPeopleJson(List<TopDayDTO> list)
        {
            var obj = new JObject();

            var series = TopDayPeopleChart(list);
            var labels = TopDayZoneChart(list);

            obj.Add("series", series);
            obj.Add("labels", labels);

            return obj;
        }

        public JObject TopDayPeopleChart(List<TopDayDTO> list)
        {
            var obj = new JObject();
            var serie0 = new JObject();
            int i = 0;

            foreach (var item in list)
            {
                string x = Convert.ToString(i);
                obj.Add(x, item.People);
                i++;

            }
            serie0.Add("serie0", obj);
            return serie0;
        }

        public JObject TopDayZoneChart(List<TopDayDTO> list)
        {
            var obj = new JObject();
            int i = 0;

            foreach (var item in list)
            {
                string x = Convert.ToString(i);
                obj.Add(x, item.ZoneAct);
                i++;

            }
            return obj;
        }
    }
}
