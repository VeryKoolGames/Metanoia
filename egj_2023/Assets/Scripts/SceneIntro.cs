using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneIntro : MonoBehaviour
{
    [SerializeField] public Animator transition;

    private void Start()
    {
        StartCoroutine(LoadLevel());
    }


    public IEnumerator LoadLevel()
    {
        transition.Play("test");

        yield return new WaitForSeconds(2.1f);
        SceneManager.LoadScene(1);
    }
}
