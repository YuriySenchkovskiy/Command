using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Script
{
    public class DropDownHandler : MonoBehaviour
    {
        [SerializeField] private ChangeButtonEventComponent _action;

        private Dropdown drop;
        void Start()
        {
            drop = transform.GetComponent<Dropdown>();
            drop.options.Clear();

            var keyCodes  = Enum.GetNames(typeof(KeyCode));

            foreach (var k in keyCodes)
            {
                drop.options.Add(new Dropdown.OptionData() {text = k});
            }

            DropDownItemsSend(drop);
            drop.onValueChanged.AddListener(delegate { DropDownItemsSend(drop); });
        }

        private void DropDownItemsSend(Dropdown drop)
        {
            _action?.Invoke(drop.value);
        }
    }
    
    [Serializable]
    public class ChangeButtonEventComponent : UnityEvent<Int32>
    {
    }
}