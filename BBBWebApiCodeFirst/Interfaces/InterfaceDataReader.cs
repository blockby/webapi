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
        FullDaysDTO ReadFulldaysDTO(NpgsqlDataReader reader);

        TypeDayDTO ReadTypeDayDTO(NpgsqlDataReader reader);
        TypeDayByPeriodDTO ReadTypeDayByPeriodDTO(NpgsqlDataReader reader);

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

        
    }
}
