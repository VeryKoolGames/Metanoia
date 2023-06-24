using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float speed = 2f;
    private float initialSpeed;
    public Animator transition;
    [SerializeField] private float distanceEndsAt;
    private GameObject player;

    private void Start(){
        initialSpeed = speed;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        var distance = Vector2.Distance(transform.position, player.transform.position);
        // AudioManager.Instance.CheckMusicIntensity(distance);
        Vector2 direction = player.transform.position - transform.position;
        transform.position =
            Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
        
        // end of game because monster too close
        if (distance <= distanceEndsAt && speed != 0)
        {
            Debug.Log("this is the end john, pao pao");
            speed = 0;
            // change scene to bad scene
            
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("Touched");
            AudioManager.Instance.playSound("JumpscareSound");
            LevelManager.Instance.test();
            StartCoroutine(LevelManager.Instance.LoadLevel(SceneManager.GetActiveScene().buildIndex));
        }
        speed = 0;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        speed = initialSpeed;
    }
}
