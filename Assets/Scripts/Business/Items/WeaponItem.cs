using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Business.Items
{
    public class WeaponItem : UsableItem
    {
        public float coolDown, reloadTime, magSize;
        public bool isAutomatic;
        public float errorAngle;

        public BulletItem bulletItem;
        public Mesh weaponModel;


        override public object Clone()
        {
            WeaponItem i = (WeaponItem) base.Clone();
            return i;
        }
    }
}
