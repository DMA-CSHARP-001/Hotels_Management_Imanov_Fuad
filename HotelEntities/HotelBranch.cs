using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelEntities
{
    public class HotelBranch
    {
        public HotelBranch()
        {
            Rooms = new HashSet<Room>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Location { get; set; }
        public int HotelId { get; set; }
        public virtual Hotel Hotel { get; set; }
        public virtual ICollection<Room> Rooms { get; set; }

    }
}
