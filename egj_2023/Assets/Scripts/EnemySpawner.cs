using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] [ItemCanBeNull] private List<BoxCollider2D> spawnZones = new List<BoxCollider2D>(3);
    [SerializeField] [ItemCanBeNull] private List<GameObject> enemyPrefabs = new List<GameObject>(4);
    
    // Start is called before the first frame update
    void Start()
    {
        int x = Random.Range(0, 3);
        BoxCollider2D spawnZone = spawnZones[x];
        Vector2 pos = GetRandomPointInCollider(spawnZone);
        Instantiate(enemyPrefab, pos, Quaternion.identity);
    }

    public Vector2 GetRandomPointInCollider(BoxCollider2D boxCollider)
    {
        Vector2 center = boxCollider.bounds.center;
        Vector2 size = boxCollider.bounds.size;

        float randomX = Random.Range(center.x - size.x / 2, center.x + size.x / 2);
        float randomY = Random.Range(center.y - size.y / 2, center.y + size.y / 2);

        return new Vector2(randomX, randomY);
    }
}
