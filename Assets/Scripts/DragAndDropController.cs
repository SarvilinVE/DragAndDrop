using UnityEngine;
namespace DragAndDrop
{
    internal class DragAndDropController : MonoBehaviour
    {
        [SerializeField] private SelectableObject _selectableObject;
        [SerializeField] private Camera _camera;
        [SerializeField] private JointSettings _jointSettings;

        private DragAndDropModel _dragAndDropModel;
        private MouseInteractions _mouseInteractions;

        private ISelectable[] _buildings;

        private void Start()
        {
            _dragAndDropModel = new DragAndDropModel(_selectableObject, _jointSettings);
            _mouseInteractions = new MouseInteractions(_selectableObject, _dragAndDropModel, _camera);

            _buildings = FindObjectsOfType<BuldingView>();
        }
        private void Update()
        {
            _mouseInteractions.Interaction();
            if (_mouseInteractions.IsMouseDragging)
            {
                foreach(var building in _buildings)
                {
                    if (!building.IsSelected)
                        building.Rigidbody.isKinematic = false;
                }
            }
            else
            {
                foreach (var building in _buildings)
                {
                    if (!building.IsSelected)
                    {
                        if(building.SelectablePosition == building.SelectableDefaultPosition && building.SelectableRotation == building.SelectableDefaultRotation)
                            building.Rigidbody.isKinematic = true;
                    }
                }
            }
        }
        private void FixedUpdate()
        {
            if (_mouseInteractions.IsMouseDragging)
                _selectableObject.Move(_camera, 2000.0f);
        }
    }
}
