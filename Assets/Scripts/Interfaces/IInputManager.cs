using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Interfaces
{
    public interface IInputManager
    {
        public void OnPressA();
        public void OnPressE();
        public void OnPressLeft();
        public void OnPressRight();
        public void OnPressUp();
        public void OnPressDown();
        public void OnSpace();
        public void OnClickLeft(Vector3 mousePos, bool firstClick);
        public void OnClickMiddle(Vector3 mousePos, bool firstClick);
        public void OnClickRight(Vector3 mousePos, bool firstClick);
        public void OnScrollUp();
        public void OnScrollDown();
        public void OnJoystickMove(Vector3 move);
        public void OnStay();
        public void OnMouseMove(Vector3 mousePos);

    }
}
