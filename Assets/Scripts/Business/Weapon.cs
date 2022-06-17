using Assets.Scripts.Business.Items;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Business
{
    /// <summary>
    /// MonoBehaviour that represents the behaviour of the player's weapon.
    /// Not to be confounded with WeaponItem :
    /// - Weapon is a component of Unity, that contains the logic for attacking, reloading and switching
    /// - WeaponItem is a business class that contains the specs of a weapon, only the data part
    /// </summary>
    public abstract class Weapon : MonoBehaviour
    {
        public bool isReloading { get; protected set; }

        protected float lastAttack;
        WeaponItem weaponItem;

        public GameObject weaponModel;


        virtual protected void Awake()
        {
            lastAttack = 0;
            isReloading = false;
            if (weaponModel == null) weaponModel = transform.Find("Model").gameObject;
        }


        virtual public void SetWeapon(WeaponItem weapon)
        {
            MeshFilter weaponMesh = weaponModel.GetComponent<MeshFilter>();
            weaponItem = weapon;
            weaponMesh.mesh = weapon.weaponModel;
        }


        virtual public void Attack(bool isFirstClick)
        {

        }


        virtual public void Reload()
        {

        }

        virtual protected void Reloaded()
        {
        
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
