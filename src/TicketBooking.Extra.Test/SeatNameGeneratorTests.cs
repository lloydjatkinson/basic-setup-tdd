using Shouldly;

using System;
using System.Collections.Generic;
using System.Linq;

using Xunit;

namespace TicketBooking.Extra.Test
{
    public class SeatNameGeneratorTests
    {
        [Fact]
        public void ShouldAcceptOnlyPositiveRowCount()
        {
            var generator = SeatNameGenerator.GenerateSeats(0, 0);
            Should.Throw<ArgumentOutOfRangeException>(() => generator.ToList());
        }

        [Fact]
        public void ShouldAcceptOnlyPositiveSeatsPerRowCount()
        {
            var generator = SeatNameGenerator.GenerateSeats(1, 0);
            Should.Throw<ArgumentOutOfRangeException>(() => generator.ToList());
        }

        [Fact]
        public void ShouldReturnSingleSeat()
        {
            var generator = SeatNameGenerator.GenerateSeats(1, 1);
            var seats = generator.ToList();

            seats.Count.ShouldBe(1);
        }

        [Fact]
        public void ShouldReturnFirstSeatInFirstRow()
        {
            var generator = SeatNameGenerator.GenerateSeats(1, 1);
            var seats = generator.ToList();

            seats.First().ShouldBe("A1");
        }

        [Fact]
        public void ShouldReturnSingleRowOfSeats()
        {
            var generator = SeatNameGenerator.GenerateSeats(1, 10);
            var seats = generator.ToList();

            seats.All(seat => seat.StartsWith("A"));
        }

        [Fact]
        public void ShouldReturnSequentialSeatNames()
        {
            var generator = SeatNameGenerator.GenerateSeats(1, 3);
            var expectedSeats = new List<string>() { "A1", "A2", "A3" };

            var seats = generator.Take(3);

            seats.ShouldBe(expectedSeats);
        }

        [Fact]
        public void ShouldReturnMultipleRowsOfSeats()
        {
            var generator = SeatNameGenerator.GenerateSeats(3, 3);
            var expectedSeats = new List<string>()
            {
                "A1", "A2", "A3",
                "B1", "B2", "B3"
            };

            var seats = generator.Take(6);

            seats.ShouldBe(expectedSeats);
        }

        [Fact]
        public void ShouldIncrementLetterSequence()
        {
            var generator = SeatNameGenerator.GenerateSeats(27, 1);
            var seats = generator.Skip(Constants.LatinAlphabetCharacters).First();

            seats.ShouldBe("AA1");
        }
    }
}