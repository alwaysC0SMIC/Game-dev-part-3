using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_dev_S2_project_1
{
    public class Position
    {
        //Two integer fields, one storing the x-cordinate and the other storing the y-coordinate
        public int XCod { get; set; }
        public int YCod { get; set; }

        //Constructor that assigns the values to the corresponding x and y fields.
        public Position(int xcod, int ycod)
        {
            XCod = xcod;
            YCod = ycod;
        }
    }
}
