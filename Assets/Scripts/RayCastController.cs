using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCastController : MonoBehaviour
{
    [SerializeReference] private LayerMask _rayLayerMask;

    private void Update()
    {
        Ray ray = new Ray();
        ray.origin = transform.position;
        ray.direction = transform.forward;

        if (Physics.Raycast(ray, out RaycastHit hit, 30f, _rayLayerMask))
        {
            Debug.DrawLine(ray.origin, hit.point, Color.green);
            Debug.Log(hit.collider.gameObject.name);
            Debug.Log(hit.distance);
        }
    }
}
