using Assets.Scripts.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityExtensions;

public class DefaultInputController : InputController
{
    Rigidbody playerBody;


    private void Start()
    {
        playerBody = player.GetComponent<Rigidbody>();
        activePanels = new List<GameObject>();
    }


    private void Update()
    { 

    }


    void FixedUpdate()
    {

    }


    override public void OnClickLeft(Vector3 mousePos, bool firstClick)
    {
        player.Shoot(firstClick);
    }


    override public void OnClickRight(Vector3 mousePos, bool firstClick)
    {

    }


    override public void OnClickMiddle(Vector3 mousePos, bool firstClick)
    {

    }


    override public void OnPressA(bool firstClick)
    {
        throw new System.NotImplementedException();
    }


    override public void OnPressE(bool firstClick)
    {
        throw new System.NotImplementedException();
    }


    override public void OnPressF(bool firstClick)
    {
        throw new System.NotImplementedException();
    }

    override public void OnPressI(bool firstClick)
    {
        if(firstClick)
        {
            TogglePanel(InventoryPanel);
        }
    }

    override public void OnPressK(bool firstClick)
    {
        if (firstClick)
        {
            TogglePanel(SkillsPanel);
        }
    }

    override public void OnPressL(bool firstClick)
    {
        if (firstClick)
        {
            TogglePanel(MissionsPanel);
        }
    }


    override public void OnPressR(bool firstClick)
    {
        throw new System.NotImplementedException();
    }


    override public void OnPressShift(bool firstClick)
    {
        throw new System.NotImplementedException();
    }

    /*
    override public void OnPressEscape(bool firstClick)
    {
        }
    }*/


    override public void OnPressDown()
    {
        throw new System.NotImplementedException();
    }

    override public void OnPressLeft()
    {
        throw new System.NotImplementedException();
    }

    override public void OnPressRight()
    {
        throw new System.NotImplementedException();
    }

    override public void OnPressUp()
    {
        throw new System.NotImplementedException();
    }

    override public void OnScrollDown()
    {
        throw new System.NotImplementedException();
    }

    override public void OnScrollUp()
    {
        throw new System.NotImplementedException();
    }

    override public void OnSpace()
    {
        throw new System.NotImplementedException();
    }


    override public void OnJoystickMove(Vector3 move)
    {
        playerBody.velocity -= new Vector3(playerBody.velocity.x, 0, playerBody.velocity.z) * player.speedDecay;
        //Vector3 force = move * player.velocity * 1 / Mathf.Max(1, playerBody.velocity.magnitude);
        Vector3 force = move * player.velocity * (player.velocity - playerBody.velocity.magnitude);
        playerBody.AddForce(force);
    }


    override public void OnStay()
    {
        /*
        Vector3 force = new Vector3(-playerBody.velocity.x, 0, -playerBody.velocity.z);
        if (force.magnitude > 0.1f)
            force = force * player.velocity * 1 / Mathf.Max(1, playerBody.velocity.magnitude);
        playerBody.AddForce(force);
        */
        playerBody.velocity -= new Vector3(playerBody.velocity.x, 0, playerBody.velocity.z) * player.speedDecay;
    }


    override public void OnMouseMove(Vector3 mousePos)
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

    
    public void TogglePanel(GameObject panel)
    {
        if (activePanels.Contains(panel))
        {
            ClosePanel(panel);
        }
        else
        {
            OpenPanel(panel);
        }
    }


    public void ClosePanel(GameObject panel)
    {
        panel.SetActive(false);
        activePanels.Remove(panel);
    }


    public void OpenPanel(GameObject panel)
    {
        panel.SetActive(true);
        activePanels.Add(panel);
    }

}
