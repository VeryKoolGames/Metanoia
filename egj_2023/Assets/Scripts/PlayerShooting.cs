using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] private int ammoNumber = 3;
    [SerializeField] private GameObject ammoObject;
    [SerializeField] private GameObject bulletOne;
    [SerializeField] private GameObject bulletTwo;
    [SerializeField] private GameObject bulletThree;
    [SerializeField] private float bulletSpeed;
    [SerializeField] private Animator cameraAnim;
    [SerializeField] private Animator playerAnim;
    [SerializeField] private bool isReloading = false;
    [SerializeField] private GameObject aimLine;
    private GameObject enemy;

    private void Start()
    {
        enemy = GameObject.FindGameObjectWithTag("Enemy");
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale != 0)
        {
            if (Input.GetMouseButtonDown(0) && ammoNumber > 0 && !isReloading)
            {
                Shoot();
            }
            else if (Input.GetMouseButtonDown(0) && ammoNumber <= 0 && !isReloading)
            {
                Reload();
                AudioManager.Instance.playSound("EmptyGunSound");
            }
        }
    }
    
    void Shoot()
    {
        Vector3 worldMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Vector2 direction = (Vector2)((worldMousePos - transform.position));
        direction.Normalize ();

        // Creates the bullet locally
        GameObject bullet = (GameObject)Instantiate (
            ammoObject,
            transform.position + (Vector3)( direction * 0.5f),
            Quaternion.identity);
        bullet.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;
        ammoNumber -= 1;
        AudioManager.Instance.playSound("GunshotSound");
        playerAnim.SetTrigger("shoots");
        cameraAnim.SetTrigger("shoots");
        if (ammoNumber == 2)
        {
            bulletOne.SetActive(false);
        }
        else if ( ammoNumber == 1)
        {
            bulletTwo.SetActive(false);
        }
        else
        {
            bulletThree.SetActive(false);
            aimLine.tag = "Untagged";
            enemy.GetComponent<EnemyMovement>().speed = 3f;
        }
        isReloading = true;
        StartCoroutine(Reload());
    }
    
    private IEnumerator Reload()
    {
        yield return new WaitForSeconds(1f);
        AudioManager.Instance.playSound("ReloadSound");
        yield return new WaitForSeconds(1.2f);
        isReloading = false;
    }
}
