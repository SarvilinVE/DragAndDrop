using UnityEngine;
namespace DragAndDrop
{
    internal class DragAndDropModel
    {
        private SelectableObject _selectableObject;
        private JointSettings _jointSettings;
        public DragAndDropModel(SelectableObject selectableObject, JointSettings jointSettings)
        {
            _selectableObject = selectableObject;
            _jointSettings = jointSettings;
        }

        private void onSelected(ISelectable selectable)
        {
            selectable.IsSelected = true;
            selectable.Rigidbody.isKinematic = false;
        }

        public void Drag()
        {
            _selectableObject.OnSelected += onSelected;
            onSelected(_selectableObject.CurrentValue);
        }
        public void Drop()
        {
            _selectableObject.OnSelected -= onSelected;
            if (_selectableObject.CurrentValue.IsGrounded)
            {
                _selectableObject.CurrentValue.SelectableDefaultPosition = _selectableObject.CurrentValue.SelectablePosition;
                _selectableObject.CurrentValue.SelectableDefaultRotation = _selectableObject.CurrentValue.SelectableRotation;

            }
            else
            {
                _selectableObject.CurrentValue.SelectablePosition = _selectableObject.CurrentValue.SelectableDefaultPosition;
                _selectableObject.CurrentValue.SelectableRotation = _selectableObject.CurrentValue.SelectableDefaultRotation;
                _selectableObject.CurrentValue.IsGrounded = true;
            }
            _selectableObject.CurrentValue.IsSelected = false;
            StateUpdateJoint(_selectableObject.CurrentValue.ConfigurableJoint);
        }
        private void StateUpdateJoint(ConfigurableJoint configurableJoint)
        {
            configurableJoint.autoConfigureConnectedAnchor = false;
            configurableJoint.connectedAnchor = _selectableObject.CurrentValue.SelectablePosition;
            configurableJoint.autoConfigureConnectedAnchor = true;
        }
    }
}
