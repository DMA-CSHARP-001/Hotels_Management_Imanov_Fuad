using HotelEntities;

namespace Repository
{
    public  class ApplicationDbContext
    {
        //Db qoshulanda bu classdan istifade edilecek

        public static List<HotelBranch> listHotels = new List<HotelBranch>()
        {
            new HotelBranch{Id=1,Name="Hotel1",Password = "123"},
            new HotelBranch{Id=2,Name="Hotel2",Password = "1234"},
            new HotelBranch{Id=3,Name="Hotel3",Password = "12345"},
            new HotelBranch{Id=4,Name="Hotel4",Password = "123456"},
        };
        public static List<Room> listRooms = new List<Room>()
        {
            new Room{Id=1,Number = 1,RoomTypeId = 1,RoomStatus = true,},
            new Room{Id=2,Number = 2,RoomTypeId = 1,RoomStatus = false},
            new Room{Id=3,Number = 3,RoomTypeId = 1,RoomStatus = true},
            new Room{Id=4,Number = 4,RoomTypeId = 1,RoomStatus = true},
            new Room{Id=5,Number = 5,RoomTypeId = 1,RoomStatus = true},
            new Room{Id=6,Number = 6,RoomTypeId = 1,RoomStatus = false},
            new Room{Id=7,Number = 7,RoomTypeId = 1,RoomStatus = true},
            new Room{Id=8,Number = 8,RoomTypeId = 1,RoomStatus = false},
            new Room{Id=9,Number = 9,RoomTypeId = 1,RoomStatus = true},
            new Room{Id=10,Number = 10,RoomTypeId = 2,RoomStatus = false},
            new Room{Id=11,Number = 11,RoomTypeId = 2,RoomStatus = true},
            new Room{Id=12,Number = 12,RoomTypeId = 2,RoomStatus = true},
            new Room{Id=13,Number = 13,RoomTypeId = 2,RoomStatus = true},
            new Room{Id=14,Number = 14,RoomTypeId = 2,RoomStatus = false},
            new Room{Id=15,Number = 15,RoomTypeId = 2,RoomStatus = true},
            new Room{Id=16,Number = 16,RoomTypeId = 2,RoomStatus = false},
            new Room{Id=17,Number = 17,RoomTypeId = 2,RoomStatus = true},
            new Room{Id=18,Number = 18,RoomTypeId = 2,RoomStatus = true},
        };
    }
}