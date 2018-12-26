using BBBWebApiCodeFirst.DataReaders;
using BBBWebApiCodeFirst.DataTransferObjects;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BBBWebApiCodeFirst.SqlConnectors
{
    public class SqlConnector
    {
        private readonly string connectionString = "User ID = postgres; Password = Cl4nd3st1n0; Server = localhost; Port = 5432; Database = BlockDb; Integrated Security = true; Pooling = true;";

        public List<MainChartDTO> getMainChartDtoList(string selectString)
        {
            using (var conn = new NpgsqlConnection(connectionString))
            {
                conn.Open();

                using (var cmd = new NpgsqlCommand(selectString, conn))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        List<MainChartDTO> mainChartDtoList = new List<MainChartDTO>();

                        while (reader.Read())
                        {
                            DataReader dataReader = new DataReader();
                            MainChartDTO mainChartDTO = dataReader.ReadMainChartDTO(reader);
                            mainChartDtoList.Add(mainChartDTO);
                        }
                        return mainChartDtoList;

                        //ObjectConverter objConverted = new ObjectConverter();
                        //var obj = objConverted.MainChartDayJson(mainChartDtoList);
                        //return obj;
                    }
                }
            }
        }
    }
}
