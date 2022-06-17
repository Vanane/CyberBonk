using Assets.Scripts.Business;
using Assets.Scripts.Business.Items;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityExtensions;

public class Player : MonoBehaviour
{
    public Inventory inventory;
    public Weapon weaponComponent;

    public Rigidbody body;
    
    // Player stats and states
    public float velocity, speedDecay;

    public bool weaponDrawn;

    public Player()
    {
        inventory = new Inventory();
    }


    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        // Manual drag and slow down
        body.velocity -= new Vector3(body.velocity.x, 0, body.velocity.z) * speedDecay;
    }


    public void EquipWeapon(WeaponItem weaponItem)
    {
        if (inventory.IsInInventory(weaponItem))
        {
            GameObject weaponGO = weaponComponent.gameObject;
            if(!weaponComponent.IsCurrentEquipped(weaponItem))
            {
                Weapon newWeapon;
                switch(weaponItem)
                {
                    case RangedWeaponItem r:
                        newWeapon = weaponGO.AddComponent<RangedWeapon>();
                        break;
                    case MeleeWeaponItem m:
                        newWeapon = weaponGO.AddComponent<MeleeWeapon>();
                        break;
                    default:
                        newWeapon = weaponGO.AddComponent<UnhandedWeapon>();
                        break;
                }
                Destroy(weaponComponent);

                weaponComponent = newWeapon;
                weaponComponent.SetWeapon(weaponItem);
            }
            ToggleWeapon(true);
        }
    }


    /// <summary>
    /// Draw or lay down the weapon, depending of its previous state
    /// </summary>
    public void ToggleWeapon()
    {
        ToggleWeapon(!weaponDrawn);
    }


    /// <summary>
    /// Draw or lay down the weapon, depending of the given parameter. <see cref="ToggleWeapon()"/>
    /// </summary>
    public void ToggleWeapon(bool toggle)
    {
        if(toggle)
        {
            weaponComponent.gameObject.transform.Rotate(new Vector3(-90, 0, 0));
            weaponDrawn = true;
        }
        else
        {
            weaponComponent.gameObject.transform.Rotate(new Vector3(90, 0, 0));
            weaponDrawn = false;
        }
    }


    /// <summary>
    /// Asks the weapon to attack
    /// </summary>
    /// <param name="isFirstClick">True if the click is a first click, false if a maintained click</param>
    public void Attack(bool isFirstClick)
    {
        if (!weaponDrawn)
            ToggleWeapon();
        else
            weaponComponent.Attack(isFirstClick);
    }


    public void ReloadWeapon()
    {
        if (!weaponDrawn)
            ToggleWeapon();
        else
            weaponComponent.Reload();
    }


    public void Move(Vector3 direction)
    {
        Vector3 force = direction * velocity * (velocity - body.velocity.magnitude);
        body.AddForce(force);
    }


    public void LookAt(Vector3 mousePos)
    {
        // Rotate the player
        Vector3 worldPos = Camera.main.WorldToScreenPoint(transform.position);
        worldPos.x = mousePos.x - worldPos.x;
        worldPos.y = mousePos.y - worldPos.y;
        float angle = Mathf.Atan2(worldPos.x, worldPos.y) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, angle, 0));

        if(weaponDrawn)
        {
            // Rotate the weapon
            Vector3 weaponWorldPos = Camera.main.WorldToScreenPoint(weaponComponent.transform.position);
            weaponWorldPos.x = mousePos.x - weaponWorldPos.x;
            weaponWorldPos.y = mousePos.y - weaponWorldPos.y;
            float weaponAngle = Mathf.Atan2(weaponWorldPos.x, weaponWorldPos.y) * Mathf.Rad2Deg;
            weaponComponent.transform.rotation = Quaternion.Euler(new Vector3(0, weaponAngle, 0));
        }
    }


}
