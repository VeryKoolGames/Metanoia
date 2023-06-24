using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashlightEffect : MonoBehaviour
{
     public GameObject darkOverlay;
    public float angleThreshold = 90f; // Adjust this threshold to control when the overlay appears

    private void Update()
    {
        // Get the mouse position and convert it to world coordinates
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = Camera.main.nearClipPlane;
        Vector3 worldMousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        // Calculate the rotation angle based on the player's position and the mouse position
        Vector3 direction = worldMousePosition - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // Rotate the flashlight object based on the calculated angle
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        // Toggle the dark overlay based on the flashlight's active state
        bool isFlashlightPointingAway = Mathf.Abs(angle) > angleThreshold;
        darkOverlay.SetActive(isFlashlightPointingAway);
    }
}
