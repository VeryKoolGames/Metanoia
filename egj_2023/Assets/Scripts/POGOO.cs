using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    private SpriteRenderer mySpriteRenderer;
    float timer = 0;
    bool timerReached = false;
    // Start is called before the first frame update
    void Start()
    {
                mySpriteRenderer = GetComponent<SpriteRenderer>();
                mySpriteRenderer.flipX = true;

    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (!timerReached && timer > 1)
        {
            mySpriteRenderer.flipX = true;
            timerReached = true;
            timer = 0;
        }
       if (timerReached && timer > 1)
        {
            mySpriteRenderer.flipX = false;
            timerReached = false;
            timer = 0;
        }
    }
}
