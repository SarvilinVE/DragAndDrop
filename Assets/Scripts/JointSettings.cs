using UnityEngine;
namespace DragAndDrop
{
    [CreateAssetMenu(fileName = nameof(JointSettings), menuName = "Cursed City/" +
nameof(JointSettings), order = 0)]
    public class JointSettings : ScriptableObject
    {
        [SerializeField] private float _positionSpringY;
        [SerializeField] private float _positionDamperY;
        [SerializeField] private float _connectingAnchorY;
        [SerializeField] private float _massScale;
        [SerializeField] private ConfigurableJointMotion joint;

        public float PositionSpringY => _positionSpringY;
        public float PositionDamperY => _positionDamperY;
        public float ConnectingAnchorY => _connectingAnchorY;
        public float MassScale => _massScale;
    }
}
