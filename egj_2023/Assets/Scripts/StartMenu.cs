using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{

    public void StartGame()
    {
        SceneManager.LoadScene(4);
    }
    
    public void StartCredits()
    {
        SceneManager.LoadScene(3);
    }
    
    
    public void Quit()
    {
        Application.Quit();
    }
    
}
