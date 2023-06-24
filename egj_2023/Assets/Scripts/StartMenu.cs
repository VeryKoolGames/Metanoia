using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{

    public void StartGame()
    {
        Debug.Log("Salut");
        SceneManager.LoadScene("Scene01");
    }
    
    public void StartCredits()
    {
        SceneManager.LoadScene("Credits");
    }
    
    
    public void Quit()
    {
        Application.Quit();
    }
    
}
