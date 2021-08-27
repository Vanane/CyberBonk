using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace UnityExtensions
{
    public static class MoInput
    {
        private static Vector2 lastScrollDelta;


        /// <summary>
        /// returns -1 if scroll down, 1 if scroll up, 0 else, if in the current frame, the mousewheel has been scrolled.
        /// </summary>
        /// <returns></returns>
        public static int ScrollHasChanged()
        {
            int ret = Input.mouseScrollDelta.y < lastScrollDelta.y ? 1 : Input.mouseScrollDelta.y > lastScrollDelta.y ? -1 : 0;
            if(ret != 0)
                lastScrollDelta = Input.mouseScrollDelta;
            return ret;
        }


        public static Vector3 GetZQSDDirection()
        {
            Vector3 ret = new Vector3
            {
                x = Input.GetKey(KeyCode.D) ? 1 : Input.GetKey(KeyCode.Q) ? -1 : 0,
                y = 0,
                z = Input.GetKey(KeyCode.Z) ? 1 : Input.GetKey(KeyCode.S) ? -1 : 0,
            }.normalized;

            return ret;
        }

    }
}
