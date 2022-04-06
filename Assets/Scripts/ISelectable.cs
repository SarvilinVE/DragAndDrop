using UnityEngine;

namespace DragAndDrop
{
    internal interface ISelectable
    {
        public bool IsSelectable{ get; set; }
        public bool IsGrounded{ get; set; }
        public Vector3 SelectablePosition { get; }
        public ConfigurableJoint ConfigurableJoint { get; }
    }
}
