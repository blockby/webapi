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

        JObject BydayJson(List<BydayDTO> list);

        JObject TypeDayJson(List<TypeDayDTO> list, string typeday);

        JObject FulldaysJson(List<FullDaysDTO> list);


        JObject ByDayPeriodJson(List<DayByTypeDTO> list);

        JObject WeekDayByPeriodJson(List<DayByTypeDTO> list);

        JObject WeekendByPeriodJson(List<DayByTypeDTO> list);

        JObject FullDaysByPeriodJson(List<DayByTypeDTO> list);

        

        JObject ByDayByActivityJson(List<DayByTypeDTO> list);

        JObject WeekDaysByActivityJson(List<DaysByActivityDTO> list);

        JObject WeekendByActivityJson(List<DaysByActivityDTO> list);

        JObject FullDaysByActivityJson(List<DayByTypeDTO> list);

        

        JObject ByDayByPeriodByActivityJson(List<ByDayByPeriodByActivityDTO> list, string day);

        JObject ByWeekdaysByPeriodByActivityJson(List<ByDayByPeriodByActivityDTO> list);

        JObject WeekendByPeriodByActivityJson(List<ByDayByPeriodByActivityDTO> list);

        JObject FullDaysByPeriodByActivityJson(List<ByDayByPeriodByActivityDTO> list);


        JObject AllWeekByHoursJson(List<BydayDTO> list);

        JObject sharedLocationJson(List<SharedLocationDTO>list);

        



    }
}
