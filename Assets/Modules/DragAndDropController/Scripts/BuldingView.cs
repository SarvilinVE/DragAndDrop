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
        private void Awake()
        {
            _configurableJoint.autoConfigureConnectedAnchor = false;

            var connectedAnchorY = _configurableJoint.connectedAnchor;
            connectedAnchorY.y = _jointSettings.ConnectingAnchorY;
            _configurableJoint.connectedAnchor = connectedAnchorY;

            _configurableJoint.autoConfigureConnectedAnchor = true;

            _configurableJoint.xMotion = _jointSettings.XMotion;
            _configurableJoint.yMotion = _jointSettings.YMotion;
            _configurableJoint.zMotion = _jointSettings.ZMotion;

            var linearLimitSpring = _configurableJoint.linearLimitSpring;
            linearLimitSpring.spring = _jointSettings.Spring;
            _configurableJoint.linearLimitSpring = linearLimitSpring;

            var linearLimit = _configurableJoint.linearLimit;
            linearLimit.limit = _jointSettings.Limit;
            _configurableJoint.linearLimit = linearLimit;

            var xDrive = _configurableJoint.xDrive;
            xDrive.positionSpring = _jointSettings.PositionSpringX;
            xDrive.positionDamper = _jointSettings.PositionDamperX;
            _configurableJoint.xDrive = xDrive;

            var yDrive = _configurableJoint.yDrive;
            yDrive.positionSpring = _jointSettings.PositionSpringY;
            yDrive.positionDamper = _jointSettings.PositionDamperY;
            _configurableJoint.yDrive = yDrive;

            var zDrive = _configurableJoint.zDrive;
            zDrive.positionSpring = _jointSettings.PositionSpringZ;
            zDrive.positionDamper = _jointSettings.PositionDamperZ;
            _configurableJoint.zDrive = zDrive;
        }

        private void Start()
        {
            _defaultPosition = transform.position;
            _defaultRotation = transform.rotation;
            _rigidbody.isKinematic = true;
            _isGrounded = true;
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
