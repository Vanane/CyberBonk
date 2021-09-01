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
        public float damage, coolDown, reloadTime, maxAmmo;
        public bool isAutomatic;
        public float curAmmo { get; private set; }

        private float lastShot;
        public bool isReloading { get; private set; }

        public Bullet bulletPrefab;

        void Start()
        {
            lastShot = 0;
            isReloading = false;
            curAmmo = maxAmmo;
        }


        /// <summary>
        /// Shoots a bullet, creating a prefab with a given impulse towards where the player is looking.
        /// </summary>
        /// <param name="isFirstClick">True if the click that provoked that shot was a first click, or a maintained click. A manual weapon won't shoot if it's a maintained click.</param>

        public void Shoot(bool isFirstClick)
        {
            if (isReloading) return;
            if (!isFirstClick && !isAutomatic) return;
            if (curAmmo == 0)
            {
                Reload();
                return;
            }
            else
            {
                if ((lastShot + coolDown) <= Time.time)
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
            if (isReloading || curAmmo == maxAmmo) return;
            isReloading = true;
            Debug.Log("Reloading...");
            Invoke("Reloaded", reloadTime);
        }


        private void Reloaded()
        {
            isReloading = false;
            curAmmo = maxAmmo;
            Debug.Log("Reloaded !");
        }


        private void CreateBullet()
        {
            Bullet b = Instantiate(bulletPrefab, transform.position + transform.forward, transform.rotation);
            b.body.AddForce(b.transform.forward * b.speed);
        }
    }
}
