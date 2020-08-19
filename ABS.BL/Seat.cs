using System;
using System.Collections.Generic;
using System.Text;

namespace ABS.BL
{

    /// <summary>
    /// Class mentains information about seats.
    /// </summary>
    class Seat
    {
        public int Row { get; set; }
        public char Column { get; set; }
        public bool Status { get; set; } = true;

        public override string ToString()
        {
            return Row + " " + Column+" "+Status;
        }
    }
}
