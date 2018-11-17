using System;

namespace SagaApp.Activities
{
    public class ReserveFlightActivity : ActivityBase, IActivity
    {
        private const string flightReservationAction = "flightReservations";
        private const string flightCancellationAction = "flightCancellations";

        public object Do(string name)
        {
            Console.WriteLine("-- Reserving flight --");
            throw new Exception("Some error");
            var reservationId = GetReservationId();
            Console.WriteLine("Reserved flight {0}, reservation id {1}", name, reservationId);
            return new { reservationId };
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
