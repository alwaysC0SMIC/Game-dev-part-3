using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_dev_S2_project_1
{

    public class HealthPickUpTile : PickUpTile
    {
        //Q4.2
        //Displays the health pack

        public override char display
        {
            get
            {
                return char.Parse("+");
            }
        }
        // saves postion co-ordniates of the object
        public HealthPickUpTile(Position position) : base(position)
        {
            this.PickupPos = position;
        }

       public Position PickupPos { get; }

        // overrides the abstact pickup tile class method to specifiy healing, will be used for different types of buffs in prt 3
        public override void ApplyEffect(CharacterTile tar)
        {
            tar.Heal(10);
        }

        //Constructor


    }

}
