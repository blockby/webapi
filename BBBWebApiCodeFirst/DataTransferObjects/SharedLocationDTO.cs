using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BBBWebApiCodeFirst.DataTransferObjects
{
    public class SharedLocationDTO
    {
        public int IdLocation { get; set; }

        public int IdUser { get; set; }

        public string Owner { get; set; }
        
        public string Address { get; set; }

        public string TypeProp { get; set; }

        public double Longitude { get; set; }

        public double Latitude { get; set; }

        public bool State { get; set; }

        public int Service { get; set; }
    }
}
