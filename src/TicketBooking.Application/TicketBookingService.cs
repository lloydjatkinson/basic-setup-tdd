using System;

namespace TicketBooking.Application
{
    public class TicketBookingService
    {
        private readonly int capacity;

        public TicketBookingService(int capacity)
        {
            this.capacity = capacity;
        }

        public bool RequestSeats(int seats)
        {
            if (seats > this.capacity)
            {
                return false;
            }

            return true;
        }
    }
}