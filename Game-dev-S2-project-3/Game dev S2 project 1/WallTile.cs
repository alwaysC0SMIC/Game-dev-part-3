using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_dev_S2_project_1
{
    internal class WallTile : Tile
    {
        //Overrides the get accessor of the Tile class’s Display property to 
        // return a “█” character
        public override char display
        {
            get
            {
                return char.Parse("█");
            }
        }

        // A constructor that accepts a Position parameter, which is then 
        //passed to the base class constructor.
        public WallTile(Position position) : base(position)
        {
        }
    }
}
