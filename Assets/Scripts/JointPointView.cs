using UnityEngine;

public class JointPointView : MonoBehaviour
{
    private GameObject _getTarget;
    public bool isMouseDragging;
    private Vector3 _offsetValue;
    private Vector3 _positionOfScreen;
    [SerializeField] private float step = 5.0f;
    [SerializeField] private float moveZ;

    void Start()
    {
        isMouseDragging = false;
    }

    void Update()
    {


        if (!isMouseDragging)
        {
            _getTarget = transform.gameObject;
            if (_getTarget != null)
            {
                isMouseDragging = true;
                _positionOfScreen = Camera.main.WorldToScreenPoint(_getTarget.transform.position);
                _offsetValue = _getTarget.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, _positionOfScreen.z));
                moveZ = 0.0f;
            }
        }

        if (Input.GetMouseButtonUp(1))
        {
            isMouseDragging = false;
        }

        if (isMouseDragging)
        {
            var currentScreenSpace = new Vector3(Input.mousePosition.x, Input.mousePosition.y, moveZ + _positionOfScreen.z);
            var currentPosition = Camera.main.ScreenToWorldPoint(currentScreenSpace) + _offsetValue;

            _getTarget.transform.position = currentPosition;
            moveZ += Input.GetAxis("Mouse ScrollWheel") * step * Time.deltaTime;
        }
    }
}
