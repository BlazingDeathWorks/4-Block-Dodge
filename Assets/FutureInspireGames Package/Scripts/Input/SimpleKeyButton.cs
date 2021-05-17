using UnityEngine;
using System;

namespace FutureInspireGames
{
    [Serializable]
    public class SimpleKeyButton
    {
        [SerializeField]
        private KeyCode keyCode;
        public KeyCode KeyCode { set => keyCode = value; }
        public event Action OnKeyPressEvent = null;
        public bool IsEnabled { get; private set; }

        public bool IsPressed()
        {
            return Input.GetKeyDown(keyCode) || Input.GetKey(keyCode);
        }

        public void DisableBy(bool condition)
        {
            if (condition)
            {
                IsEnabled = true;
                return;
            }
            IsEnabled = false;
        }

        public void TriggerOnKeyPress()
        {
            if (IsPressed() && IsEnabled)
            {
                OnKeyPressEvent?.Invoke();
            }
        }
    }
}
