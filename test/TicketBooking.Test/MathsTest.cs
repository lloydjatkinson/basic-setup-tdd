using Shouldly;
using Xunit;

namespace TicketBooking.Test
{
    public class MathsTest
    {
        [Theory]
        [InlineData(1, 2)]
        public void AddingPositiveNumbersReturnsPositiveNumber(int first, int second)
        {
            var result = first + second;

            result.ShouldBePositive();
        }
    }
}