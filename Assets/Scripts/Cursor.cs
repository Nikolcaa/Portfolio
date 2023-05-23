using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cursor : MonoBehaviour
{
    [SerializeField] private float _mouseZOffset;

    private void Update()
    {
        FollowMouse();
    }

    private void FollowMouse()
    {
        transform.position = MouseManager.GetMousePos(_mouseZOffset);
    }
}