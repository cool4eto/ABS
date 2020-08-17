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
        public FlightSection()
        {

        }
        public FlightSection(SeatClass seatClass, int rows, int cols)
        { 
            this.SeatClass = seatClass;
            if (rows >= 1 && rows <= 100 && cols >= 1 && cols <= 10)
            {
                for (int i = 0; i < cols; i++)
                {
                    for (int j = 0; j < rows; j++)
                    {
                        Seat seatToAdd = new Seat();
                        seatToAdd.Column = Convert.ToChar('A' + i);//translates the integer value to alphabethical char
                        seatToAdd.Row = j + 1;//because we want the rows to start at 1 not at 0
                        _seats.Add(seatToAdd);
                    }
                }
            }
            else
            {
                throw new ArgumentOutOfRangeException();
            }
        }
        
        public SeatClass SeatClass { get; set; }
        private List<Seat> _seats = new List<Seat>() ;

        /// <summary>
        /// Finds if the section has available seat.
        /// </summary>
        /// <returns></returns>
        public bool HasAvailableSeats()
        {
            foreach(Seat seat in _seats)
            {
                if (seat.Status) return true;
            }
            return false;
        }
        public bool BookSeat()
        {
            foreach (Seat seat in _seats)
            {
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
            foreach (Seat seat in _seats)
            {
                if (seat.Row==row&&seat.Column==col&&seat.Status)
                {
                    seat.Status = false;
                    return true;
                }
            }
            return false;
        }
        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(SeatClass.ToString());
            builder.Append("\n");
            for(int i=0;i<_seats.Count;i++)
            {
                builder.Append(_seats[i].ToString());
                builder.Append(" ; ");
            }
            return builder.ToString();
        }
    }
}
