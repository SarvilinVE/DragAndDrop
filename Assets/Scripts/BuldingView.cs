using UnityEngine;
namespace DragAndDrop
{
    internal class BuldingView : MonoBehaviour, ISelectable
    {
        [SerializeField] private ConfigurableJoint _configurableJoint;
        [SerializeField] private JointSettings _jointSettings;
        private bool _isSelected = false;
        private bool _isGrounded = true;
        private bool _isDefaulted = true;
        private Vector3 _defaultPosition;
        public ConfigurableJoint ConfigurableJoint => _configurableJoint;
        public bool IsSelectable { get => _isSelected; set { _isSelected = value; } }
        public bool IsGrounded { get => _isGrounded; set { _isGrounded = value; } }
        public Vector3 SelectablePosition => transform.position;

        private void Start()
        {
            _defaultPosition = transform.position;
        }
        private void OnCollisionEnter(Collision collision)
        {
            if (!_isSelected)
            {
                if (!_isGrounded)
                {
                    if (collision.transform.tag == "Ground")
                    {
                        _isGrounded = true;
                        _defaultPosition = transform.position;
                    }

                    if (collision.transform.tag != "Ground" || collision.transform.tag == "Building")
                        transform.position = _defaultPosition;
                }
            }
        }
        private void Update()
        {
            if (_isSelected)
                return;

            if (_isGrounded && _isDefaulted)
                return;

            if (!_isGrounded)
            {
                JointOff();
            }

            if (_isGrounded && !_isDefaulted)
            {
                JointOn();
            }
        }
        private void JointOff()
        {
            _configurableJoint.autoConfigureConnectedAnchor = false;

            _configurableJoint.yMotion = ConfigurableJointMotion.Free;

            var anchor = _configurableJoint.connectedAnchor;
            anchor.y = _jointSettings.ConnectingAnchorY;
            _configurableJoint.connectedAnchor = anchor;

            var driveY = _configurableJoint.yDrive;
            driveY.positionSpring = 0.0f;
            driveY.positionDamper = 0.0f;
            _configurableJoint.yDrive = driveY;

            _configurableJoint.massScale = 0.0f;

            _isDefaulted = false;
        }
        private void JointOn()
        {
            _configurableJoint.autoConfigureConnectedAnchor = true;

            _configurableJoint.yMotion = ConfigurableJointMotion.Locked;

            var anchor = _configurableJoint.connectedAnchor;
            anchor.y = _jointSettings.ConnectingAnchorY;
            _configurableJoint.connectedAnchor = anchor;

            var driveY = _configurableJoint.yDrive;
            driveY.positionSpring = _jointSettings.PositionSpringY;
            driveY.positionDamper = _jointSettings.PositionDamperY;
            _configurableJoint.yDrive = driveY;

            _configurableJoint.massScale = _jointSettings.MassScale;

            _isDefaulted = true;
        }
    }
}
