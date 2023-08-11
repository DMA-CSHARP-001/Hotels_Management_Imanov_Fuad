using HotelEntities;
using Repository;
using System.Collections.Generic;

namespace Hotel_Management
{
    class StartConfiguration
    {
        public static void Start()
        {
            Console.WriteLine("Please input Hotel name and password for input to system management");
            bool checkLoop = true;
            while (checkLoop)
            {
                string name = Console.ReadLine();
                bool checkName = false;
                string password = new Guid().ToString();
                foreach (var hotel in ApplicationDbContext.listHotels)
                {
                    if (name == hotel.Name)
                    {
                        checkName = true;
                        password = hotel.Password;
                        break;
                    }
                }
                if (checkName)
                {
                    Console.WriteLine($"Please input password for Hotel-{name}:");
                    while (true)
                    {
                        string pass = Console.ReadLine();
                        if (!string.IsNullOrWhiteSpace(pass) && pass == password)
                        {
                            Console.WriteLine("You are logged in management system.");
                            checkLoop = false;
                            ChooseOperation();
                            break;
                        }

                        else
                        {
                            Console.WriteLine("Password incorrect.");
                            Console.WriteLine("Please input corret password:");
                        }

                    }
                }
                else
                {
                    Console.WriteLine("Name incorrect");
                    Console.WriteLine("Please input corret name");
                }
            }
        }

        private static void ChooseOperation()
        {
            Console.WriteLine("Please choose operation");

            bool checkForLoop = true;
            while (checkForLoop)
            {
                Console.WriteLine("1.Vacate a room");
                Console.WriteLine("2.Book a room ");
                var answer = Console.ReadKey();
                if (answer.KeyChar == '1')
                {
                    checkForLoop = false;
                    Console.WriteLine();
                    VacateRoom();
                    break;
                }
                else if (answer.KeyChar == '2')
                {
                    checkForLoop = false;
                    Console.WriteLine();
                    ChooseRoomForBooking();
                    break;
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("Incorrect choose. Pleace input valid number");
                }
            }
        }
        private static void ChooseRoomForBooking()
        {
            Console.WriteLine("Choose type of room for booking");
            bool checkForLoop = true;
            while (checkForLoop)
            {
                Console.WriteLine("1.Vip");
                Console.WriteLine("2.Simple");
                var answer = int.TryParse(Console.ReadLine(), out int chooseType);
                if (chooseType == 1 || chooseType == 2)
                {
                    RentRoom(chooseType);
                    break;
                }
                else
                {

                    while (true)
                    {
                        Console.WriteLine("Incorrect choose.If you want choose again enter 'y' else 'n'");
                        var res = Console.ReadKey();
                        if (res.KeyChar == 'y')
                        {
                            Console.WriteLine();
                            break;
                        }
                        else if (res.KeyChar == 'n')
                        {
                            checkForLoop = false;
                            break;
                        }
                        else
                        {
                            Console.WriteLine();
                        }
                    }
                }
            }
        }
        private static void RentRoom(int type)
        {
            Console.WriteLine("List of free rooms:");
            string typeOfRoom = "Simple";
            if (type == 1)
            {
                typeOfRoom = "Vip";
            }
            if (ApplicationDbContext.listRooms.Count == 0)
            {
                Console.WriteLine("Sorry, we don`t have any free room");
            }
            else
            {
                HashSet<int> setRooms = new HashSet<int>();
                Console.WriteLine("Please choose one room for booking");
                bool checkForLoop = true;
                while (checkForLoop)
                {

                    foreach (var room in ApplicationDbContext.listRooms)
                    {
                        if (room.RoomStatus && room.RoomTypeId == type)
                        {
                            Console.WriteLine($"Room number - {room.Number}, Room type - {typeOfRoom}");
                            setRooms.Add(room.Number);
                        }

                    }
                    if (setRooms.Count == 0)//sorguya uygun bosh otaq yoxdur
                    {
                        checkForLoop = false;
                        Console.WriteLine("Sorry, we don`t have any available rooms according to your request.");
                        break;
                    }
                    else
                    {
                        bool answer = int.TryParse(Console.ReadLine(), out int roomNumber);
                        if (answer)
                        {
                            //secim mentiqi
                            if (setRooms.Contains(roomNumber))
                            {
                                foreach (var room in ApplicationDbContext.listRooms)
                                {
                                    if (room.Number == roomNumber)
                                    {
                                        room.RoomStatus = false;
                                        Console.WriteLine("Successful operation.The room is booked.");
                                        checkForLoop = false;
                                        break;
                                    }
                                }
                            }
                            else
                            {
                                Console.WriteLine("Incorrect choose. Try again.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("You have not entered a number.Try again");
                        }
                    }

                }
            }

        }
        private static void VacateRoom()
        {
            Console.WriteLine("List of reserved rooms:");
            foreach(var room in ApplicationDbContext.listRooms)
            {
                string roomType = "Simple";
                if(room.RoomTypeId == 1)
                {
                    roomType = "Vip";
                }
                if (!room.RoomStatus)
                {
                    Console.WriteLine($"Room number - {room.Number}, room type - {roomType}, room status - booked");
                }
               
            }
            Console.WriteLine();
            Console.WriteLine("Please enter the number of the room you wish to vacate");
            bool checkForLoop = true;
            while (checkForLoop)
            {
                var answer = int.TryParse(Console.ReadLine(), out int numberRoom);
                if (answer)
                {
                    bool vacate = false;
                    bool roomIsAlredyFree = false;
                    foreach (var room in ApplicationDbContext.listRooms)
                    {
                        if (room.Number == numberRoom)
                        {
                            if (room.RoomStatus)
                            {
                                roomIsAlredyFree = true;
                            }
                            room.RoomStatus = true;
                            vacate = true;
                            break;
                        }
                    }
                    if (roomIsAlredyFree)
                    {
                        Console.WriteLine("This room is not in the booked room. Please enter the correct number");
                    }
                    else if (vacate)
                    {
                        Console.WriteLine($"Successful operation. The room with number {numberRoom} has been vacated.");
                        checkForLoop = false;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("No room with this number.Try again");
                    }
                }
                else
                {
                    Console.WriteLine("You have not entered a number.Try again");
                }
            }
        }
    }
}
