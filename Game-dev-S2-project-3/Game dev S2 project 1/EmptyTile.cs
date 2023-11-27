using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_dev_S2_project_1
{
    internal class EmptyTile : Tile
    
    {
        //Override the get accessor of the Tile class’s Display property to return 
        //a “.” character.
        public override char display
        {
            get
            {
                return char.Parse(".");
            }
        }
        //Constructor that accepts a Position parameter, which is then 
        //passed on to the base class constructor.
        public EmptyTile(Position pos) : base(pos)
        {
        }
    }
}

//refernece
//https://stackoverflow.com/questions/33946594/c-sharp-how-to-convert-string-to-char