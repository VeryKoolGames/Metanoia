using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.SceneManagement;
using Vector2 = UnityEngine.Vector2;

public class EnemyMovement : MonoBehaviour
{

    public float speed = 1f;
    private float initialSpeed;
    private GameObject player;

    private void Start()
    {
        initialSpeed = speed;
        player = GameObject.FindGameObjectWithTag("Player");
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
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        var triggerSpeed = speed;
        if (other.tag == "Player")
        {
            AudioManager.Instance.playSound("JumpscareSound");
            LevelManager.Instance.test();
            StartCoroutine(LevelManager.Instance.LoadLevel(SceneManager.GetActiveScene().buildIndex));
        }
        else if (other.tag == "AimLine")
        {
            Debug.Log("Found");
            speed = 0f;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "AimLine")
        {
            speed = initialSpeed;
        }
    }
}
