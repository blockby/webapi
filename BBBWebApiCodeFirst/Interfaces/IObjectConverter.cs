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

        JObject FulldaysJson(List<FullDaysDTO> list);

        JObject ByDayPeriodJson(List<TypeDayByPeriodDTO> list);

        JObject FullDaysByPeriodJson(List<TypeDayByPeriodDTO> list);

        JObject WeekDayByPeriodJson(List<TypeDayByPeriodDTO> list);

        JObject WeekendByPeriodJson(List<TypeDayByPeriodDTO> list);

        JObject ByDayByActivityJson(List<ByDayByActivityDTO> list);

        JObject FullDaysByActivityJson(List<FullDaysByActivityDTO> list);

        JObject WeekDaysByActivityJson(List<WeekDaysByActivityDTO> list);

        JObject WeekendByActivityJson(List<WeekendByActivityDTO> list);

        JObject ByDayByPeriodByActivityJson(List<ByDayByPeriodByActivityDTO> list, string day);

        JObject ByWeekdaysByPeriodByActivityJson(List<ByWeekdaysByPeriodByActivityDTO> list);

        JObject WeekendByPeriodByActivityJson(List<WeekendByPeriodByActivityDTO> list);

        JObject FullDaysByPeriodByActivityJson(List<FullDaysByPeriodByActivityDTO> list);

        JObject AllWeekByHoursJson(List<AllWeekByHoursDTO> list);

        JObject sharedLocationJson(List<SharedLocationDTO>list);

        JObject TypeDayJson (List<TypeDayDTO> list, string typeday);



    }
}
