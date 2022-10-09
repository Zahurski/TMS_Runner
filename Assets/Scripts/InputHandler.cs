using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour, IInputHandler
{
    private bool _isHeld = false;
    private Vector3 _position;
    private float _horizontalAxis;

    public float GetHorizontalAxis() => _horizontalAxis;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _isHeld = true;
            _position = Input.mousePosition; //следим за позицией пальца по экрану
        }

        if (Input.GetMouseButtonUp(0))
        {
            _isHeld = false;
            _position = Vector3.zero;
            _horizontalAxis = 0f;
        }

        if (_isHeld)
        {
            Vector3 offset = _position - Input.mousePosition; //следит влево/вправо мы ведем пальцем
            _horizontalAxis = offset.x / Screen.width; //только по иксу запоминаем движения, без верх/низ и на ширину экрана для уменьшения скорости
            _position = Input.mousePosition;
        }
    }
}
