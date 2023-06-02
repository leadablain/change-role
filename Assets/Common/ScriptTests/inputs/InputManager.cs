using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

// trigger,
// grip,
// primaryButton,
// secondaryButton,
// primary2DAxis,
// secondary2DAxis,
// primary2DAxisClick,
// primary2DAxisTouch,
// secondary2DAxisClick,
// secondary2DAxisTouch,
// menuButton

public class InputManager : MonoBehaviour
{
    public float triggerThreshold = 0.5f;
    public float gripThreshold = 0.5f;
    

    private XRController xrController;

    void Start()
    {
        xrController = GetComponent<XRController>();
    }

    void Update()
    {
        if (xrController.inputDevice.TryGetFeatureValue(CommonUsages.trigger, out float triggerValue))
        {
            if (triggerValue >= triggerThreshold)
            {
                Debug.Log("Trigger enfoncé "+triggerValue);
            }
        }

        if (xrController.inputDevice.TryGetFeatureValue(CommonUsages.grip, out float gripValue))
        {
            if (gripValue >= gripThreshold)
            {
                Debug.Log("Grip enfoncé "+gripValue);
            }
        }

        if (xrController.inputDevice.TryGetFeatureValue(CommonUsages.primaryButton, out bool primaryButton))
        {
                Debug.Log("Primary Button pressed : "+primaryButton);
        }



    }
}