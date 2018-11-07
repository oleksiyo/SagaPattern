using System;

namespace SagaApp.Activities
{
    public class ReserveHotelActivity : ActivityBase, IActivity
    {
        private const string hotelReservationAction = "hotelReservations";
        private const string hotelCancellationAction = "hotelCancellations";

        public object Do(string name)
        {
            Console.WriteLine("-- Reserving hotel --");

            var reservationId = GetReservationId();
            Console.WriteLine("Reserved hotel {0}, reservation id {1}", name, reservationId);
            return new { reservationId };
        }

        public bool Compensate(object item)
        {
            var reservationId = item;
            Console.WriteLine("Cancelled hotel {0}", reservationId);
            return true;
        }

        public Uri WorkItemQueueAddress => new Uri(BaseReservationAddress + hotelReservationAction);

        public Uri CompensationQueueAddress => new Uri(BaseCompensationAddress + hotelCancellationAction);
    }
}