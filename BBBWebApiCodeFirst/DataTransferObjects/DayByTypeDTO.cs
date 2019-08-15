using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BBBWebApiCodeFirst.DataTransferObjects
{
    public class DayByTypeDTO: MainDTO
    {
        private string _type;

        public string Type { get { return _type; } set { _type = value; } }
        
        public DayByTypeDTO(int idDay, string day, int people, string type) : base(idDay, day, people)
        {
            _type = type;
        }        
    }
}
