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

        public List<BydayDTO> ReadBydayDTO(NpgsqlDataReader reader)
        {
            List<BydayDTO> dTOList = new List<BydayDTO>();


            while (reader.Read())
            {
                BydayDTO dTO = new BydayDTO();
                dTO = new BydayDTO(reader.GetString(0), reader.GetInt32(1), reader.GetInt32(2));
                dTOList.Add(dTO);
            }
            return dTOList;
        }

        public List<MainDTO> ReadMainDTO (NpgsqlDataReader reader)
        {
            List<MainDTO> mainDTOList = new List<MainDTO>();

            while (reader.Read())
            {
                MainDTO mainDTO = new MainDTO(reader.GetInt32(0), reader.GetString(1), reader.GetInt32(2)) { };
                mainDTOList.Add(mainDTO);
            }
            return mainDTOList;
        }

        public List<DayByTypeDTO> ReadDayByTypeDTO(NpgsqlDataReader reader)
        {
            List<DayByTypeDTO> dtoList = new List<DayByTypeDTO>();

            while (reader.Read())
            {
                int id_day = reader.GetInt32(0);
                string day = reader.GetString(1);
                string type = reader.GetString(2);
                int people = reader.GetInt32(3);

                DayByTypeDTO dTO = new DayByTypeDTO(id_day, day, people, type) { };
                dtoList.Add(dTO);
            }
            return dtoList;
        }

        public List<DaysByActivityDTO> ReadDaysByActivityDTO(NpgsqlDataReader reader)
        {
            List<DaysByActivityDTO> dtoList = new List<DaysByActivityDTO>();

            while (reader.Read())
            {
                int id_day = reader.GetInt32(0);
                string day = reader.GetString(1);
                int type_day = reader.GetInt32(2);
                string name_activity = reader.GetString(3);
                int people = reader.GetInt32(4);

                DaysByActivityDTO dTO = new DaysByActivityDTO(id_day, day, people, type_day, name_activity) { };
                dtoList.Add(dTO);
            }
            return dtoList;           
        }

        public List<ByDayByPeriodByActivityDTO> ReadByDayByPeriodByActivityDTO(NpgsqlDataReader reader)
        {
            List<ByDayByPeriodByActivityDTO> dtoList = new List<ByDayByPeriodByActivityDTO>();

            while (reader.Read())
            {
                int id_day = reader.GetInt32(0);
                string day = reader.GetString(1);
                string name_period = reader.GetString(2);
                string name_activity = reader.GetString(3);
                int people = reader.GetInt32(4);

                ByDayByPeriodByActivityDTO dTO = new ByDayByPeriodByActivityDTO(id_day, day, people, name_activity, name_period) { };

                dtoList.Add(dTO);
            }
            return dtoList;
        }

        public SharedLocationDTO ReadSharedLocationDTO(NpgsqlDataReader reader)
        {
            int id_location = reader.GetInt32(0);
            int id_user = reader.GetInt32(1);
            string owner = reader.GetString(2);
            string address = reader.GetString(3);
            string type_prop = reader.GetString(4);
            double longitude = reader.GetDouble(5);
            double latitude = reader.GetDouble(6);
            bool state = reader.GetBoolean(7);
            int service = reader.GetInt32(8);
                        
            SharedLocationDTO sharedLocationDTO = new SharedLocationDTO()
            {
                IdLocation = id_location,
                IdUser = id_user,
                Owner = owner,
                Address = address,
                TypeProp = type_prop,
                Longitude = longitude,
                Latitude = latitude,
                State = state,
                Service = service
            };

            return sharedLocationDTO;
        }
    }
}
