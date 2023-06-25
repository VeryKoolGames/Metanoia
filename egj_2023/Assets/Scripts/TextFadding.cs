using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextFadding : MonoBehaviour
{
    [SerializeField] public Animator textFadding;

    private void Start()
    {
        textFadding.Play("Base Layer");
    }
    
}
