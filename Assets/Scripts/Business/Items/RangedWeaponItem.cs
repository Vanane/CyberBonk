using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Business.Items
{
    public class RangedWeaponItem : WeaponItem
    {
        public bool isAutomatic;
        public float errorAngle;

        public BulletItem bulletItem;
        private bool disposedValue;

        override public object Clone()
        {
            RangedWeaponItem i = (RangedWeaponItem) base.Clone();
            return i;
        }


        public void Attack()
        {

        }
    }
}
