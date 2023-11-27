using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_dev_S2_project_1
{
    public abstract class Tile
    {
        // A private field of type position
        private Position pos;
        

        //Declares property that exposes the x value of the Position field
        public int x
        {
            get { return pos.XCod; }
            set { pos.XCod = value; }

        }

        //Declares property that exposes the y value of the Position field
        public int y
        {
            get { return pos.YCod; }
            set { pos.YCod = value; }

        }

        //An abstract Property of type char named Display that only has 
        //the get accessor. 
        public abstract char display { get; }

        //A constructor that accepts a Position type as a parameter, and 
        //then assigns it to the class’s Position field.
        public Tile(Position pos)
        {
            this.pos = pos;
        }
    }
}
