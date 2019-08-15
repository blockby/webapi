using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BBBWebApiCodeFirst.DataTransferObjects
{
    public class ByDayByPeriodByActivityDTO: DayByTypeDTO
    {
        private string _namePeriod;

        public string NamePeriod {get{ return _namePeriod;} set { _namePeriod = value; }}

        public ByDayByPeriodByActivityDTO(int idDay, string day, int people, string type, string namePeriod): base (idDay, day, people, type)
        {
            _namePeriod = namePeriod;
        }
    }
}
