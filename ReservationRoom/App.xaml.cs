using ReservationRoom.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace ReservationRoom
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            Hotel hotel = new Hotel("President Suites");

            hotel.MakeReservation(new Reservation(
                new RoomID(1, 1),
                "Gilang Agung Saputra",
                new DateTime(2023,1,1),
                new DateTime(2023,1,2)
                ));

            base.OnStartup(e);
        }
    }
}
