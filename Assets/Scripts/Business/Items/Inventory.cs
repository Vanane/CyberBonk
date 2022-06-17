using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Business.Items
{
    public class Inventory
    {
        public enum ArmorSlot { Head, Vest, Pants }
        public enum WeaponSlot { Main, Side, Consumable }

        /// <summary>
        /// Contains the pieces of armor currently equipped. Doesn't serve as an inventory extension, only stores the "equipped" information.
        /// </summary>
        private Dictionary<ArmorSlot, Item> armorSlots; // TODO : remplacer Item par une classe ArmorItem

        /// <summary>
        /// Contains the weapons and grenades currently equipped. Doesn't serve as an inventory extension, only stores the "equipped" information.
        /// </summary>
        private Dictionary<WeaponSlot, WeaponItem> weaponSlots;

        /// <summary>
        /// Contains the list of all items present in the inventory, with 
        /// </summary>
        private Dictionary<Item, int> items; // Items and number of it

        private Dictionary<BulletItem, int> ammos;
        
        public int money;

        public Inventory()
        {
            items = new Dictionary<Item, int>();
            ammos = new Dictionary<BulletItem, int>();

            armorSlots = new Dictionary<ArmorSlot, Item>();

            armorSlots.Add(ArmorSlot.Head, null);
            armorSlots.Add(ArmorSlot.Vest, null);
            armorSlots.Add(ArmorSlot.Pants, null);

            weaponSlots = new Dictionary<WeaponSlot, WeaponItem>();

            weaponSlots.Add(WeaponSlot.Main, null);
            weaponSlots.Add(WeaponSlot.Side, null);
            weaponSlots.Add(WeaponSlot.Consumable, null);

            money = 0;
        }


        public Item AddItem(Item i, int count = 1)
        {
            if (count < 1) return null;
            if (!i.isStackable)
            {
                items.Add(i, 1);
            }
            else
            {
                Item firstSimilarItem = items.First(x => x.Key.Equals(i)).Key;
                if(firstSimilarItem == null)
                    items.Add(i, count);
                else
                    items[firstSimilarItem] += count;
            }
            return i;
        }


        public void RemoveItem(UsableItem i, int count = 1)
        {
            if (count < 1) return;
            if (items.ContainsKey(i))
            {
                if (items[i] > count)
                    items[i] -= Math.Min(items[i], count);
                if(items[i] == 0)
                    items.Remove(i);
            }
        }


        public void AddAmmo(BulletItem i, int count = 1)
        {
            if (count < 1) return;
            if (!ammos.ContainsKey(i))
                ammos.Add(i, 0);
            ammos[i] += count;
        }


        public void RemoveAmmo(BulletItem i, int count = 1)
        {
            if (count < 1) return;
            if (!ammos.ContainsKey(i))
                ammos.Add(i, 0);
            ammos[i] -= Math.Min(ammos[i], count);
        }


        public void AddMoney(int count)
        {
            if (count < 1) return;
            money += count;
        }


        public void RemoveMoney(int count)
        {
            if (count < 1) return;
            money -= Math.Min(money, count);
        }


        public bool IsInInventory(Item i)
        {
            return items.ContainsKey(i);
        }


        public WeaponItem GetMainWeapon()
        {
            return weaponSlots[WeaponSlot.Main];
        }

        public void SetMainWeapon(WeaponItem item)
        {
            if(IsInInventory(item))
                weaponSlots[WeaponSlot.Main] = item;
        }


        public WeaponItem GetSideWeapon()
        {
            return weaponSlots[WeaponSlot.Side];
        }

        public void SetSideWeapon(WeaponItem item)
        {
            if (IsInInventory(item))
                weaponSlots[WeaponSlot.Side] = item;
        }


        public WeaponItem GetConsumableWeapon()
        {
            return weaponSlots[WeaponSlot.Consumable];
        }
        public void SetConsumableWeapon(Item item)
        {
            // TODO : Manage consumable items
        }


        /// <summary>
        /// Get enumerator to enumerate every item in the inventory
        /// </summary>
        /// <returns></returns>
        public Dictionary<Item, int>.Enumerator GetEnumerator()
        {
            return items.GetEnumerator();
        }


        /// <summary>
        /// Get number of items in the inventory
        /// </summary>
        /// <returns></returns>
        public int GetItemCount()
        {
            return items.Count;
        }


        /// <summary>
        /// Get number of items and quantities of it, in total
        /// </summary>
        /// <returns></returns>
        public int GetItemCountWithDuplicates()
        {
            int count = 0;
            foreach(KeyValuePair<Item, int> pair in items)
            {
                count += pair.Value;
            }
            return count;
        }
    }
}
