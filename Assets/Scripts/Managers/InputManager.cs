using Assets.Scripts.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityExtensions;

/// <summary>
/// Object that computes and manages inputs for the player's controls
/// </summary>
public class InputManager : MonoBehaviour
{

    private Dictionary<KeyCode, bool> firstClickState;
    private Dictionary<KeyCode, UnityEvent<bool>> keyEvents;

    public UnityEvent<Vector3> OnMouseMove, OnJoystick;
    public UnityEvent<bool> OnClickL, OnClickR, OnClickM, OnA, OnE, OnF, OnR, OnI, OnK, OnL, OnEscape;


    private void Start()
    {
        firstClickState = new Dictionary<KeyCode, bool>
        {
            { KeyCode.Mouse0, false },
            { KeyCode.Mouse1, false },
            { KeyCode.Mouse2, false },

            { KeyCode.A, false },
            { KeyCode.E, false },
            { KeyCode.F, false },
            { KeyCode.R, false },

            { KeyCode.I, false },
            { KeyCode.K, false },
            { KeyCode.L, false },

            { KeyCode.Escape, false },
        };

        keyEvents = new Dictionary<KeyCode, UnityEvent<bool>>
        {
            { KeyCode.Mouse0, OnClickL },
            { KeyCode.Mouse1, OnClickR },
            { KeyCode.Mouse2, OnClickM },

            { KeyCode.A, OnA },
            { KeyCode.E, OnE },
            { KeyCode.F, OnF },
            { KeyCode.R, OnR },

            { KeyCode.I, OnI },
            { KeyCode.K, OnK },
            { KeyCode.L, OnL },

            { KeyCode.Escape, OnEscape },

        };
    }


    private void Update()
    {
    }


    void FixedUpdate()
    {
        DetectMouseInputs();
        DetectInputs();
    }


    void DetectMouseInputs()
    {
        if (Input.GetKey(KeyCode.Mouse0)) { firstClickState[KeyCode.Mouse0] = false; } else firstClickState[KeyCode.Mouse0] = true;
        if (Input.GetKey(KeyCode.Mouse1)) { firstClickState[KeyCode.Mouse1] = false; } else firstClickState[KeyCode.Mouse1] = true;
        if (Input.GetKey(KeyCode.Mouse2)) { firstClickState[KeyCode.Mouse2] = false; } else firstClickState[KeyCode.Mouse2] = true;
        OnMouseMove.Invoke(Input.mousePosition);
    }


    void DetectInputs()
    {
        int scrollDelta = MoInput.ScrollHasChanged();
        Vector3 joystick = MoInput.GetZQSDDirection();

        OnJoystick.Invoke(joystick);

        foreach (KeyValuePair<KeyCode, UnityEvent<bool>> keyPressed in keyEvents)
        {
            if (Input.GetKey(keyPressed.Key)) { keyPressed.Value.Invoke(firstClickState[keyPressed.Key]); firstClickState[keyPressed.Key] = false; } else firstClickState[keyPressed.Key] = true;
        }
    }
}
