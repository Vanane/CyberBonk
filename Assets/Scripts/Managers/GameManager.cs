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
        WeaponItem gun = ItemRepository.GetInstance().CopyItem<WeaponItem>(20);
        player.inventory.AddItem(gun);
        player.EquipWeapon(gun);
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
            player.Shoot(firstClick);
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
