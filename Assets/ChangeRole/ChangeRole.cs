using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeRole : MonoBehaviour
{

    public bool trace;
    public GameObject[] roles;
    private GameObject player;    
    private Vector3 playerPos;

    // Start is called before the first frame update
    void Start()
    {
        foreach (GameObject element in roles) {
            Debug.Log("role =" + element.name + " _ " + element.transform.position);
        }
    }

    // Update is called once per frame
    void Update()
    {
        player = GameObject.Find("3D");
        // Vector3 currentPosSameY = transform.position;
        // currentPosSameY.y = playerPos.y;

        if (Input.GetKeyDown(KeyCode.N))
        {
            Vector3 pos = roles[1].transform.position;
            //Debug.Log("Touche : " + KeyCode.N + " | pos role 1"+pos);
            player.transform.position = pos;
            player.transform.rotation = Quaternion.Euler(0, 90, 0);
            Debug.Log("player = " + player.transform.position+ " pos = "+pos);

            SingletonManager.SetPlayerPos(playerPos);
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            Vector3 pos = roles[0].transform.position;
            //Debug.Log("Touche : " + KeyCode.S + " | pos role 0" + pos);
            player.transform.position = pos;
            player.transform.rotation = Quaternion.Euler(0, -90, 0);
            Debug.Log("player = " + player.transform.position + " pos = " + pos);
            SingletonManager.SetPlayerPos(playerPos);         
        }

        if (trace)
        {
            // string traceTxt = gameObject.name+"/ChangePosition" +
            //                " __ distance = " + distance +
            //                " __ near = " + nearLimit.seuil +
            //                " __ far = " + farLimit.seuil;
            // SingletonManager.WriteTrace(SingletonManager.GetModeVR(), traceTxt);
        }

    }

   
}
