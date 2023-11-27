using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Game_dev_S2_project_1
{
    public class AttackBuffPickup_Tile : PickUpTile
    {
        // Q.3.2
        //Displays the attack buff
        public override char display
        {
            get
            {
                return char.Parse("*");
            }
        }

        // saves position of the object
        public AttackBuffPickup_Tile(Position position) : base(position)
        {
            this.PickupPos = position;
            
            
        }
        public Position PickupPos { get; }

        //Applies the double damage
        public override void ApplyEffect(CharacterTile characterTile)
        {
            characterTile.SetDoubleDamage(3);
            
            
            
            
        }
  
    }
}
