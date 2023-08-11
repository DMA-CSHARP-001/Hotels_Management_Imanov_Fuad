using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelEntities
{
    public class Room
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public bool RoomStatus { get; set; }
        public int RoomTypeId { get; set; }
        public int BranchId { get; set; }
        public virtual HotelBranch HotelBranch { get; set; }
        public virtual RoomType RoomType { get; set; }
    }
}
