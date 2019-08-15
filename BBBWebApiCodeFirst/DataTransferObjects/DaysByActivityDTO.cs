using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BBBWebApiCodeFirst.DataTransferObjects
{
    public class DaysByActivityDTO: MainDTO
    {
        private int _typeDay;
        private string _nameActivity;

        public int TypeDay { get{return _typeDay;} set{_typeDay = value;}}
        public string NameActivity { get { return _nameActivity; } set { _nameActivity = value; }}

        public DaysByActivityDTO (int idDay, string day , int people, int typeDay, string nameActivity): base (idDay, day, people)
        {
            _typeDay = typeDay;
            _nameActivity = nameActivity;
        }
    }
}
