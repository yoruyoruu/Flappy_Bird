using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject _prefab;
    [SerializeField] private float _spawnRate = 1f;
    [SerializeField] private float _minHight = -1f;
    [SerializeField] private float _maxHight = 1f;

    private void OnEnable() 
    {
        InvokeRepeating(nameof(spawn), _spawnRate, _spawnRate);
    }

    private void OnDisable() 
    {
        CancelInvoke(nameof(spawn));
    }

    private void spawn()
    {
        GameObject pipes = Instantiate(_prefab, transform.position, Quaternion.identity);
        pipes.transform.position += Vector3.up * Random.Range(_minHight, _maxHight);
    }
}
