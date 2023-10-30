using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_dev_S2_project_1
{

    public abstract class CharacterTile : Tile
    {
        //Variables
        Position charPos;
        private int hitPoints, maxHitPoints, attPower;
        public Tile[] visionArray;

        //Constructor that assigns variables
        public CharacterTile(Position pos, int hitPnts, int attPwr) : base(pos)
        {
            charPos = pos;
            hitPoints = hitPnts;
            attPower = attPwr;
            maxHitPoints = hitPnts;
            visionArray = new Tile[4];

            // Initializing vision field
        }

        //Updates the vision tiles according to the character's position
        public void UpdateVision(Level lvl)
        {
            try
            {
                Tile[,] array = lvl.array2D;

                Tile tileUp = array[charPos.XCod, charPos.YCod - 1];
                Tile tileDown = array[charPos.XCod, charPos.YCod + 1];
                Tile tileLeft = array[charPos.XCod - 1, charPos.YCod];
                Tile tileRight = array[charPos.XCod + 1, charPos.YCod];

                visionArray[0] = tileUp;
                visionArray[1] = tileRight;
                visionArray[2] = tileDown;
                visionArray[3] = tileLeft;


            }
            catch (NullReferenceException ex)
            {
            }
        }


        //Subtracts damage taken from character's hitpoints
        public void TakeDamage(int dmg)
        {
            hitPoints = hitPoints - dmg;
            if (hitPoints < 0)
            {
                hitPoints = 0;
            }
        }

        //Deals damage to targeted character object based off characters attack power
        public void Attack(CharacterTile attChar)
        {
            attChar.TakeDamage(attPower);
        }

        //Checks if character has any remaining hit points
        public bool IsDead()
        {
            return hitPoints <= 0;
        }
        // restores character's hit points, if the maxhitpoints are lower than the restored hit points. The hitpoints changes the amount from ther maxhitpoints
        public void Heal(int resamount)
        {


            hitPoints += resamount;
            if (hitPoints >= maxHitPoints)
            {
              hitPoints = maxHitPoints;
               
            }



        }

        //Accessor method for exposing character's hitpoints
        public int HP()
        {
            return hitPoints;
        }

    }
    //References:
    //https://learn.microsoft.com/en-us/dotnet/csharp/fundamentals/exceptions/exception-handling
}


