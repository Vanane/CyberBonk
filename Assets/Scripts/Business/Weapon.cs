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

        public bool isReloading { get; private set; }
        public float curAmmo { get; private set; }

        private float lastShot;
        WeaponItem weaponItem;

        public GameObject weaponModel;


        void Start()
        {
            lastShot = 0;
            isReloading = false;
        }


        public void Equip(WeaponItem weapon)
        {
            MeshFilter weaponMesh = weaponModel.GetComponent<MeshFilter>();
            weaponItem = weapon;
            curAmmo = weapon.magSize;
            weaponMesh.mesh = weapon.weaponModel;
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
                    CreateBullets();
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


        private void CreateBullets()
        {
            for(int i = 0; i < weaponItem.bulletItem.projectileCount; i++)
            {
                Invoke("CreateBullet", weaponItem.bulletItem.delayBetweenProjectiles * i);
            }
        }


        private Bullet CreateBullet()
        {
            Debug.Log(weaponItem.errorAngle);
            GameObject go = Instantiate(weaponItem.bulletItem.projectile, transform.position + transform.forward, transform.rotation);
            Bullet b = go.GetComponent<Bullet>();
            b.bulletItem = weaponItem.bulletItem;
            b.Shoot(weaponItem.bulletItem.velocity, weaponItem.bulletItem.decayTime, weaponItem.errorAngle);
            return b;
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
