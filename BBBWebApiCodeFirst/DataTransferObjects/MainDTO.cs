using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BBBWebApiCodeFirst.DataTransferObjects
{
    public class MainDTO
    {
        private int _idDay;
        private string _day;
        public int _people;


        public int IdDay { get { return _idDay; } set { _idDay = value; } }
        public string Day { get { return _day; } set { _day = value; } }
        public int People { get { return _people; } set { _people = value; } }

        public MainDTO(int idDay, string day, int people)
        {
            _idDay = idDay;
            _day = day;
            _people = people;
        }
    }
}
