using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_dev_S2_project_1
{
    public abstract class PickUpTile : Tile
    {
        // Q 4.1 an abstract class that will be used for different types of pick ups in part 3 



        public PickUpTile(Position pos) : base(pos) // constructor with objects position co-ordniates
        {
        }

        public abstract void ApplyEffect(CharacterTile tar); // abatract method used to implents effects once the pick up tile is used


        // https://www.w3schools.com/cs/cs_abstract.php 
    }
}
