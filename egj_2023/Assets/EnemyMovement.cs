using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed;
    private float initialSpeed;
    public GameObject player;

    private void Start(){
        initialSpeed = speed;
    }

    private void Update()
    {
        var distance = Vector2.Distance(transform.position, player.transform.position);
        Vector2 direction = player.transform.position - transform.position;
        transform.position =
            Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        speed = 0;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        speed = initialSpeed;
    }
}
