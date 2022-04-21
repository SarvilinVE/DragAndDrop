using UnityEngine;

namespace DragAndDrop
{
    internal interface ISelectable
    {
        public bool IsSelected{ get; set; }
        public bool IsGrounded{ get; set; }
        public Rigidbody Rigidbody { get; }
        public Vector3 SelectablePosition { get; set; }
        public Vector3 SelectableDefaultPosition { get; set; }
        public Quaternion SelectableRotation { get; set; }
        public Quaternion SelectableDefaultRotation { get; set; }
        public ConfigurableJoint ConfigurableJoint { get; }
    }
}
