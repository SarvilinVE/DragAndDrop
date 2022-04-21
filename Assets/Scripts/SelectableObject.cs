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
        public void Move(Camera cam, float speed)
        {
            if(CurrentValue.IsGrounded)
                CurrentValue.Rigidbody.isKinematic = true;

            var positionOfScreen = Camera.main.WorldToScreenPoint(CurrentValue.SelectablePosition);
            var offsetValue = CurrentValue.SelectablePosition - cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, positionOfScreen.z));

            var currentScreenSpace = new Vector3(Input.mousePosition.x, Input.mousePosition.y, positionOfScreen.z);
            var currentPosition = cam.ScreenToWorldPoint(currentScreenSpace);

            var pos = CurrentValue.Rigidbody.position;
            pos.x = currentPosition.x;
            pos.y = CurrentValue.SelectablePosition.y;
            pos.z = currentPosition.z;
            CurrentValue.Rigidbody.position = pos;

            CurrentValue.Rigidbody.MovePosition(CurrentValue.Rigidbody.position - offsetValue * Time.deltaTime);

            if(Input.GetAxis("Mouse ScrollWheel") != 0)
                Rotation(speed);
        }
        public void Rotation(float speed)
        {
            Vector3 rotationY = new Vector3(0, Input.GetAxis("Mouse ScrollWheel"), 0);
            rotationY = rotationY.normalized * speed * Time.deltaTime;
            Quaternion deltaRotation = Quaternion.Euler(rotationY );

            CurrentValue.Rigidbody.MoveRotation(CurrentValue.Rigidbody.rotation * deltaRotation );
        }
    }
}
