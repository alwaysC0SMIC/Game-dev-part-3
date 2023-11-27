using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_dev_S2_project_1
{
    internal class EmptyTile : Tile
    //Q2.3
    {

        public override char display 
        { 
            get
            {
                return char.Parse(".");

            }


        }
        
        public EmptyTile(Position pos) : base(pos)
        {
            


        }



        
    }
}
//Requirements
//The requirements for the EmptyTile class are as follows:
//It must extend the Tile class. xx
//It must have a constructor that accepts a Position parameter, which is then 
//passed on to the base class constructor. xx
//It must override the get accessor of the Tile class’s Display property to return 
//a “.” character.xx


//refernece
//https://stackoverflow.com/questions/33946594/c-sharp-how-to-convert-string-to-char