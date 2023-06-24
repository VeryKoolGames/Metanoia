using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private Transform playerPos;
    [SerializeField] [ItemCanBeNull] private List<BoxCollider> spawnZones = new List<BoxCollider>(4);
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Hello World");
        int x = Random.Range(0, 4);
        Debug.Log("Random number: " + x);
        BoxCollider spawnZone = spawnZones[x];
        Vector2 pos = GetRandomPointInBounds(spawnZone.bounds);
        Debug.Log(pos);
        Instantiate(enemyPrefab, pos, Quaternion.identity);
    }

    public static Vector3 RandomPointInBounds(Bounds bounds) {
        return new Vector3(
            Random.Range(bounds.min.x, bounds.max.x),
            Random.Range(bounds.min.y, bounds.max.y),
            Random.Range(bounds.min.z, bounds.max.z)
        );
    }
    
    
    // public Vector3 GetRandomPointInsideCollider( BoxCollider boxCollider )
    // {
    //     Vector3 extents = boxCollider.size / 2f;
    //     Vector3 point = new Vector3(
    //         Random.Range( -extents.x, extents.x ),
    //         Random.Range( -extents.y, extents.y ),
    //         Random.Range( -extents.z, extents.z )
    //     )  + boxCollider.center;
    //     return boxCollider.transform.TransformPoint( point );
    // }
    // public static Vector2 GetRandomPointInsideCollider( BoxCollider2D boxCollider )
    // {
    //     Vector2 extents = boxCollider.size / 2;
    //     Vector2 point = new Vector2(
    //         Random.Range( -extents.x, extents.x ),
    //         Random.Range( -extents.y, extents.y )
    //     );
    //     // Debug.Log(boxCollider.transform.TransformPoint(point));
    //     return BoxCollider2D. transform.TransformPoint(point);
    // }
    
    public Vector3 GetRandomPointInBounds(Bounds bounds) {
        float minX = bounds.size.x * -0.5f;
        float minY = bounds.size.y * -0.5f;
        float minZ = bounds.size.z * -0.5f;

        return (Vector3)transform.TransformPoint(
            new Vector3(Random.Range (minX, -minX),
                Random.Range (minY, -minY),
                Random.Range (minZ, -minZ))
        );
    }
}
