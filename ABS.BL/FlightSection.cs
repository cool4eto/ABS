using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;

namespace ABS.BL
{
    public enum SeatClass { First, Business, Economy };
    public class FlightSection
    {
        public SeatClass SeatClass { get; set; }
        private Seat[,] _seats = new Seat[100, 10];

        public FlightSection(SeatClass seatClass, int rows = 1, int cols = 1)
        { 
            //first we throw exception
            this.SeatClass = seatClass;
            if (rows < 1 || rows > 100 || cols < 1 || cols > 10)
                throw new Exception(ExceptionHelper.FlightSectionTooBig);

            for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < cols; j++)
                    {
                        Seat seatToAdd = new Seat();
                        seatToAdd.Column = Convert.ToChar('A' + j);//translates the integer value to alphabethical char
                        seatToAdd.Row = i + 1;//because we want the rows to start at 1 not at 0
                        _seats[i, j] = seatToAdd;
                    }
                }
        }
        
        /// <summary>
        /// Finds if the section has available seat.
        /// </summary>
        /// <returns></returns>
        public bool HasAvailableSeats()
        {
            foreach(Seat seat in _seats)
            {   
                if (seat == null) break;
                if (seat.Status) return true;
            }

            return false;
        }

        public bool BookSeat()
        {
            foreach (Seat seat in _seats)
            {
                if (seat == null) break;
                if (seat.Status)
                {
                    seat.Status = false;
                    return true;
                }
            }

            return false;
        }

        public bool BookSeat(int row, char col)
        {
            if (row < 1 || row > 100) 
                throw new Exception(ExceptionHelper.RowOutOfBouund);
            //The range of the upper case letters A-J is 65 to 74 we use that to determine if the col value is correct
            int colToInt = col;
            if (colToInt < 65 || colToInt > 74) 
                throw new Exception(ExceptionHelper.ColumnOutOfBound);
            Seat seatToBook = _seats[row - 1, colToInt - 65];
            if ( seatToBook == null||!seatToBook.Status) 
                return false;
            _seats[row - 1, colToInt - 65].Status=false;

            return true; 
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append($"{SeatClass.ToString()}\n");
            foreach (Seat seat in _seats)
            {
                if (seat == null) break;
                builder.Append($"{seat};");
            }

            return builder.ToString();
        }
    }
}
