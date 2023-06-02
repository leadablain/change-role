using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class OculusInputManager : MonoBehaviour
{
    private XRController rightController;

    private void Awake()
    {
        // Récupère le contrôleur droit
        rightController = GetComponent<XRController>();
    }

    private void Update()
    {
        InputDevice rightInputDevice = rightController.inputDevice;
        bool primaryButtonState = false;
        bool secondaryButtonState = false;

        if (rightInputDevice.TryGetFeatureValue(CommonUsages.primaryButton, out primaryButtonState) && primaryButtonState)
        {
            Debug.Log("Bouton A de la manette droite enfoncé");
        }

        if (rightInputDevice.TryGetFeatureValue(CommonUsages.secondaryButton, out secondaryButtonState) && secondaryButtonState)
        {
            Debug.Log("Bouton B de la manette droite enfoncé");
        }
    }
}
