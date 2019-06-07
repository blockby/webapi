using BBBWebApiCodeFirst.DataTransferObjects;
using BBBWebApiCodeFirst.Interfaces;
using BBBWebApiCodeFirst.Models;
using NetTopologySuite.Geometries;
using Newtonsoft.Json.Linq;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace BBBWebApiCodeFirst.DataReaders
{
    public class DataReader : InterfaceDataReader
    {

        public DataReader()
        {

        }


        public MainChartDTO ReadMainChartDTO(NpgsqlDataReader reader)
        {
            var obj = new JObject();

            int id = reader.GetInt32(0);
            string day = reader.GetString(1);
            int hour = reader.GetInt32(2);
            int people = reader.GetInt32(3);
            decimal density = reader.GetDecimal(4);

            MainChartDTO mainChartDTO = new MainChartDTO
            {
                Id = id,
                Day = day,
                Hour = hour,
                People = people,
                Density = density
            };

            return mainChartDTO;
        }

        public BydayDTO ReadBydayDTO (NpgsqlDataReader reader)
        {
            var obj = new JObject();

            string day = reader.GetString(0);
            double hour = reader.GetDouble(1);
            int people = reader.GetInt32(2);

            BydayDTO bydayDTO = new BydayDTO()
            {
                Day = day,
                Hour = hour,
                People = people
            };

            return bydayDTO;
        }
    }
}
