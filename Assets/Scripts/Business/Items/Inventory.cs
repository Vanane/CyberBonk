using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Business.Items
{
    public class Inventory
    {
        public Dictionary<UsableItem, int> items; // Items and number of it

        public Dictionary<BulletItem, int> ammos;
        public int money;

        public Inventory()
        {
            items = new Dictionary<UsableItem, int>();
            ammos = new Dictionary<BulletItem, int>();
            money = 0;
        }


        public UsableItem AddItem(UsableItem i, int count = 1)
        {
            if (count < 1) return null;
            if (!i.isStackable)
            {
                items.Add(i, 1);
            }
            else
            {
                UsableItem firstSimilarItem = items.First(x => x.Key.Equals(i)).Key;
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
    }
}
