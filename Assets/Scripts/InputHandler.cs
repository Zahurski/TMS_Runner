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
            _position = Input.mousePosition; //������ �� �������� ������ �� ������
        }

        if (Input.GetMouseButtonUp(0))
        {
            _isHeld = false;
            _position = Vector3.zero;
            _horizontalAxis = 0f;
        }

        if (_isHeld)
        {
            Vector3 offset = _position - Input.mousePosition; //������ �����/������ �� ����� �������
            _horizontalAxis = offset.x / Screen.width; //������ �� ���� ���������� ��������, ��� ����/��� � �� ������ ������ ��� ���������� ��������
            _position = Input.mousePosition;
        }
    }
}
