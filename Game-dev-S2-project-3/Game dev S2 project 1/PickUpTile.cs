using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_dev_S2_project_1
{
    [Serializable]
    public abstract class PickUpTile : Tile
    {

        public PickUpTile(Position pos) : base(pos) // constructor with objects position co-ordniates
        {
        }

        public abstract void ApplyEffect(CharacterTile tar); // abatract method used to implents effects once the pick up tile is used

        // Anon. (n.d). Abstract Classes and Methods. [Online]. Available at: 
        // https://www.w3schools.com/cs/cs_abstract.php 
        // [Last Accessed 28 November 2023] 
    }
}
