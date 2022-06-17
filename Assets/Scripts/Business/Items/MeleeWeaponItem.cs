using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Business.Items
{
    public class MeleeWeaponItem : WeaponItem
    {
        public bool isAutomatic;
        public float errorAngle;

        public BulletItem bulletItem;


        override public object Clone()
        {
            MeleeWeaponItem i = (MeleeWeaponItem) base.Clone();
            return i;
        }


        public void Attack()
        {

        }
    }
}
