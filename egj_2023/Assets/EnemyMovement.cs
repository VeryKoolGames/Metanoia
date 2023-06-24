using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    // public GameObject player;
    public float speed;
    public GameObject player;
    public bool canMove = true;

    private void Update()
    {
        if(!canMove)return;
        // var player = GameObject.FindGameObjectWithTag("Player");
        var distance = Vector2.Distance(transform.position, player.transform.position);
        Vector2 direction = player.transform.position - transform.position;
        transform.position =
            Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("XD");
        // speed = 0;
        canMove = false;
    }
}
