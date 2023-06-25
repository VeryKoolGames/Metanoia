using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance;
    [SerializeField]
    private float transitionTime = 1f;
    [SerializeField] public Animator transition;


    private void Awake()
    {
        Instance = this;
    }

    public int test()
    {
        Debug.Log("Working");
        return 1;
    }
    
    public IEnumerator LoadLevel(int sceneNumber)
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(sceneNumber);
    }
}