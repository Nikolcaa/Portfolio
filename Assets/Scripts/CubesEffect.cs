using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CubesEffect : MonoBehaviour
{
    [Header("Prefabs")]
    [SerializeField] private GameObject _cube;

    [Header("Properties")]
    [SerializeField] private int _rows;
    [SerializeField] private int _columns;
    [SerializeField] private float _spacing;
    [SerializeField] private float _mouseZOffset;

    // Private
    private float _startPosX = 0f;
    private float _startPosY = 0f;
    private List<Transform> _cubes = new List<Transform>();
    private List<Vector3> _cubesPositions = new List<Vector3>();
    private Vector3 _cachedCubeScale;


    private void Start()
    {
        CreateCubesGrid();
        _cachedCubeScale = _cubes[0].localScale;
    }

    float _distanceDeviderMax = 4.5f;
    float _distanceDeviderMin = 0f;
    float _distanceDevider;
    private void Update()
    {
        Vector3 mousePos = MouseManager.GetMousePos(_mouseZOffset);
        _distanceDevider = Mathf.Lerp(_distanceDeviderMin, _distanceDeviderMax, ScrollManager.ScrollValue*3 - 2);

        if (_distanceDevider <= 0)
            return;

        for (int i = 0; i < _cubes.Count; i++)
        {
            Transform cube = _cubes[i];
            float distance = Mathf.Clamp01(Vector2.Distance(_cubesPositions[i], mousePos) / _distanceDevider);

            // Position
            Vector3 dir2 = mousePos - _cubesPositions[i];
            cube.position = Vector3.Lerp(_cubesPositions[i], _cubesPositions[i] + dir2, distance);

            // Rotate
            //cube.LookAt(mousePos);
            Vector3 dir = Vector2.ClampMagnitude(_cubesPositions[i] - mousePos, 1);
            cube.forward = Vector3.Lerp(Vector3.forward, dir, distance);

            // Scale
            cube.localScale = Vector3.Lerp(_cachedCubeScale, new Vector3(6, 6, 6), distance);


        }
    }

    private void CreateCubesGrid()
    {
        for (int y = 0; y < _rows; y++)
        {
            for (int x = 0; x < _columns; x++)
            {
                _startPosX = (_columns / -2);
                _startPosY = -(_rows - 1) / 2f;
                Transform newCube = Instantiate(_cube, new Vector3(_startPosX + x, _startPosY + y, transform.position.z), Quaternion.identity).transform;
                newCube.SetParent(transform);
                _cubes.Add(newCube);
                _cubesPositions.Add(newCube.position);
            }
        }
    }

}