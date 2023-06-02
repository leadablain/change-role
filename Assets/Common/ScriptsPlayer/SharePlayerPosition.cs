using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR;

public class SharePlayerPosition : MonoBehaviour
{
    public bool trace;
    public float delaiMajPlayerPosition;   
    private GameObject player;
    private Vector3 playerPos; 

    // Start is called before the first frame update
    void Start()
    { 
        InvokeRepeating("CheckPlayerPosition", 0.1f, 0.1f);        
    }    
    
    // Update is called once per frame
    void Update()
    {
        if(SingletonManager.GetModeVR()){
            player = GameObject.Find("Headset");
        } else {
            player = GameObject.Find("3D");
        }
        //Debug.Log(player.name);
    }

    private void CheckPlayerPosition()
    {
        playerPos = player.transform.position;
        SingletonManager.SetPlayerPos(playerPos);

        if (trace)
        {
            string traceTxt = gameObject.name+ " __ playerPos : " + playerPos;
            Debug.Log(player.transform.position);
            SingletonManager.WriteTrace(SingletonManager.GetModeVR(), traceTxt);
        }
        
    }
    
}
