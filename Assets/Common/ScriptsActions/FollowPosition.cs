using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPosition : MonoBehaviour
{
    public bool trace;
    public bool sameX;
    public bool sameZ;

    public float seuilDistanceAxis;

    void Start()
    {
 
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 playerPos = SingletonManager.GetPlayerPos();
        Vector3 newPos = transform.position;

        float distance = 0;
        if(sameX) {
            distance = Mathf.Abs(transform.position.z - playerPos.z);
            if (distance < seuilDistanceAxis) { 
                newPos = new Vector3(playerPos.x, transform.position.y, transform.position.z);
                transform.position = newPos ;
            }
        }

        if(sameZ) {
            distance = Mathf.Abs(transform.position.x - playerPos.x);            
            if (distance < seuilDistanceAxis) { 
                newPos = new Vector3(transform.position.x, transform.position.y, playerPos.z);
                transform.position = newPos ;
            }
        }

        if (trace)
        {
            string traceTxt = gameObject.name+"/FollowPosition" +
                           " __ distance = " + distance +
                           " __ playerPos = " + playerPos +
                           " __ newPos = " + newPos;
            SingletonManager.WriteTrace(SingletonManager.GetModeVR(), traceTxt);
        }

    }


}
