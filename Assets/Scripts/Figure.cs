using System.Collections.Generic;
using UnityEngine;

public class Figure : MonoBehaviour
{
    [SerializeField] private Transform figure = null;
    [SerializeField] private float sensitivity = 0.5f;
    [SerializeField] private List<GameObject> obstacles = null;
    [SerializeField] private GameObject wallsController = null;

    private IEnumerable<GameObject> ObstaclesPrefab => obstacles;
    private Vector3 _mouseReference;
    private float _rotationY;
    private bool _isMouseDragging;
    private bool _isTouchDragging;

    public void Awake()
    {
        wallsController = GameObject.Find("WallsController");
        wallsController.GetComponent<WallsController>().walls.AddRange(ObstaclesPrefab);
    }

    private void FixedUpdate()
    {
        if (Input.touchCount == 1)
        {
            _isTouchDragging = true;
            
            Touch touch0 = Input.GetTouch(0);
            
            if (touch0.phase == TouchPhase.Moved)
            {
                _rotationY = touch0.deltaPosition.x;
            }
        }
        else
        {
            _isTouchDragging = false;
        }

        if (Input.GetMouseButton(0))
        {
            _isMouseDragging = true;
        }
        else
        {
            _isMouseDragging = false;
            _mouseReference = Vector3.zero;
        }
        
        if (_isMouseDragging)
        {
            if (_mouseReference == Vector3.zero)
            {
                _mouseReference = Input.mousePosition;
            }
            
            var mouseOffset = (Input.mousePosition - _mouseReference);
            _rotationY = -(mouseOffset.x + mouseOffset.y) * sensitivity;
            
            _mouseReference = Input.mousePosition;
        }
        
        if (_isMouseDragging || _isTouchDragging)
        {
            figure.Rotate(0f, _rotationY * sensitivity, 0f);
        }
    }
}