using System;
using SagaApp.Work;

namespace SagaApp.Activities
{
    public class ReserveFlightActivity : ActivityBase, IActivity
    {
        private const string flightReservationAction = "flightReservations";
        private const string flightCancellationAction = "flightCancellations";
        private const string flightNumberKey = "flightNumber";

        public WorkResult Do(WorkItem workItem)
        {
            Console.WriteLine("-- Reserving flight --");

            var flightNumber = workItem.Arguments[flightNumberKey];
            //throw new Exception("Some error");
            var reservationId = GetReservationId();
            Console.WriteLine("Reserved flight {0}, reservation id {1}", flightNumber, reservationId);

            return new  WorkResult { { reservationIdKey, reservationId } };
        }

        public bool Compensate(object item)
        {
            var reservationId = item;
            Console.WriteLine("Cancelled flight {0}", reservationId);
            return true;
        }

        public Uri WorkItemQueueAddress => new Uri(BaseReservationAddress + flightReservationAction);

        public Uri CompensationQueueAddress => new Uri(BaseCompensationAddress + flightCancellationAction);
    }
}
