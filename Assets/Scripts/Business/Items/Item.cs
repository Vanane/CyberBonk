using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Business.Items
{
    public abstract class Item : ICloneable
    {
        public int id;
        public string name;
        public string spriteName;

        public int maxCount { get; private set; } // Maximum size of a stack, if stackable
        public bool isStackable { get; private set; }

        virtual public object Clone()
        {
            Item i = (Item)this.MemberwiseClone();
            i.name = String.Copy(name);
            i.spriteName = String.Copy(spriteName);
            return i;
        }
    }
}
