using System;

namespace SagaApp.Activities
{
    public class ActivityBase
    {
        private static readonly Random rnd = new Random(1);

        public int GetReservationId()
        {
            return rnd.Next(100000);
        }

        public string BaseReservationAddress => "some_reservation_address://";
        public string BaseCompensationAddress => "some_compensation_address://";
    }
}