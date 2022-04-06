using UnityEngine;
namespace DragAndDrop
{
    internal class DragAndDropModel
    {
        private SelectableObject _selectableObject;
        private JointSettings _jointSettings;

        private JointPointView _jointPointView;
        private Vector3 _defaultJointPointPosition;
        private bool _isDefaulted = true;
        public DragAndDropModel(SelectableObject selectableObject, JointPointView jointPointView, JointSettings jointSettings)
        {
            _selectableObject = selectableObject;
            _jointPointView = jointPointView;
            _jointSettings = jointSettings;
        }

        private void onSelected(ISelectable selectable)
        {
            selectable.IsSelectable = true;
            selectable.IsGrounded = false;
            _isDefaulted = true;
            selectable.ConfigurableJoint.connectedBody = _jointPointView.GetComponent<Rigidbody>();
        }

        public void Drag(Vector3 position)
        {
            var pos = new Vector3(position.x, position.y, position.z);
            _defaultJointPointPosition = _jointPointView.transform.position;
            _jointPointView.transform.position = pos;

            _jointPointView.gameObject.SetActive(true);

            _selectableObject.OnSelected += onSelected;
            onSelected(_selectableObject.CurrentValue);
        }
        public void Drop()
        {
            _selectableObject.OnSelected -= onSelected;
            _selectableObject.CurrentValue.IsSelectable = false;
            _selectableObject.CurrentValue.ConfigurableJoint.connectedBody = null;
            _jointPointView.transform.position = _defaultJointPointPosition;
            _jointPointView.gameObject.SetActive(false);
        }
    }
}
