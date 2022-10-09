using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveController : MonoBehaviour, IMoveController
{
    [SerializeField] private float _slewingSpeed;
    [SerializeField] private float _roadWidth;
    [SerializeField] private float _forwardSpeed;

    public void Move(float horizontalAxis)
    {
        Vector3 position = transform.position;
        position.x += -horizontalAxis * _slewingSpeed;
        position.x = Mathf.Clamp(position.x, -_roadWidth / 2f, _roadWidth / 2f);
        position.z += _forwardSpeed * Time.deltaTime;
        transform.position = position;
    }
}
