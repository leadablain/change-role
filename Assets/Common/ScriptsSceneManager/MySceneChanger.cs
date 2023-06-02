using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;


public class MySceneChanger : MonoBehaviour
{
    public string nextScene;

    private GameObject rightHand;
    private XRController xrController;
    private bool running = true;

    // Start is called before the first frame update
    void Start()
    {
        if(SingletonManager.GetModeVR()){
            rightHand = GameObject.Find("XR Controller Device");
            xrController = rightHand.GetComponent<XRController>();
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if(SingletonManager.GetModeVR()){
            // A button
            if(running) {
                if (xrController.inputDevice.TryGetFeatureValue(CommonUsages.primaryButton, out bool primaryButton))
                {                
                    if(primaryButton){
                        running = false;
                        Debug.Log("Primary Button pressed2 : "+primaryButton+running);
                        Invoke("changeScene", 0.1f);
                    }
                }
            }

        } else {
            // KEYBOARD
            //Load a scene by the name "SceneName" if you press the x key.

            if (Input.GetKeyDown(KeyCode.X))
            {
                Debug.Log("Touche :"+KeyCode.X);
                Invoke("changeScene", 0.1f);
            }
        }

    }

    void changeScene()
    {
        SceneManager.LoadScene(nextScene);
    }
    
}
