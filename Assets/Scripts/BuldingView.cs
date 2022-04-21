using UnityEngine;
namespace DragAndDrop
{
    internal class BuldingView : MonoBehaviour, ISelectable
    {
        [SerializeField] private ConfigurableJoint _configurableJoint;
        [SerializeField] private JointSettings _jointSettings;
        [SerializeField] private Rigidbody _rigidbody;
        private bool _isSelected = false;
        private bool _isGrounded = false;
        private Vector3 _defaultPosition;
        private Quaternion _defaultRotation;
        public ConfigurableJoint ConfigurableJoint => _configurableJoint;
        public Rigidbody Rigidbody => _rigidbody;
        public bool IsSelected { get => _isSelected; set { _isSelected = value; } }
        public bool IsGrounded { get => _isGrounded; set { _isGrounded = value; } }
        public Vector3 SelectablePosition { get => transform.position; set => transform.position = value; }
        public Vector3 SelectableDefaultPosition { get => _defaultPosition; set => _defaultPosition = value; }
        public Quaternion SelectableRotation { get => transform.rotation; set => transform.rotation = value; }
        public Quaternion SelectableDefaultRotation{ get => _defaultRotation; set => _defaultRotation = value; }

        private void Start()
        {
            _defaultPosition = transform.position;
            _defaultRotation = transform.rotation;
            _rigidbody.isKinematic = true;
            _isGrounded = true;

            _configurableJoint.xMotion = ConfigurableJointMotion.Free;
            _configurableJoint.yMotion = ConfigurableJointMotion.Limited;
            _configurableJoint.zMotion = ConfigurableJointMotion.Free;
        }
        private void OnTriggerEnter(Collider other)
        {
            if (other.transform.CompareTag($"Building"))
            {
                if (IsSelected)
                    _isGrounded = false;
            }
        }
        private void OnTriggerExit(Collider other)
        {
            if (other.transform.CompareTag($"Building"))
            {
                if (IsSelected)
                    _isGrounded = true;
            }
        }
    }
}
