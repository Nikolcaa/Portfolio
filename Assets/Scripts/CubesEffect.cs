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

    [Header("Components")]
    [SerializeField] private Transform _granicnik;

    // Private
    private float _startPosX = 0f;
    private float _startPosY = 0f;
    private List<Transform> _cubes = new List<Transform>();
    private List<Vector3> _cubesPositions = new List<Vector3>();
    private List<Transform> _cubesPositionsPart2 = new List<Transform>();
    private Vector3 _cachedCubeScale;

    public void SetUp()
    {
        CreateCubesGrid();
        CreateCubesGrid2();
        _cachedCubeScale = _cubes[0].localScale;
        Debug.Log(_cachedCubeScale);
        //Invoke(nameof(Animate_CubesComeToCursor), 2f);
    }

    private void Animate_CubesComeToCursor()
    {
        foreach (Transform cube in _cubes)
        {
            cube.DOMove(Cursor.Position, 5)
                .SetSpeedBased(true)
                .SetEase(Ease.InOutBack);

            cube.DOScale(new Vector3(6, 6, 6), 2);
        }
    }

    float _distanceDeviderMax = 15f; // 4.5f // 8f
    float _distanceDeviderMin = 0f;
    float _distanceDevider;
    private void Update()
    {
        if (GameManager.Instance.GameState != GameState.STATE1_HOME)
            return;

        //Vector3 mousePos = MouseManager.GetMousePos(_mouseZOffset);
        Vector3 mousePos = Cursor.Position;
        _distanceDevider = Mathf.Lerp(_distanceDeviderMax, _distanceDeviderMin, ScrollManager.ScrollValue * 3f - 2.5f); // This one is to be like a black hole
        //_distanceDevider = _distanceDeviderMax; 

        //if (_distanceDevider <= 0)
        //    return;

        for (int i = 0; i < _cubes.Count; i++)
        {
            Transform cube = _cubes[i];
            float distance = Mathf.Clamp01(Vector2.Distance(_cubesPositions[i], mousePos) / _distanceDevider);

            float d = Vector2.Distance(mousePos, _cubesPositionsPart2[i].position);
            if (d <= 3.2f) // changable
            {
                cube.position = Vector3.Lerp(cube.position, _cubesPositionsPart2[i].position, 80 * Time.deltaTime);
                cube.localScale = Vector3.Lerp(cube.localScale, _cachedCubeScale, 4 * Time.deltaTime);
                cube.forward = Vector3.Lerp(cube.forward, Vector3.forward, 4 * Time.deltaTime);
                continue;
            }
            if (ScrollManager.ScrollValue <= 0.43f) // after this they will go to fixed positions
            {
                cube.position = Vector3.Lerp(cube.position, _cubesPositionsPart2[i].position, 40 * Time.deltaTime);
                cube.localScale = Vector3.Lerp(cube.localScale, _cachedCubeScale, 4 * Time.deltaTime);
                cube.forward = Vector3.Lerp(cube.forward, Vector3.forward, 4 * Time.deltaTime);
                continue;
            }

            // Position
            Vector3 dir2 = mousePos - _cubesPositions[i];
            Vector3 finalPos = Vector3.Lerp(_cubesPositions[i], _cubesPositions[i] - dir2, distance);
            //Vector3 finalPos = Vector3.Lerp(_cubesPositions[i], _cubesPositions[i] + dir2, distance); // This one is to be like a black hole
            cube.position = Vector3.MoveTowards(cube.position, finalPos, Time.deltaTime * 35);

            // Rotate
            cube.LookAt(mousePos);
            //Vector3 dir = Vector2.ClampMagnitude(_cubesPositions[i] - mousePos, 1);
            //cube.forward = Vector3.Lerp(Vector3.forward, dir, distance);

            // Scale
            Vector3 newScale = Vector3.Lerp(_cachedCubeScale / 4, _cachedCubeScale / 1.2f, _distanceDevider / _distanceDeviderMax);
            Vector3 finalScale = Vector3.Lerp(newScale, new Vector3(0, 0, 0), distance * 4f); // distance*3
            cube.localScale = Vector3.MoveTowards(cube.localScale, finalScale, Time.deltaTime * 8);

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
                //newCube.SetParent(transform);
                //newCube.localScale = new Vector3(108, 108, 108);
                _cubes.Add(newCube);
                _cubesPositions.Add(newCube.position);
            }
        }
    }

    // With offset
    private void CreateCubesGrid2()
    {
        //float yOffset = _granicnik.position.y;
        GameObject parent = new GameObject();
        for (int y = 0; y < _rows; y++)
        {
            for (int x = 0; x < _columns; x++)
            {
                _startPosX = (_columns / -2);
                _startPosY = -(_rows - 1) / 2f;
                GameObject newPos = new GameObject();
                newPos.transform.position = new Vector3(_startPosX + x, _startPosY + y, transform.position.z);
                newPos.transform.SetParent(parent.transform);
                _cubesPositionsPart2.Add(newPos.transform);
            }
        }
        parent.transform.SetParent(_granicnik);
        parent.transform.localPosition = Vector3.zero;
        parent.transform.localScale = new Vector3(108, 108, 108);
    }

}