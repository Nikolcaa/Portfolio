using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class RotateByDragging : MonoBehaviour
{
    [SerializeField] private Transform _targetT;
    [SerializeField] private float speed = 40;

    Vector2 mPrevPos = Vector2.zero;
    Vector2 mPosDelta = Vector2.zero;

    private void Update()
    {
        mPrevPos = Cursor.Position;
    }


    private void OnMouseDrag()
    {
        float XaxisRotation = Input.GetAxis("Mouse X") * Time.deltaTime * speed;
        float YaxisRotation = Input.GetAxis("Mouse Y") * Time.deltaTime * speed;
        // select the axis by which you want to rotate the GameObject
        _targetT.RotateAround(Vector3.down, XaxisRotation);
        _targetT.RotateAround(Vector3.right, YaxisRotation);
    }
}
