using Assets.Scripts.Business.Items;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Business
{
    public class UnhandedWeapon : Weapon
    {
        MeleeWeaponItem weaponItem;


        override protected void Awake()
        {
            base.Awake();
        }


        override public void SetWeapon(WeaponItem weapon)
        {
            MeshFilter weaponMesh = weaponModel.GetComponent<MeshFilter>();
            weaponItem = (MeleeWeaponItem) weapon;
            weaponMesh.mesh = weapon.weaponModel;
        }


        override public void Attack(bool isFirstClick)
        {
            Swing(isFirstClick);
        }


        private void Swing(bool firstClick)
        {

        }


        override public void Reload()
        {

        }


        override protected void Reloaded()
        {

        }
    }
}
