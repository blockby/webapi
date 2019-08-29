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
        private JArray outsideActivityArray = JArray.Parse(@"['Living', 'Working', 'Commuters', 'Passer-by', 'Leisure/Fun']");
        private JArray outsidePeriodArray = JArray.Parse(@"['Morning', 'Afternoon', 'Evening', 'Night']");
        private JArray insidePeriodArray = JArray.Parse(@"['Morning', 'Midday', 'Afternoon']");
        private JArray insideCustomerActivityArray = JArray.Parse(@"['Take-away Customers', 'Sit-down Customers']");
        private JArray insideTransactionActivityArray = JArray.Parse(@"['Transaction Time 1-5 minutes', 'Transaction Time over 5-10 minutes']");

        private JObject obj = new JObject();
        private string title;

        JArray yAxisArray = new JArray();
        JArray jArray = new JArray();

        public ObjectConverter()
        {

        }

        public JObject BydayJson(List<BydayDTO> list)
        {
            foreach (var item in list){
                JObject individualObj = new JObject();
                individualObj.Add("day", item.Day);
                individualObj.Add("hour", item.Hour);
                individualObj.Add("people", item.People);
                jArray.Add(individualObj);
            }            
            obj.Add("data", jArray);
            return obj;
        }

        public JObject TypeDayJson(List<MainDTO> list)
        {
            foreach (var item in list)
            {
                JObject individualObj = new JObject();
                individualObj.Add("id_day", item.IdDay);
                individualObj.Add("day", item.Day);               
                individualObj.Add("people", item.People);
                jArray.Add(individualObj);
            }
            obj.Add("data", jArray);
            return obj;
        }

        public JObject FulldaysJson(List<MainDTO> list)
        {        
            foreach (var item in list)
            {
                JObject individualObj = new JObject();
                individualObj.Add("id_day", item.IdDay);
                individualObj.Add("title", "All Week by Days");
                individualObj.Add("xAxis", item.Day);
                individualObj.Add("yAxis", item.People);
                jArray.Add(individualObj);
            }
            obj.Add("data", jArray);
            return obj;
        }

        public JObject ByDayPeriodJson(List<DayByTypeDTO> list)
        {
            foreach (var item in list)
            {
                JObject individualObj = new JObject();
                individualObj.Add("id", item.IdDay);
                individualObj.Add("title", item.Day);
                individualObj.Add("xAxis", item.Type);
                individualObj.Add("yAxis", item.People);
                jArray.Add(individualObj);
            }
            obj.Add("data", jArray);
            return obj;
        }
        
        public JObject FullDaysByPeriodJson(List<DayByTypeDTO> list, string serviceId)
        {            
            ConverterHandler handler = new ConverterHandler();
            JObject finalObj = new JObject();
            JArray periodJArray = new JArray();
            
            if (serviceId == "1")
            {
                jArray = handler.getInsideFullDayByPeriodJArray(list);
                periodJArray = insidePeriodArray;
            }
            else if  (serviceId == "2")
            {
                jArray = handler.getOutsideFullDayByPeriodJArray(list);
                periodJArray = outsidePeriodArray;
            }

            obj.Add("title", "All Week by Periods");
            obj.Add("xAxis", daysArray);
            obj.Add("legend", periodJArray);
            obj.Add("yAxis", jArray);
;
            return CreateFinalObject(obj);       
        }

        public JObject TypeDayByPeriodJson(List<DayByTypeDTO> list, string serviceId, string type_day)
        {
            ConverterHandler handler = new ConverterHandler();            
            JArray dayJArray = new JArray();
            JArray periodJArray = new JArray();

            if (type_day == "1")
            {
                title = "Weekdays by Periods";
                dayJArray = weekdayArray;
                if (serviceId == "1")
                {
                    periodJArray = insidePeriodArray;
                    jArray = handler.GetInsideWeekDayByPeriodJArray(list);
                }
                else if (serviceId == "2")
                {
                    periodJArray = outsidePeriodArray;
                    jArray = handler.GetOutsideWeekDayByPeriodJArray(list);
                }
            }
            else if (type_day == "2")
            {
                title = "Weekend by Periods";
                dayJArray = weekendArray;

                if (serviceId == "1")
                {
                    jArray = handler.GetInsideWeekendByPeriodJArray(list);
                }
                else if (serviceId == "2")
                {
                    jArray = handler.getOutsideWeekendByPeriodJArray(list);
                }                
            }            

            obj.Add("title", title);
            obj.Add("xAxis", dayJArray);
            obj.Add("legend", periodJArray);
            obj.Add("yAxis", jArray);

            return CreateFinalObject(obj);
        }        


        public JObject ByDayByActivityJson(List<DayByTypeDTO> list, string serviceId)
        {
            ConverterHandler handler = new ConverterHandler();                        
            jArray = handler.GetByDaysByActivityJArray(list);
            obj.Add("data", jArray);
            return obj;                      
        }

        public JObject FullDaysByActivityJson(List<DayByTypeDTO> list, string serviceId, string spec)
        {
            ConverterHandler handler = new ConverterHandler();
            title = "All Week by Activities";
            JArray periodJArray = new JArray();           

            if (serviceId == "1")
            {
                if (spec == "customer_spec")
                {
                    jArray = handler.GetInsideCustomerFullDaysByActivityJArray(list);
                    periodJArray = insideCustomerActivityArray;
                }
                else if (spec == "transaction_spec")
                {
                    jArray = handler.GetInsideTransactionFullDaysByActivityJArray(list);
                    periodJArray = insideTransactionActivityArray;
                }                
            }
            else if (serviceId == "2")
            {
                jArray = handler.getOutsideFullDaysByActivityJArray(list);
                periodJArray = outsideActivityArray;
            }

            obj.Add("title", "All Week by Activities");
            obj.Add("xAxis", daysArray);
            obj.Add("legend", periodJArray);
            obj.Add("yAxis", jArray);

            return CreateFinalObject(obj);  
        }

        public JObject TypeDaysByActivityJson(List<DaysByActivityDTO> list, string serviceId, string spec, string typeDay)
        {
            ConverterHandler handler = new ConverterHandler();
            JArray dayJArray = new JArray();
            JArray legendJArray = new JArray();

            if (typeDay == "1")
            {
                title = "Weekdays by Activities";
                dayJArray = weekdayArray;

                if (serviceId == "1")
                {
                    if (spec == "customer_spec")
                    {
                        jArray = handler.GetInsideCustomerWeekDaysByActivityJArray(list);
                        legendJArray = insideCustomerActivityArray;
                    }
                    else if (spec == "transaction_spec")
                    {
                        jArray = handler.getInsideTransactionWeekDaysByActivityJArray(list);
                        legendJArray = insideTransactionActivityArray;
                    }
                }
                else if (serviceId == "2")
                {
                    legendJArray = outsideActivityArray;
                    jArray = handler.GetOutsideWeekDaysByActivityJArray(list);
                }
            }
            else if (typeDay == "2")
            {
                title = "Weekend by Activities";
                dayJArray = weekendArray;

                if (serviceId == "1")
                {
                    if (spec == "customer_spec")
                    {
                        jArray = handler.GetInsideCustomerWeekendByActivityJArray(list);
                        legendJArray = insideCustomerActivityArray;
                    }
                    else if (spec == "transaction_spec")
                    {
                        jArray = handler.GetInsideTransactionWeekendByActivityJArray(list);
                        legendJArray = insideTransactionActivityArray;
                    }
                }
                else if (serviceId == "2")
                {
                    legendJArray = outsideActivityArray;
                    jArray = handler.GetOutsideWeekendByActivityJArray(list);
                }
            }            

            obj.Add("title", title);
            obj.Add("xAxis", dayJArray);
            obj.Add("legend", legendJArray);
            obj.Add("yAxis", jArray);

            return CreateFinalObject(obj);
        }
        

        public JObject ByDayByPeriodByActivityJson(List<ByDayByPeriodByActivityDTO> list, string day, string serviceId, string spec)
        {
            ConverterHandler handler = new ConverterHandler();
            string dayToConcat = handler.getDayById(day);
            string titleInternal = dayToConcat + " by Periods & by Activities";
            JArray periodJArray = new JArray();
            JArray legendJArray = new JArray();

            if (serviceId == "1")
            {                
                periodJArray = insidePeriodArray;
                if (spec == "customer_spec")
                {                    
                    jArray = handler.GetInsideCustomerByDayByPeriodByActivityJArray(list, day);
                    legendJArray = insideCustomerActivityArray;    
                }
                else if (spec == "transaction_spec")
                {
                    jArray = handler.GetInsideTransactionByDayByPeriodByActivityJArray(list, day);
                    legendJArray = insideTransactionActivityArray;

                }                
            }
            else if (serviceId == "2")
            {
                jArray = handler.GetOutsideByDayByPeriodByActivityJArray(list, day);
                periodJArray = outsidePeriodArray;
                legendJArray = outsideActivityArray;
            }

            obj.Add("title", titleInternal);
            obj.Add("xAxis", periodJArray);
            obj.Add("legend", legendJArray);
            obj.Add("yAxis", jArray);

            return CreateFinalObject(obj);
        }        

        public JObject TypeDaysByPeriodByActivityJson(List<ByDayByPeriodByActivityDTO> list, string serviceId, string spec, string dayType)
        {
            ConverterHandler handler = new ConverterHandler();            
            JArray dayJArray = new JArray();
            JArray periodJArray = new JArray();
            JArray activitiesJArray = new JArray();

            if (dayType == "1")
            {
                title = "Weekdays by Periods & by Activities";
                dayJArray = weekdayArray;

                if (serviceId == "1")
                {
                    periodJArray = insidePeriodArray;
                    if (spec == "customer_spec")
                    {
                        activitiesJArray = insideCustomerActivityArray;
                        yAxisArray = JArray.FromObject(handler.GetInsideCustomerWeekDaysByPeriodByActivityJArray(list));
                    }
                    else if (spec == "transaction_spec")
                    {                        
                        activitiesJArray = insideTransactionActivityArray;
                        yAxisArray = JArray.FromObject(handler.GetInsideTransactionWeekDaysByPeriodByActivityJArray(list));
                    }
                }
                else if (serviceId == "2")
                {
                    periodJArray = outsidePeriodArray;
                    activitiesJArray = outsideActivityArray;
                    yAxisArray = JArray.FromObject(handler.GetOutsideWeekDaysByPeriodByActivityJArray(list));
                }
            }
            else if (dayType == "2")
            {
                title = "Weekend by Periods & by Activities";
                dayJArray = weekendArray;

                if (serviceId == "1")
                {
                    periodJArray = insidePeriodArray;
                    if (spec == "customer_spec")
                    {
                        yAxisArray = JArray.FromObject(handler.GetInsideCustomerWeekendByPeriodByActivityJArray(list));
                        activitiesJArray = insideCustomerActivityArray;
                    }
                    else if (spec == "transaction_spec")
                    {
                        yAxisArray = JArray.FromObject(handler.GetInsideTransactionWeekendByPeriodByActivityJArray(list));
                        activitiesJArray = insideTransactionActivityArray;
                    }
                }
                else if (serviceId == "2")
                {
                    periodJArray = outsidePeriodArray;
                    activitiesJArray = outsideActivityArray;
                    yAxisArray = JArray.FromObject(handler.GetOutsideWeekendByPeriodByActivityJArray(list));
                }
            }

            obj.Add(title);
            obj.Add(dayJArray);
            obj.Add(yAxisArray);
            obj.Add(periodJArray);
            obj.Add(activitiesJArray);

            return CreateFinalObject(obj);
        }
   

        public JObject FullDaysByPeriodByActivityJson(List<ByDayByPeriodByActivityDTO> list, string serviceId, string spec)
        {
            ConverterHandler handler = new ConverterHandler();            
            title = "All Week by Days, by Periods & by Activities";
            JArray dayJArray = daysArray;
            JArray periodJArray = new JArray();
            JArray activitiesJArray = new JArray();

            if (serviceId == "1")
            {
                periodJArray = insidePeriodArray;

                if (spec == "customer_spec")
                {
                    yAxisArray = JArray.FromObject(handler.GetInsideCustomerFullDaysByPeriodByActivityJArray(list));                                
                    activitiesJArray = insideCustomerActivityArray;
                }
                else if (spec == "transaction_spec")
                {
                    yAxisArray = JArray.FromObject(handler.GetInsideTransactionFullDaysByPeriodByActivityJArray(list));
                    activitiesJArray = insideTransactionActivityArray;
                }
            }
            else if (serviceId == "2")
            {
                yAxisArray = JArray.FromObject(handler.GetOutsideFullDaysByPeriodByActivityJArray(list));            
                periodJArray = outsidePeriodArray;
                activitiesJArray = outsideActivityArray;
            }
            
            obj.Add("title", title);
            obj.Add("xAxis", dayJArray);
            obj.Add("yAxis", yAxisArray);
            obj.Add("periods", periodJArray);
            obj.Add("activities", activitiesJArray);

            return CreateFinalObject(obj);
        }

        public JObject AllWeekByHoursJson(List<BydayDTO> list, string serviceId)
        {
            ConverterHandler handler = new ConverterHandler();
            string spec = new string ("");

            if (serviceId == "1")
            {
                spec = "inside";                
            }
            else if (serviceId == "2")
            {
                spec = "outside";
            }
            obj = handler.GetAllWeekByHoursJson(list, spec);
            return obj;            
        }

        public JObject sharedLocationJson(SharedLocationDTO item)
        {         

            JObject locationJObject = new JObject();

            locationJObject.Add("id_location", item.IdLocation);
            locationJObject.Add("id_user", item.IdUser);
            locationJObject.Add("owner", item.Owner);
            locationJObject.Add("address", item.Address);
            locationJObject.Add("typeProperty", item.TypeProp);
            JObject coordinatesJObject = new JObject();
            coordinatesJObject.Add("longitude", item.Longitude);
            coordinatesJObject.Add("latitude", item.Latitude);
            locationJObject.Add("coordinates", coordinatesJObject);
            locationJObject.Add("state", item.State);
            locationJObject.Add("id_service", item.Service);        

            obj.Add("data", locationJObject);
            return obj;
        }


        private JObject CreateFinalObject(JObject obj)
        {
            JObject finalObj = new JObject();
            finalObj.Add("data", obj);
            return finalObj;
        }

        public JArray getXArray()
        {
            for (int i = 0; i < 24; i++)
            {
                jArray.Add("Monday");
            }
            for (int i = 0; i < 24; i++)
            {
                jArray.Add("Tuesday");
            }
            for (int i = 0; i < 24; i++)
            {
                jArray.Add("Wednesday");
            }
            for (int i = 0; i < 24; i++)
            {
                jArray.Add("Thursday");
            }
            for (int i = 0; i < 24; i++)
            {
                jArray.Add("Friday");
            }
            for (int i = 0; i < 24; i++)
            {
                jArray.Add("Saturday");
            }
            for (int i = 0; i < 24; i++)
            {
                jArray.Add("Sunday");
            }
            return jArray;
        }

        public JArray getZArray()
        {
            for (int i = 0; i < 7; i++)
            {
                for (int x = 0; x < 24; x++)
                {
                    jArray.Add(x);
                }
            }
            return jArray;
        }
    }
}