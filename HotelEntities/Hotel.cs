using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelEntities
{
    public class Hotel
    {
        public Hotel()
        {
            Branches = new HashSet<HotelBranch>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<HotelBranch> Branches { get; set; }
    }
}
