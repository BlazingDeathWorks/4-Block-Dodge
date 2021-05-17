using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace FutureInspireGames
{
    public static class Keyboard
    {
        public static KeyCode ReadKeyDown()
        {
            foreach (KeyCode keyCode in Enum.GetValues(typeof(KeyCode)))
            {
                if (Input.GetKeyDown(keyCode))
                {
                    return keyCode;
                }
            }
            return KeyCode.None;
        }

        public static KeyCode ReadKey()
        {
            foreach (KeyCode keyCode in Enum.GetValues(typeof(KeyCode)))
            {
                if (Input.GetKey(keyCode))
                {
                    return keyCode;
                }
            }
            return KeyCode.None;
        }

        public static KeyCode ReadKeyUp()
        {
            foreach (KeyCode keyCode in Enum.GetValues(typeof(KeyCode)))
            {
                if (Input.GetKeyUp(keyCode))
                {
                    return keyCode;
                }
            }
            return KeyCode.None;
        }
    }
}
