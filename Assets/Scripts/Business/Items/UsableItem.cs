using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Business.Items
{
    public abstract class UsableItem : Item
    {
        public virtual void UseItem()
        {
            // Maybe it would take a GameObject target, and apply an effect on it ?
            // e.g. a health potion : player clicks the potion in the inventory and uses it, it calls UseItem(playerObject) and adds x to playerObject.Player.health
        }
    }
}
