using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_dev_S2_project_1
{
    //Part 3 Q2.3
    public class TyrantTile : EnemyTile
    {
        private Position tyrantPosition;
        private Level currentlvl;

        public TyrantTile(Position pos, Level lvl, int hitPoints = 15, int attackPower = 5): base(pos, hitPoints, attackPower, lvl) {
            tyrantPosition = pos;
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
                    return char.Parse("§");

                }
            }
        }

        //Check for potential empty tiles in the tyrant's vision array
        public override bool GetMove(out Tile targetTile)
        {
            //Default values
            bool isEmpty = false;
            int j = 0;
            int index;
            targetTile = null;
            Tile[] potentialTiles = new Tile[4];

            HeroTile ht = currentlvl.getHeroTile();

            //Loops through vision array to find empty tiles, then assigns to potential tiles
            for (int i = 0; i < visionArray.Length; i++)
            {
                if (visionArray[i].display == '.')
                {
                    isEmpty = true;
                    potentialTiles[j] = visionArray[i];
                    
                }
                else
                {
                    potentialTiles[j] = null;
                }

                j++;

            }

            //Checks if tyrant is already in range of hero
            if ((this.x == ht.x + 1 || this.x == ht.x - 1) && (this.y == ht.y + 1 || this.y == ht.y - 1))
            {
                isEmpty = false;
                targetTile = null;
            } else {
                //Determines which move to make if not in range
                //First attempts move on y axis, then on x axis, if niether are possible it returns null

                //Quadrant 1 check (Hero is above to the right)
                if (ht.x >= this.x && ht.y >= this.y)
                {
                    if (potentialTiles[0] != null)
                    {
                        targetTile = potentialTiles[0];
                        isEmpty = true;
                    }
                    else
                    {
                        if (potentialTiles[1] != null)
                        {
                            targetTile = potentialTiles[1];
                            isEmpty = true;
                        }
                        else
                        {
                            targetTile = null;
                            isEmpty = false;
                        }
                    }
                }

                //Quadrant 2 check (Hero is below to the right)
                if (ht.x >= this.x && ht.y <= this.y)
                {
                    if (potentialTiles[2] != null)
                    {
                        targetTile = potentialTiles[2];
                        isEmpty = true;
                    }
                    else
                    {
                        if (potentialTiles[1] != null)
                        {
                            targetTile = potentialTiles[1];
                            isEmpty = true;
                        }
                        else
                        {
                            targetTile = null;
                        }
                    }
                }

                //Quadrant 3 check (Hero is below to the left)
                if (ht.x <= this.x && ht.y <= this.y)
                {
                    if (potentialTiles[2] != null)
                    {
                        targetTile = potentialTiles[2];
                        isEmpty = true;
                    }
                    else
                    {
                        if (potentialTiles[3] != null)
                        {
                            targetTile = potentialTiles[3];
                            isEmpty = true;
                        }
                        else
                        {
                            targetTile = null;
                        }
                    }
                }

                //Quadrant 4 check (Hero is above to the left)
                if (ht.x <= this.x && ht.y >= this.y)
                {
                    if (potentialTiles[1] != null)
                    {
                        targetTile = potentialTiles[1];
                        isEmpty = true;
                    }
                    else
                    {
                        if (potentialTiles[3] != null)
                        {
                            targetTile = potentialTiles[3];
                            isEmpty = true;
                        }
                        else
                        {
                            targetTile = null;
                        }
                    }
                }
            }
            return isEmpty;
            }

        //Checks tile array of level, attacks all character tiles in range
        public override CharacterTile[] GetTargets()
        {
            CharacterTile[] targetTiles = null;
            int j = 0;

            EnemyTile[] enemyTargets = currentlvl.GetEnemyTiles();
            HeroTile heroTarget = currentlvl.getHeroTile();

            //Checks if any enemy tiles are in range
            for (int i = 0; i < enemyTargets.Length; i++)
            {
                if (enemyTargets[i].x == this.x || enemyTargets[i].y == this.y)
                {
                    targetTiles[j] = enemyTargets[i];
                    j++;
                    //!!causes crash when going to a next level!!
                }
            }

            //Checks if hero tile is in range
            if (heroTarget.x == this.x || heroTarget.y == this.y)
            {
                targetTiles[j] = heroTarget;
                j++;
            }

            return targetTiles;
        }

    }
}
