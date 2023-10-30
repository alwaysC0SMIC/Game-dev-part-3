using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_dev_S2_project_1
{
    public class ExitTile : Tile
    {
        
        //Displays the exit
        //Overrides the get accessor of the Tile class's Display property
        public override char display
        {
            get
            {
                return char.Parse("▒");
            }
        }

        //Accepts a Position parameter and passes it on to the base class constructor
        public ExitTile(Position position) : base(position)
        {
        }

    }
}
