using BBBWebApiCodeFirst.DataTransferObjects;
using Newtonsoft.Json.Linq;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace BBBWebApiCodeFirst.Interfaces
{
    interface IObjectConverter
    {

        JObject AllWeekByHoursJson(List<BydayDTO> list, string serviceId);

        JObject sharedLocationJson(SharedLocationDTO dto);


        JObject BydayJson(List<BydayDTO> obj);

        JObject TypeDayJson(List<MainDTO> list);

        JObject FulldaysJson(List<MainDTO> list);
        

        JObject ByDayPeriodJson(List<DayByTypeDTO> list);

        JObject TypeDayByPeriodJson(List<DayByTypeDTO> list, string serviceId, string dayType);

        JObject FullDaysByPeriodJson(List<DayByTypeDTO> list, string serviceId);
                

        JObject ByDayByActivityJson(List<DayByTypeDTO> list, string serviceId);

        JObject TypeDaysByActivityJson(List<DaysByActivityDTO> list, string serviceId, string spec, string dayType);

        JObject FullDaysByActivityJson(List<DayByTypeDTO> list, string serviceId, string spec);

        

        JObject ByDayByPeriodByActivityJson(List<ByDayByPeriodByActivityDTO> list, string day, string serviceId, string spec);

        JObject TypeDaysByPeriodByActivityJson(List<ByDayByPeriodByActivityDTO> list, string serviceId, string spec, string dayType);

        JObject FullDaysByPeriodByActivityJson(List<ByDayByPeriodByActivityDTO> list, string serviceId, string spec);
        
    }
}
