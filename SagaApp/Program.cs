using System;
using System.Collections.Generic;
using SagaApp.Activities;

namespace SagaApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var activities = new List<IActivity> { new ReserveHotelActivity(), new ReserveFlightActivity() };

            var routingConveyor = new RoutingConveyor(activities);
            routingConveyor.ProcessNext();

            Console.ReadLine();
        }
    }
}