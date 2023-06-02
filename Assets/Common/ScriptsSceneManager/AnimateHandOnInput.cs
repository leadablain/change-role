using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AnimateHandOnInput : MonoBehaviour
{
    public InputActionProperty pincAnimationAction;
    public InputActionProperty gripAnimationAction;
    public Animator handAnimator;
    private TextMesh console;

    // Start is called before the first frame update
    void Start()
    {
        console = GameObject.Find("My Console").GetComponent<TextMesh>();
    }

    // Update is called once per frame
    void Update()
    {
        float triggerValue = pincAnimationAction.action.ReadValue<float>();
        handAnimator.SetFloat("Trigger",triggerValue);
        //console.text = triggerValue.ToString("N2");

        float gripValue = gripAnimationAction.action.ReadValue<float>();
        handAnimator.SetFloat("Grip",gripValue);
    }
}
