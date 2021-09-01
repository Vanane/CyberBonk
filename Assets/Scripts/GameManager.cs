using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public PlayerController player;
    public UIManager uiManager;
    
    public bool paused;

    private float previousTimeScale;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void OnEscape(bool firstClick)
    {
        if(uiManager.isPanelActive)
        {
            uiManager.CloseLastPanel();
        }
    }


    public void OnKey(KeyCode key, bool firstClick)
    {

    }


    public void OnMouseClick(KeyCode key, bool firstClick)
    {

    }


    public void OnMouseMove(Vector3 direction)
    {

    }


    public void OnJoystick(Vector3 direction)
    {

    }


    private void DoPause()
    {
        paused = true;
        previousTimeScale = Time.timeScale;
        Time.timeScale = 0.0f;
        uiManager.OpenPanel(UIManager.Panels.Pause);
    }


    private void DoUnpause()
    {
        uiManager.ClosePanel(UIManager.Panels.Pause);
        Time.timeScale = previousTimeScale;
        paused = false;
    }
}
