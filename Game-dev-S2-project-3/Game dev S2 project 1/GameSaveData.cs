using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_dev_S2_project_1
{
    [Serializable]
    public class GameSaveData // this class is made to contain all the nessary fields needed to be saved in the text file 
    {
        public Level currentLevel { get; set; } 
        public int noLevels { get; set; }
        public int currentLevelNumber { get; set; } 


        public GameSaveData(int noLevels, int curentLevelno, Level current) { 


            currentLevel = current;
            this.noLevels = noLevels;
            currentLevelNumber = curentLevelno;

        }

    }
}
