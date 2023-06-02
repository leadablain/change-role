using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class DetectButtonX : MonoBehaviour
{
    private InputDevice targetDevice;

    void Start()
    {
        // Recherche de l'InputDevice associé au contrôleur Oculus Quest 2 gauche
        var inputDevices = new List<InputDevice>();
        InputDevices.GetDevicesAtXRNode(XRNode.LeftHand, inputDevices);
        foreach (var device in inputDevices)
        {
            if (device.characteristics == InputDeviceCharacteristics.Left | device.characteristics == InputDeviceCharacteristics.Controller)
            {
                targetDevice = device;
                break;
            }
        }
    }

    void Update()
    {
        TextMesh console;
        console = GameObject.Find("My Console").GetComponent<TextMesh>();
        console.text = "ready";
        
        // Vérifie si le bouton X du contrôleur Oculus Quest 2 a été pressé
        if (targetDevice.TryGetFeatureValue(CommonUsages.primaryButton, out bool primaryButtonValue) && primaryButtonValue)
        {
            console.text = "x button pressed";
        }        
    }
}






