using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    private Vector3 _cachedCubeScale;


    private void Start()
    {
        CreateCubesGrid();
        _cachedCubeScale = _cubes[0].localScale;
    }

    private void Update()
    {
        foreach (Transform cube in _cubes)
        {
            // Rotate
            cube.LookAt(MouseManager.GetMousePos(_mouseZOffset));

            // Scale
            //float distance
            //cube.localScale = Vector3.Lerp(Vector3.zero, _cachedCubeScale, M)
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
                Transform newCube = Instantiate(_cube, new Vector3(_startPosX + x, _startPosY + y, 0), Quaternion.identity).transform;
                newCube.SetParent(transform);
                _cubes.Add(newCube);
            }
        }
    }

}