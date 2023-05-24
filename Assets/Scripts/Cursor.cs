using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cursor : MonoBehaviour
{
    [SerializeField] private float _mouseZOffset;
    [SerializeField] private float _speed;
    private static Transform T;

    public static Vector3 Position => T.position;

    private void Awake()
    {
        T = transform;
    }

    private void Update()
    {
        FollowMouse();
    }

    private void FollowMouse()
    {
        transform.position = Vector3.Lerp(transform.position, MouseManager.GetMousePos(_mouseZOffset), _speed * Time.deltaTime);
    }
}