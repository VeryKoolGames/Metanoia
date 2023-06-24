using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.SceneManagement;
using Vector2 = UnityEngine.Vector2;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float speed = 0.5f;
    // private float initialSpeed;
    private GameObject player;

    private void Start(){
        // initialSpeed = speed;
        player = GameObject.FindGameObjectWithTag("Player");
        Debug.Log(speed);
    }

    private void Update()
    {
        var distance = Vector2.Distance(transform.position, player.transform.position);
        AudioManager.Instance.CheckMusicIntensity(distance);
        // AudioManager.Instance.CheckMusicIntensity(distance); // to create in EACH scene
        Vector2 direction = player.transform.position - transform.position;

        // // sin
        // Vector2 pos = transform.position; // get pos
        //
        // float sin = Mathf.Sin(pos.x); // get y = sin(x)
        // pos.y = sin; // update y
        //
        // transform.position = pos; // update pos
        // // sin
        //
        // Vector2 pos = Mathf.Sin(transform.position.x);
        // float sin = Mathf.Sin(transform.position.x);
        
        
        transform.position =
            Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
        
        // change prefab when out of spotlight
        
        // // end of game because monster too close
        // if (distance <= distanceEndsAt && speed != 0)
        // {
        //     AudioManager.Instance.playSound("JumpscareSound");
        //     StartCoroutine(LevelManager.Instance.LoadLevel(SceneManager.GetActiveScene().buildIndex));
        //     speed = 0;
        // }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("Touched");
            AudioManager.Instance.playSound("JumpscareSound");
            LevelManager.Instance.test();
            StartCoroutine(LevelManager.Instance.LoadLevel(SceneManager.GetActiveScene().buildIndex));
            // speed = 0;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        // speed = initialSpeed;
    }
}
