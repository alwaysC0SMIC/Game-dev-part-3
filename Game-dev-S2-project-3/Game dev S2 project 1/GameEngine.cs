using Microsoft.VisualBasic.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Runtime.Serialization.Formatters.Binary;
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

            //Checks if tile is an exit tile and unlocked
            if (hero.visionArray[targetTile].display == '▒') {
                success = true;
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
        // Q5 Save Game 
        public void SaveGame()
        {
            string filetext = "file.txt";
            string fielbin = "file.bin";

            string convert = File.ReadAllText(filetext);
            byte[] binarydata = Encoding.UTF8.GetBytes(convert);
            File.WriteAllBytes(filetext, binarydata); // converts the text file into a binary file to store the saved data
            GameSaveData save = new GameSaveData(NumLevels, currentLevelNumber, currentlevel); // creates a new object to contain all the fields in one object, to save the fields into one file 

            BinaryFormatter fomrat = new BinaryFormatter();

            FileStream file = new FileStream("file.txt", FileMode.Create);  
            fomrat.Serialize(file, save); // serilizes the fields in the object to convert it to data that is contained in the file
            file.Close(); // closes the filestreamer 

            

           

        } 
        // Q 5 Load Game
        public void LoadGame()
        {

            if (File.Exists("file.txt")) // checks if the saved file exists
            {
                BinaryFormatter format = new BinaryFormatter();
                FileStream file = new FileStream("file.txt", FileMode.Open); // uses the formatter to derserlises the data
                GameSaveData save = (GameSaveData)format.Deserialize(file); // creates a new object, and converts the data into it's designated fields in the gamesave object
                file.Close();
                if (save != null) {
                    NumLevels = save.noLevels; // savadata object sets the loaded data into the gameegnine fields to load the saved map
                    currentlevel = save.currentLevel;
                    currentLevelNumber = save.currentLevelNumber;
                }
                MessageBox.Show("Loaded save successful\n" + MessageBoxButtons.OK); // confirms if the save was successful
            }
            
            else
            {
                MessageBox.Show("Error failed to load game\n"+ MessageBoxButtons.OK); // displays an error if the file was not found 
            }

           
            

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

        // Need to add comments
        public void TriggerAttack(Level.Direction direct)
        {
            if (game != GameState.GameOver) 
            {

                
                HeroAttack(direct);
                EnemiesAttack();
                heroStats = getHeroStats();
               
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
       

    }
}
/*
 * 
 * References 
 * Roy, T. (2012). How to save a Game State?. [Online]. Available at:
 *  https://gamedev.stackexchange.com/questions/29195/how-to-save-a-game-state
 * [Last Accessed 28 November 2023]
 * 
 * Arun, L. (2021). Serializing and Deserializing an Object as Binary Data Using Binary Formatter ASP.NET C#. [Online]. Available at:
 * https://www.c-sharpcorner.com/UploadFile/d3e4b1/serializing-and-deserializing-the-object-as-binary-data-usin/ 
 * [Last Accessed 28 November 2023]
 * 
   Anon. (2021). How to: Read and Write to a Newly Created Data File. [Online]. Available at:
   https://learn.microsoft.com/en-us/dotnet/standard/io/how-to-read-and-write-to-a-newly-created-data-file 
   [Last Accessed 28 November 2023]

   Chand, M. (2023). How to Read a Binary File in C#. [Online]. Available at:
   https://www.c-sharpcorner.com/UploadFile/mahesh/read-a-binary-file-in-C-Sharp/
   [Last Accessed 28 November 2023]

   Rhodanny (2021). How can I save data/information to text file and read back?. [Online]. Available at:
   https://learn.microsoft.com/en-us/answers/questions/670543/how-can-i-save-data-information-to-text-file-and-r
   [Last Accessed 28 November 2023]

   Jallepalli, K. (2023). MessageBox.Show Method in C#. [Online]. Available at: 
   https://www.c-sharpcorner.com/UploadFile/736bf5/messagebox-show/
   [Last Accessed 28 November 2023] 
   

 
 */

