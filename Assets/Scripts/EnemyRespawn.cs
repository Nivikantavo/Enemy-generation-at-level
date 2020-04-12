using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRespawn : MonoBehaviour
{
    [SerializeField] private Transform _respawn;
    [SerializeField] private GameObject _enemy;

    private Transform[] _respawnPoints;
    
    void Start()
    {
        _respawnPoints = new Transform[_respawn.childCount];

        for (int i = 0; i < _respawn.childCount; i++)
        {
            _respawnPoints[i] = _respawn.GetChild(i);
        }

        StartCoroutine(SpawnEnemy());
    }

    private IEnumerator SpawnEnemy()
    {
        var WaitForOneSecond = new WaitForSeconds(1f);

        int _pointIndex;

        while (true) 
        {
            _pointIndex = Random.Range(0, _respawnPoints.Length);

            Instantiate(_enemy, _respawnPoints[_pointIndex]);

            _enemy.transform.position = _respawnPoints[_pointIndex].position;
            
            yield return WaitForOneSecond;
        }
    }
}
