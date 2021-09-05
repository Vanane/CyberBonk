using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PausePanel : UIPanel
{
    override public void OnOpen()
    {
        Debug.Log("paused");
    }


    override public void OnClose()
    {

    }
}
