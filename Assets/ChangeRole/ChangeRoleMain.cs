using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeRoleMain : MonoBehaviour
{
    public string sceneA;
    public string sceneB;

    public GameObject playerA;
    public GameObject playerB;

    bool gotoB = true;
    void FlipFlop() 
    {
        if (gotoB == true) 
        {
            SceneManager.LoadScene(sceneB, LoadSceneMode.Additive);
            SceneManager.UnloadSceneAsync(sceneA);
            playerA.SetActive(false);
            playerB.SetActive(true);
        }
        else
        {
            SceneManager.LoadScene(sceneA, LoadSceneMode.Additive);
            SceneManager.UnloadSceneAsync(sceneB);
            playerA.SetActive(true);
            playerB.SetActive(false);
        }
        gotoB = !gotoB;
    }

    void Start() 
    {
        SceneManager.LoadScene(sceneA, LoadSceneMode.Additive);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.N)) 
        {
            FlipFlop();
        }
    }
}
