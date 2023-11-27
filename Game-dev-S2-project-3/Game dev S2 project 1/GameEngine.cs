using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_dev_S2_project_1
{
    public class GameEngine
    {
        //NumLevels stores the number of levels in the game
        private Level currentlevel;
        private int NumLevels;
        private int currentLevelNumber = 1;
        //private random used for rolling random numbers

        private Random random;
        const int MIN_SIZE = 10;
        const int MAX_SIZE = 20;

        //Enum for tracking level state
        private GameState game = GameState.InProgress;

        //Amount of moves made in the game
        private int numMoves = 0;

        public string heroStats;
        public string nopickups;

        //This is debug code that was used inititally to determine damage but is currently used for status of exit
        public string heroDamage;

        public GameEngine(int NumLevels)
        {
            //The width and height of the level will be determined by rolling
            //a random number between MIN_SIZE and MAX_SIZE for both the width
            //and the height of the level

            Random rnd = new Random();
            int width = rnd.Next(MIN_SIZE, MAX_SIZE + 1);
            int height = rnd.Next(MIN_SIZE, MAX_SIZE + 1);
            this.NumLevels = NumLevels;
            currentlevel = new Level(width, height, currentLevelNumber);
            nopickups = getPicUpNo();


        }
        //This method will return the ToString value of the current-level , or an end screen if the game is completed
        public String ToString()
        {
            String result = "";

            if (game == GameState.Complete)
            {
                result = "CONGRATULATIONS, YOU'VE FINISHED THE GAME!";
            }
            else if (game == GameState.InProgress) {
                result = currentlevel.ToString();
            } 
            else if (game == GameState.GameOver) {
                result = "GAME OVER";
            }

            return result;
        }

        //MoveHero method which signifies the desired move
        private bool MoveHero(Level.Direction move)
        {
            
            bool success = false;
            int targetTile = (int)move;

            HeroTile hero = currentlevel.getHeroTile();

            nopickups = "Tile Image: " + hero.visionArray[targetTile].display;
            //Checks if tile is an exit tile and unlocked
            if (hero.visionArray[targetTile].display == '▒') {
                success = true;
                nopickups = "Entered next level";
                if (currentLevelNumber >= NumLevels)
                {
                    game = GameState.Complete;
                    success = false;
                }
                else {
                    NextLevel();
                    success = true;
                }
            }

            //checks if tile is an empty tile
            if (hero.visionArray[targetTile].display == '.')
            {
                success = true;
                currentlevel.SwopTiles(hero.visionArray[targetTile], currentlevel.getHeroTile());
                currentlevel.UpdateVision(currentlevel, currentlevel.getHeroTile(), currentlevel.GetEnemyTiles());
            }

            // checks if tiles is a HealthPickUp Tile
            if (hero.visionArray[targetTile].display == '+'|| hero.visionArray[targetTile].display == '*')
            {
                success = true;
                Position recent = new Position(hero.visionArray[targetTile].x, hero.visionArray[targetTile].y);
              
                currentlevel.pick.ApplyEffect(hero);
                currentlevel.CreateTile(Level.TileType.Empty, recent);
               
                hero.UpdateVision(currentlevel);
                



            }
            return success;
        }

        //Calls MoveHero()
        public void TriggerMovement(Level.Direction move)
        {
            if (game != GameState.GameOver)
            {

                numMoves++;
                if (numMoves % 2 == 0)
                {
                    MoveHero(move);
                    MoveEnemies();
                }
                else
                {
                    MoveHero(move);
                }

                heroDamage = getHeroDamage();
            }
        }

        
        //Global enum for tracking progress regarding levels
        public enum GameState { 
        InProgress,
        Complete,
        GameOver,
        }

        //Loads next level while maintaining hero's attributes across levels
        public void NextLevel() {
            currentLevelNumber++;
            HeroTile tempHero = currentlevel.getHeroTile();

            Random rnd = new Random();
            int width = rnd.Next(MIN_SIZE, MAX_SIZE + 1);
            int height = rnd.Next(MIN_SIZE, MAX_SIZE + 1);

            currentlevel = new Level(width, height, currentLevelNumber, tempHero);
            // possible bug, there is no pick up
           
        }

        //Part 2 - Q2.4
        
        private void MoveEnemies() 
        {

            EnemyTile[] enemyArray = currentlevel.GetEnemyTiles();
            Tile target;

            for (int i = 0; i < enemyArray.Length; i++)
            {
                if (enemyArray[i].IsDead())
                {}
                else
                {
                    if (enemyArray[i].GetMove(out target)) 
                    {
                        if (target != null)
                        {
                            currentlevel.SwopTiles(enemyArray[i], target);
                        }  
                    }
                }    
            }
            currentlevel.UpdateVision(currentlevel, currentlevel.getHeroTile() ,enemyArray);
        }

        //Part 2 - Q3.1
        //Checks if the hero can attack a nearby character tile if one is available in the vision array
        private bool HeroAttack(Level.Direction direct) {
            //Part 2 Q3.3
            if (game != GameState.GameOver)
            {
                bool success = false;
                HeroTile ht = currentlevel.getHeroTile();
                CharacterTile ct;
                Tile targetTile;

                try
                {
                    targetTile = ht.visionArray[(int)direct];

                    if (targetTile.display == 'Ϫ' || targetTile.display == 'ᐂ' || targetTile.display == '§')
                    {
                        success = true;

                        
                        // Get EnemyTile for array
                        EnemyTile[] enemyArray = currentlevel.GetEnemyTiles();
                        ht.Attack(enemyArray[0]);
                       
                        for (int i = 0; i < enemyArray.Length; i++)
                        {
                            if (enemyArray[i].x == targetTile.x &&
                                enemyArray[i].y == targetTile.y)
                            {

                                
                                ht.Attack(enemyArray[i]);

                            }

                        }
                        
                        
                    }
                    else
                    {
                        success = false;
                    }

                }
                catch (NullReferenceException ex)
                {
                    success = false;
                }


                return success;
            }
            return false;
        }

        
        public void TriggerAttack(Level.Direction direct)
        {
            if (game != GameState.GameOver) 
            {

                //Will be updated later in POE
                HeroAttack(direct);
                EnemiesAttack();
                heroStats = getHeroStats();
                heroDamage = getHeroDamage();
                //nopickups = getPicUpNo();
               

                if (currentlevel.getHeroTile().IsDead())
                {
                    game = GameState.GameOver;
                }
            }
            //call the current levels update exit method
            currentlevel.UpdateExit(currentlevel.GetEnemyTiles());
         

        }

        //Loops through all living enemies and attacks any character tiles in their vision arrays 
        
        private void EnemiesAttack() {

            EnemyTile[] et = currentlevel.GetEnemyTiles();
            
            for (int i = 0; i < et.Length; i++) {
                if (et[i].display != 'x')
                {
                    CharacterTile[] targets = et[i].GetTargets();

                    if (targets != null && targets.Length > 0)
                    {



                        for (int j = 0; j < targets.Length; j++)
                        {
                            if (targets[j] != null)
                            {
                                et[i].Attack(targets[j]);
                            }
                        }
                    }
                }
            }
        }


        //The next three methods are for debug

        //Used to keep track of hero health
        public string getHeroStats() {
            string temp = "HP: " + currentlevel.getHeroTile().HP() + "/40"; 
            return temp;
        }
        //used inititally to keep track of damage but now is used to track status of exit
        public string getHeroDamage() {
            string tempd = "Damage: " + currentlevel.getHeroTile().Damage() + "/10"; //This where it displays the damage (outdated, will delete for final submissiosn
            tempd = "Status of exit " + currentlevel.getExitTile().display; // shows the status of the exit
            return tempd;
        }

        //Keeps track of the amount of pickups
        public string getPicUpNo()
        {
            string temp = "no of Health Pick up items: " + currentlevel.text;
            temp = "Status of exit " + currentlevel.getExitTile().ExitUnlocked;
            temp = "Enemy health " + currentlevel.GetEnemyTiles()[0].HP();
            return temp;
        }


    }
}
