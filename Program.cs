using System;
using System.Collections.Generic;

namespace HotelManagementSystem
{
    public enum RoomStyle
    {
        King,
        Twin,
        Queen
    }

    public class HotelRoom
    {
        public int RoomNumber { get; }
        public RoomStyle Style { get; }
        public bool IsBooked { get; set; }

        public HotelRoom(int roomNumber, RoomStyle style)
        {
            RoomNumber = roomNumber;
            Style = style;
            IsBooked = false;
        }
    }

    public class Hotel
    {
        public string Name { get; }
        public string Address { get; }
        public List<HotelRoom> Rooms { get; }

        public Hotel(string name, string address)
        {
            Name = name;
            Address = address;
            Rooms = new List<HotelRoom>();
        }

        public void AddRoom(HotelRoom room)
        {
            Rooms.Add(room);
        }

        public void DisplayAvailableRooms()
        {
            Console.WriteLine($"Available rooms at {Name}:");
            foreach (var room in Rooms)
            {
                if (!room.IsBooked)
                {
                    Console.WriteLine($"Room {room.RoomNumber} - {room.Style}");
                }
            }
        }

        public void DisplayBookedRooms()
        {
            Console.WriteLine($"Booked rooms at {Name}:");
            foreach (var room in Rooms)
            {
                if (room.IsBooked)
                {
                    Console.WriteLine($"Room {room.RoomNumber} - {room.Style}");
                }
            }
        }
    }

    public class Guest
    {
        public string Name { get; }
        public List<HotelRoom> BookedRooms { get; }

        public Guest(string name)
        {
            Name = name;
            BookedRooms = new List<HotelRoom>();
        }

        public void DisplayBookedRooms()
        {
            Console.WriteLine($"Booked rooms for guest {Name}:");
            foreach (var room in BookedRooms)
            {
                Console.WriteLine($"Room {room.RoomNumber} - {room.Style}");
            }
        }
    }

    public class Reservation
    {
        public HotelRoom Room { get; }
        public DateTime CheckInDate { get; }
        public DateTime CheckOutDate { get; }

        public Reservation(HotelRoom room, DateTime checkInDate, DateTime checkOutDate)
        {
            Room = room;
            CheckInDate = checkInDate;
            CheckOutDate = checkOutDate;
        }

        public int CalculateTotalNights()
        {
            TimeSpan duration = CheckOutDate - CheckInDate;
            return duration.Days;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Create hotels
            Hotel hotel1 = new Hotel("TwinStar Hotel", "876 Main St");
            Hotel hotel2 = new Hotel("SHALLA Resort", "653 STC St");

            // Add rooms to hotels
            hotel1.AddRoom(new HotelRoom(111, RoomStyle.Twin));
            hotel1.AddRoom(new HotelRoom(112, RoomStyle.King));
            hotel2.AddRoom(new HotelRoom(133, RoomStyle.Queen));
            hotel2.AddRoom(new HotelRoom(134, RoomStyle.King));

            // Display available rooms
            hotel1.DisplayAvailableRooms();
            hotel2.DisplayAvailableRooms();

            // Make reservations
            Guest guest1 = new Guest("Ms.Yanna");
            Reservation reservation1 = new Reservation(hotel1.Rooms[0], new DateTime(2024, 4, 5), new DateTime(2024, 4, 15));
            Reservation reservation2 = new Reservation(hotel2.Rooms[1], new DateTime(2024, 5, 9), new DateTime(2024, 5, 20));
            guest1.BookedRooms.Add(reservation1.Room);
            guest1.BookedRooms.Add(reservation2.Room);

            // Display booked rooms of a guest
            guest1.DisplayBookedRooms();

            // Display reservation details of a guest
            Console.WriteLine($"Total nights for reservation 1 for {guest1.Name}: {reservation1.CalculateTotalNights()}");
            Console.WriteLine($"Total nights for reservation 2 for {guest1.Name}: {reservation2.CalculateTotalNights()}");
        }
    }
}
