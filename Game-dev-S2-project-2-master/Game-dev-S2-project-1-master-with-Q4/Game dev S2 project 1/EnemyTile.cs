using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_dev_S2_project_1
{
    public abstract class EnemyTile : CharacterTile
    {
        //Part 2 Q2.1
        //Constructor with position, hit points and attack power parameters
        //Part 3 Q2.1
        //Level parameter added to constructor
        public EnemyTile(Position pos, int hitPoints, int attPower, Level lvl) : base(pos, hitPoints, attPower)
        {   
        }

        //Checks if there are any empty tiles in the grunt’s vision array
        public abstract bool GetMove(out Tile targetTile);

        //Returns a CharacterTile array of targets
        public abstract CharacterTile[] GetTargets();
    }
}//References:
//https://www.geeksforgeeks.org/c-sharp-abstract-classes/
