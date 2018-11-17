using System;
using SagaApp.Work;

namespace SagaApp.Activities
{
    public class ReserveHotelActivity : ActivityBase, IActivity
    {
        private const string hotelReservationAction = "hotelReservations";
        private const string hotelCancellationAction = "hotelCancellations";
        private const string hotelNameKey = "hotelName";


        public WorkResult Do(WorkItem workItem)
        {
            Console.WriteLine("-- Reserving hotel --");
            var hotelName = workItem.Arguments[hotelNameKey];
            var reservationId = GetReservationId();
            Console.WriteLine("Reserved hotel {0}, reservation id {1}", hotelName, reservationId);

            return new WorkResult { { reservationIdKey, reservationId } };
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