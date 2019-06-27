using BBBWebApiCodeFirst.DataTransferObjects;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BBBWebApiCodeFirst.Interfaces
{
    interface InterfaceDataReader    {

        BydayDTO ReadBydayDTO (NpgsqlDataReader reader);
        WeekdaysDTO ReadWeekdaysDTO(NpgsqlDataReader reader);
        FullDaysDTO ReadFulldaysDTO(NpgsqlDataReader reader);
        ByDayPeriodDTO ReadByDayPeriodDTO(NpgsqlDataReader reader);
        FullDaysByPeriodDTO ReadFullDaysByPeriodDTO(NpgsqlDataReader reader);
        WeekDayByPeriodDTO ReadWeekDayByPeriodDTO(NpgsqlDataReader reader);
        WeekendByPeriodDTO ReadWeekendByPeriodDTO(NpgsqlDataReader reader);
        ByDayByActivityDTO ReadByDayByActivityDTO(NpgsqlDataReader reader);
        FullDaysByActivityDTO ReadFullDaysByActivityDTO(NpgsqlDataReader reader);
        WeekDaysByActivityDTO ReadWeekDaysByActivityDTO(NpgsqlDataReader reader);
        WeekendByActivityDTO ReadWeekendByActivityDTO(NpgsqlDataReader reader);
        ByDayByPeriodByActivityDTO ReadByDayByPeriodByActivityDTO(NpgsqlDataReader reader);
        ByWeekdaysByPeriodByActivityDTO ReadByWeekdaysByPeriodByActivityDTO(NpgsqlDataReader reader);
        WeekendByPeriodByActivityDTO ReadWeekendByPeriodByActivityDTO(NpgsqlDataReader reader);
        FullDaysByPeriodByActivityDTO ReadFullDaysByPeriodByActivityDTO(NpgsqlDataReader reader);
      
        AllWeekByHoursDTO ReadAllWeekByHoursDTO(NpgsqlDataReader reader);
        SharedLocationDTO ReadSharedLocationDTO(NpgsqlDataReader reader);

        TypeDayDTO ReadTypeDayDTO(NpgsqlDataReader reader);

    }
}
