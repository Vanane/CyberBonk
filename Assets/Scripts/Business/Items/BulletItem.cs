using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Business.Items
{
    public class BulletItem : Item
    {
        public float damage;
        public float velocity;
        public float decayTime;
        public int projectileCount = 1;
        public float delayBetweenProjectiles = 0.0f;

        public GameObject projectile;


        override public object Clone()
        {
            BulletItem i = (BulletItem)base.Clone();
            return i;
        }
    }
}
