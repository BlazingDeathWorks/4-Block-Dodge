using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FutureInspireGames
{
    public class SimpleKeyButtonManager : MonoBehaviour
    {
        [SerializeField]
        SimpleKeyButton[] keyButtons = null;
        public SimpleKeyButton[] KeyButtons => keyButtons;

        private void TriggerEachSimpleKeyButton()
        {
            foreach (SimpleKeyButton keyButton in keyButtons)
            {
                keyButton.TriggerOnKeyPress();
            }
        }

        private void Update()
        {
            TriggerEachSimpleKeyButton();
        }
    }
}
