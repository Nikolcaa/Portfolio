using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsCubeEffect : MonoBehaviour
{
    [SerializeField] private Transform _followTargetT;
    [SerializeField] private Transform _bottomColliderT;
    [SerializeField] private Transform _leftColliderT;
    [SerializeField] private Transform _rightColliderT;
    [SerializeField] private Transform[] _cubes;
    [SerializeField] private GameObject _cubesParent;

    private bool _isActive = false;

    private void Update()
    {
        LimitCubesPosition();

        if (!_isActive && ScrollManager.ScrollValue <= 0.5f)
        {
            _isActive = true;
            _cubesParent.SetActive(true);
        }
    }

    private void LimitCubesPosition()
    {
        foreach (Transform cubeT in _cubes)
        {
            Vector3 newPos = cubeT.position;
            if (cubeT.position.y <= _bottomColliderT.position.y)
            {
                newPos.y = _bottomColliderT.position.y;
            }
            if (cubeT.position.x <= _leftColliderT.position.x)
            {
                newPos.x = _leftColliderT.position.x;
            }
            if (cubeT.position.x >= _rightColliderT.position.x)
            {
                newPos.x = _rightColliderT.position.x;
            }
            cubeT.position = newPos;
        }
    }
}
