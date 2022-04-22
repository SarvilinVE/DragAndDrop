using UnityEngine;
namespace DragAndDrop
{
    [CreateAssetMenu(fileName = nameof(JointSettings), menuName = "Cursed City/" +
nameof(JointSettings), order = 0)]
    public class JointSettings : ScriptableObject
    {
        [SerializeField] private float _connectingAnchorY;
        [SerializeField] private ConfigurableJointMotion _xMotion;
        [SerializeField] private ConfigurableJointMotion _yMotion;
        [SerializeField] private ConfigurableJointMotion _zMotion;
        [Header ("Leaner Limit Spring")]
        [SerializeField] private float _spring;
        [Header("Leaner Limit")]
        [SerializeField] private float _limit;
        [Header("X Drive")]
        [SerializeField] private float _positionSpringX;
        [SerializeField] private float _positionDamperX;
        [Header("Y Drive")]
        [SerializeField] private float _positionSpringY;
        [SerializeField] private float _positionDamperY;
        [Header("Z Drive")]
        [SerializeField] private float _positionSpringZ;
        [SerializeField] private float _positionDamperZ;

        
        public float ConnectingAnchorY => _connectingAnchorY;
        public ConfigurableJointMotion XMotion => _xMotion;
        public ConfigurableJointMotion YMotion => _yMotion;
        public ConfigurableJointMotion ZMotion => _zMotion;
        public float Spring => _spring;
        public float Limit => _limit;
        public float PositionSpringX => _positionSpringX;
        public float PositionDamperX => _positionDamperX;
        public float PositionSpringY => _positionSpringY;
        public float PositionDamperY => _positionDamperY;
        public float PositionSpringZ => _positionSpringZ;
        public float PositionDamperZ => _positionDamperZ;
    }
}
