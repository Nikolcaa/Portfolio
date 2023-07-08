using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateConstantly : MonoBehaviour
{
    [SerializeField] private Transform _targetT;
    [SerializeField] private Vector3 _speed;


    private void Update()
    {
        _targetT.Rotate(new Vector3(_speed.x * Time.deltaTime, _speed.y * Time.deltaTime, _speed.z * Time.deltaTime));
    }
}
