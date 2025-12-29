using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//По архитектуре:
//Хорошей практикой было бы сделать декомпозицию на несколько классов, тк класс отвечает за многие вещи, как создание, изменение, роегистрацию и тд
//В будущем будет легче тестировать и поддерживать
namespace GeometryApp
{
    internal class HotelBooking
    {
        private int _currentRoomNumber = 0;
        //Непотокобезопасен, может произойти гонка данных,
        //два гостя могут получить один номер(переделать на потокобезопасные типы данных)
        private static List<Guest> Guests = new List<Guest>();
        //Непотокобезопасен, может произойти гонка данных(переделать на потокобезопасные типы данных)
        //Список не нужно делать статичным, список гостей не должен быть общим
        private IDatabase _database = null!;
        private IRoomService _roomService = null!;
        private string _hotelName;
        private static object _lock = new object();

        public HotelBooking(string name, IDatabase db, IRoomService roomService)
        {
            _hotelName = name;
            _database = db;
            _roomService = roomService;
        }

        public void RegisterGuest(Guest g)
        {
            //Инкрементируется без синхронизации, в многопоточной среде, если используется, то нужна защита через lock
            //Например:
            //lock(_lock)
            //{
            //    _currentRoomNumber++;
            //    g.RoomNumber = _currentRoomNumber;
            //    Guests.Add(g);
            //}
            _currentRoomNumber++;
            Guests.Add(g);
            g.RoomNumber = _currentRoomNumber;
        }

        public async void CheckAvailability(int roomId)//не позволяет ловить исключения извне, поменять реализацию, поменять void, например async Task
        {
            lock (_lock)
            {
                var available = _roomService.IsAvailable(roomId).Result;//может быть deadlock
                if (!available)
                    throw new Exception("Room is not available!");//Хорошей практикой также является создавние собственных исключений
            }
        }

        public async void SaveBooking()//Сделать также как CheckAvailability, переделать на async Task
        {
            var data = new
            {
                Hotel = _hotelName,
                Guests = Guests.Select(g => new { g.Name, g.RoomNumber }).ToList()//Непотокобезопасно
            };

            await _database.SaveAsync(data);
        }

        public static string GetAllGuestNames()//Не стоит использовать конкатенацию строк, очень сильно забивается память, нужно переделать на .join
        {
            string result = "";
            foreach (var g in Guests)//Непотокобезопасно
                result += g.Name;

            return result;
        }
    }

    public class Guest
    {
        public string Name { get; set; }//Изменил бы на required тк имя не может быть null
        public int RoomNumber { get; set; }
    }

    public interface IDatabase
    {
        Task SaveAsync(object data);
    }

    public interface IRoomService
    {
        Task<bool> IsAvailable(int roomId);
    }
}
