using CommunityToolkit.Diagnostics;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketBooking.Extra
{
    /// <summary>
    /// Generates seat names based on a sequence.
    /// </summary>
    public static class SeatNameGenerator
    {
        /// <summary>
        /// Generates the character segment of the seat name.
        /// </summary>
        /// <remarks>
        /// Derived from the formula Excel uses for column names: https://stackoverflow.com/questions/837155/fastest-function-to-generate-excel-column-letters-in-c-sharp
        /// </remarks>
        /// <param name="columnNumber">The column number used to generate the character segment.</param>
        /// <returns>The character segment of the seat name.</returns>
        private static string SequentialName(int columnNumber)
        {
            int dividend = columnNumber + 1;
            string columnName = string.Empty;
            int modulo;

            while (dividend > 0)
            {
                modulo = (dividend - 1) % Constants.LatinAlphabetCharacters;
                columnName = Convert.ToChar(65 + modulo).ToString() + columnName;
                dividend = (dividend - modulo) / Constants.LatinAlphabetCharacters;
            }

            return columnName;
        }

        /// <summary>
        /// Generates a collection of sequential seat numbers based on the specified number of rows and seats per row.
        /// </summary>
        /// <remarks>
        /// The sequence starts at A1 and ends at Z1 and then starts at AA1.
        /// </remarks>
        /// <param name="rows"></param>
        /// <param name="seatsPerRow"></param>
        /// <returns></returns>
        public static IEnumerable<string> GenerateSeats(int rows, int seatsPerRow)
        {
            Guard.IsGreaterThanOrEqualTo(rows, 1, nameof(rows));
            Guard.IsGreaterThanOrEqualTo(seatsPerRow, 1, nameof(seatsPerRow));

            int currentRow = 0;
            int currentSeat = 1;

            while (currentRow < rows)
            {
                yield return SequentialName(currentRow) + currentSeat;

                currentSeat++;
                if (currentSeat > seatsPerRow)
                {
                    currentSeat = 1;
                    currentRow++;
                }
            }
        }
    }
}
