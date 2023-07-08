using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateTowardsCursor : MonoBehaviour
{
    [SerializeField] private bool _x;
    [SerializeField] private bool _y;
    [SerializeField] private bool _z;

    private void Update()
    {
        Vector3 newRot = transform.rotation.eulerAngles;
        Vector3 dir = (transform.position - Cursor.Position).normalized;

        transform.forward = new Vector3(dir.x, Mathf.Clamp(dir.y, -1, 0), dir.z*4);
    }
}
