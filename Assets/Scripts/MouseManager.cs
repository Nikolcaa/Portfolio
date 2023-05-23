using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseManager : MonoBehaviour
{
    private static Camera _cam;
    public static Vector3 MousePos;

    private void Awake()
    {
        _cam = Camera.main;
    }

    private void Update()
    {
        MousePos = CalculateMousePos();
    }

    private Vector3 CalculateMousePos()
    {
        Vector3 pos;
        pos = _cam.ScreenToWorldPoint(Input.mousePosition);
        pos.z = 0;
        return pos;
    }

    public static Vector3 GetMousePos(float zOffset = 0)
    {
        Vector3 pos;
        pos = _cam.ScreenToWorldPoint(Input.mousePosition);
        pos.z = zOffset;
        return pos;
    }


}