using Assets.Scripts.Business;
using Assets.Scripts.Business.Items;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityExtensions;

public class Player : MonoBehaviour
{
    public Inventory inventory;
    public Weapon weapon;

    // Player Stats
    public float velocity, speedDecay;

    public Rigidbody body;

    public Player()
    {
        inventory = new Inventory();
    }


    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody>();
    }


    public void EquipWeapon(WeaponItem weaponItem)
    {
        if(!weapon.IsCurrentEquipped(weaponItem))
            weapon.Equip(weaponItem);
    }


    /// <summary>
    /// Asks the weapon to shoot
    /// </summary>
    /// <param name="isFirstClick">True if the click that provoked that shot was a first click, or a maintained click</param>
    public void Shoot(bool isFirstClick)
    {
        weapon.Shoot(isFirstClick);
    }


    public void ReloadWeapon()
    {
        weapon.Reload();
    }


    public void Move(Vector3 direction)
    {
        body.velocity -= new Vector3(body.velocity.x, 0, body.velocity.z) * speedDecay;
        //Vector3 force = move * player.velocity * 1 / Mathf.Max(1, body.velocity.magnitude);
        Vector3 force = direction * velocity * (velocity - body.velocity.magnitude);
        body.AddForce(force);
    }


    public void LookAt(Vector3 mousePos)
    {
        Vector3 worldPos = Camera.main.WorldToScreenPoint(transform.position);
        worldPos.x = mousePos.x - worldPos.x;
        worldPos.y = mousePos.y - worldPos.y;
        float angle = Mathf.Atan2(worldPos.x, worldPos.y) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, angle, 0));

        Vector3 weaponWorldPos = Camera.main.WorldToScreenPoint(weapon.transform.position);
        weaponWorldPos.x = mousePos.x - weaponWorldPos.x;
        weaponWorldPos.y = mousePos.y - weaponWorldPos.y;
        float weaponAngle = Mathf.Atan2(weaponWorldPos.x, weaponWorldPos.y) * Mathf.Rad2Deg;
        weapon.transform.rotation = Quaternion.Euler(new Vector3(0, weaponAngle, 0));
    }


}
