using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetPlayerMode : MonoBehaviour
{
    public bool modeVirtualReality;

    // Start is called before the first frame update
    void Start()
    {
        SingletonManager.SetModeVR(modeVirtualReality);

        if(modeVirtualReality){
            GameObject.Find("3D").SetActive(false);
            GameObject.Find("VR").SetActive(true);
            //Debug.Log("PlayerVR = 3D:false, VR:true");
        } else {
            GameObject.Find("3D").SetActive(true);
            GameObject.Find("VR").SetActive(false);
            //Debug.Log("Player3D = 3D:true, VR:false");
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
