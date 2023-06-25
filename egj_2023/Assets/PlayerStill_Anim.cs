using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFlip : MonoBehaviour
{
    public SpriteRenderer theSR;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // player flips : https://www.youtube.com/watch?v=6obBCWLH1GI
        if (!theSR.flipX && Input.mousePosition.x > Screen.width / 2f)
        {
            theSR.flipX = true;
        }
        else if (theSR.flipX && Input.mousePosition.x < Screen.width / 2f)
        {
            theSR.flipX = false;
        }
    }
}
