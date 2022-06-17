using Assets.Scripts.Business;
using Assets.Scripts.Business.Items;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityExtensions;
using static UnityEngine.InputSystem.InputAction;

public class Player : MonoBehaviour
{
    public Inventory inventory;
    public Weapon weaponComponent;

    public Rigidbody body;
    
    // Player stats and states
    public float velocity, speedDecay;

    public bool weaponDrawn;


    private InputAction moveAction;
    Vector3 moveDirection;
    
    private InputAction lookAction;
    Vector3 lookTarget;
    
    private InputAction attackAction;
    bool firstAttack;

    public Player()
    {
        inventory = new Inventory();        

        moveAction = new InputAction();
        lookAction = new InputAction();
        attackAction = new InputAction();
    }


    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody>();
    }


    private void Update()
    {
        if (attackAction.enabled)
        {
            Attack(firstAttack);
            firstAttack = false;
        }
    }


    private void FixedUpdate()
    {
        // Manual drag and slow down
        if (moveAction.enabled)
            Move(moveDirection);
        else
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
        if (toggle)
        {
            weaponComponent.gameObject.transform.localScale = new Vector3(1, 1, 1);
            weaponDrawn = true;
        }
        else
        {
            weaponComponent.gameObject.transform.localScale = new Vector3(0, 0, 0);
            weaponDrawn = false;
        }
    }


    public void EquipMainWeapon()
    {
        EquipWeapon(inventory.GetMainWeapon());
    }

    public void EquipSideWeapon()
    {
        EquipWeapon(inventory.GetSideWeapon());
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


    #region Action Input Enablers
    /* Actions tat can be held for an indefinite amount of time, like moving and shooting */
    public void OnActionMove(CallbackContext context)
    {
        if (context.performed)
        {
            Vector2 direction2D = (Vector2)context.ReadValueAsObject();
            moveDirection = new Vector3(direction2D.x, 0, direction2D.y);

            moveAction.Enable();
        }
        else if (context.canceled)
            moveAction.Disable();
    }

    public void OnActionAttack(CallbackContext context)
    {
        if (context.performed)
        {
            firstAttack = true;
            attackAction.Enable();            
        }
        else if (context.canceled)
            attackAction.Disable();
    }
    #endregion
}
