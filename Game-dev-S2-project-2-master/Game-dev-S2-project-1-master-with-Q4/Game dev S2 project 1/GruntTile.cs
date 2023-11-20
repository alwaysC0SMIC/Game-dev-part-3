using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_dev_S2_project_1
{
    public class GruntTile : EnemyTile
    {
        //Part 2 Q2.2
        //Part 3 Q2.1 - Added level parameter
        public GruntTile(Position pos, Level lvl, int hitPoints = 10, int attPower = 1) : base(pos, hitPoints, attPower, lvl)
        {
        }

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
                    return char.Parse("Ϫ");
                    
                }
            }
        }

        //Check if there are any empty tiles in the grunt’s vision array
        public override bool GetMove(out Tile targetTile)
        {
            //Default values
            bool isEmpty = false;
            int j = 0;
            targetTile = null;
            Tile[] potentialTiles = new Tile[4];

            //Loops through vision array to find empty tiles, then assigns to potential tiles
            for (int i = 0; i < visionArray.Length; i++)
            {
                if (visionArray[i].display == '.') {
                    isEmpty = true;
                    potentialTiles[j] = visionArray[i];
                    j++;
                }
            }
            //Selects random tile out of available empty tiles if available
            if (isEmpty)
            {
                Random rnd = new Random();
                int index = rnd.Next(0, potentialTiles.Length);
                targetTile = potentialTiles[index];
            }
            return isEmpty;
        }

        //Checks vision array of grunt to see if there is a hero tile, if one is in range it gets returned
        public override CharacterTile[] GetTargets()
        {
            //This will need to be updated to include other enemy types in part 3, for now just affects the hero tile
            //will need a counter in part 3 to keep 
            
            int j = 0;
            CharacterTile[] tempChar = new CharacterTile[4];

            for (int i = 0;  i < visionArray.Length; i++)
            {

                if (visionArray[i].display == '▼')
                {
                    try
                    {
                        tempChar[j] = visionArray[i] as HeroTile;
                    }
                    catch (NullReferenceException ex)
                    { 
                    }
                }
            }

            return tempChar;

        }
    }
}
