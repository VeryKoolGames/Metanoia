using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletColliding : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Enemy")
        {
            // Destroy(col.gameObject);
            GameObject enemy = col.gameObject;
            enemy.GetComponent<EnnemyHealthManager>().Hit();
            Debug.Log("EXPLOISION");
            //StartCoroutine(LevelManager.Instance.LoadLevel(2));
        }
    }
}
