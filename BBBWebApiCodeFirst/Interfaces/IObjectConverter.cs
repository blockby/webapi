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
        JObject MainChartDayJson(List<MainChartDTO> list);

        JObject HourlyPeopleJson(List<MainChartDTO> list);

        JObject TimeJson();

        JObject DayJson(List<MainChartDTO> list);

        JObject MainChartWeekJson(List<MainChartDTO> list);

        JObject WeeklyPeopleJson(List<MainChartDTO> list);

        JObject WeekDayJson();

        JObject BydayJson(List<BydayDTO> list);

    }
}
