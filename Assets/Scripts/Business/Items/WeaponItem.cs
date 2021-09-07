using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Business.Items
{
    public abstract class WeaponItem : UsableItem
    {
        public float coolDown, reloadTime, magSize;

        public Mesh weaponModel;
    }
}
