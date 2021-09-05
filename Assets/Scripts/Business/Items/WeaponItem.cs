using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Business.Items
{
    public class WeaponItem : UsableItem
    {
        public float coolDown, reloadTime, magSize;
        public bool isAutomatic;

        public BulletItem bulletAmmo;


        override public object Clone()
        {
            WeaponItem i = (WeaponItem) base.Clone();
            return i;
        }
    }
}
