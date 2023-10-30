using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_dev_S2_project_1
{
    internal abstract class Tile 
    //Q.2.2
    {
        private Position pos;
        public int x;
        public int y;

        public abstract char display{ get; }


        public Tile( Position pos)
        {
            this.pos = pos;


        }



    }
}
//Requirements
//It must be marked abstract. xx
//must contain a private field of type Position. xx
//It must declare property that exposes the x value of the Position field.xx
//It must declare property that exposes the y value of the Position field.xx
//It must have a constructor that accepts a Position type as a parameter, and 
//then assigns it to the class’s Position field.xx
//It must have an abstract Property of type char named Display that only has 
//the get accessor. xx
//The get accessor will be overridden by classes derived from 
//Tile to return the character that visually represents each tile xx