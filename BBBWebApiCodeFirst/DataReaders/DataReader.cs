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

        public WeekdaysDTO ReadWeekdaysDTO (NpgsqlDataReader reader)
        {
            var obj = new JObject();

            double id_day = reader.GetDouble(0);
            string day = reader.GetString(1);
            string category = reader.GetString(2);
            int people = reader.GetInt32(3);

            WeekdaysDTO weekdaysDTO = new WeekdaysDTO()
            {
                IdDay = id_day,
                Day = day,
                Category = category,
                People = people
            };

            return weekdaysDTO;
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

        public ByDayPeriodDTO ReadByDayPeriodDTO(NpgsqlDataReader reader)
        {
            int id_day = reader.GetInt32(0);
            string day = reader.GetString(1);
            string name_period = reader.GetString(2);
            int people = reader.GetInt32(3);

            ByDayPeriodDTO byDayPeriodDTO = new ByDayPeriodDTO()
            {
                IdDay = id_day,
                Day = day,
                NamePeriod = name_period,
                People = people
            };
            return byDayPeriodDTO;
        }

        public FullDaysByPeriodDTO ReadFullDaysByPeriodDTO(NpgsqlDataReader reader)
        {
            double id_day = reader.GetDouble(0);
            string day = reader.GetString(1);
            string name_period = reader.GetString(2);
            int people = reader.GetInt32(3);

            FullDaysByPeriodDTO byDayPeriodDTO = new FullDaysByPeriodDTO()
            {
                IdDay = id_day,
                Day = day,
                NamePeriod = name_period,
                People = people
            };
            return byDayPeriodDTO;
        }

        public WeekDayByPeriodDTO ReadWeekDayByPeriodDTO(NpgsqlDataReader reader)
        {
            double id_day = reader.GetDouble(0);
            string day = reader.GetString(1);
            string name_period = reader.GetString(2);
            int people = reader.GetInt32(3);

            WeekDayByPeriodDTO weekDayByPeriodDTO = new WeekDayByPeriodDTO()
            {
                IdDay = id_day,
                Day = day,
                NamePeriod = name_period,
                People = people
            };
            return weekDayByPeriodDTO;
        }

        public WeekendByPeriodDTO ReadWeekendByPeriodDTO (NpgsqlDataReader reader)
        {
            double id_day = reader.GetDouble(0);
            string day = reader.GetString(1);
            string name_period = reader.GetString(2);
            int people = reader.GetInt32(3);

            WeekendByPeriodDTO weekendByPeriodDTO = new WeekendByPeriodDTO()
            {
                IdDay = id_day,
                Day = day,
                NamePeriod = name_period,
                People = people
            };
            return weekendByPeriodDTO;
        }

        public ByDayByActivityDTO ReadByDayByActivityDTO(NpgsqlDataReader reader)
        {
            int id_day = reader.GetInt32(0);
            string day = reader.GetString(1);
            string name_activity = reader.GetString(2);
            int people = reader.GetInt32(3);

            ByDayByActivityDTO byDayByActivityDTO = new ByDayByActivityDTO()
            {
                IdDay = id_day,
                Day = day,
                NameActivity = name_activity,
                People = people
            };
            return byDayByActivityDTO;
        }

        public FullDaysByActivityDTO ReadFullDaysByActivityDTO(NpgsqlDataReader reader)
        {
            double id_day = reader.GetDouble(0);
            string day = reader.GetString(1);
            string name_activity = reader.GetString(2);
            int people = reader.GetInt32(3);

            FullDaysByActivityDTO fullDaysByActivityDTO = new FullDaysByActivityDTO()
            {
                IdDay = id_day,
                Day = day,
                NameActivity = name_activity,
                People = people
            };

            return fullDaysByActivityDTO;
        }

        public WeekDaysByActivityDTO ReadWeekDaysByActivityDTO(NpgsqlDataReader reader)
        {
            double id_day = reader.GetDouble(0);
            string day = reader.GetString(1);
            string type_day = reader.GetString(2);
            string name_activity = reader.GetString(3);
            int people = reader.GetInt32(4);

            WeekDaysByActivityDTO weekDaysByActivityDTO = new WeekDaysByActivityDTO()
            {
                IdDay = id_day,
                Day = day,
                TypeDay = type_day,
                NameActivity = name_activity,
                People = people
            };

            return weekDaysByActivityDTO;
        }

        public WeekendByActivityDTO ReadWeekendByActivityDTO(NpgsqlDataReader reader)
        {
            double id_day = reader.GetDouble(0);
            string day = reader.GetString(1);
            string type_day = reader.GetString(2);
            string name_activity = reader.GetString(3);
            int people = reader.GetInt32(4);

            WeekendByActivityDTO weekendByActivityDTO = new WeekendByActivityDTO()
            {
                IdDay = id_day,
                Day = day,
                TypeDay = type_day,
                NameActivity = name_activity,
                People = people
            };

            return weekendByActivityDTO;
        }

        public ByDayByPeriodByActivityDTO ReadByDayByPeriodByActivityDTO(NpgsqlDataReader reader)
        {
            int id_day = reader.GetInt32(0);
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

        public ByWeekdaysByPeriodByActivityDTO ReadByWeekdaysByPeriodByActivityDTO (NpgsqlDataReader reader)
        {
            int id_day = reader.GetInt32(0);
            string day = reader.GetString(1);
            string name_period = reader.GetString(2);
            string name_activity = reader.GetString(3);
            int people = reader.GetInt32(4);

            ByWeekdaysByPeriodByActivityDTO byWeekdaysByPeriodByActivityDTO = new ByWeekdaysByPeriodByActivityDTO()
            {
                IdDay = id_day,
                Day = day,
                NamePeriod = name_period,
                NameActivity = name_activity,
                People = people
            };

            return byWeekdaysByPeriodByActivityDTO;

        }

        public WeekendByPeriodByActivityDTO ReadWeekendByPeriodByActivityDTO(NpgsqlDataReader reader)
        {
            int id_day = reader.GetInt32(0);
            string day = reader.GetString(1);
            string name_period = reader.GetString(2);
            string name_activity = reader.GetString(3);
            int people = reader.GetInt32(4);

            WeekendByPeriodByActivityDTO weekendByPeriodByActivityDTO = new WeekendByPeriodByActivityDTO()
            {
                IdDay = id_day,
                Day = day,
                NamePeriod = name_period,
                NameActivity = name_activity,
                People = people
            };

            return weekendByPeriodByActivityDTO;
        }

        public FullDaysByPeriodByActivityDTO ReadFullDaysByPeriodByActivityDTO(NpgsqlDataReader reader)
        {
            double id_day = reader.GetDouble(0);
            string day = reader.GetString(1);
            string name_period = reader.GetString(2);
            string name_activity = reader.GetString(3);
            int people = reader.GetInt32(4);

            FullDaysByPeriodByActivityDTO fullDaysByPeriodByActivityDTO = new FullDaysByPeriodByActivityDTO()
            {
                IdDay = id_day,
                Day = day,
                NamePeriod = name_period,
                NameActivity = name_activity,
                People = people
            };

            return fullDaysByPeriodByActivityDTO;
        }

        public WeekendDTO ReadWeekendDTO(NpgsqlDataReader reader)
        {
            var obj = new JObject();

            double id_day = reader.GetDouble(0);
            string day = reader.GetString(1);
            string type_day = reader.GetString(2);
            int people = reader.GetInt32(3);

            WeekendDTO weekendDTO = new WeekendDTO()
            {
                IdDay = id_day,
                Day = day,
                TypeDay = type_day,
                People = people
            };

            return weekendDTO;
        }

        public AllWeekByHoursDTO ReadAllWeekByHoursDTO(NpgsqlDataReader reader)
        {
            var obj = new JObject();

            string day = reader.GetString(0);
            double hour = reader.GetDouble(1);
            int people = reader.GetInt32(2);

            AllWeekByHoursDTO allWeekByHoursDTO = new AllWeekByHoursDTO()
            {
                Day = day,
                Hour = hour,
                People = people
            };

            return allWeekByHoursDTO;
        }
    }
}
