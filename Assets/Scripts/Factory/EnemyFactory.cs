using System;
using UnityEngine;

public class EnemyFactory : MonoBehaviour, IFactory
{

    [SerializeField]
    public GameObject[] enemyPrefab;

    [SerializeField]
    public Transform[] spawnPoints;

    public GameObject FactoryMethod(int tag, int spawnPointIndex)
    {
        GameObject enemy = Instantiate(enemyPrefab[tag],
        spawnPoints[spawnPointIndex].position,
        spawnPoints[spawnPointIndex].rotation);

        return enemy;
    }
}