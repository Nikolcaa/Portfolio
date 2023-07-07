using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cursor : MonoBehaviour
{
    [SerializeField] private float _mouseZOffset;
    [SerializeField] private float _speed;
    private static Transform T;

    public static Vector3 Position => T.position;

    public void SetUp()
    {
        T = transform;
        T.position = Vector3.zero;
    }

    private void Update()
    {
        if (GameManager.Instance.GameState != GameState.STATE1_HOME)
            return;

        FollowMouse();
        RotateToMouse();
        ScaleToMouse();
    }

    private void FollowMouse()
    {
        transform.position = Vector3.Lerp(transform.position, MouseManager.GetMousePos(_mouseZOffset), _speed * Time.deltaTime);
    }

    private void RotateToMouse()
    {
        Vector3 dir = Vector2.ClampMagnitude(transform.position - MouseManager.GetMousePos(_mouseZOffset), 1);
        transform.up = dir;
    }

    private void ScaleToMouse()
    {
        Vector2 dir = transform.position - MouseManager.GetMousePos(_mouseZOffset);
        Vector3 newScale = transform.localScale;
        newScale.y = 1 + dir.magnitude / 2.5f;
        newScale.x = 1 - dir.magnitude / 4f;
        transform.localScale = newScale;
    }
}