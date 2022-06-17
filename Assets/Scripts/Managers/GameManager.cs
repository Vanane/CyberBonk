using Assets.Scripts.Business.Items;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Player player;
    public UIManager uiManager;

    public bool paused;

    private float previousTimeScale;


    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(ItemRepository.GetInstance() == null);
        RangedWeaponItem smg = ItemRepository.GetInstance().GetInstanceOfItem<RangedWeaponItem>(21);
        RangedWeaponItem shotgun = ItemRepository.GetInstance().GetInstanceOfItem<RangedWeaponItem>(22);
        
        player.inventory.AddItem(smg);
        player.inventory.AddItem(shotgun);
        player.inventory.SetMainWeapon(smg);
        player.inventory.SetSideWeapon(shotgun);
        player.EquipWeapon(shotgun);
        player.ToggleWeapon(true);
    }

    // Update is called once per frame
    void Update()
    {

    }


    public void OnEscape(bool firstClick)
    {
        if (uiManager.hasPanelsActive && !paused)
            uiManager.CloseLastPanel();
        else
        {
            if (firstClick)
                if (paused)
                    DoUnpause();
                else
                    DoPause();
        }
    }


    public void OnClickL(bool firstClick)
    {
        if (!uiManager.hasPanelsActive && !paused)
        {
            player.Attack(firstClick);
        }
    }


    public void OnClickR(bool firstClick)
    {

    }


    public void OnClickM(bool firstClick)
    {

    }


    public void OnA(bool firstClick)
    {
    }


    public void OnE(bool firstClick)
    {
        if(firstClick)
            player.ToggleWeapon();
    }


    public void OnF(bool firstClick)
    {
    }


    public void OnR(bool firstClick)
    {
        if (!paused)
            player.ReloadWeapon();
    }


    public void OnI(bool firstClick)
    {
        if(firstClick)
            uiManager.TogglePanel(UIManager.Panels.Inventory);
    }


    public void OnK(bool firstClick)
    {
    }

    public void OnL(bool firstClick)
    {
    }

    public void OnAlpha1(bool firstClick)
    {
        if(firstClick)
            player.EquipWeapon(player.inventory.GetMainWeapon());
    }


    public void OnAlpha2(bool firstClick)
    {
        if (firstClick)
            player.EquipWeapon(player.inventory.GetSideWeapon());
    }


    public void OnMouseMove(Vector3 direction)
    {
        if (!paused)
            player.LookAt(direction);
    }


    public void OnJoystick(Vector3 direction)
    {
        if (!paused)
            player.Move(direction);
    }


    public void DoPause()
    {
        paused = true;
        previousTimeScale = Time.timeScale;
        Time.timeScale = 0.0f;
        uiManager.OpenPanel(UIManager.Panels.Pause);
    }


    public void DoUnpause()
    {
        uiManager.ClosePanel(UIManager.Panels.Pause);
        Time.timeScale = previousTimeScale;
        paused = false;
    }
}
