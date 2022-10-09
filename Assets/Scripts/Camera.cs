using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    [SerializeField] private float _smooth;
    [SerializeField] private GameObject _target;
    [SerializeField] private float _height;

    void FixedUpdate()
    {
        Vector3 pos = new Vector3(_target.transform.position.x, _target.transform.position.y + _height, _target.transform.position.z - 10);
        transform.position = Vector3.Lerp(transform.position, pos, _smooth);
    }
}
