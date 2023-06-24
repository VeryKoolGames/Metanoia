using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.SceneManagement;
using Vector2 = UnityEngine.Vector2;

public class EnemyMovement : MonoBehaviour
{
<<<<<<< HEAD
<<<<<<< HEAD
    [SerializeField] private float speed = 0.5f;
    // private float initialSpeed;
    private GameObject player;

    private void Start(){
        // initialSpeed = speed;
=======
=======

>>>>>>> 0289184c04914d41e8dddb0f7e9fba2ac697b510
    [SerializeField] private float speed = 1f;
    private float initialSpeed;
    private GameObject player;

    private void Start()
    {
        initialSpeed = speed;
<<<<<<< HEAD
>>>>>>> 051194c764e347eb49e750c0fc38b22c0d813477
=======
>>>>>>> 0289184c04914d41e8dddb0f7e9fba2ac697b510
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
        if (other.tag == "Player")
        {
            AudioManager.Instance.playSound("JumpscareSound");
            LevelManager.Instance.test();
            StartCoroutine(LevelManager.Instance.LoadLevel(SceneManager.GetActiveScene().buildIndex));
        }
        else if (other.tag == "Torchlight")
        {
            Debug.Log("Found");
            speed = 0.2f;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        // speed = initialSpeed;
    }
}
