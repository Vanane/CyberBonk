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

        public GameObject bulletPrefab;


        override public object Clone()
        {
            BulletItem i = (BulletItem)base.Clone();
            return i;
        }
    }
}
