using Shouldly;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TicketBooking.Application;

using Xunit;

namespace TicketBooking.Test
{
    public class SeatBookingTests
    {
        [Fact]
        public void ShouldReturnStatusIndicatingNotEnoughSeats()
        {
            var ticketBookingService = new TicketBookingService(0);

            var result = ticketBookingService.RequestSeats(1);

            result.ShouldBe(false);
        }

        [Theory]
        [InlineData(15, 10, 10)]
        public void ReturnsNotEnoughSeatsAvailiable(int capacity, int firstBookingSeats, int secondBookingSeats)
        {
            var ticketBookingService = new TicketBookingService(capacity);

            var firstBooking = ticketBookingService.RequestSeats(firstBookingSeats);
            var secondBooking = ticketBookingService.RequestSeats(secondBookingSeats);

            firstBooking.ShouldBe(false);
            secondBooking.ShouldBe(true);
        }

        [Fact]
        public void ReturnsStatusIndicatingSeatsAvailiableWithBookingLessThanCapacity()
        {
            var capacity = 15;
            var firstBookingSeats = 15;

            var ticketBookingService = new TicketBookingService(capacity);

            var firstBooking = ticketBookingService.RequestSeats(firstBookingSeats);

            firstBooking.ShouldBe(true);
        }

        [Fact]
        public void ReturnsStatusIndicatingSeatsAvailiable()
        {
            var capacity = 15;
            var firstBookingSeats = 5;
            var secondBookingSeats = 5;

            var ticketBookingService = new TicketBookingService(capacity);

            var firstBooking = ticketBookingService.RequestSeats(firstBookingSeats);
            var secondBooking = ticketBookingService.RequestSeats(secondBookingSeats);

            firstBooking.ShouldBe(true);
            secondBooking.ShouldBe(true);
        }

        //[Theory]
        //public void ReturnsStatusAndNumberOfRemainingSeats()
        //{

        //}
    }
}
