using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR;

public class MyControllers : MonoBehaviour
{

    public bool trace;
    
    private TextMesh console;
    //private bool dataEnable = true;
    private GameObject player;
    private Vector3 worldPos;
    private GameObject headset, leftHand, rightHand;
    private Vector3 headsetPos, leftHandPos, rightHandPos;
    private InputDevice head, left, right;

    // Start is called before the first frame update
    void Start()
    {
        // if(SingletonManager.GetModeVR() && trace){
            console = GameObject.Find("My Console").GetComponent<TextMesh>();
            headset = GameObject.Find("Headset");
            leftHand = GameObject.Find("LeftHand Controller");
            rightHand = GameObject.Find("RightHand Controller");
            player = GameObject.Find("XR Origin");
        // }
        
        // List<InputDevice> devices = new List<InputDevice>();
        // InputDevices.GetDevices(devices);
        // foreach (var item in devices) { 
        //     console.text += item.name + item.characteristics +"\n";
        // }
        // head = devices[0];
        // left = devices[1];
        // right = devices[2];
    }

    // Update is called once per frame
    void Update()
    {
        if(SingletonManager.GetModeVR() && trace){
            console.text = "";
            console.color = Color.white;

            //PLAYER WORLD POSITION
            worldPos = player.transform.position;
            console.text += "world pos :"
                + " x = " + worldPos.x.ToString("N2") + " | "
                + " y = " + worldPos.y.ToString("N2") + " | "
                + " z = " + worldPos.z.ToString("N2");

            // // PLAYER HEAD/LEFT/RIGHT POSITIONS
            headsetPos = headset.transform.position;
            leftHandPos = leftHand.transform.position;
            rightHandPos = rightHand.transform.position;
            console.text += "\nheadset :"
                        + " x = " + (headsetPos.x - worldPos.x).ToString("N2") + " | "
                        + " y = " + (headsetPos.y - worldPos.y).ToString("N2") + " | "
                        + " z = " + (headsetPos.z - worldPos.z).ToString("N2");
            console.text += "\nlefthand :"
                        + " x = " + (leftHandPos.x - worldPos.x).ToString("N2") + " | "
                        + " y = " + (leftHandPos.y - worldPos.y).ToString("N2") + " | "
                        + " z = " + (leftHandPos.z - worldPos.z).ToString("N2");
            console.text += "\nrighthand :"
                        + " x = " + (rightHandPos.x - worldPos.x).ToString("N2") + " | "
                        + " y = " + (rightHandPos.y - worldPos.y).ToString("N2") + " | "
                        + " z = " + (rightHandPos.z - worldPos.z).ToString("N2") + "\n\n";
        }
    }
}