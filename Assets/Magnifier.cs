using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magnifier : MonoBehaviour
{
    [SerializeField] private Transform _renderSphereT;
    [SerializeField] private Transform _graph;
    float _zOffset;
    Vector3 _cachedPos;

    private void Start()
    {
        _zOffset = transform.position.z;
        _cachedPos = transform.localPosition;
    }

    private void Update()
    {

        if (ScrollManager.ScrollValue >= 0.1f && ScrollManager.ScrollValue <= 0.4f)
        {
            FollowCursor();
        }
        else
        {
            transform.localPosition = Vector3.Lerp(transform.localPosition, _cachedPos, Time.deltaTime * 3);
        }
    }

    private void FollowCursor()
    {
        transform.position = Vector3.Lerp(transform.position, new Vector3(Cursor.Position.x, Cursor.Position.y, _zOffset), Time.deltaTime * 10);

    }
}
