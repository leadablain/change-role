using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveLight : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        bool modeVirtualReality = SingletonManager.GetModeVR();
        if(modeVirtualReality) gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
