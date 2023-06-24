using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRaycastController : MonoBehaviour
{
    private LineRenderer lineRenderer;
    public Vector3 shootingPoint;

    void Start(){
        this.lineRenderer = GetComponent<LineRenderer>();
    }
    private void Update() {
        if (Input.GetMouseButtonDown(0)) {
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            LayerMask layerMask = LayerMask.GetMask("EnnemyLayer");
            RaycastHit2D hit = Physics2D.Raycast(transform.position, (worldPosition - transform.position).normalized, Mathf.Infinity, layerMask);
        
            if (hit.collider != null) {
                Debug.Log("Raycast hit: " + hit.collider.gameObject.name);
            }else{
                Debug.Log("Raycast hit nothing");
            }
        }
    }
}
