using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class RotateByDragging : MonoBehaviour
{
    [SerializeField] private Transform _targetT;

    Vector3 mPrevPos = Vector3.zero;
    Vector3 mPosDelta = Vector3.zero;

    private void Update()
    {
        mPrevPos = Cursor.Position;
    }

    private void OnMouseDrag()
    {
        mPosDelta = Cursor.Position - mPrevPos;
        _targetT.Rotate(_targetT.up, -Vector3.Dot(mPosDelta, Vector3.right), Space.World);
    }
}
