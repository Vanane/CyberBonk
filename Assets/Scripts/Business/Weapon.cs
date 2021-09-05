using Assets.Scripts.Business.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Business
{
    public class Weapon : MonoBehaviour
    {
        WeaponItem weaponItem;

        public float curAmmo { get; private set; }

        private float lastShot;
        public bool isReloading { get; private set; }


        void Start()
        {
            lastShot = 0;
            isReloading = false;
        }


        public void Equip(WeaponItem weapon)
        {
            weaponItem = weapon;
            curAmmo = weapon.magSize;
        }


        /// <summary>
        /// Shoots a bullet, creating a prefab with a given impulse towards where the player is looking.
        /// </summary>
        /// <param name="isFirstClick">True if the click that provoked that shot was a first click, or a maintained click. A manual weapon won't shoot if it's a maintained click.</param>
        public void Shoot(bool isFirstClick)
        {
            if (isReloading) return;
            if (!isFirstClick && !weaponItem.isAutomatic) return;
            if (curAmmo == 0)
            {
                Reload();
                return;
            }
            else
            {
                if ((lastShot + weaponItem.coolDown) <= Time.time)
                {
                    Debug.Log("pew !");
                    lastShot = Time.time;
                    curAmmo--;
                    CreateBullet();
                }
            }
        }


        public void Reload()
        {
            if (isReloading || curAmmo == weaponItem.magSize) return;
            isReloading = true;
            Debug.Log("Reloading...");
            Invoke("Reloaded", weaponItem.reloadTime);
        }


        private void Reloaded()
        {
            isReloading = false;
            curAmmo = weaponItem.magSize;
            Debug.Log("Reloaded !");
        }


        private void CreateBullet()
        {
            GameObject go = Instantiate(weaponItem.bulletAmmo.bulletPrefab, transform.position + transform.forward, transform.rotation);
            Bullet b = go.GetComponent<Bullet>();   
            b.body.AddForce(b.transform.forward * b.speed);
        }


        /// <summary>
        /// Returns true if the current weapon the entity has equipped is the one given in parameter. 
        /// </summary>
        /// <param name="weapon"></param>
        /// <returns></returns>
        public bool IsCurrentEquipped(WeaponItem weapon)
        {
            return weaponItem == weapon;
        }
    }
}
