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

        

        public TypeDayDTO ReadTypeDayDTO(NpgsqlDataReader reader)
        {
            var obj = new JObject();

            double id_day = reader.GetDouble(0);
            string day = reader.GetString(1);
            int type_day = reader.GetInt32(2);
            int people = reader.GetInt32(3);

            TypeDayDTO typeDayDTO = new TypeDayDTO()
            {
                IdDay = id_day,
                Day = day,
                TypeDay = type_day,
                People = people
            };

            return typeDayDTO;
        }

        public FullDaysDTO ReadFulldaysDTO (NpgsqlDataReader reader)
        {
            double id_day = reader.GetDouble(0);
            string day = reader.GetString(1);
            int people = reader.GetInt32(2);

            FullDaysDTO fulldaysDTO = new FullDaysDTO()
            {
                IdDay = id_day,
                Day = day,
                People = people
            };

            return fulldaysDTO;
        }


        public DayByTypeDTO ReadDayByTypeDTO(NpgsqlDataReader reader)
        {
            double id_day = reader.GetDouble(0);
            string day = reader.GetString(1);
            string type = reader.GetString(2);
            int people = reader.GetInt32(3);

            DayByTypeDTO weekDayByPeriodDTO = new DayByTypeDTO()
            {
                IdDay = id_day,
                Day = day,
                Type = type,
                People = people
            };
            return weekDayByPeriodDTO;
        }





        public DaysByActivityDTO ReadDaysByActivityDTO(NpgsqlDataReader reader)
        {
            double id_day = reader.GetDouble(0);
            string day = reader.GetString(1);
            string type_day = reader.GetString(2);
            string name_activity = reader.GetString(3);
            int people = reader.GetInt32(4);

            DaysByActivityDTO weekDaysByActivityDTO = new DaysByActivityDTO()
            {
                IdDay = id_day,
                Day = day,
                TypeDay = type_day,
                NameActivity = name_activity,
                People = people
            };

            return weekDaysByActivityDTO;
        }





        public ByDayByPeriodByActivityDTO ReadByDayByPeriodByActivityDTO(NpgsqlDataReader reader)
        {
            double id_day = reader.GetDouble(0);
            string day = reader.GetString(1);
            string name_period = reader.GetString(2);
            string name_activity = reader.GetString(3);
            int people = reader.GetInt32(4);

            ByDayByPeriodByActivityDTO byDayByPeriodByActivityDTO = new ByDayByPeriodByActivityDTO()
            {
                IdDay = id_day,
                Day = day,
                NamePeriod = name_period,
                NameActivity = name_activity,
                People = people
            };

            return byDayByPeriodByActivityDTO;
        }    

        



        public SharedLocationDTO ReadSharedLocationDTO(NpgsqlDataReader reader)
        {
            var obj = new JObject();

            int id_location = reader.GetInt32(0);
            int id_user = reader.GetInt32(1);
            string owner = reader.GetString(2);
            string address = reader.GetString(3);
            string type_prop = reader.GetString(4);
            double longitude = reader.GetDouble(5);
            double latitude = reader.GetDouble(6);
            bool state = reader.GetBoolean(7);
            
            SharedLocationDTO sharedLocationDTO = new SharedLocationDTO()
            {
                IdLocation = id_location,
                IdUser = id_user,
                Owner = owner,
                Address = address,
                TypeProp = type_prop,
                Longitude = longitude,
                Latitude = latitude,
                State = state
            };

            return sharedLocationDTO;
        }
    }
}
