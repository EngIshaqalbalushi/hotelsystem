using HotelSystem.Models;
using HotelSystem.Repository;
using HotelSystem.Services;

namespace HotelSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {

            using var context = new HotelContext();

            // Repositories
            var roomRepo = new RoomRepository(context);
            var guestRepo = new GuestRepository(context);
            var reservationRepo = new ReservationRepository(context);
            var reviewRepo = new ReviewRepository(context);

            // Services
            var roomService = new RoomService(roomRepo);
            var guestService = new GuestService(guestRepo);
            var reservationService = new ReservationService(reservationRepo); // ✅ not context or guestRepo
            var reviewService = new ReviewService(reviewRepo);


            // Menu Loop
            while (true)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("========== HOTEL ROOM MANAGEMENT ==========");
                Console.ResetColor();

                Console.WriteLine("1. Add Room");
                Console.WriteLine("2. Add Guest");
                Console.WriteLine("3. Make Reservation");
                Console.WriteLine("4. Leave Review");
                Console.WriteLine("5. View All Rooms");
                Console.WriteLine("6. View All Reservations");
                Console.WriteLine("7. View Reviews for Room");
                Console.WriteLine("0. Exit");
                Console.Write("Choice: ");

                var choice = Console.ReadLine();
                Console.WriteLine();

                switch (choice)
                {
                    case "1":
                        Console.Write("Room Number: ");
                        int roomNum = int.Parse(Console.ReadLine()!);
                        Console.Write("Daily Rate: ");
                        double rate = double.Parse(Console.ReadLine()!);
                        roomService.AddRoom(new Room { RoomNumber = roomNum, DailyRate = rate, IsReserved = false });
                        break;

                    case "2":
                        Console.Write("Guest Name: ");
                        string guestName = Console.ReadLine()!;
                        guestService.AddGuest(new Guest { GuestName = guestName });
                        break;

                    case "3":
                        Console.Write("Guest Name: ");
                        string gName = Console.ReadLine()!;
                        Console.Write("Room Number: ");
                        int rNum = int.Parse(Console.ReadLine()!);
                        Console.Write("Nights: ");
                        int nights = int.Parse(Console.ReadLine()!);
                        reservationService.AddReservation(new Reservation
                        {
                            GuestName = gName,
                            RoomNumber = rNum,
                            Nights = nights
                        });
                        break;

                    case "4":
                        Console.Write("Guest Name: ");
                        string reviewGuest = Console.ReadLine()!;
                        Console.Write("Room Number: ");
                        int reviewRoom = int.Parse(Console.ReadLine()!);
                        Console.Write("Rating (1-5): ");
                        int rating = int.Parse(Console.ReadLine()!);
                        Console.Write("Comment: ");
                        string? comment = Console.ReadLine();

                        reviewService.AddReview(new Review
                        {
                            GuestName = reviewGuest,
                            RoomNumber = reviewRoom,
                            Rating = rating,
                            Comment = comment
                        });
                        break;

                    case "5":
                        var rooms = roomService.GetAllRooms();
                        foreach (var room in rooms)
                            Console.WriteLine($"Room {room.RoomNumber} | Rate: {room.DailyRate} | Reserved: {room.IsReserved}");
                        break;

                    case "6":
                        var res = reservationService.GetAllReservations();
                        foreach (var r in res)
                            Console.WriteLine($"Guest: {r.GuestName} | Room: {r.RoomNumber} | Nights: {r.Nights} | Cost: {r.TotalCost}");
                        break;

                    case "7":
                        Console.Write("Room Number: ");
                        int revRoom = int.Parse(Console.ReadLine()!);
                        var reviews = reviewService.GetReviewsByRoom(revRoom);
                        foreach (var review in reviews)
                            Console.WriteLine($"[{review.Rating}★] {review.GuestName}: {review.Comment}");
                        break;

                    case "0":
                        return;

                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }

                Console.WriteLine("\nPress Enter to continue...");
                Console.ReadLine();
            }

        }
    }
}
