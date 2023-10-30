using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_dev_S2_project_1
{
    public class HeroTile : CharacterTile
    {
        
        //Dispays the character tile and what state they are
        public override char display
        {
            get
            {
                if (IsDead())
                {
                    return char.Parse("x");
                }
                else
                {
                    return char.Parse("▼");
                }
            }
        }
        //Constructor for hero tile
        public HeroTile(Position pos, int hitPnts = 40, int attPwr = 5) : base(pos, hitPnts, attPwr)
        {
        }
    }
}

