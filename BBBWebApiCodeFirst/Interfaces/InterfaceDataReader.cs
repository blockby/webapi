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
        List<BydayDTO> ReadBydayDTO (NpgsqlDataReader reader);

        List<MainDTO> ReadMainDTO(NpgsqlDataReader reader);

        List<DayByTypeDTO> ReadDayByTypeDTO(NpgsqlDataReader reader);

        List<DaysByActivityDTO> ReadDaysByActivityDTO(NpgsqlDataReader reader);

        List<ByDayByPeriodByActivityDTO> ReadByDayByPeriodByActivityDTO(NpgsqlDataReader reader);

        SharedLocationDTO ReadSharedLocationDTO(NpgsqlDataReader reader);
    }
}
