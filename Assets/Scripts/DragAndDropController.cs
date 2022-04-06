using UnityEngine;
namespace DragAndDrop
{
    internal class DragAndDropController : MonoBehaviour
    {
        [SerializeField] private SelectableObject _selectableObject;
        [SerializeField] private Camera _camera;
        [SerializeField] private JointPointView _jointPointView;
        [SerializeField] private JointSettings _jointSettings;

        private DragAndDropModel _dragAndDropModel;
        private MouseInteractions _mouseInteractions;

        private void Start()
        {
            _dragAndDropModel = new DragAndDropModel(_selectableObject, _jointPointView, _jointSettings);
            _mouseInteractions = new MouseInteractions(_selectableObject, _dragAndDropModel, _camera);
        }
        private void Update()
        {
            _mouseInteractions.Interaction();
        }
    }
}
