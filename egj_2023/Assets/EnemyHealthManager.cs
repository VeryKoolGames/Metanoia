using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemyHealthManager : MonoBehaviour
{
    public int health = 2;
    public GameObject enemyPrefabs;
    private GameObject player;
    private GameObject enemy;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("EnnemyManager");
        player = GameObject.FindGameObjectsWithTag("Player")[0];
        enemy = GameObject.FindGameObjectsWithTag("Enemy")[0];
    }

    public void Hit(){
        if(health > 0){
            health--;
            Debug.Log("Health is now " + health);
            if(health != 0) {
                AudioManager.Instance.playSound("HitSound");
                Respawn();
                return;
            }
            AudioManager.Instance.playSound("DyingSound");
            StartCoroutine(LevelManager.Instance.LoadLevel(2));
        }
    }

    private void Respawn(){
        Vector3 centerOfRadius = player.transform.position;

        float spawnRadius = Vector3.Distance(player.transform.position, enemy.transform.position);
        Vector2 randomPoint = Random.insideUnitCircle.normalized * spawnRadius;
        Vector3 spawnPosition = centerOfRadius + new Vector3(randomPoint.x, randomPoint.y, 10);

        enemy.transform.position = spawnPosition;
    }
}