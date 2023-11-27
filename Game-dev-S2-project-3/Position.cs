using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_dev_S2_project_1
{

    internal class Position
    //Q.2.1
    {
        private int XCod { get; set; }
        private int YCod { get; set; }

        public Position(int xcod, int ycod)
        {
            XCod = xcod;
            YCod = ycod;
        }
    }





    
}
//Requirements
//Two private integer fields, one storing the x-coordinate and the other 
//storing the y-coordinate. xx
// A constructor that accepts two integer parameters, the x and y coordinate.xx 
//The constructor should then assign these values to the corresponding x and 
//y fields. xx
//Finally, create two properties one for each of the x-coordinate and y-coordinate backing fields. It should allow for accessing and modifying these 
//backing fields xx
