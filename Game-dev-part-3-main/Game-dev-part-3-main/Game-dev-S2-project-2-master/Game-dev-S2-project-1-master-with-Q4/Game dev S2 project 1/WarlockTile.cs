using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_dev_S2_project_1
{
    //Part 3 Q2.2
    public class WarlockTile : EnemyTile
    {
        private Position warlockPos;
        private Level currentlvl;

        public WarlockTile(Position pos, Level lvl, int hitpoints = 10, int attackPower = 5) : base(pos, hitpoints, attackPower, lvl)
        {
            warlockPos = pos;
            currentlvl = lvl;
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
                    return char.Parse("ᐂ");
                }
            }
        }

        //Returns null as warlock tiles cannot move
        public override bool GetMove(out Tile targetTile)
        {
            targetTile = null;
            return false;
        }

        //Checks surrounding tiles of warlock using vision array and level object to find targets (both hero and enemy)
        public override CharacterTile[] GetTargets()
        {
            Tile[] adjacentVisionArray = new Tile[8];
            //Tiles from Vision Array
            adjacentVisionArray[0] = visionArray[0];
            adjacentVisionArray[1] = visionArray[1];
            adjacentVisionArray[2] = visionArray[2];
            adjacentVisionArray[3] = visionArray[3];
            //Finds targets adjacent to warlock Tile
            Tile[,] array = currentlvl.array2D;
            //Upper Left Tile
            adjacentVisionArray[4] = array[warlockPos.XCod-1, warlockPos.YCod - 1];
            //Upper Right Tile
            adjacentVisionArray[5] = array[warlockPos.XCod + 1, warlockPos.YCod - 1];
            //Lower Left Tile
            adjacentVisionArray[6] = array[warlockPos.XCod - 1, warlockPos.YCod + 1];
            //Lower Right Tile
            adjacentVisionArray[7] = array[warlockPos.XCod + 1, warlockPos.YCod + 1];

            //Checks the adjacent vision array for hero/enemy tiles
            int j = 0;
            List<CharacterTile> warlockTargets = new List<CharacterTile>();
            for (int i = 0; i < adjacentVisionArray.Length; i++)
            {
                if (adjacentVisionArray[i].display == '▼' || adjacentVisionArray[i].display == 'Ϫ' || adjacentVisionArray[i].display == '§')
                {
                    try
                    {
                        if (adjacentVisionArray[i].display == '▼')
                        {
                            warlockTargets.Add(adjacentVisionArray[i] as HeroTile);
                        }
                        else {
                            warlockTargets.Add(adjacentVisionArray[i] as EnemyTile);
                        }
                    }
                    catch (NullReferenceException ex)
                    {
                    }
                }
            }
            //Converts List to array
            CharacterTile[] tempChar = warlockTargets.ToArray();
            return tempChar;
        }

    }
    //References:
    //https://www.programiz.com/csharp-programming/list#:~:text=List%20is%20a%20class,1%2C%202%20and%203
    //https://stackoverflow.com/questions/629178/conversion-from-listt-to-array-t
}
