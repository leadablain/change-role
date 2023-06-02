using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable] // Cette annotation permet d'afficher la variable dans l'inspecteur Unity
public struct structTriggersPos
{
    public float seuil;
    public Vector3 pos;
}

public class ChangePosition : MonoBehaviour
{

    public bool trace;
    public bool reverse;
    public structTriggersPos nearLimit;
    public structTriggersPos farLimit;
    private Vector3 currentPos;
    private float minDistance;

    // Start is called before the first frame update
    void Start()
    {
        minDistance = 999f;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 playerPos = SingletonManager.GetPlayerPos();
        Vector3 currentPosSameY = transform.position;
        currentPosSameY.y = playerPos.y;
        float distance = Vector3.Distance(currentPosSameY, playerPos);
        
        if(reverse) changePos(distance);
        else {
            if(distance < minDistance) {
                minDistance = distance;
                changePos(minDistance);
            }
        } 

        if (trace)
        {
            string traceTxt = gameObject.name+"/ChangePosition" +
                           " __ distance = " + distance +
                           " __ near = " + nearLimit.seuil +
                           " __ far = " + farLimit.seuil;
            SingletonManager.WriteTrace(SingletonManager.GetModeVR(), traceTxt);
        }

        void changePos(float distance)
        {
            if(distance < nearLimit.seuil) { currentPos = nearLimit.pos; }
            else if(distance > farLimit.seuil) { currentPos = farLimit.pos; }
            else {
                currentPos = SingletonManager.MapV3(distance, nearLimit.seuil, farLimit.seuil, nearLimit.pos, farLimit.pos);
            }
            transform.position = currentPos;
        }

    }

   
}
