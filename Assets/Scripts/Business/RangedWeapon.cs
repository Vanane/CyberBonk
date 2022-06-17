using Assets.Scripts.Business.Items;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Business
{
    public class RangedWeapon : Weapon
    {
        public float curAmmo { get; private set; }

        RangedWeaponItem weaponItem;


        override protected void Awake()
        {
            base.Awake();
        }


        override public void SetWeapon(WeaponItem weapon)
        {
            MeshFilter weaponMesh = weaponModel.GetComponent<MeshFilter>();
            weaponItem = (RangedWeaponItem) weapon;
            curAmmo = weapon.magSize;
            weaponMesh.mesh = weapon.weaponModel;
        }


        override public void Attack(bool isFirstClick)
        {
            Shoot(isFirstClick);
        }


        /// <summary>
        /// Shoots a bullet, creating a prefab with an impulse towards where the player is looking.
        /// </summary>
        /// <param name="isFirstClick">True if the click that provoked that shot was a first click, false if a maintained click. A manual weapon won't shoot if it's a maintained click.</param>
        private void Shoot(bool isFirstClick)
        {
            RangedWeaponItem tempItem = ((RangedWeaponItem)weaponItem);

            if (isReloading) return;
            if (!isFirstClick && !tempItem.isAutomatic) return;
            if (curAmmo == 0)
            {
                Reload();
                return;
            }
            else
            {
                if ((lastAttack + tempItem.coolDown) <= Time.time)
                {
                    Debug.Log("pew !");
                    lastAttack = Time.time;
                    curAmmo--;
                    CreateBullets();
                }
            }
        }


        override public void Reload()
        {
            if (isReloading || curAmmo == weaponItem.magSize) return;
            isReloading = true;
            Debug.Log("Reloading...");
            Invoke("Reloaded", weaponItem.reloadTime);
        }


        override protected void Reloaded()
        {
            isReloading = false;
            curAmmo = weaponItem.magSize;
            Debug.Log("Reloaded !");
        }


        private void CreateBullets()
        {
            RangedWeaponItem tempItem = ((RangedWeaponItem)weaponItem);

            for (int i = 0; i < tempItem.bulletItem.projectileCount; i++)
            {
                Invoke("CreateBullet", tempItem.bulletItem.delayBetweenProjectiles * i);
            }
        }


        private Bullet CreateBullet()
        {
            RangedWeaponItem tempItem = ((RangedWeaponItem)weaponItem);

            GameObject go = Instantiate(tempItem.bulletItem.projectile, transform.position + transform.forward, transform.rotation);
            Bullet b = go.GetComponent<Bullet>();
            b.bulletItem = tempItem.bulletItem;
            b.Shoot(tempItem.bulletItem.velocity, tempItem.bulletItem.decayTime, tempItem.errorAngle);
            return b;
        }
    }
}
