using System.Linq;
using UnityEngine;
namespace DragAndDrop
{
    internal class MouseInteractions
    {
        private SelectableObject _selectableObject;
        private DragAndDropModel _dragAndDropModel;
        private GameObject _getTarget;
        public bool IsMouseDragging;
        public bool IsScrollWheel;
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
                RaycastHit hitInfo;
                _getTarget = ReturnClickedObject(out hitInfo);
                if (_getTarget != null)
                {
                    IsMouseDragging = true;
                }
            }
            if (Input.GetMouseButtonUp(1))
            {
                IsMouseDragging = false;
                _dragAndDropModel.Drop();
            }

            if (Input.GetAxis("Mouse ScrollWheel") != 0)
            {
                IsScrollWheel = true;
            }
            else
            {
                IsScrollWheel = false;
            }

        }
        GameObject ReturnClickedObject(out RaycastHit hit)
        {
            GameObject target = null;
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray.origin, ray.direction * 10, out hit))
            {
                target = hit.collider.gameObject;
                var selectable = target.GetComponent<ISelectable>();
                if(selectable != null)
                {
                    _selectableObject.SetValue(selectable);
                    _dragAndDropModel.Drag();
                    return target;
                }
            }
            return target = null;
        }
    }
}
