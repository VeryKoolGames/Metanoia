using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float speed = 1f;
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
        speed = initialSpeed;
    }
}
