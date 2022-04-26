using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodSplatterNormal : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Collider collider = GetComponent<Collider>();

        Vector3 closestPoint = collider.ClosestPoint(transform.position);

        Debug.Log(closestPoint);
    }
}
