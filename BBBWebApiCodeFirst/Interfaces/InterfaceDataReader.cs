using BBBWebApiCodeFirst.DataTransferObjects;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BBBWebApiCodeFirst.Interfaces
{
    interface InterfaceDataReader    {

        MainChartDTO ReadMainChartDTO(NpgsqlDataReader reader);
        BydayDTO ReadBydayDTO (NpgsqlDataReader reader);

    }
}
