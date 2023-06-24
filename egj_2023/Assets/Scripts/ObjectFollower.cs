using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectFollower : MonoBehaviour
{
    public GameObject target;
    private float initialZ;

    void Start()
    {
        initialZ = Camera.main.transform.position.z;
    }

    void Update()
    {
        transform.position = new Vector3(target.transform.position.x, target.transform.position.y, initialZ);
    }
}
