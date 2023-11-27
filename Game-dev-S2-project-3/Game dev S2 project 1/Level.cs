using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game_dev_S2_project_1
{
    public class Level
    {
        public Tile[,] array2D;
        // 2D array of type Tile
        private int Width;
        private int Height;
        private HeroTile heroTile = new HeroTile(null);
        private ExitTile exitTile;

        //Part 2 Q2.3
        //Stores all enemies in the level
        private EnemyTile[] enemyArray;

        private PickUpTile pickUpTile;

        //If all enemies are dead the exit unlocks
        public void UpdateExit(EnemyTile[] enemyArray)
        {

            exitTile.ExitUnlocked = true;        
           
            for (int i = 0; i < enemyArray.Length; i++)
            {
                if (enemyArray[i].HP() > 0)
                {
                    exitTile.ExitUnlocked = false;
                    i = enemyArray.Length;

                }
            }
        }

        //A random will determine whether a health pickup or buff attack pickup is created
        private PickUpTile CreatPickupTile (Position position)
        {
            PickUpTile result;

            Random rand = new Random();
            int ran = rand.Next(1,101);
            
            
            if (ran > 65)
            {
                result = new HealthPickUpTile(position);
                
            }
            else
            {
                result = new AttackBuffPickup_Tile(position);
                
            }

            return result;
        }
  

    public PickUpTile pick
        {
            get
            {
                return pickUpTile;
            }
        }
        public int text
        {
            set;
            get;
        }
        private List<Position> pickupPos;

        //Enum called TileType that has values
        public enum TileType
        {
            Empty,
            Wall,
            Hero,
            Exit,
            Enemy,
            PickUp,
        }

        //Direction enum for moving the hero character
        public enum Direction
        {
            Up,
            Right,
            Down,
            Left,
            None,
        }

        //The constructor  initialises the 2D Tile array, using the width and the 
        //height values as the array’s dimensions.
        public Level(int width, int height, int enemyNum, HeroTile ht = null, int numPick = 1)
        {
            Width = width;
            Height = height;
            array2D = new Tile[Width, Height];
            enemyArray = new EnemyTile[enemyNum];
            Random r = new Random();
            InitialiseTiles();
            
            //Creates a new hero tile + object if one doesn't already exist
            //If it exists, it gets assigned a new position
            Position randomHero = GetRandomEmptyPosition();

            if (ht == null)
            {
              CreateTile(TileType.Hero, randomHero);
              heroTile = new HeroTile(randomHero);
            }
            else
            {
                ht.x = randomHero.XCod;
                ht.y = randomHero.YCod;
                heroTile = ht;
            }
            //heroTile.UpdateVision(this);  - no longer needed

            //Populates level with enemy tiles
            for (int i = 0; i < enemyNum; i++) {
                Position randomEnemy = GetRandomEmptyPosition();

                
                enemyArray[i] = CreateTile(TileType.Enemy, randomEnemy) as EnemyTile;
            }


            UpdateVision(this, heroTile, enemyArray);

            //Sets up a random tile to be the exit tile
            Position randomExit = GetRandomEmptyPosition();
            exitTile = CreateTile(TileType.Exit, randomExit) as ExitTile;
            

            // sets random amount for pick ups to spawn
            numPick = r.Next(1, 3);
            text = numPick;
            
            pickupPos = new List<Position>();
            for (int i = 0; i < numPick; i++)
            {
                // sets a random location for pickup items to spawn
                Position randomPickup = GetRandomEmptyPosition();
                CreateTile(TileType.PickUp, randomPickup);
                HealthPickUpTile pt = new HealthPickUpTile(randomPickup);
                pickUpTile = pt;
                pickupPos.Add(randomPickup);
            }
        }

        //Allows the CreatTile method to use the x and y integers
        private Tile CreateTile(TileType type, int x, int y)
        {
            Position pos = new Position(x, y);
            return CreateTile(type, pos);
        }

        //Uses the tiletype and position to decide if it will be an empty tile, wall tile, hero tile or exit tile
        public Tile CreateTile(TileType type, Position pos)
        {
            Tile tile = null;
            switch (type)
            {
                case TileType.Empty:
                    tile = new EmptyTile(pos);
                    array2D[pos.XCod, pos.YCod] = tile;
                    break;
                case TileType.Wall:
                    tile = new WallTile(pos);
                    array2D[pos.XCod, pos.YCod] = tile;
                    break;
                case TileType.Hero:
                    tile = new HeroTile(pos);
                    array2D[pos.XCod, pos.YCod] = tile;
                    break;
                case TileType.Exit:
                    tile = new ExitTile(pos);
                    array2D[pos.XCod, pos.YCod] = tile;
                    break;
                case TileType.Enemy:
                    //Produces random enemy 
                    tile = CreateEnemyTile(pos);  
                    array2D[pos.XCod, pos.YCod] = tile;
                    break;
                case TileType.PickUp: // will have differnt types of pick up items in part 3 
                    tile = CreatPickupTile(pos);
                    array2D[pos.XCod, pos.YCod] = tile;
                    break;
                default:
                    break;
            }
            return tile;
        }

        //Initialises the tiles
        private void InitialiseTiles()
        {
            for (int y = 0; y < Height; y++)    
            {
                for (int x = 0; x < Width; x++)
                {
                    if (x == 0 || x == Width - 1 || y == 0 || y == Height - 1)
                    {
                        CreateTile(TileType.Wall, x, y);
                    }
                    else
                    {
                        CreateTile(TileType.Empty, x, y);
                    }
                }
            }
        }
       
        //Will construct one long string to form the entire level’s visual representation
        //It will loop through the 2D Tile array row by row, adding each Tile’s
        //character representation to the string by accessing its Display property.
       
        public String ToString()
        {

            String result = "";

            for (int y = 0; y < Height; y++)   
            {
                for (int x = 0; x < Width; x++)
                {
                    Tile basic = array2D[(int)x, (int)y];
                    result += basic.display;
                }
                result += "\n";
            }
            return result;
        }

        
        //Finds a random empty tile, returns as Position object
        private Position GetRandomEmptyPosition()
        {
            Random rnd = new Random();
            int randomX = rnd.Next(1, Width-1);
            int randomY = rnd.Next(1, Height-1);
            bool found = false;

            while (found == false)
            {
                if (array2D[randomX, randomY].display == '.')
                {
                    found = true;
                }  
                else
                {
                    randomX = rnd.Next(1, Width - 1);
                    randomY = rnd.Next(1, Height - 1);
                }
            }
            Position ps = new Position(randomX, randomY);
            return ps;
        }

        
        //Swaps 2 tiles
        public void SwopTiles(Tile swap1, Tile swap2)
        {
            try
            {
                // Swapping Tiles in array
                array2D[swap2.x, swap2.y] = swap1;
                array2D[swap1.x, swap1.y] = swap2;

                // Swopping x and y coordinates in the tiles themselves
                int tempX, tempY;

                tempY = swap1.y;
                swap1.y = swap2.y;
                swap2.y = tempY;

                tempX = swap1.x;
                swap1.x = swap2.x;
                swap2.x = tempX;

                
            }
            catch (NullReferenceException ex)
            {
            }
        }

        // HeroTile is read only property for exposure,  the return type is HeroFile to have access
        // to all methods
        public HeroTile getHeroTile()
        {
            return heroTile;
        }

        //ExitTile is read only property for exposure
        public ExitTile getExitTile()
        {
            return exitTile;
        }

        //Accessor for enemyArray
        public EnemyTile[] GetEnemyTiles()
        {
            return enemyArray;
        }

       


        //Part 2 Q2.3 - UpdateVision method for updating all characterTiles
        public void UpdateVision(Level lvl, HeroTile ht, EnemyTile[] et)
        {
            //Hero Update
            ht.UpdateVision(lvl);

            //Enemy Update
            for (int i = 0; i < et.Length; i++)
            {
                et[i].UpdateVision(lvl);
            }
        }

        //Part 3 Q2.4
        private EnemyTile CreateEnemyTile(Position pos)
        {
            EnemyTile enemyArray = null;

            //Generates random number between 1 and 100
            Random rnd = new Random();
            int typeSelector = rnd.Next(1, 100);

            //Creates enemytile based off percentage chance
            if (1 <= typeSelector && typeSelector <= 50)
            {
                enemyArray = new GruntTile(pos, this);
            }
            else {
                if (51 <= typeSelector && typeSelector <= 80)
                {
                    enemyArray = new WarlockTile(pos, this);
                }
                else {
                    if (81 <= typeSelector && typeSelector <= 100)
                    {
                        enemyArray = new TyrantTile(pos, this);
                    }
                }
            }

            return enemyArray;  
        }




    }
}
//reference
//https://stackoverflow.com/questions/622832/how-to-build-a-tiled-map-in-java-for-a-2d-game
//https://codereview.stackexchange.com/questions/10550/creating-a-2d-array-of-map-tiles
//https://stackoverflow.com/questions/2706500/how-do-i-generate-a-random-integer-in-c
// https://stackoverflow.com/questions/72639651/c-sharp-how-to-use-values-in-array-from-one-class-to-another-class
//https://www.infoworld.com/article/3546242/how-to-use-const-readonly-and-static-in-csharp.html#:~:text=Use%20the%20readonly%20keyword%20in,or%20in%20a%20constructor%20only.