using Assets.Scripts.Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityExtensions;

public class InputManager : MonoBehaviour, IInputManager
{
    public PlayerController player;
    Rigidbody playerBody;

    private bool firstClickLeft, firstClickRight, firstClickMiddle;


    private void Start()
    {
        playerBody = player.GetComponent<Rigidbody>();
    }


    private void Update()
    {
        DetectMouseInputs();
    }


    void FixedUpdate()
    {
        DetectInputs();
    }


    void DetectMouseInputs()
    {
        if (Input.GetKey(KeyCode.Mouse0)) OnClickLeft(Input.mousePosition, firstClickLeft); else firstClickLeft = true;
        if (Input.GetKey(KeyCode.Mouse2)) OnClickMiddle(Input.mousePosition, firstClickMiddle); else firstClickMiddle = true;
        if (Input.GetKey(KeyCode.Mouse1)) OnClickRight(Input.mousePosition, firstClickRight); else firstClickRight = true;
    }


    void DetectInputs()
    {
        int scrollDelta = MoInput.ScrollHasChanged();
        Vector3 joystick = MoInput.GetZQSDDirection();

        if (joystick != Vector3.zero) OnJoystickMove(joystick); else OnStay();
        if (Input.GetKey(KeyCode.E)) // Use();
        if (Input.GetKey(KeyCode.F)) // Melee();
        if (Input.GetKey(KeyCode.R)) // Reload();
        if (Input.GetKey(KeyCode.LeftShift)) // Run();
        if (scrollDelta > 0) OnScrollUp();
        if (scrollDelta < 0) OnScrollDown();
        OnMouseMove(Input.mousePosition);        
    }


    public void OnClickLeft(Vector3 mousePos, bool firstClick)
    {
        player.Shoot(firstClick);
        firstClickLeft = false;
    }

    public void OnClickMiddle(Vector3 mousePos, bool firstClick)
    {
        Debug.Log("Clicked at " + mousePos);
        firstClickMiddle = false;

    }

    public void OnClickRight(Vector3 mousePos, bool firstClick)
    {
        Debug.Log("Clicked at " + mousePos);
        firstClickRight = false;

    }

    public void OnPressDown()
    {
        throw new System.NotImplementedException();
    }

    public void OnPressLeft()
    {
        throw new System.NotImplementedException();
    }

    public void OnPressRight()
    {
        throw new System.NotImplementedException();
    }

    public void OnPressUp()
    {
        throw new System.NotImplementedException();
    }

    public void OnScrollDown()
    {
        throw new System.NotImplementedException();
    }

    public void OnScrollUp()
    {
        throw new System.NotImplementedException();
    }

    public void OnSpace()
    {
        throw new System.NotImplementedException();
    }


    public void OnJoystickMove(Vector3 move)
    {
        playerBody.velocity -= new Vector3(playerBody.velocity.x, 0, playerBody.velocity.z) * player.speedDecay;
        //Vector3 force = move * player.velocity * 1 / Mathf.Max(1, playerBody.velocity.magnitude);
        Vector3 force = move * player.velocity * (player.velocity - playerBody.velocity.magnitude);
        playerBody.AddForce(force);
    }


    public void OnStay()
    {
        /*
        Vector3 force = new Vector3(-playerBody.velocity.x, 0, -playerBody.velocity.z);
        if (force.magnitude > 0.1f)
            force = force * player.velocity * 1 / Mathf.Max(1, playerBody.velocity.magnitude);
        playerBody.AddForce(force);
        */
        playerBody.velocity -= new Vector3(playerBody.velocity.x, 0, playerBody.velocity.z) * player.speedDecay;
    }


    public void OnMouseMove(Vector3 mousePos)
    {
        Vector3 worldPos = Camera.main.WorldToScreenPoint(player.transform.position);
        worldPos.x = mousePos.x - worldPos.x;
        worldPos.y = mousePos.y - worldPos.y;
        float angle = Mathf.Atan2(worldPos.x, worldPos.y) * Mathf.Rad2Deg;
        player.transform.rotation = Quaternion.Euler(new Vector3(0, angle, 0));

        Vector3 weaponWorldPos = Camera.main.WorldToScreenPoint(player.weapon.transform.position);
        weaponWorldPos.x = mousePos.x - weaponWorldPos.x;
        weaponWorldPos.y = mousePos.y - weaponWorldPos.y;
        float weaponAngle = Mathf.Atan2(weaponWorldPos.x, weaponWorldPos.y) * Mathf.Rad2Deg;
        player.weapon.transform.rotation = Quaternion.Euler(new Vector3(0, weaponAngle, 0));
    }
}
