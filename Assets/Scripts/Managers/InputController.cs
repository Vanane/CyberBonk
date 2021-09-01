using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts.Interfaces
{
    public abstract class InputController : MonoBehaviour
    {
        public PlayerController player;
        public GameObject PauseMenuPanel, InventoryPanel, SkillsPanel, MissionsPanel;

        public List<GameObject> activePanels;



        virtual public void OnPressA(bool firstClick) { }
        virtual public void OnPressE(bool firstClick) { }
        virtual public void OnPressF(bool firstClick) { }
        virtual public void OnPressI(bool firstClick) { }
        virtual public void OnPressK(bool firstClick) { }
        virtual public void OnPressL(bool firstClick) { }
        virtual public void OnPressR(bool firstClick) { }
        virtual public void OnPressEscape(bool firstClick) { }
        virtual public void OnPressShift(bool firstClick) { }
        virtual public void OnPressLeft() { }
        virtual public void OnPressRight() { }
        virtual public void OnPressUp() { }
        virtual public void OnPressDown() { }
        virtual public void OnSpace() { }
        virtual public void OnClickLeft(Vector3 mousePos, bool firstClick) { }
        virtual public void OnClickMiddle(Vector3 mousePos, bool firstClick) { }
        virtual public void OnClickRight(Vector3 mousePos, bool firstClick) { }
        virtual public void OnScrollUp() { }
        virtual public void OnScrollDown() { }
        virtual public void OnJoystickMove(Vector3 move) { }
        virtual public void OnStay() { }
        virtual public void OnMouseMove(Vector3 mousePos) { }
    }
}
