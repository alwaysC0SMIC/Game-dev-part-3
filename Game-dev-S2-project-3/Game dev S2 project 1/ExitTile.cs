using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_dev_S2_project_1
{
    public class ExitTile : Tile
    {
        public Boolean ExitUnlocked  = false;
        

        //Displays whether the exit is locked or unlocked
        public override char display
        {
            
            get
            {
                if (ExitUnlocked)
                {
                    
                    return char.Parse("▒");

                }
                else
                {
                    return char.Parse("▓");
                    
                }
                
            }
        }
        

        //Accepts a Position parameter and passes it on to the base class constructor
        public ExitTile(Position position) : base(position)
        {
        }

    }
}
