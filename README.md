# basic-setup-tdd

I used this while I was interviewing for a role. Despite being a big advocate for testing, maintainable, and good software the interview spent 20 minutes pointlessly debating the names for unit tests. TDD far beyond any useful practicallity was instilled and I felt like it was mainly a wholly pointless exercise and left the interview feeling unhappy with the approach or the little time (1 hour) for the level of discussion, design, detail obsession required.

Without any exageration this is the only code I was literally *allowed* to write during the interview, along with tests for it:

```cs
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
```

Here's some conversation (and a useful link within) about TDD gone wrong: https://www.reddit.com/r/programming/comments/wrlt1s/i_have_complicated_feelings_about_tdd/
