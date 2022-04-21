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
        private Vector3 _positionOfScreen;
        private Vector3 _offsetValue;
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
                    
                    //Converting world position to screen position.
                    //_positionOfScreen = Camera.main.WorldToScreenPoint(_getTarget.transform.position);
                    //_offsetValue = _getTarget.transform.position - _camera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, _positionOfScreen.z));
                }
            }

            //Mouse Button Up
            if (Input.GetMouseButtonUp(1))
            {
                IsMouseDragging = false;
                _dragAndDropModel.Drop();
            }

            //Is mouse Moving
            if (IsMouseDragging)
            {
                //_selectableObject.Move(_camera, 2000.0f);
                ////tracking mouse position.
                //var currentScreenSpace = new Vector3(Input.mousePosition.x, Input.mousePosition.y, _positionOfScreen.z);

                ////converting screen position to world position with offset changes.
                //var currentPosition = _camera.ScreenToWorldPoint(currentScreenSpace) + _offsetValue;

                ////It will update target gameobject's current postion.
                //_getTarget.transform.position += new Vector3(currentPosition.x, _getTarget.transform.position.y, currentPosition.z);
                //_getTarget.GetComponent<Rigidbody>().velocity = _getTarget.transform.position;
                //var curPos = new Vector3(currentPosition.x, _getTarget.transform.position.y, currentPosition.z);
                //_getTarget.transform.position = Vector3.MoveTowards(_getTarget.transform.position, curPos, 20.0f * Time.deltaTime);
                //_selectableObject.CurrentValue.Rigidbody.velocity = new Vector3(currentPosition.x, _selectableObject.CurrentValue.Rigidbody.velocity.y, currentPosition.z);

            }

        }

        //Method to Return Clicked Object
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
