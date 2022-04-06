using System;
using UnityEngine;
namespace DragAndDrop
{
    [CreateAssetMenu(fileName = nameof(SelectableObject), menuName = "Cursed City/" +
nameof(SelectableObject), order = 0)]
    internal class SelectableObject : ScriptableObject
    {
        public ISelectable CurrentValue { get; private set; }
        public Action<ISelectable> OnSelected;

        public void SetValue(ISelectable value)
        {
            if (value != null)
            {
                CurrentValue = value;
                OnSelected?.Invoke(value);
            }
        }
    }
}
