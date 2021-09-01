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
    private Dictionary<KeyCode, UnityEvent<bool>> inputEvents, mouseEvents;

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

        mouseEvents = new Dictionary<KeyCode, UnityEvent<bool>>
        {
            { KeyCode.Mouse0, OnClickL},
            { KeyCode.Mouse1, OnClickR},
            { KeyCode.Mouse2, OnClickM},
        };

        inputEvents = new Dictionary<KeyCode, UnityEvent<bool>>
        {
            { KeyCode.A, OnA },
            { KeyCode.E, OnE },
            { KeyCode.F, OnF },
            { KeyCode.R, OnR },

            { KeyCode.I, OnI },
            { KeyCode.K, OnK },
            { KeyCode.L, OnL },
        };
    }


    private void Update()
    {
        DetectEscape();
    }


    void FixedUpdate()
    {
        DetectMouseInputs();
        DetectInputs();
    }


    void DetectMouseInputs()
    {
        foreach (KeyValuePair<KeyCode, UnityEvent<bool>> keyPressed in mouseEvents)
        {
            if (Input.GetKey(keyPressed.Key)) { keyPressed.Value.Invoke(firstClickState[keyPressed.Key]); firstClickState[keyPressed.Key] = false; } else firstClickState[keyPressed.Key] = true;
        }
        OnMouseMove.Invoke(Input.mousePosition);
    }


    void DetectInputs()
    {
        int scrollDelta = MoInput.ScrollHasChanged();
        Vector3 joystick = MoInput.GetZQSDDirection();

        OnJoystick.Invoke(joystick);

        foreach (KeyValuePair<KeyCode, UnityEvent<bool>> keyPressed in inputEvents)
        {
            if (Input.GetKey(keyPressed.Key)) { keyPressed.Value.Invoke(firstClickState[keyPressed.Key]); firstClickState[keyPressed.Key] = false; } else firstClickState[keyPressed.Key] = true;
        }
    }


    void DetectEscape()
    {
        if (Input.GetKey(KeyCode.Escape)) { OnEscape.Invoke(firstClickState[KeyCode.Escape]); firstClickState[KeyCode.Escape] = false; } else firstClickState[KeyCode.Escape] = true;
    }
}
