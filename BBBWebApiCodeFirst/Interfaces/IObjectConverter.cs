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

        JObject TopPeopleJson(List<TopDTO> list);

        JObject TopPeopleChart(List<TopDTO> list);

        JObject TopZoneChart(List<TopDTO> list);

        JObject MinPeopleJson(List<TopDTO> list);

        JObject MinPeopleChart(List<TopDTO> list);

        JObject MinZoneChart(List<TopDTO> list);

        JObject TableHomeDayJson(List<TableHomeDayDTO> list);

        JObject TableHomeWeekJson(List<TableHomeWeekDTO> list);

        JObject TopDayPeopleJson(List<TopDayDTO> list);

    }
}
