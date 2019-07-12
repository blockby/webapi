using BBBWebApiCodeFirst.DataTransferObjects;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BBBWebApiCodeFirst.Interfaces
{
    interface InterfaceDataReader
    {
        BydayDTO ReadBydayDTO (NpgsqlDataReader reader);

        FullDaysDTO ReadFulldaysDTO(NpgsqlDataReader reader);

        TypeDayDTO ReadTypeDayDTO(NpgsqlDataReader reader);

        DayByTypeDTO ReadDayByTypeDTO(NpgsqlDataReader reader);

        DaysByActivityDTO ReadDaysByActivityDTO(NpgsqlDataReader reader);      

        ByDayByPeriodByActivityDTO ReadByDayByPeriodByActivityDTO(NpgsqlDataReader reader);

        SharedLocationDTO ReadSharedLocationDTO(NpgsqlDataReader reader);
    }
}
