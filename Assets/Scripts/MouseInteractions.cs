using System.Linq;
using UnityEngine;
namespace DragAndDrop
{
    internal class MouseInteractions
    {
        private SelectableObject _selectableObject;
        private DragAndDropModel _dragAndDropModel;
        private Camera _camera;
        public MouseInteractions(SelectableObject selectableObject, DragAndDropModel dragAndDropModel, Camera camera)
        {
            _selectableObject = selectableObject;
            _dragAndDropModel = dragAndDropModel;
            _camera = camera;
        }
        public void Interaction()
        {
            if (Input.GetMouseButtonDown(1))
            {
                var hits = Physics.RaycastAll(_camera.ScreenPointToRay(Input.mousePosition));
                if (hits.Length == 0)
                {
                    return;
                }
                var selectable = hits
                    .Select(hit => hit.collider.GetComponent<ISelectable>())
                    .Where(c => c != null)
                    .FirstOrDefault();
                _selectableObject.SetValue(selectable);
                if (selectable != null)
                    _dragAndDropModel.Drag(_selectableObject.CurrentValue.SelectablePosition);
            }
            if (Input.GetMouseButtonUp(1))
            {
                if (_selectableObject.CurrentValue != null)
                    _dragAndDropModel.Drop();
            }
        }
    }
}
