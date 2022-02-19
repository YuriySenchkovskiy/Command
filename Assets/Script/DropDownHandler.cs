using System;
using UnityEngine;
using UnityEngine.UI;

namespace Script
{
    public class DropDownHandler : MonoBehaviour
    {
        void Start()
        {
            var input = FindObjectOfType<InputHandler>();
            var drop = transform.GetComponent<Dropdown>();
            drop.options.Clear();

            var keyCodes  = Enum.GetNames(typeof(KeyCode));

            foreach (var k in keyCodes)
            {
                drop.options.Add(new Dropdown.OptionData() {text = k});
            }

            input.ChangeGoForwardButton(drop.value);
            drop.onValueChanged.AddListener(input.ChangeGoForwardButton);
        }
    }
}