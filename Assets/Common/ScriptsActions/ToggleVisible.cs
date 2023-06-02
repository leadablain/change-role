using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleVisible : MonoBehaviour
{
    public bool trace;
    public bool toVisible;
    public float seuilDistance;
    private MeshRenderer meshRenderer;

    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();      
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 playerPos = SingletonManager.GetPlayerPos();

        Vector3 currentPosSameY = transform.position;
        currentPosSameY.y = playerPos.y;
        float distance = Vector3.Distance(currentPosSameY, playerPos);
        
        if (distance < seuilDistance) { 
            if(toVisible) meshRenderer.enabled = true;
            else meshRenderer.enabled = false;
        }
        else { 
            if(toVisible) meshRenderer.enabled = false;
            else meshRenderer.enabled = true;
        }

        if (trace)
        {
            string traceTxt = gameObject.name+"/ToggleVisible" +
                           " __ distance = " + distance +
                           " __ seuil =" + seuilDistance +
                           " __ visible = " + meshRenderer.enabled;                          
            SingletonManager.WriteTrace(SingletonManager.GetModeVR(), traceTxt);
        }

    }

}
