using System;
using System.Collections.Generic;
using SagaApp.Activities;
using SagaApp.Work;

namespace SagaApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var workItems = new WorkItem[]
            {
                new WorkItem<ReserveHotelActivity>(new WorkItemArguments{{ "hotelName", "BNB"}}),
                new WorkItem<ReserveFlightActivity>(new WorkItemArguments{{"fligthNumber", "DU-2355LE"}})
            };

            var routingConveyor = new RoutingConveyor(workItems);
            routingConveyor.ProcessNext();

            Console.ReadLine();
        }
    }
}