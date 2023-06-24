using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuUI;
    public GameObject player;
    private MovementController mc;
    private bool isPaused = false;
    private string[] pausedPlayerComponents = new string[]{"MovementController", "RaycastController"};

    private void Start(){
        mc = player.GetComponent<MovementController>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
                Resume();
            else
                Pause();
        }
    }

    public void Resume()
    {
        Debug.Log("resume ran");
        pauseMenuUI.SetActive(false);
        setPlayerScriptsState(true);
        Time.timeScale = 1f;
        isPaused = false;
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
        setPlayerScriptsState(false);
    }

    public void Quit()
    {
        Application.Quit();
    }

        private void setPlayerScriptsState(bool state){
            foreach (string typeStr in pausedPlayerComponents) { 
                System.Type scriptType = System.Type.GetType(typeStr);
                Component scriptComponent = player.GetComponent(scriptType);
        if (scriptComponent != null)
        {
            Behaviour scriptBehaviour = scriptComponent as Behaviour;
            if (scriptBehaviour != null) scriptBehaviour.enabled = state;
        }
            }
    }
}
