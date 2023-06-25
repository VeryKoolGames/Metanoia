using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroSceneManager : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Entering Scene");
        StartCoroutine(WaitForAnim());
    }

    private IEnumerator WaitForAnim()
    {
        yield return new WaitForSeconds(17f);
        SceneManager.LoadScene(1);
    }
}
