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
        JObject WeekdaysJson(List<WeekdaysDTO> list);

        JObject BydayJson(List<BydayDTO> list);

        JObject FulldaysJson(List<FullDaysDTO> list);

        JObject ByDayPeriodJson(List<ByDayPeriodDTO> list);

        JObject FullDaysByPeriodJson(List<FullDaysByPeriodDTO> list);

        JObject WeekDayByPeriodJson(List<WeekDayByPeriodDTO> list);

        JObject WeekendByPeriodJson(List<WeekendByPeriodDTO> list);

        JObject ByDayByActivityJson(List<ByDayByActivityDTO> list);

        JObject FullDaysByActivityJson(List<FullDaysByActivityDTO> list);

        JObject WeekDaysByActivityJson(List<WeekDaysByActivityDTO> list);

        JObject WeekendByActivityJson(List<WeekendByActivityDTO> list);

        JObject ByDayByPeriodByActivityJson(List<ByDayByPeriodByActivityDTO> list, string day);

        JObject ByWeekdaysByPeriodByActivityJson(List<ByWeekdaysByPeriodByActivityDTO> list);

        JObject WeekendByPeriodByActivityJson(List<WeekendByPeriodByActivityDTO> list);

        JObject FullDaysByPeriodByActivityJson(List<FullDaysByPeriodByActivityDTO> list);

        JObject WeekendJson(List<WeekendDTO> list);

    }
}
