using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] private int ammoNumber = 2;
    [SerializeField] private GameObject ammoObject;
    [SerializeField] private GameObject bulletOne;
    [SerializeField] private GameObject bulletTwo;
    [SerializeField] private float bulletSpeed;
    private bool isReloading = false;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && ammoNumber > 0 && !isReloading)
        {
            Shoot();
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
        if (ammoNumber == 1)
        {
            bulletOne.SetActive(false);
        }
        else
        {
            bulletTwo.SetActive(false);
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
