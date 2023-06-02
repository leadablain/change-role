using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;


public class InputButtonA : MonoBehaviour
{
    private GameObject rightHand;
    private XRController xrController;

    void Start()
    {
        rightHand = GameObject.Find("XR Controller Device");
        xrController = rightHand.GetComponent<XRController>();
    }

    void Update()
    {
        if (xrController.inputDevice.TryGetFeatureValue(CommonUsages.primaryButton, out bool primaryButton))
        {
                Debug.Log("Primary Button pressed : "+primaryButton);
        }

    }
}

// Liste de composants d'un gameobject
// Component[] components = rightHand.GetComponents<Component>();
// foreach (Component component in components)
// {
//     Debug.Log("Component name: " + component.GetType().Name);
// }
